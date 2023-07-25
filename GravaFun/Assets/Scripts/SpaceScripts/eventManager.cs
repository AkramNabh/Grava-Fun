using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventManager : MonoBehaviour
{

    /*
    
    this script is for managing the event of the canvas, determining wither pictuers should be shown or not
    
    */


    //reference to the red-rocket gameobject
    public GameObject rocket;
    // an array of gameobjects that will hold all the components of the canvas
    public GameObject[] images;
    // a reference of the red-rocket guides 
    public GameObject[] rocketGuides;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the red-rocket is not active
        if(rocket.activeSelf == false){
            // iterates through all the images array and activates all of them
            for(int i = 0; i < images.Length; i++){
                images[i].SetActive(true);
            }
            // iterates through all the red-rocket guides and de-activates them all
            for(int i = 0; i < rocketGuides.Length; i++){
                rocketGuides[i].SetActive(false);
            }
        }

    }



    /*
    

    */
}
