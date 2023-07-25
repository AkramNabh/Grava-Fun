using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{


    /*
    
    this script is for the gravitational force of the planets in the space level
    
    */


    // a float to determine the force value of the gravity
    public float graForce;
    // a float to determine the radius of the gravitational force surrounding the planet
    public float planetR;
    //a value to fix the rotation of the object on entering the force field
    public float objectRotationSpeed = 2f;


    private void OnTriggerStay2D(Collider2D other) {
        
        // excluding the bullets from the gravitation force in an if condition
        if(other.gameObject.tag != "Bullet" && other.gameObject.tag != "white-Bullet"){

            //calculating the direction between the planet and the object the force is applied on, multiplied by the force amount
            Vector3 dir = (transform.position - other.transform.position) * graForce;
            // adds the calculated direction to the object as force
         other.GetComponent<Rigidbody2D>().AddForce(dir);

            //if condition to check for some specific objects
        if(other.CompareTag("Player") ||
         other.CompareTag("Grabable" )||
          other.CompareTag("rocket")  ||
          other.CompareTag("Alien")
          
          ){

            //line below is for fixing the rotation of the objects, and pulls the object towards the center
            other.transform.up = Vector3.MoveTowards(other.transform.up, - dir, graForce * Time.deltaTime * objectRotationSpeed);

        }
        

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // checking if rocket touched the planet
            if(other.CompareTag("rocket")){
                // disabling the rocketscript
               other.GetComponent<RocketScript>().enabled = false;
               // freezing the velocity of the rocket
               other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnDrawGizmosSelected()
    {
        // Draw the orbit field in the Unity editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, planetR);
    }
}
