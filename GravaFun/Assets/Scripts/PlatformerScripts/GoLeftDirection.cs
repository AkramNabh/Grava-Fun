using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeftDirection : MonoBehaviour
{



    /*
    
    this script is for when the hidden room is revealed in the platformer level
    
    */

    //a reference of the gate object that will close the road back to the green container
    public GameObject moveOnActivate;
    // a reference to the message object
    public GameObject Message;
    //a reference to the audio source
    public AudioSource sfx;
     private bool isMovable = false; // bool for action
    public float moveDis = 20f; // distance of move
    public float moveSpeed = 2f; // speed of movement
    private float startPosX; // saves the start position of the movable
    private bool mustDestroy = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isMovable = true;
            Message.SetActive(true);
            sfx.Play();
        }
    }

            private void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
            Message.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
            mustDestroy = true;
            }
        }
    void Start()
    {
        startPosX = moveOnActivate.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        


        
         if(moveOnActivate.transform.position.x < startPosX + moveDis && isMovable && !mustDestroy)  // moving condition
            {
                float moveAmount = moveSpeed * Time.deltaTime; // saving the move amount
                Vector3 newPos = moveOnActivate.transform.position + new Vector3(moveAmount, 0f, 0f); 
                moveOnActivate.transform.position = newPos;
            }
            if(mustDestroy){
                Destroy(gameObject, 10f);
            }

    }


}
