using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

this script is for the button behavior in the first level, located in the hole that the boulder supposed to 
fall in, the way it works, that the button needs to stay on the pressed phase, which means if the button
is not pressed the functionality will be deactivated, it will stay active while the button is pressed.

*/


public class ButtonBehavior : MonoBehaviour
{
   
    public Sprite pressedTexture; // referance of the texture of the pressed button
    public Sprite normalTexture; // referance of the texture of the unpressed button
    public GameObject affector; // referance of the affector that will be disabled later on in the code
    public GameObject message; // a message will be shown when the button is activated by player
    public GameObject message2; // a message will be shown when the button is activated by the boulder
    public GameObject stopper; // a collider that will prevent the player to break out of the level script
    public AudioSource buttonSFX; // an audiosource reference
    public GameObject movable;
    public float delayTime = 3f;
    public float moveDis = 20f;
    public float moveSpeed = 2f;
    private float startPosX;
    private bool isPressed = false; // a basic bool
    private bool isPressedbyBoulder = false; // a basic bool
    


    /*
    ontrigger is afunction that will be triggered if  a specific object entered the field of the collider,
    which means object does not collide, it only sends a trigger signal.
    */

    private void OnTriggerEnter2D(Collider2D col)
    {
        // if the collided object has a movable tag
if(col.gameObject.tag == "Movables"){
    // checks if the button is not pressed
        if (!isPressed)
        {
           
            isPressed = true; // makes the bool true
            isPressedbyBoulder = true;
            //changes the texture of the button to a pressed button texture
            GetComponent<SpriteRenderer>().sprite = pressedTexture;
            //destroys the stopper collider
            Destroy(stopper);
            //activating the message that the boulder has pressed the button
            message2.SetActive(true);
        }

        //if the player was the one who pressed it
        } else if(col.gameObject.tag == "Player"){
                    isPressed = true;
            GetComponent<SpriteRenderer>().sprite = pressedTexture;
            //activates a message for the player to read and get out of the place
            message.SetActive(true);
    }
    //plays the button sound effect wither it was pressed by any of them
    buttonSFX.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Movables"){
        if (!isPressed)
        {
           
            isPressed = true;
            isPressedbyBoulder = true;
            GetComponent<SpriteRenderer>().sprite = pressedTexture;
            Destroy(stopper);
            message2.SetActive(true);
        }
        } else if(collision.gameObject.tag == "Player"){
                    isPressed = true;
            GetComponent<SpriteRenderer>().sprite = pressedTexture;
            message.SetActive(true);
    }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Movables"){
        if (isPressed)
        {
           
            isPressed = false;
            GetComponent<SpriteRenderer>().sprite = normalTexture; //sets the texture to the unpressed texture
        }
        } else if(other.gameObject.tag == "Player"){
                    isPressed = false;
            GetComponent<SpriteRenderer>().sprite = normalTexture;
            message.SetActive(false);
    }
    buttonSFX.Play();
    }

    void Start()
    {
        startPosX = movable.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //if the button is pressed
        if(isPressed){
            // it will de-activate the audio source and the collider of the affector object
            affector.GetComponent<BoxCollider2D>().enabled = false;
            affector.GetComponent<AudioSource>().enabled = false;
        }

        if(isPressedbyBoulder){
            if(movable.transform.position.x < startPosX + moveDis){
                float moveAmount = moveSpeed * Time.deltaTime;
                Vector3 newPos = movable.transform.position + new Vector3(moveAmount, 0f, 0f);
                movable.transform.position = newPos;
            }
        } 
    }
}
