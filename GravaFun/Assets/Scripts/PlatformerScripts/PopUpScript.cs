using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* 


basic script for testing how to input texts into the game, and loading them in a nice way

the way it works, is by placing a message sprite, that contains the message and deactivate it on the right position
and with this script gets attatched to any object, and on triggering, the message sprite will be activated, and when exitting
the trigger the message will deactivate again.
*/


public class PopUpScript : MonoBehaviour
{
    public GameObject Message;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Message.SetActive(true);
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Message.SetActive(false);
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
