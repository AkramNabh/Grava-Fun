using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayerScript : MonoBehaviour
{

    /*
    
    this script is for the player movement in the space level
    
    */

    // a float to handle movement speed
    public float moveSpeed = 5f;
    // a float to handle the jump speed
    public float jumpSpeed = 5f;
    // a reference of the player virtual camera
    public GameObject playerCam;
    // a reference of the gun guide object
    public GameObject gunGuide;
    // a reference of the pausepanel object
    public GameObject pausePanel;
    // a reference of the animator component
    private Animator PlayerAnimation;
    // a reference of the player rigidbody
    private Rigidbody2D player;
    // a float for handling movement direction
    private float moveDir;
    // a bool to handle if climbing
    private bool isClimbing = false;
    // a reference of the box collider of the player
    private BoxCollider2D feetCollider;
    // a reference to handle if grounded
    private bool isGrounded = false;
    // two floats for handling the direction horizontally and vertically (recieving input)
    private float DirH;
    private float DirV;
    // a reference of the sprite renderer component
    private SpriteRenderer sprite;


    private void Start()
    {
        // capturing references of the player object rigidbody, spriterenderer, animator, box collider
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        PlayerAnimation = GetComponent<Animator>();
        feetCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        // checks if the pause panel is not active
        if(!pausePanel.activeSelf){
            // reads input from used on the x axis
        DirH = Input.GetAxisRaw("Horizontal");
        
        
        // a key listener with is grounded bool
        if(isGrounded && Input.GetButtonDown("Jump")){
            // add force to the up direction of the object with the jump speed value
             player.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
             // turns the jumping animation on
            PlayerAnimation.SetBool("IsJumping", true); 
            // if button is released
         }else if (Input.GetButtonUp("Jump"))
        {
            // turns of the animation
         PlayerAnimation.SetBool("IsJumping", false); 
        }
        
        // calls the move animation function
        moveAnimation();
        // sets the player virtual camera rotation to the player rotation to make the scene look more natural
        playerCam.transform.rotation = this.transform.rotation;
        }
    }


    private void FixedUpdate() {

        
        // checks if the player is grounded and the pause panel is not active
         if (isGrounded && !pausePanel.activeSelf)
        {
            // adds force to the player to the right, and since dirH will be 1, -1 or 0, it will work to both directions
            player.AddForce(transform.right * DirH * moveSpeed);

            //checks if the absolute value of the velocity of the player on the x-axis is bigger than mathf.epsilon
            // mathf.epsilon, is a value that is very close to 0, but never reaches to it

           bool playerHasHorizantolSpeed = Mathf.Abs(player.velocity.x) > Mathf.Epsilon;


           // sets the walking animation to the result of the playerhorizontalspeed bool
            PlayerAnimation.SetBool("IsWalking", playerHasHorizantolSpeed);
            //checks if the dirH has a positive value to fix its scale 
            if (DirH > 0)
            {
                // fixes the scale of the player
                transform.localScale = new Vector2(Mathf.Sign(DirH), 1f);
                // fixes the gunguide scale if it was not equal to null
                if(gunGuide != null){
                gunGuide.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
                }
            }
            // same goes to if the dirH was negative, it will flip it
            else if (DirH < 0)
            {
                transform.localScale = new Vector2(Mathf.Sign(DirH), 1f);
                if(gunGuide != null){
                 gunGuide.GetComponent<RectTransform>().localScale = new Vector2(-1f, 1f);
                }
            }
    }
    
    }
    



    private void OnCollisionEnter2D(Collision2D col)
    {
        // checks all the objects that will turn the isgrounded bool to true
        if ((col.gameObject.CompareTag("Grabable") ||
             col.gameObject.CompareTag("Doors") ||
             
             col.gameObject.CompareTag("Movables") ||
             col.gameObject.CompareTag("Joints") ||
             col.gameObject.CompareTag("Ground")||
             col.gameObject.CompareTag("Buttons")||
             col.gameObject.CompareTag("planet")) &&  !col.collider.isTrigger) {
            isGrounded = true;
            
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
        // this is if the player is outside the triggering radius of the planet
        if(other.CompareTag("planet")){
            // makes the player drag value to 0
            player.drag = 0f;
        }

       
    }

    private void OnTriggerStay2D(Collider2D other) {
        // if the player is in the triggering radius of the planet
        if(other.CompareTag("planet")){
            // changes the player drag to 3
            player.drag = 3f;
            
            //calculate the value difference between the planet triggering radius and the distance between the 
            // player and the planet surface
            float distance = Mathf.Abs(other.GetComponent<Gravitation>().planetR - Vector2.Distance(transform.position, other.transform.position));
            //another check if the difference value is less than 0.5 then object is considered as grounded
            if (distance < 1f)
            {
                isGrounded = distance < 0.5f;
            }
        }

        
    }



    private void moveAnimation(){
        if(DirH != 0){
            PlayerAnimation.SetBool("IsWalking", true);
        } else {
    PlayerAnimation.SetBool("IsWalking", false);
        }
    }


    public bool isonGround(){
        return isGrounded;
    }
}
