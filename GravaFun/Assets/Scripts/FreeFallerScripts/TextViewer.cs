using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextViewer : MonoBehaviour
{

    /*
    
    this script is for the texts that show up on the beginning of the freefaller level where it explains
    what is the level about and what is the purpose of it.
    
    
    */


    //an array of gameobject called texts.
    public GameObject[] texts;

    private void OnTriggerEnter2D(Collider2D other) {
        //when the player triggers the trigger
        if(other.gameObject.CompareTag("Player")){
            //a for loop that loops through the array of objects and sets each one of the elements active
                for(int i = 0; i < texts.Length; i++){
                    texts[i].SetActive(true);
                 }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        //when the player exits the trigger
         if(other.gameObject.CompareTag("Player")){
            //a for loop that loops through the array of object and de-activates all it's elements
                for(int i = 0; i < texts.Length; i++){
                    texts[i].SetActive(false);
                 }
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
