using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inactiveRocket : MonoBehaviour
{


    /*
    
    
    this script is for the black rocket, it is only activated while the player didnt actually activate the rocket, 
    it will show messages that the player cant use the rocket yet
    
    */

    // a reference of the guide object
    public GameObject guide;
    // a reference of the message object
    public GameObject message;
    // a bool to check if triggering 
    private bool istrigger = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //checks if the player is the one triggering
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
            message.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //key listener and an istrigger bool
        if(istrigger && Input.GetKeyDown(KeyCode.G)){
            message.SetActive(true);
        }
    }
}
