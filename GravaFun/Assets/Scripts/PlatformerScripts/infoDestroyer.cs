using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoDestroyer : MonoBehaviour
{

    /*
    
    this script is for destroying the messages game objects in the beginning of the gameplay of the platformer level
    
    */



    public GameObject message;
    private bool mustDestroy = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            message.SetActive(true);
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            message.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
                    message.SetActive(false);
        mustDestroy = true;
        }

        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mustDestroy){
            Destroy(gameObject);
        }
    }
}
