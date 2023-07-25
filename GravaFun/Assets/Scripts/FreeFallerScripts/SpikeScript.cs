using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    /*
    
    this script is for all the spikes in the freefaller level, and each one of them holds it
    
    */


    // a reference of the bubble object
    public GameObject bubble;
    //a reference of the restart button object
    public GameObject button;
    //a delay that will be used later on
    public float timeDelay = 3f;
    //a reference of the audiosource
    public AudioSource sfx;
    //a vector2 object called startpos, will be used later on
    private Vector2 startpos;
    // a bool to check if the bubble is popped or not
    private bool isPopped = false;

    private void OnTriggerEnter2D(Collider2D other) {
        // checking if the triggerer is the bubble and not any other object
        if(other.gameObject.tag == "Bubble"){
            isPopped = true;
            //playing the sfx
            sfx.Play();

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Bubble"){
            //turning the bool into false when exiting the trigger
            isPopped = false;
        }
    }
    void Start()
    {   
        //capturing the position of the exactly when the scene is run
        //which is basically saving the bubble start position
        startpos = new Vector2(bubble.transform.position.x, bubble.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //if the spike got triggered
        if(isPopped){
            // turning the bodytype of the bubble into a static object
            bubble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //transforming the bubble position to the startpos
            bubble.transform.position = startpos;
            //reseting the rotation of the bubble
            bubble.transform.rotation = Quaternion.identity;
            //activating the restart button
            button.SetActive(true);
                
            
        }
    
        }
    }

