using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketActivator : MonoBehaviour
{


    /*
    this script is for the black rocket in the end of the space level, that was attached to the activating lever
    */


    // a reference of a texture
    public Sprite texture;

    // a reference of the particle system that is on the rocket
    public ParticleSystem rocketParticles;
    // a reference of the message object
    public GameObject message;
    // a reference of the guide object
    public GameObject guide;
    // a reference of the inactivecollider object, that was put on top of the rocket
    public GameObject inActiveCollider;
    // a reference of the black rocket
    public GameObject rocket;
    // a reference of the sprite renderer
    private SpriteRenderer spRender;
    // a bool to check if triggered
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other) {
        // checks if player is the one triggering
        if(other.gameObject.CompareTag("Player")){
            guide.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
                    guide.SetActive(false);
                    message.SetActive(false);
            isTriggered = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
                if(other.gameObject.CompareTag("Player")){
                    guide.SetActive(true);
            isTriggered = true;
        }
    }
    void Start()
    {
        // capturing the reference of the sprite renderer of the lever
        spRender = GetComponent<SpriteRenderer>();
        // stoping the rocketparticles system 
        rocketParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //a key listener with the istriggered bool
        if(isTriggered && Input.GetKeyDown(KeyCode.G)){
            // changing the texture of the lever 
            spRender.sprite = texture;
            // play the rocket particles
            rocketParticles.Play();
            // destroy the inactivecollider 
            Destroy(inActiveCollider);
            // setting the message object to true
            message.SetActive(true);
            // enable the box collider of the rocket
            rocket.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
