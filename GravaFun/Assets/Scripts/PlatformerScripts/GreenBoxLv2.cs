using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

this script is for handling the green container box in level 1, and what it does, it activates the usage of a 
specific lever.

*/
public class GreenBoxLv2 : MonoBehaviour
{
    //a reference to the wind affector
    public GameObject windCollider; 
    // a reference to the hidden ladders tilemap
    public GameObject hiddenLadders;
    // a reference of a message object
    public GameObject Message;
    //a reference to the audio source 
    public AudioSource sfx;
    //references for the virtual camera's to create a cutscene
    public GameObject playerCam;
    public GameObject boulderCam;
    private bool isTriggered = false;

   
    private void OnTriggerEnter2D(Collider2D other) {
        // checks if the trigger got triggered by the right object
        if(other.gameObject.tag == "Grabable"){
            isTriggered = true; // turnes the boxcollider to true for the lever
            // plays the sound effect
            sfx.Play();
            // activates the hidden ladder
            hiddenLadders.SetActive(true);
            // activates the message object
            Message.SetActive(true);
            //switches between the player camera to the rolling boulder camera
            playerCam.SetActive(false);
            boulderCam.SetActive(true);
            
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered){
            windCollider.GetComponent<BoxCollider2D>().enabled = true;
            windCollider.GetComponent<AudioSource>().enabled = true;
        }
    }

}
