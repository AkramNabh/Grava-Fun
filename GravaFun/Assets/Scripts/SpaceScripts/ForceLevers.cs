using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLevers : MonoBehaviour
{

    /*
    
    this script is for all the levers in the space level.
    
    */


    // an array of sprites that will hold the different lever textures
    public Sprite[] textures;
    // a reference of the lever sprite renderer
    private SpriteRenderer spRender;
    // a bool to see if it clickable
    private bool isClickable = false;
    // an int that will help in iterating
    private int currentTexture = 0;
    // a bool that will be passed to other script later on
    public bool isGreen = false;
    // a reference of the audio source
    public AudioSource SFX;
    
    private void OnTriggerEnter2D(Collider2D other) {
        // if the player is the on triggering, turns isclickable to true
        if(other.CompareTag("Player")){
            isClickable = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        // if the player is the on triggering, turns isclickable to true
                if(other.CompareTag("Player")){
            isClickable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        // if the player is not triggering anymore, turns isclickable to false
                if(other.CompareTag("Player")){
            isClickable = false;
        }
    }
    void Start()
    {
        //captures reference of the sprite renderer
        spRender = GetComponent<SpriteRenderer>();
        // sets the texture of the sprite as the default one
        spRender.sprite = textures[currentTexture];
    }

    // Update is called once per frame
    void Update()
    {   
        // checks if the lever isclickable, and the keylistener for the G button
        if (isClickable && Input.GetKeyDown(KeyCode.G)) 
        {
            //plays the SFX
            SFX.Play();
            // updates the value of the current texture on clicking
            currentTexture = (currentTexture + 1) % 2; 
            // passing the currenttexture value to the array and use it as the sprite
            spRender.sprite = textures[currentTexture];

            if(currentTexture == 1){ 
                // determining if isGreen depending on the texture that is active
                isGreen = true;
            } else{
                isGreen = false;
            }
    }

    }
}
