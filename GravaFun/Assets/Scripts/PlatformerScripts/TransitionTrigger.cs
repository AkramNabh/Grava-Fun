using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    private bool isTriggered = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isTriggered = true;
        }
    }

    private void Update() {
        if(isTriggered){

        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<GameManager>().loadNextLevel();
        }
        
    }
}
