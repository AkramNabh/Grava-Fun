using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundScroller : MonoBehaviour
{

    /*
    
    
    this script is for the background layers of the GUI in the start menu of the game

    
    */

    // references of the background layers
    public RawImage backGround;
    public RawImage backGround2;
    public RawImage backGround3;
    public RawImage backGround4;

    //floats that each couple will be used for a layer
    public float x, y;
    public float x2, y2;
    public float x3, y3;
    public float x4, y4;

    // Update is called once per frame
    void Update()
    {
        /*
        
        uvRect is a proprety of the rawimage type of objects, and it saves rect object that will be sized as the 
        uvRect of the rawimage, it will take control over the position of the rawimage, where changing the 
        position of the rect will lead to change the position of the rawimage.

        so basically what is happening in the lines is that the uvRect will save a new rect every frame update, and 
        the new rect, will have the position of the uvRect of the raw imageand adds to it the specified 
        floats as a vector2, while keeping the size the same, and the size is being taken from the uvrect of the 
        raw image 

        what happens is

        the uvRect of the rawimage = a new rect object having the rawimage uvRect position + a vector2 having x, y values
        multiplied with the time.deltatime (returns value of real time in updating each frame),
        and passing the uvRect size to the new rect that has been instantiated to keep the size the same
        
        */
        backGround.uvRect = new Rect(backGround.uvRect.position + new Vector2(x, y) * Time.deltaTime, backGround.uvRect.size);
        backGround2.uvRect = new Rect(backGround2.uvRect.position + new Vector2(x2, y2) * Time.deltaTime, backGround2.uvRect.size);
        backGround3.uvRect = new Rect(backGround3.uvRect.position + new Vector2(x3, y3) * Time.deltaTime, backGround3.uvRect.size);
        backGround4.uvRect = new Rect(backGround4.uvRect.position + new Vector2(x4, y4) * Time.deltaTime, backGround4.uvRect.size);
    }
}
