using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*


this script is to act on the door, it will be changed later on

*/
public class ForDoor : MonoBehaviour
{
    private Rigidbody2D DoorRigid; //reference to the rigidbody of the object that holds the script
   
   /*
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") //comparing the tags, to make sure it collided with the right object
        {
            
            Rigidbody2D DoorRigid = this.GetComponent<Rigidbody2D>();
            DoorRigid.bodyType = RigidbodyType2D.Static; // after the object collides with the ground, its rigidbody gets set to static
            this.transform.rotation = Quaternion.identity; // a function to fix any un-necessery rotation.
        }
    }
 */
    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Force-Affectors") //comparing the tags, to make sure it collided with the right object
        {
            Rigidbody2D DoorRigid = this.GetComponent<Rigidbody2D>();
            DoorRigid.bodyType = RigidbodyType2D.Static; // after the object collides with the ground, its rigidbody gets set to static
            this.transform.rotation = Quaternion.identity; // a function to fix any un-necessery rotation.
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
