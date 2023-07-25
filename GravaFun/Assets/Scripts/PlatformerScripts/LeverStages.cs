using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*


this script is for the 3 leveled lever, it has 3 textures, and each texture will be used later on for a different action
, basically in this file, it recieves all textures, save them in an array, and increase the index when needed.

and in this script it was used to open the trapdoor on the boulder that will click on the button in the hole.
*/



public class LeverStages : MonoBehaviour
{
    public Sprite[] leverStages; // array of sprites references
    public AudioSource SFX;
    public GameObject moveOnActivate; // the movable
    public GameObject message;
     private bool isMovable = false; // bool for action
    public float moveDis = 20f; // distance of move
    public float moveSpeed = 2f; // speed of movement
    private float startPosX; // saves the start position of the movable
    public float delayTime = 4.0f; // delay
    private int currentStage = 0; // counter
    private SpriteRenderer spRender; // reference of the sprite rendered
    private bool canPress = false; // bool to check if player can press or not

// on trigger functions to activate the canPress bool
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            canPress = true;
            message.SetActive(true);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            canPress = true;
            message.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            canPress = false;
            message.SetActive(false);
        }
    }

    void Start()
    {
        startPosX = moveOnActivate.transform.position.x; // saving the start position of the movable
        spRender = GetComponent<SpriteRenderer>(); // capturing reference of the sprite renderer component

        spRender.sprite = leverStages[currentStage]; // sitting the first index of the sprite array as the first sprite rendered

    }
    
    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.G)) // keylistener with a condition
        {
            currentStage = (currentStage + 1) % 3; // keeping current stage value not exceed 0 to 2
            spRender.sprite = leverStages[currentStage];
            SFX.Play();
            if(currentStage == 2){ // specifying the stage for activating the move
                isMovable = true;
            }
        }
        

         if(moveOnActivate.transform.position.x < startPosX + moveDis && isMovable)  // moving condition
            {
                StartCoroutine(TriggerWithDelay()); // delay
                float moveAmount = moveSpeed * Time.deltaTime; // saving the move amount
                Vector3 newPos = moveOnActivate.transform.position + new Vector3(moveAmount, 0f, 0f); 
                moveOnActivate.transform.position = newPos;
            }
    }


    IEnumerator TriggerWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
