using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{

    /*
    
    
    this script is for the usage of the mouse to draw dots in the freefaller level
    
    
    */


    //a reference of the dots gameobject (saved as a prefab)
    public GameObject dots;
    //a reference of the bubble object
    private GameObject bubble;
    private void Start() {

        //capturing the bubble gameobject and saving it to the reference
        bubble = GameObject.FindGameObjectWithTag("Bubble");
    }
    void Update()
    {
        //a condition that checks if the bodytype of the bubble is dynamic
        if(bubble.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic){
            // if the bubble is dynamic, then activates the mouse listener for the left click
        if(Input.GetMouseButton(0)){
            // if clicked then create a vector2 and save in it the position of the mouse
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //anothe vector2 that will translate the mousePos to the position in the game world
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            //instantiate a dots object, saving giving it the objPos to spawn at, and reseting its rotation to original
            Instantiate(dots, objPos, Quaternion.identity);
        }
        
        }
    }
}
