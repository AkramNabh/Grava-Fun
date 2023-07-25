using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverNotActive : MonoBehaviour
{

    /*
    
    this script is for the lever on the ground that will drop the movable boulder
    
    */


    // a reference to the guide message
    public GameObject message;
    // a reference to the unusable lever message
    public GameObject message2;
    private bool isActive = false;
private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.gameObject.tag == "Player"){

        isActive = true;

    }



}


private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){

        isActive = true;

    }
}


private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){

        isActive = false;

    }
}


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive){
            message2.SetActive(true);
            if(Input.GetKeyDown(KeyCode.G)){
                message.SetActive(true);
            }
        } else {
            message2.SetActive(false);
            message.SetActive(false);
        }
    }
}
