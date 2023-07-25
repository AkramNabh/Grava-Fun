using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderScript : MonoBehaviour
{


    /*
    
    this script is for the boulder that will activate the botton in the platformer level
    
    */

    //a reference to the audio source
    public AudioSource boulderSFX;
    // a delay for the soundeffect so it does not sound repetitve
    public float SFXdelay = 0.5f;
    //a float that hold a movement value, will be used soon
    public float movementValue = 0.01f;
    //bool to determine if it is touching the ground.
    private bool isGrounded;
    //a reference to the boulder rigidbody
    private Rigidbody2D boulderBody;
    //a float that will act like a timer
    private float timer;
    //a bool to check if the boulder is colliding with the player.
    private bool isCollided;


    void Start()
    {
        //capturing the reference of the rigidbody of the boulder
        boulderBody = GetComponent<Rigidbody2D>();
        //zeroing the timer float
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the boulder is colliding with the player
        if(isCollided){
            //checks if the object has velocity, and checking if it is bigger than the movement 
        if(Mathf.Abs(boulderBody.velocity.x) > movementValue){
            //saves the real time value in the timer float
        timer += Time.deltaTime;
        //checks if the timer is bigger than the SFX delay so it plays
        if(timer > SFXdelay){
            //plays the SFX
        boulderSFX.Play();
        //resets the timer
        timer = 0;
        }
       }
    } else {
        //stops the SFX (interupts it)
        boulderSFX.Stop();
    }
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            isCollided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
                if(other.gameObject.CompareTag("Player")){
            isCollided = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
               if(other.gameObject.CompareTag("Player")){
            isCollided = true;
        } 
    }
}
