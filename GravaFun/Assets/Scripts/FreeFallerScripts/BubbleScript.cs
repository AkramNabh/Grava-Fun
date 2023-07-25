using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{

    /*
    
    this script is for the bubble in the freefaller level, controlling everything about it.
    
    */


    //a reference to a sprite ( raw image )
    public Sprite BubbleSp;
    //a reference to the player object
    public GameObject player;
    //a reference to the player virtual camera
    public GameObject playerCam;
    //a reference to the bubble virtual camera
    public GameObject bubbleCam;
    //a float variable that will contain the gravity force value (scaller)
    public float GRScale = 0.3f;
    //a reference to the box collider that the bubble has
    private BoxCollider2D boxCol;
    // a reference to the circle collider that the bubble has
    private CircleCollider2D circleCol;
    //a reference ti the bubble rigidbody
    private Rigidbody2D bubbleBody;
    // a reference to the bubble sprite renderer
    private SpriteRenderer spRender;


    private void OnTriggerEnter2D(Collider2D other) {
        // on triggering, it checks the triggerer object's tag to check if the player triggered it
        if(other.gameObject.tag == "Player"){
            //de-activating the player object
            player.SetActive(false);
            //de-activating the player virtual camera and activating the bubble virtual camera
            playerCam.SetActive(false);
            bubbleCam.SetActive(true);
            //changing the sprite of the bubble
            spRender.sprite = BubbleSp;
            // disable the box collider that the bubble has
            boxCol.enabled = false;
            // enabling the circle collider that the bubble has
            circleCol.enabled = true;
            //switching the bodytype of the bubble from static into dynamic
            bubbleBody.bodyType = RigidbodyType2D.Dynamic;
            //setting the gravityscale of the bubble's rigidbody to the variable GRScale
            bubbleBody.gravityScale = GRScale;
        }
    }
    void Start()
    {   //A bunch of reference capturer's
        boxCol = GetComponent<BoxCollider2D>();
        circleCol = GetComponent<CircleCollider2D>();
        bubbleBody = GetComponent<Rigidbody2D>();
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
