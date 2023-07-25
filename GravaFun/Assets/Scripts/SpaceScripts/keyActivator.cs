using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyActivator : MonoBehaviour
{


    /*
    
    this script is for randomizing the spawn of the key, randomizing which enemy will drop it, and to actually drop
    it from the selected enemy by the randomizer
    
    */



    //an array of objects that will hold all the enemies
    public GameObject[] enemy;
    // a reference of the redkey
    public GameObject redKey;
    // a vector2 that will hold the key spawn positon
    private Vector2 keyPos;
    // an int that will hold the value that came out of the randomizer
    private int randomChoice;
    // a float that will act like a timer
    private float timer;

    private void Start() {
        // random.rang is a function that returns an int number between 2 values passed as parameters
        // first values is 0 and second value is the size of the enemies array -1 to not exceed the array size
        randomChoice = Random.Range(0, enemy.Length - 1);
        // saves the key spawn position in keypos, coming from the chosen enemy's position
        keyPos = enemy[randomChoice].transform.position;
        // clearing the timer
        timer = 0;
    }

    private void Update() {
        // checks if the chosen enemy is shot.
        if(enemy[randomChoice].GetComponent<Shooter>().isShot){
            // adding real time to the timer variable
            timer += Time.deltaTime;
            // checks if the timer is bigger than 0.5 which is have a second basically
            if(timer > 0.5f){
                // activating the red key
            redKey.SetActive(true);
            // changing its position to the chosen enemy position
            redKey.transform.position = keyPos;
            // destroys this gameobject
            Destroy(gameObject);
            }
            
        }
}

}
