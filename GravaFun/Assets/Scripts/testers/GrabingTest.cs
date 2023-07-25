using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabingTest : MonoBehaviour
{
public Transform grabDetect;  // a point was created around the player to detect from where player can grab
    public Transform BoxHolder; // the place of the box when its held by the player
    public float rayDist; // distance of grabbing, which means how far can the player grab from
    private GameObject heldObject; // the object currently being held

    // Update is called once per frame
    void Update()
    {
        /*
        starting off with raycasthit2D, this method creates a raycast, that detects closest collision
        where you give it a position to start from, direction, and length, it works more like a lazer beam,
        where returns null when not colliding with any object, and by this way, i can check for it not
        equal to null, and making sure iti is the right object that has a tag, grabable, and most importantly
        if the E key is pressed, the player will grab it, and on pressing the E key again, the player will release the object.
        */

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabable")
        {
            if (Input.GetKeyDown(KeyCode.E) && heldObject == null)
            {
                heldObject = grabCheck.collider.gameObject;
                heldObject.transform.parent = BoxHolder; // transform the gameobject to the boxholder point
                heldObject.transform.position = BoxHolder.position; // gives the game object the same position of the boxholder
                heldObject.GetComponent<Rigidbody2D>().isKinematic = true; // turnes the gameobject rigidbody type to kinematic
            }
            else if (Input.GetKeyDown(KeyCode.E) && heldObject != null)
            {
                heldObject.transform.parent = null; // on release will turn into null
                heldObject.GetComponent<Rigidbody2D>().isKinematic = false; // sets it back to whatever the rigidbody type was
                heldObject = null;
            }
        }
    }
}
