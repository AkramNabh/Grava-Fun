using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    
    /*
    
    this script is for the button that pops up if the bubble touched a spike so the player can retry again.
    
    */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BubbleRelease(GameObject bubble){
        // turns the bodytype of the rigidbody of the bubble into a dynamic body.
        bubble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
        //this function to de-activate the button when it is clicked so it does not stay on screen while playing.
    public void ButtonController(GameObject button){
        button.SetActive(false);
    }
}
