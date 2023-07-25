using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDestroyer : MonoBehaviour
{
    /*
    
    a basic function attached to the dot object, it is an automatic destroyer of the object
    
    */

    public int ticks = 5; // a counter
    private SpriteRenderer spRender; 


    void Start()
    {
        Destroy(this.gameObject, 2.5f); 
    }
   
}
