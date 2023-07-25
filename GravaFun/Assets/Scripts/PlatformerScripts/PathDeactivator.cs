using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* 


this script is for 2 hidden colliders on top of the hidden path, they re-activate the path collider, so the 
player does not fall in the exit of the path.

*/
public class PathDeactivator : MonoBehaviour
{
    public GameObject path; // reference of the path tilemap

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player"){
            path.GetComponent<PolygonCollider2D>().enabled = true; // re-activating the collider
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
