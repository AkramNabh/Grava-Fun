using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    /*
    
    this script is for the enemies in the space level

    */





    // a reference of the purple bullets object
    public GameObject bullet;
    // a reference to a position that will be used as a bullet position
    public Transform bulletPos;
    // a reference to the player object
    public GameObject player;
    // an int variable that will fix the scale of the enemy if it was reverted in some cases
    public int scaleFixer = 1;
    // references of audio sources, one for shooting and the other for movement
    public AudioSource lazerSFX;
    public AudioSource movementSFX;
    // a float to determine the movement speed of the object
    public float moveSpeed = 5f;
    // a delay for the bulley cycle, between bullets
    public int bulletCycle = 2;
    // a float that hold the shoot range which is a radius 
    public float shootRange;
    // a reference to the bubble object of the enemy
    public GameObject bubble;
    // a bool to determine if the enemy got shot or not
    public bool isShot = false;
    // a delay for the SFX
    public float movementSFXDelay = 2.5f;
    // a float holding the penetration force value
    public float penetrationForce = 5f;
    // a float holding the float force ( upwards )
    public float floatForce = 5f;
    // a timer for the SFX
    private float SFXtimer;
    // a reference to the enemy rigidbody
    private Rigidbody2D enemyRB;
    // a timer that will be used for other purposes
    private float timer;
    // a bool that will determine if player is in the range of shooting
    private bool isInRange = false;
    // an int to determine the direction of movement.
    private int movementSwitcher = 1;
    // a bool to determine if the enemy is grounded
    private bool isGrounded = false;
    // a reference of the enemy animator
    private Animator ShooterAnimation;
    // a vector2 to save the direction of the bullet
    private Vector2 bulletDir;
    



    void Start()
    {
        // capturing references of the enemy rigidbody and the enemy animator
        enemyRB = GetComponent<Rigidbody2D>();
        ShooterAnimation = GetComponent<Animator>();
        // zeroing the SFX timer
        SFXtimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // adding real time to the SFX timer
        SFXtimer += Time.deltaTime;
        // calculating the distance between the enemy and the player, with .Distance, that will return it
        float distance = Vector2.Distance(transform.position, player.transform.position);
        // checking if distance is less or equal to the shoot range
        if(distance <= shootRange){
            // start adding real time to the normal timer
        timer += Time.deltaTime;
        // calculate the distance on the X-axis between the player and the enemy
        float distanceX = player.transform.position.x - transform.position.x;
        //checks if the timer is bigger than the bulletcycle, and the enemy is not shot
        if(timer > bulletCycle && !isShot){
            // reseting the timer
            timer = 0;
            // calls pullthetrigger function
            pullTheTrigger();
            // plays the shooting SFX
            lazerSFX.Play();
        }


        //if conditions that will depend on the distance on the x-axis to determine which side to look at
        // if the player is in the shoot zone
        // if distance is positive
        if (distanceX > 0 )
            {
                transform.localScale = new Vector2(Mathf.Sign(distanceX * scaleFixer), 1f);
            }
            // if distance is negative
            else if (distanceX < 0 )
            {
                transform.localScale = new Vector2(Mathf.Sign(distanceX * scaleFixer), 1f);
            }

            // turns the isinrange to true for other purposes
            isInRange = true;
        } else{
            // isinrange = false
            isInRange = false;
            //re-scaling the enemy on the direction it was walking to depending on some aspects will be explained later
            if(movementSwitcher > 0){
                transform.localScale = new Vector2(Mathf.Sign(movementSwitcher), 1f);
            } else if(movementSwitcher < 0){
                transform.localScale = new Vector2(Mathf.Sign(movementSwitcher), 1f);
            }

            
        }
        

        // if the enemy gets shot, the coroutine of deadprocess function starts.
        if(isShot){
            StartCoroutine(DeadProcess());
        }
    }

    /*
    fixedUpdate explained :-

    the fixed update does not update per frame like the update function, it updates depending on the physics engine 
    that is used in the project, in my project it updates every 0.02 seconds, and it is much more accurate with 
    physic's functions like applying all sorts of forces, basically it is more physically accurate, it will add 
    delays for physics calculations to be compiled correctly ( smoothens it out )
    
    */
    private void FixedUpdate() {
        // checks if the enemy is grounded, and the player is not in range
        if(isGrounded && !isInRange){
            // puts force to the enemy object to the right, with a movement switcher and movespeed
            // the movement switcher, switches depending on some collider objects that will act like a penetrating 
            // object for the enemy, when collids with them, it switches the direction of the force from + to -
            enemyRB.AddForce(transform.right * movementSwitcher * moveSpeed);
            // checks if the SFXtime is bigger than the SFX delay
            if(SFXtimer >movementSFXDelay){
                // plays the SFX
                movementSFX.Play();
                // resets the SFX timer
                SFXtimer = 0;
            }
        }
        // animation handling
        if(!isInRange){
            // sets the walking animation on if the player is not in range
                ShooterAnimation.SetBool("IsWalking", true);
                ShooterAnimation.SetBool("IsShooting", false);
            }else if(isInRange) {
                // sets the shooting animation on if the player is in range
                ShooterAnimation.SetBool("IsShooting", true);
                ShooterAnimation.SetBool("IsWalking", false);
                
            }
    }


    //IEnumerator function for the deadprocess
    IEnumerator DeadProcess(){
        // turns the trigger of the dead animation on
        ShooterAnimation.SetTrigger("dead");
        // sets the bubble object to true
        bubble.SetActive(true);
        // disabling the box collider of the enemy
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //  saves the rotation on shot
        Quaternion currentRotation = transform.rotation;
        // freezes rotation changing
        enemyRB.freezeRotation = true;
        // adds force horizontally and vertically in a way to look like its floating
        enemyRB.AddForce(bulletDir * penetrationForce, ForceMode2D.Impulse);
        enemyRB.AddForce(transform.up * floatForce, ForceMode2D.Impulse);
        // freezes the rotation again
        enemyRB.freezeRotation = true;
        // sets the rotation after getting shot to the pre-saved rotation of the enemy
        transform.rotation = currentRotation;
        // a delay for 1.5 seconds
        yield return new WaitForSeconds(1.5f);
        // destroys the enemy object
        Destroy(gameObject);
    }


    // declaration of the pullthetrigger function
    private void pullTheTrigger(){
        // instantiate a purple bullet from the desired position and fixes its rotation
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


    void OnDrawGizmosSelected()
    {
        // Draw the orbit field in the Unity editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }



        private void OnCollisionEnter2D(Collision2D col)
    {
        //checks for specific objects on collision
        if ((col.gameObject.CompareTag("Grabable") ||
             col.gameObject.CompareTag("Doors") ||
             
             col.gameObject.CompareTag("Movables") ||
             col.gameObject.CompareTag("Joints") ||
             col.gameObject.CompareTag("Ground")||
             col.gameObject.CompareTag("Buttons")||
             col.gameObject.CompareTag("planet")) &&  !col.collider.isTrigger) {
                // sets isgrounded to true
            isGrounded = true;
            
        }

        // checking if the enemy collides with the penetrative objects that will switch its movement direction
        if(col.gameObject.CompareTag("Colliders-Penetration")){
            movementSwitcher *= -1;
        }
        //checks if it was hit by a white bullet
        if(col.gameObject.CompareTag("white-Bullet")){
            // sets the isShot to true
            isShot = true;
            // calculate the bullet direction and saves it in a vector2 bulletDir
            bulletDir =transform.position - col.transform.position;
            // normalize the vector2
            bulletDir.Normalize();
        }
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Grabable") ||
             col.gameObject.CompareTag("Doors") ||
             col.gameObject.CompareTag("Ground")  ||
            col.gameObject.CompareTag("Movables") ||
            col.gameObject.CompareTag("Joints") ||
             col.gameObject.CompareTag("Buttons")||
             col.gameObject.CompareTag("planet")) 
            &&  !col.collider.isTrigger) {
            isGrounded = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Grabable") ||
             col.gameObject.CompareTag("Ground")  ||
             col.gameObject.CompareTag("Doors") ||
             col.gameObject.CompareTag("Movables") ||
             col.gameObject.CompareTag("Joints") ||
             col.gameObject.CompareTag("Buttons")||
             col.gameObject.CompareTag("planet")) 
            &&  !col.collider.isTrigger) {
            isGrounded = false;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("planet")){
            enemyRB.drag = 0f;
        }

       
    }

    private void OnTriggerStay2D(Collider2D other) {
        // checks if the enemy is triggered by the planet object
        if(other.CompareTag("planet")){
            //calculate the value difference between the planet triggering radius and the distance between the 
            // player and the planet surface
            float distance = Mathf.Abs(other.GetComponent<Gravitation>().planetR - Vector2.Distance(transform.position, other.transform.position));
            // checks if distance is less than 1 to consider grounded
            if (distance < 1f)
            {
                isGrounded = distance < 0.5f;
            }
        }

        
    }


}
