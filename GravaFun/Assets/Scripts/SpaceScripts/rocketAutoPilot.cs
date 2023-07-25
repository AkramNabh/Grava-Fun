using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketAutoPilot : MonoBehaviour
{


    /*
    this script is for the red rocket autopilot upon loading the space level
    */


    // a reference of a the start point transform, where it will give control back to the player
    public Transform startingPoint;
    // a float of movespeed
    public float moveSpeed = 5f;
    // a reference of the red rocket particles system
    public ParticleSystem particles;
    // an array of gameobjects that wll hold the guides
    public GameObject[] guides;
    // a float holding stopDistance that will be used as a condition
    public float stopDis = 0.01f;
    // a float of a specific distance, it will be used as a condition
    public float loadingDis = 10f;
    // a bool to determine if the red rocket reached to the stop point
    private bool isReached;
    
    void Start()
    {
    }
    void Update()
    {
        // if didnt reach yet
        if(!isReached){
            // play the particles
            particles.Play();
            // calculate the change of the distance between the start point and the red rocket
    Vector2 distance  = startingPoint.position - transform.position;
            // forces the red rocket to move towards the start point, by using movetowards.
    transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, moveSpeed * Time.deltaTime);
    // if the distance between the red rocket and the starting point is less or equal to stop distance
    if(distance.magnitude <= stopDis){
        // destroyes the particles
        Destroy(particles);
        // and sets the isreached bool to true
        isReached = true;
        // re-enabling the player control over the rocket
        gameObject.GetComponent<RocketScript>().enabled = true;
        gameObject.GetComponent<rocketAutoPilot>().enabled = false;
    }
    // if the distance is less or equal to the loading distance
    if(distance.magnitude <= loadingDis){
        // it changes the movespeed, to act like de-acceleration
        moveSpeed = 3f;
        // activates the guides
            for(int i = 0; i < guides.Length; i++){
            guides[i].SetActive(true);
        }
    }
        }
   
    }
}
