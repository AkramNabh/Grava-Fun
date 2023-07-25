using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMount : MonoBehaviour
{

    /*
    
    this script is for the black rocket, so the player can use it 
    
    */



    // a reference of the guide object
    public GameObject guide;
    // a reference of the player object
    public GameObject player;
    // a reference of the player virtual camera
    public GameObject playerCam;
    // a reference of the rocket virtual camera
    public GameObject rocketCam;
    // a bool to determine if istriggered
    private bool istrigger = false;
    // a reference of the rocket rigidbody
    private Rigidbody2D rocketRB;
    private void OnTriggerEnter2D(Collider2D other) {
        // checks if the player is the one triggering
        if(other.gameObject.CompareTag("Player")){
            istrigger = true;
            guide.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
            istrigger = true;
            guide.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
            istrigger = false;
            guide.SetActive(false);
        }
    }
    void Start()
    {
        // captures the rigidbody reference of the rocket
        rocketRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // a key listener, with istrigger bool
        if(istrigger && Input.GetKeyDown(KeyCode.G)){
            // de-activates the guide
            guide.SetActive(false);
            // switches between the player virtual camera to the rocket virtual camera
            playerCam.SetActive(false);
            rocketCam.SetActive(true);
            // de-activating the player object
            player.SetActive(false);
            // changes the velocity of the rocket, to look like its going upwards, even with the rotation of the object
            rocketRB.velocity = new Vector2(5f, 0f);
        }

        // checks if the rocketcam is active
        if(rocketCam != null){
            // sets the rotation of the rocket virtual camera the same as the rotation of the black rocket rotation
            rocketCam.transform.rotation = transform.rotation;
        }
    }
}
