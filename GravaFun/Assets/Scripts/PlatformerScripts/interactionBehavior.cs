using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

this script is for the vertical lever in level 1.

1-switches the texture
2-sends a signal to move a trapdoor to drop the box
3- only usable by the player on a curtain key pressing

*/


public class interactionBehavior : MonoBehaviour
{
    public float delayTime = 4.0f; // delay,.. for some reason its not working
    public GameObject moveOnActivate; // reference of the movable object
    private bool isTrigger = false; // a bool to determine if triggered
    public float moveDis = 2f; // moving distance of the movable object upon activation
    public float moveSpeed = 2f; // speed of the move
    private float startPosX; // will save the starting position of the movable object
    private bool canPress = false; // bool for switching the textures
    private bool isActive = false; // 
    public Sprite[] leverStages; // array of textures
    private int currentStage = 0; // counter
    private SpriteRenderer spRender; // the sprite renderer reference
    public AudioSource SFX;
    public GameObject message;
    void Start()
    {
        startPosX = moveOnActivate.transform.position.x; //saving the starting pos of the movable object
        spRender = GetComponent<SpriteRenderer>(); // capturing the reference of the sprite renderer 

        spRender.sprite = leverStages[currentStage]; // sitting the first index of the array to the sprite
    }

  

    // basic on trigger functions that will return a bool of can press or not.
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

    void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.G)) //key listener
        {
            currentStage = (currentStage + 1) % 2; // switching through the textures with returning 0, 1 every time clicked
            spRender.sprite = leverStages[currentStage]; // sitting the right texture
            isActive = true; 
            SFX.Play();
        }


        // if condition the check if the position of the movable is less than its position with the required distance 
       //that the object is required to move, and acts upon that. 
            if(moveOnActivate.transform.position.x < startPosX + moveDis && isActive) 
            {
                StartCoroutine(TriggerWithDelay());
                float moveAmount = moveSpeed * Time.deltaTime;
                Vector3 newPos = moveOnActivate.transform.position + new Vector3(moveAmount, 0f, 0f);
                moveOnActivate.transform.position = newPos;
            }
        
    }
    
    IEnumerator TriggerWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isTrigger = true;
    }
}
