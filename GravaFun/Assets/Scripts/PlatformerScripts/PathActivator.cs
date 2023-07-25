using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*


this script was made to activate the hidden path if the player decided to go curious and drop down in it.
so the player does not get stuck, a hidden path gets revealed, or more like accessable :D

*/
public class PathActivator : MonoBehaviour
{
    public GameObject Message; // a message to show 
    public GameObject Message2;
    public GameObject path; // tilemap of the path

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            //on collision it will disable the collider of the tilemap, and turn on the message
            Message.SetActive(true);
            Message2.SetActive(true);
            path.GetComponent<PolygonCollider2D>().enabled = false;
            
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Message.SetActive(false);
            Message2.SetActive(false);
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
