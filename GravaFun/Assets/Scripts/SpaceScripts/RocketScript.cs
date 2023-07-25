using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{    

    /*
    
    this script is for the red rocket movement control.
    
    
    */


    // a float of rocket forward speed
    public float forwardSpeed = 10f;
    // a float of rocket rotation speed
    public float rotationSpeed = 5f;
    // a float that holds the de-accelearation rate
    public float deceleration = 10f;
    // a reference of the pause panel object
    public GameObject pausePanel;
    // a reference of the player object
    public GameObject player;
    // a reference of the red rocket virtual camera
    public GameObject rocketCamera;
    // a reference of the player virtual camera
    public GameObject playerCamera;
    // a reference of the guide object
    public GameObject guide;
    // a bool to check if is moving
    private bool ismoving = false;
    // a reference of the red rocket rigidbody
    private Rigidbody2D rocket;

    private void OnCollisionEnter2D(Collision2D other) {
        // checks if the rocket collided with an object will a planet tag
        if(other.gameObject.tag == "planet"){
            // saves the position of the rocket in a current vector2
            Vector2 current = this.transform.position;
            // de-activating the rocket object
            this.gameObject.SetActive(false);
            // switches virtual camera's from the rocket virtual camera to player virtual camera
            rocketCamera.SetActive(false);
            playerCamera.SetActive(true);
            // makes player position the same as the rocket before getting de-activated
            player.transform.position = current;
            // activating the player
            player.SetActive(true);
            
        }
    }
    void Start()
    {
        // capturing reference of the red rocket rigidbody
        rocket = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // checking if pausepanel is not active
        if(!pausePanel.activeSelf){

        
        // Get the input axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Apply rotation based on horizontal input
        transform.Rotate(Vector3.forward, -moveHorizontal * rotationSpeed);

        // Apply forward movement based on vertical input
        if (moveVertical > 0f)
        {
            // Accelerate forward
            if(guide != null){
                Destroy(guide);
            }
            rocket.AddRelativeForce(Vector2.up * moveVertical * forwardSpeed , ForceMode2D.Force);

            ismoving = true;
        }
        else if (moveVertical == 0f)
        {
            // Decelerate
           Vector2 oppositeForce = -rocket.velocity.normalized * deceleration;
        rocket.AddForce(oppositeForce, ForceMode2D.Force);
           ismoving = false;
        }
        Debug.Log(moveVertical);
        }
    }

}
