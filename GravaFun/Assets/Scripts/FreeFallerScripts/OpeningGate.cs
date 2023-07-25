using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningGate : MonoBehaviour
{

    /*
    
    
    this script is for the gate that holds the bubble from falling
    
    */


     public float delayTime = 4.0f; // a delay
    public GameObject moveOnActivate; // activating movement for this object
    private bool isTrigger = false; // is trigger bool
    public float moveDis = 2f; // move distance
    public float moveSpeed = 2f; //move speed
    private float startPosX;


    private void OnTriggerEnter2D(Collider2D other) {
        //checking if the triggerer is the player
        if(other.gameObject.tag == "Player"){
            isTrigger = true;
        }
    }


    void Start()
    {
        //saving the start position of the gate
        startPosX = moveOnActivate.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //on triggering
         if (isTrigger) 
        {
            //the below if condition, compares the start position + the movedistance with position of the movable object
            if(moveOnActivate.transform.position.x < startPosX + moveDis) 
            {
            float moveAmount = moveSpeed * Time.deltaTime; 
            Vector3 newPos = moveOnActivate.transform.position + new Vector3(moveAmount, 0f, 0f);
            moveOnActivate.transform.position = newPos; //after calculating the new position, this function sets it to the object
            }
        }
    }

}
