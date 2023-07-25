using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateRocket : MonoBehaviour
{


    /*
    
    this script is meant for the rocket in the end of the freefaller game, activates it and makes it accelerate.
    
    */

    //reference to the player gameobject
    public GameObject player; 
    //reference to the player virtual camera
    public GameObject playerCam;
    //reference to the rocket virtual camera
    public GameObject rocketCam;
    //reference to the message that pops up near the rocket saying ( ROCKET !!)
    public GameObject message;
    //reference to the particle system of the 
    public ParticleSystem particles;
    // variable that determines the speed of the rocket.
    public float rocketSpeed = 5f;
    //a reference of the rocket rigidbody.
    private Rigidbody2D rocketB;
    //a delay that will be used soon.
    public float delayAmount = 3f;
    private bool isActive;



    private void OnTriggerEnter2D(Collider2D other) {
        //checking if the object that triggered the trigger collider is the player by comparing it's tag, on entering
        if(other.gameObject.CompareTag("Player")){
            isActive = true;
            message.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //checking if the object that triggered the trigger collider is the player by comparing it's tag, on exiting 
        if(other.gameObject.CompareTag("Player")){
            isActive = false;
            message.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        //checking if the object that triggered the trigger collider is the player by comparing it's tag, while staying
        if(other.gameObject.CompareTag("Player")){
            isActive = true;
            message.SetActive(true);
        }
    }
    void Start()
    {
        //capturing the reference using the getcomponent
        rocketB = GetComponent<Rigidbody2D>();
        //de-activating the particles system the moment the script starts.
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //a key listener that on activation will activate sertain actions.
        if(isActive && Input.GetKeyDown(KeyCode.G)){
            //destroying the pop up message object.
            Destroy(message);
            //starting the coroutine function -activatingRocket-
            StartCoroutine(activatingRocket());
        }
    }

    //IEnumerator function that allows putting delaying in the update method, more like giving a script that will process
    //and will not update to next loop until the IEnumerator finishes its code.
    IEnumerator activatingRocket(){

        //de-activating the player object
        player.SetActive(false);
        //de-activating the player camera
        playerCam.SetActive(false);
        //activating the rocket camera
        rocketCam.SetActive(true);
        //start playing the particle system.
        particles.Play();
        //stops the code syncing until the delay amount of real time seconds is finished
        yield return new WaitForSeconds(delayAmount);
        //adds velocity to the rocket rigidbody, only changing on the Y-axis
        rocketB.velocity = new Vector2(0f, rocketSpeed);


    }
}
