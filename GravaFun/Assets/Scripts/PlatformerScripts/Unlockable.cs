using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*

this script is for the green lock box in the introduction level.

to turn it into static, and fix its rotation if rotation accured

*/




public class Unlockable : MonoBehaviour
{
    public GameObject lockBox; // reference of the lock box
    public GameObject unlockBox; // reference of the unlock box
    public AudioSource landSFX;
    
    private Vector2 unlockBoxPos; // vector to save the unlock box position
    private bool isGrounded = false;
    private bool wasGrounded = false;
    private bool hasLanded = false;
    private bool isgrabbed = false;
    public bool inPlace = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Container")
        {
            
            lockBox.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // turning the green box to a static object
            this.gameObject.transform.position = unlockBoxPos; // sitting the lock box position as its container
            
            lockBox.transform.rotation = Quaternion.identity; // fixing the rotation of the lock box if uccored
            inPlace = true;
        }
    }

    void Start()
    {
        unlockBoxPos = unlockBox.transform.position;  //saving the unlock box position
    }

    
    void Update()
    {
        
        isgrabbed = GameObject.FindGameObjectWithTag("Player").GetComponent<GrabController>().isHoldingBox;
        if(isgrabbed){
            hasLanded = false;
        }
        if(!wasGrounded && isGrounded && !hasLanded && landSFX != null){
            landSFX.Play();
            hasLanded = true;
        }
    wasGrounded = isGrounded;

    }



    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
                if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
                if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
