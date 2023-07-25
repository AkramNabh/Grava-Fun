using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{


    /*
    
    this script is for the guide in the freefaller level, to show how to use the mouse to instentiate dots using it
    
    
    */



    //a reference of the bubble object
    public GameObject bubble;

    //a reference of the message object
    public GameObject message;
    //a reference of the guide object
    public GameObject guide;
    //a reference to the animator that hold the guide animation.
    public Animator guideAnimation;
    //a bool to see if triggers
    private bool istriggering = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //checking the tag of the triggering game object if bubble or not
        if(other.gameObject.CompareTag("Bubble")){
            //switching the bodytype of the rigidbody of the bubble into a static type
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //setting the message and the guide object as active
            message.SetActive(true);
            guide.SetActive(true);
            //making the trigger bool true for usage
            istriggering = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(istriggering){
            //triggering the animation that has the trigger (Start)
            guideAnimation.SetTrigger("Start");
        }

        // a condition that has a mouselistener for the left click of the mouse and if the trigger bool is true
        if(Input.GetMouseButtonDown(0) && istriggering){
            //destroys the object that holds this script
            Destroy(gameObject);
            //destroys the message and the guide objects
            Destroy(message);
            Destroy(guide);
            //switches back the bubble rigidbody bodytype to dynamic
            bubble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
