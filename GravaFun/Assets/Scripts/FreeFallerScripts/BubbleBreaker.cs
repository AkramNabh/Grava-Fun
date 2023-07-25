using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBreaker : MonoBehaviour
{

    /*
    
    this script is for the trigger collider that exists on the buttom of the freefalling arena to break out of the 
    bubble and give control back again to the player object with the keyboard control.
    
    
    */

    //reference to the player object
    public GameObject player;
    //referenece to the bubble object
    public GameObject bubble;
    //reference to a sprite (raw image)
    public Sprite bubbleTex;
    //reference to the player camera
    public GameObject playerCam;
    //reference to the bubble camera
    public GameObject BubbleCam;

    private void OnTriggerEnter2D(Collider2D other) {

        //on triggering, it checks the tag of the triggering object if it is the bubble
        if(other.gameObject.tag == "Bubble"){
            //turning back the player to active
            player.SetActive(true);
            // changing the sprite of the bubble to the referenced sprite
            bubble.GetComponent<SpriteRenderer>().sprite = bubbleTex;
            //changing the body type of the bubble into a static
            bubble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //giving the player the position of the bubble to make it look like the player popped out of it
            player.transform.position = bubble.transform.position;
            //camera switching
            BubbleCam.SetActive(false);
            playerCam.SetActive(true);


        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
