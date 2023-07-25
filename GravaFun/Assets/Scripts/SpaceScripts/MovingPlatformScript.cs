using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{


    /*
    
    this script is for the teleporting platformes between the planets
    
    */


    //an array of textures for the platform
    public Sprite[] Textures;
    // a float that will act like a delaytime
    public float delayTime = 5f;
    // a reference of the lever that will activate the platform
    public GameObject lever;
    // a reference of the audio source
    public AudioSource sfx;
    // a reference of the affector that pushes the player to the other planet
    public BoxCollider2D force;
    // a bool to check if isactive
    private bool isActive;
    // a reference of the sprite renderer of the teleportation platform
    private SpriteRenderer spRender;
    // a bool to break out of the SFX loop
    private bool sfxBreaker;
    void Start()
    {
        // capturing the reference of the sprite renderer of the platform
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //retrieving the isGreen bool value from the forcelevers script in the lever, and saving it in isActive
        isActive = lever.GetComponent<ForceLevers>().isGreen;
        // if isActive
        if(isActive){
            // an if condition to break out of looping the sound effect
            if(!sfxBreaker){
            sfx.Play();
            sfxBreaker = true;
            }
            // starts the coroutine of the textureloop function
            StartCoroutine(textureLoop());
            
        } else {
            // resets the texture back to the original one
        spRender.sprite = Textures[0];
        // turning off the affector force
        force.enabled = false;
        }
    }



    // IEnumerator function to loop through the textures and give a time for the force to get activated
     IEnumerator textureLoop(){ 
        // a for loop that iterates through the textures, and sets them to the sprite renderer
    for (int i = 0; i < Textures.Length; i++) 
        {
            spRender.sprite = Textures[i]; 
            // a specified delay
            yield return new WaitForSeconds(delayTime); 
        }
        // activating the affector's force.
    force.enabled = true;
    }
}
