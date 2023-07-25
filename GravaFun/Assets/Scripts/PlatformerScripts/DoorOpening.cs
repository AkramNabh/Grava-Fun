using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

this script is for the red door in the introduction level, it will make the the door fall down into the hole
with the addition of an object that will be move upon activation.
*/
public class DoorOpening : MonoBehaviour
{
    public float delayTime = 4.0f; // a delay
    public GameObject door;  // switching type of rigid body of this object
    public GameObject moveOnActivate; // activating movement for this object
    private bool isTrigger = false;
    public float moveDis = 2f; // move distance
    public float moveSpeed = 2f; //move speed
    private float startPosX; // capturing the start position on the x axis
    private void OnTriggerEnter2D(Collider2D col) // on trigger function for the object that holds this script
    {
        if (col.gameObject.tag == "Grabable") //basic comparing of the tag of the right object to activate
        {
            StartCoroutine(TriggerWithDelay()); //activate the move with a delay
            
            Rigidbody2D boxBody = door.GetComponent<Rigidbody2D>(); // capturing the reference of the rigidbody of the door
            boxBody.bodyType = RigidbodyType2D.Dynamic; // switching the rigidbody type to dynamic
        }
    }

    void Start()
    {
        startPosX = moveOnActivate.transform.position.x; // capturing the start position of the movable object
    }

    
    void Update()
    {
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
    
    
    IEnumerator TriggerWithDelay()
    {
        yield return new WaitForSeconds(delayTime); // the delay decided by the user
        isTrigger = true;
    }
}
