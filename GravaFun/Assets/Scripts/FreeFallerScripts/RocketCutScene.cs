using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCutScene : MonoBehaviour
{


    /*
    
    
    this script is for the rocket cutScene on the freefaller level after getting out from the bubble

    
    */


    //reference of the player virtual camera
    public GameObject playerCamera;
    //reference of the rocket virtual camera
    public GameObject rocketCamera;
    //reference of the player object
    public GameObject player;
    //reference of the message object
    public GameObject message;
    //a delay that will be used later on
    public float delayAmount = 5f;
    //a bool for containing the trigger
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //checking if the triggerer is the player or not
        if(other.gameObject.CompareTag("Player")){

            
            isTriggered = true;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered){
            //activating the coroutine function
            StartCoroutine(backToPlayer());
        }
    }

    // an IEnumerator function to apply the cutscene
    IEnumerator backToPlayer(){

        // de-activating the player virtual camera
        playerCamera.SetActive(false);
        //activating the rocket virtual camera
            rocketCamera.SetActive(true);
            // activating the message object
            message.SetActive(true);
            //de-activating movement of the player so the player stand still until the cutscene finishes
            player.GetComponent<GirlBehavior>().enabled = false;
            player.GetComponent<SFX>().enabled = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            

            //waiting for the delayamount number of seconds in real time to count and then the codes after will be 
            //compiled
             yield return new WaitForSeconds(delayAmount);

            //switching back the cameras from the rocket virtual camera to the player virtual camera
            playerCamera.SetActive(true);
            rocketCamera.SetActive(false);
            //de-activating the message
            message.SetActive(false);
            //re-activating the player movement again
            player.GetComponent<GirlBehavior>().enabled = true;
            player.GetComponent<SFX>().enabled = true;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            isTriggered = false;
            //destroying the gameobject that holds this script
            Destroy(gameObject);
            

    }
    
}
