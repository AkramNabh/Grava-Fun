using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inactiveLever : MonoBehaviour
{



    /*
    
    this script is for the lever that will activate the black rocket, will be disabled in the gameplay, because
    it only works when the lever is inactive
    
    */

    //a reference of the message object
    public GameObject message;
    // a reference of the guide object
    public GameObject guide;
    // a bool to see if it triggering
    private bool istrigger = false;
    private void OnTriggerEnter2D(Collider2D other) {

        //checks if player is triggering
        if(other.gameObject.CompareTag("Player")){
            // sets the guide to active 
            guide.SetActive(true);
            // sets the istrigger bool to true
            istrigger = true;
        }
    }


    private void OnTriggerStay2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
                    guide.SetActive(true);
            istrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
            istrigger = false;
            guide.SetActive(false);
            message.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // a key listener and istrigger bool
        if(istrigger && Input.GetKeyDown(KeyCode.G)){
            //display the message that says the lever is inactive
            message.SetActive(true);
        }
    }
}
