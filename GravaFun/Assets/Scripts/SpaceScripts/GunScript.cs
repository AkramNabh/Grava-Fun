using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunScript : MonoBehaviour
{
    
    /*
    
    this script is for the child gun in the player object
    
    */


    // a reference of the white bullets object
    public  GameObject bullet;
    // a reference to the how to use guide object
    public GameObject guide;
    // a reference of a transform that holds the bullet position
    public Transform bulletPos;
    // a reference to the audio source
    public AudioSource lazerSFX;
    // a bool to check if holding the gun or not
    private bool isHoldingGun;
    // a float to determine the bullet speed
    public float bulletSpeed = 5f;
    // a delay between each bullets shot
    public float bulletDelay = 5f;
    // a bool to check if shooting is allowed or not
    private bool isAllowed = true;
    // a bool to check if player is shooting
    private bool isTriggered = false;
    void Start()
    {     
        // activating the the guide on the start up  
        guide.SetActive(true);
    }
    void Update()
    {
        // a key listener with a bool that determines if the player can shoot with the timer
            if(Input.GetKeyDown(KeyCode.Q) && isAllowed){
                // destroys the guide gameobject
                Destroy(guide);
                // calls the pullthetrigger function
                pullTheTrigger();
                // plays the gun SFX
                lazerSFX.Play();
                // falsing the isallowed bool 
                isAllowed = false;
                // invoke is a function that calls another function that is passed as a parameter, with a float that
                // will act as a delay, it is used in the update function because it literally invokes it
                Invoke("pullingAllowed", bulletDelay);
            } 

            // if conditions to fix the guide text rotation so it does not flip if the parent flips
            if(guide != null && gameObject.transform.localScale.x == 1){
                guide.transform.localScale = new Vector3(1f, 1f, 1f);
            } else if(guide != null && gameObject.transform.localScale.x == -1){
                guide.transform.localScale = new Vector3(1f, 1f, 1f);
            }
    }


    // the declaration of the pullthetrigger function    
    private void pullTheTrigger(){
        // instantiate the bullet object, with a position, and a rotation
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


    // the declaration of the pullingallowed function that was used in the invoke function in the update.
    private void pullingAllowed(){
        isAllowed = true;
    }
}
