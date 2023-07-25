using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
   
    /*
    this script is for managing the canvas images, updating them depending on actions and reactions
    */


    // an int value to initialize the player health
   public int playerHealth = 3;
   // an array of image references for the hearts 
   [SerializeField] private Image[] hearts;
   

   private void Start() {

    // updating the image function being called first when the script is loaded
    updateHealth();
    
   }



    // decleration of the updatehealth function
   public void updateHealth(){
    // a for loop to iterate through all the images in the images array
    for(int i = 0; i < hearts.Length; i++){
        // checks the value of the player health is bigger than the iterator value
        if(i < playerHealth){
            // updates it to original color
            hearts[i].color = Color.white;
        }
        
        else {
            // blackence it to look like it was lost
            hearts[i].color = Color.black;
        }
    }
   }
}
