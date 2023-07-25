using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevelPlayer : MonoBehaviour
{
    
    /*
    
    
    this script is for the trigger that will switch to the next level if the level has been completed.
    
    
    */


    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
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
 // calls the loadnextlevel function that is in the Gamemanager script attached to the object with transitionscene tag
            GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<GameManager>().loadNextLevel();
        }
    }
}
