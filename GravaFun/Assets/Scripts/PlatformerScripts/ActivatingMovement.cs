using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingMovement : MonoBehaviour
{
   

/*

this script is for any gate that will block , or unlock something during the gameplay, with player inter-action,
and it is meant to be for the lock boxes in the platformer level.

*/


//reference of the object that will be moved
public GameObject movable;
//a delay for not making the movement instant (making it look more natural)
    public float delayTime = 3f;
    //a bool to determine when the movement action should be activated
    private bool isMove = false;
    //a float to save the start position of the movable object
    private float startPosX;
    //a float that will take the movement distance
    public float moveDis = 20f;
    //a float that takes the speed of the movement
    public float moveSpeed = 2f;

   private void OnTriggerEnter2D(Collider2D other) {
    //checks if the triggering object is the correct one to turn the bool into true
    if(other.gameObject.tag == "Grabable"){

        isMove = true;
    }
   }
    void Start()
    {
        //saves the start position of the movable object
       startPosX = movable.transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        checks if the movable object position on the X-axis is less than the original position of the movable object 
        added to it the desired move distance, and most importantly if the action should be activated with the isMove 
        bool.
        */
         if(movable.transform.position.x < startPosX + moveDis && isMove)  // moving condition
            {
                //calls a delay coroutine
                StartCoroutine(TriggerWithDelay()); // delay
                //creates a float that contains a multiplication of the movespeed multiplied with the delta time
                //(real time). so the change look natural instead of instant
                float moveAmount = moveSpeed * Time.deltaTime; // saving the move amount
                //creates a vector3 that will hold the new position with adding the moveAmount
                Vector3 newPos = movable.transform.position + new Vector3(moveAmount, 0f, 0f);
                //passes the the value to the object 
                movable.transform.position = newPos;
            }
    }

    //an IEnumerator that only acts like a delay.
         IEnumerator TriggerWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
