using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    /*
    
    this script is for the SFX of the player, walking, running, jumping, and climbing.
    
    */



//reference for each audiosource that contains its specific audio
    public AudioSource movementSFX;
    public AudioSource jumpSFX;
    public AudioSource ClimbSFX;
    public AudioSource LandSFX;
    //delays for the repetition of the sound effects to make it more acceptable to the ear
    public float movementSFXDelay = 2.5f;
    public float runningSFXDelay = 0.2f;
    public float climbingSFXDelay = 0.3f;
    // a reference to the pause panel
    public GameObject pausePanel;
    // a timer that will be used later on
    private float timer;
    // floats to capture the movement of the player on the X-axis and the Y-axis
    private float isMovingX;
    private float isMovingY;
    // bools to determine the situation the player is in, grounded, climbing, wasground and has landed
    private bool isGrounded = false;
    private bool isClimbing = false;
    private bool wasGrounded = false;
    private bool hasLanded = false;
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // checking if the pause panel is not active so the SFX do not play while the pause panel is active
        if(!pausePanel.activeSelf){

        // adding real time to the timer float
        timer += Time.deltaTime;
        //retrieving some bools from the girlBehavior script attached to the player object
        isGrounded = GameObject.FindGameObjectWithTag("Player").GetComponent<GirlBehavior>().getGrounded(); //if grounded
        isClimbing = GameObject.FindGameObjectWithTag("Player").GetComponent<GirlBehavior>().getClimbing();//if climbing
        //capturing a change in the X-axis and Y-axis
        isMovingX =Input.GetAxisRaw("Horizontal"); 
        isMovingY = Input.GetAxisRaw("Vertical");
        // if player is moving on the x-axis, but leftshift button is not clicked while grounded
        if(isMovingX != 0 && isGrounded && !Input.GetKey(KeyCode.LeftShift)){
            //checks if timer is bigger than the delay value for the movement
            if(timer > movementSFXDelay){
                //plays the movement sound effect
            movementSFX.Play();
            //restarts the timer
            timer = 0;
        }
        //if player is moving on x-axis, is grounded, and pressing on leftshift key (running)
        } else if(isMovingX != 0 && isGrounded && Input.GetKey(KeyCode.LeftShift)){
            //checks if the timer is bigger than the desired delay for running soundeffect
            if(timer > runningSFXDelay){
                // playes the sound effect
            movementSFX.Play();
            //resets the timer
            timer = 0;
        }
        }
        // checks if the button Jump (which is space) is clicked while grounded
        if(Input.GetButtonDown("Jump") && isGrounded){
            // plays the jump sfx
            jumpSFX.Play();
            // puts the has landed bool to false
            hasLanded = false;
        }
        //if player is climbing, and actually moving on the y-axis
        if(isClimbing && isMovingY != 0){
            // checks if the timer is bigger than the delay
             if(timer > climbingSFXDelay){
                //plays the sfx
            ClimbSFX.Play();
            // resets the timer for repetition
            timer = 0;
        }
        }
        // checking if the player has landed with a nested bools to play the land sfx accurately
        if(!wasGrounded && isGrounded && !hasLanded){
            LandSFX.Play();
            hasLanded = true;
        }
    wasGrounded = isGrounded;
    }
    }
}
