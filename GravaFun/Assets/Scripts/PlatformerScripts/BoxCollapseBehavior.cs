using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

this code is for the collapsable box in level 1, where it loads the textures of the box breaking down
and acts on it.

*/


public class BoxCollapseBehavior : MonoBehaviour
{

// creating some variables to use in the code.
    public Sprite[] boxStages; // an array of sprites that are modifiable in unity.
    public float delayTime = 4.0f; // modifiable delay, will be used in switching the textures of the box
    public GameObject tilemap; // a modifiable gameobject, referance to a tilemap to give actions on
    public GameObject playerCam; //reference for the virtual camers to act like a cut scene
    public GameObject boulderCam;
    public GameObject playerCol;
    public AudioSource sfx;
    private int currentStage = 0; // basic counter
    private SpriteRenderer spRender; // a reference of the sprite renderer component of the object holding this script

    private bool isCollided = false; // a bool for detection
    private float timer = 0;


    /*
    the on collision function below, it detects of the object holding this script has collided with another
    object, it will be explained breifly, and the parameter refers to the object collided with the object holding
    this script
    */
    private void OnCollisionEnter2D(Collision2D other) {

        //a common used method to decide which object has collided with the object holding this script
        //is by comparing the gameobject tag, and the tag is given in the components list
    if(other.gameObject.tag == "Movables"){
        isCollided = true;
        sfx.Play();
        StartCoroutine(textureLoop()); //a counter function in C# i will explain how it functions completely
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; // disabling the boxcollider of the object holding this script
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; //switching the rigidbody type of the object holding this script into static
    }
    }


    /*
    oncollisionstay, is a function in C# that will be activated when the collision is repeating,
    basically if the object kept colliding with the object holding this file
    */
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Movables"){
        isCollided = true;
    }
    }

    /*
    the start function, this function gets activated exactly when the game runs and gets activated,
    same concept of the constructor but with a different naming.
    */

    void Start()
    {
         spRender = GetComponent<SpriteRenderer>(); //to recieve the reference of the sprite renderer

        spRender.sprite = boxStages[currentStage]; // sits the sprite texture to the first index in the textures array
    }

    // Update is called once per frame
    void Update()
    {
        // is collided will be sit to true in the oncollision functions above, both stay and enter.
        if(isCollided){
        StartCoroutine(Fader()); // turns on another start coroutine function, the fader.
        
        }
    }

    //the fader, this function gives the fading affect to the object when called.
    IEnumerator Fader()
    {
        
        Color originalColor = spRender.color; // saving the original color of the sprite.
        float t = 0f; // simple counter
        while(t < delayTime){
            t += Time.deltaTime; //time.deltatime, this is a predefined function in C# that returns the real time deltatime
            float normalizedTime = t / delayTime; 

            // lerp, is a function that interpolates between the colors given, and the last parameter is time between each interpolate
            spRender.color = Color.Lerp(originalColor, Color.clear, normalizedTime);
            yield return null;
        }
        boulderCam.SetActive(false);
        playerCam.SetActive(true);
        playerCol.SetActive(true);
        Destroy(this.gameObject); //destroying the object holding the script
        Destroy(tilemap); // destroying the tilemap that got referenced to work as a hidden room.
    }


    IEnumerator textureLoop(){ // function looping through the textures of the box.
    
    for (int i = 0; i < boxStages.Length; i++) // a basic for loop to loop through the boxstages array.
        {
            spRender.sprite = boxStages[i]; //sprite texture setter
            yield return new WaitForSeconds(0.2f); // waits for 0.2seconds to complete a loop.
        }
    
    }
}
