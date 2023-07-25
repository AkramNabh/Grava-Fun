using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    // references of audio sources holding different sound effects
    public AudioSource movementSFX;
    public AudioSource jumpSFX;
    public AudioSource LandSFX;
    // a delay that will be used for the movement SFX
    public float movementSFXDelay = 2.5f;
    // a reference of the pausepanel object
    public GameObject pausePanel;
    // a float that will act like a timer
    private float timer;

    // floats to check changing in value on the X-axis and Y-axis
    private float isMovingX;
    private float isMovingY;
    // bools to check if grounded, is climbing, was grounded, and has landed
    private bool isGrounded = false;
    private bool isClimbing = false;
    private bool wasGrounded = false;
    private bool hasLanded = false;
    void Start()
    {
        // zeroing the timer
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the pausepanel is not active first
        if(!pausePanel.activeSelf){

        // saves the real time in the timer variable
        timer += Time.deltaTime;
        // captures the isonground bool located in the player object in the spaceplayerScript
        isGrounded = GameObject.FindGameObjectWithTag("Player").GetComponent<SpacePlayerScript>().isonGround();
        // reads change in the movement.

        // D key will return positive 1, A will return negative 1, and not pressing any will return 0
        isMovingX =Input.GetAxisRaw("Horizontal"); 
        // decreasing in y-axis value will return positive 1, increasing will return negative 1, and no change will return 0
        isMovingY = Input.GetAxisRaw("Vertical");
        //check if there is change in the x-axis, and is grounded
        if(isMovingX != 0 && isGrounded){
            // checks if the timer is bigger than the movement delay
            if(timer > movementSFXDelay){
                // plays the movement SFX
            movementSFX.Play();
            // resets the timer
            timer = 0;
        }
        } 
        //if space is clicked and is grounded
        if(Input.GetButtonDown("Jump") && isGrounded){
            // plays the jump SFX
            jumpSFX.Play();
            // sets has landed to false
            hasLanded = false;
        }
        // checks when is the perfect time to player the land SFX, and sets hasLanded bool to true
        if(!wasGrounded && isGrounded && !hasLanded){
            LandSFX.Play();
            hasLanded = true;
        }
    wasGrounded = isGrounded;
    }
    }
    
}
