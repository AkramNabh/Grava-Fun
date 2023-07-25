
using System;
using UnityEngine;


/*

this is the player script, this is where everything about the player is happening, movement, animation transition
jumping, idling, all over here, this can be attatched to any gameobject that has an animator component,
that has animations in it, correct transitions, and most importantly correct namings.

*/
public class GirlBehavior : MonoBehaviour
{

    [SerializeField] public float speed = 5f; // walking speed
    [SerializeField] public float jumpSpeed = 5f; // jumping amount
    [SerializeField] public float runningSpeed = 15f; // running speed
    [SerializeField] public float climbSpeed = 5f; // climbing the ladders speed
    public GameObject pausePanel;
    private bool isGrounded = false; // bool for touching the ground
    private Vector2 moveSpeed; // moving speed so it can be always saved and updated
    private float moveDir; // moving direction
    private Rigidbody2D player; // reference to the player rigidbody
    private Animator Girlanimation; // reference to the animator
    private BoxCollider2D feetCollider; // reference to the box collider on the bottom of the player
    private bool isRunning; // bool for detecting if the player started running or stopped
    private bool isClimbing; // bool for detecting if the player started climbing or stopped
    private float timer;
    

    private void Start()
    {
        player = GetComponent<Rigidbody2D>(); // capturing the rigidbody reference
        Girlanimation = GetComponent<Animator>(); // capturing the animator reference
        feetCollider = GetComponent<BoxCollider2D>(); // capturing the box collider reference
        timer = 0;


    }


    private void Update()
    {
        //calling the -action- functions in the update function, all of them are getting called each frame
        if(!pausePanel.activeSelf){
        Run();
        Jump();
        climbingLadder();
        FlipSprite();
        
        }

    }

    public bool getGrounded(){
        return isGrounded;
    }
    public bool getClimbing(){
        return isClimbing;
    }


    /*
    
    a simple explanation for the jump function.

    when the function is called, it checks if the right button is clicked and if the player is grounded 
    to prevent the double jumping, getbuttondown is a function that was made to read a string, and over here
    the string is jump, which refers to the space key in the keyboard.

    now whenever both conditions are activated, it increases the velocity of the player on the y-axis with
    the specified amount ( jumpspeed ) and activates the IsJumping animation.

    else it de-activates the jumping animation, so whenever the player jumping, finishes a cycle of animation 
    and the animation stops instead of repeating.


    */
    void Jump() // the jumping function
    {
       // timer += Time.DeltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity += new Vector2(0f, jumpSpeed); // adding velocity to the y-axis
            Girlanimation.SetBool("IsJumping", true); //activating the jumping animation
            
        }else if (Input.GetButtonUp("Jump"))
        {
        Girlanimation.SetBool("IsJumping", false); // de-activating the jumping animation
        } 
       
    }


    /*
    
    a simple explanation of the run function.

    starting of with getaxisraw, this function returns 1 or -1 depending on the direction of the player,
    if the player is moving to the left (negative x-axis), the function returns -1, and the opposite for moving
    right.

    i started of with making the running condition, where the player will only and only run while pressing 
    leftshift, and while pressing it, the value of the x will be higher than the value of walking, plus 
    activating the running animation and cutting it if the l-shift button was released.
    keep in mind this mechanism works on while pressing method, not onclick.

    then dust, which is the particle animation starts whenever the player is considered running
    
    */
    void Run()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift)) // is running
        {
           
            isRunning = true;
            Vector2 playerV = new Vector2(moveDir * runningSpeed, player.velocity.y);
            player.velocity = playerV;
        }
        else // else is walking
        {
            
            isRunning = false;
            Vector2 playerV = new Vector2(moveDir * speed, player.velocity.y);
            player.velocity = playerV;

            
        }

        if (isRunning) //animation controller, it stops walking and activates running and the opposite depending on the required
        {
            
            bool playerHasHorizantolSpeed = Mathf.Abs(player.velocity.x) > Mathf.Epsilon;
            Girlanimation.SetBool("IsRunning", playerHasHorizantolSpeed);
            Girlanimation.SetBool("IsWalking", false);
        }
        else
        {
            bool playerHasHorizantolSpeed = Mathf.Abs(player.velocity.x) > Mathf.Epsilon;
            Girlanimation.SetBool("IsWalking", playerHasHorizantolSpeed);
            Girlanimation.SetBool("IsRunning", false);
        }

    }

    /*
    a simple explanation of the climbingladder function.

    climbing is a simple concept, checking if the feetcollider is touching the specific layer of the ladders
    called climbable, and if its true, the getaxisraw will check on the direction on the y-axis, -1 is going
    up and 1 is goind down, result gets multiplied to the climbing speed. and making sure that
    the x-axis is stable unless clicked for changing.
    
    
    */


    void climbingLadder()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbable")))
        {
            moveDir = Input.GetAxisRaw("Vertical");
            Vector2 climbV = new Vector2(player.velocity.x, moveDir * climbSpeed);
            player.velocity = climbV;
            if(moveDir != 0){
                isClimbing = true;
            } 
            Girlanimation.SetBool("IsJumping", false);
        }
        else
        {
            isClimbing = false;
            return; 
        }

    }

    /*
    a simple explanation for the flipsprite function.

    creating a bool that will contain if the absolute value of the player direction
    
    */
    void FlipSprite()
    {
        
        bool playerHasHorizantolSpeed = Mathf.Abs(player.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizantolSpeed){
            
            transform.localScale = new Vector2 (Mathf.Sign(player.velocity.x), 1f);

        }


    }

    /*
    
    oncollision functions.


    the reason of using them, is to stop the player of double jumping, and making sure that the player
    is jumping off the right surface, where somestuff will be made so the player cant jump while standing on 
    top of them.

    list will grow by time, its all checking tags and deciding if player is on a jumpable surface or not.
    
    
    */



    private void OnCollisionEnter2D(Collision2D col)
    {
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
        if(other.CompareTag("planet")){
            player.drag = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("planet")){
            player.drag = 1f;
        }
    }
 
}



