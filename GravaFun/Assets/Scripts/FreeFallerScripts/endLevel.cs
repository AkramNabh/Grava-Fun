using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{

    /*
    
    
    this script is attached to the trigger in the end of the level to activate the animation to transform to the next
    scene.
    
    
    */


    //a bool to check if triggered
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other) {

        //comparing tag to turn the bool true if the rocket triggered and not any other object

        if(other.gameObject.CompareTag("rocket")){
            isTriggered = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered){

            //captures a reference of a function in the object that has TransitionScene tag, taking the
            //loadnextlevel from the GameManager script attatched to the object and activating that function
            // (calling it basically)
            GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<GameManager>().loadNextLevel();
        }
    }
}
