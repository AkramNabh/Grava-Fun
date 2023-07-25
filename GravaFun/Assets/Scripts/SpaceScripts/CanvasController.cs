using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    /*
    
    this is the canvas controller in the space level
    
    */

    // a reference to the gun gameobject
    public GameObject gun;
    // a reference to the gun image in the canvas
    public Image gunIMG;
    // an int that will be the value decreased on hit by the enemy to change the amount of hearts in the canvas
    public int damage = 1;
    // a reference of a transform object that will act like a respawn point
    public Transform respawnPoint;
    // a float to calculate the penetration force when the player or the enemy gets shot
    public float penetrationForce = 5f;
    // a float to calculate the amount of force that will drag the player or the enemy upwards
    public float floatForce = 5f;
    // a reference of the bubble object to show up when getting shot
    public GameObject bubble;
    // a reference of the animator that the player has
    private Animator animaton;
    // a vector2 to save the bullet direction
    private Vector2 bulletDir;
    // a reference of the player rigidbody
    private Rigidbody2D playerRB;
    // a vector2 that will save the position of the respawn point
    private Vector2 newPos;
    private void OnCollisionEnter2D(Collision2D other) {
        // if the player gets shot buy a purple bullet
        if(other.gameObject.CompareTag("Bullet")){
            // calls the gotDamaged function -decleration on buttom
            gotDamaged();
            // calculate the bullet direction to use in penetrating the player
            bulletDir =transform.position - other.transform.position;
            bulletDir.Normalize();
        }
    }
    void Start()
    {   
        //saving the spawnpoint position in the vector2
        newPos = respawnPoint.position;
        //capturing the reference of the animator
        animaton = GetComponent<Animator>();
        // capturing the reference of the player rigidbody
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // checks if the playerhealth that is being calculated in the canvasmanager script is equal to 0
        if(GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().playerHealth == 0){
            // starts the coroutine of the deadandrespawn function
            StartCoroutine(deadAndRespawn());
        }
    }

    //declaration of the gotdamaged function
    void gotDamaged(){
        //simply edits on the values saved in the canvasmanager and updates it so the number of hearts go down
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().playerHealth -= damage;
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().updateHealth();
    }


    IEnumerator deadAndRespawn(){
        /*

        this is for the death animation, i am keeping it for future purposes

        animaton.SetTrigger("dead");
        gun.SetActive(false);
        gunIMG.color = Color.black;
        yield return new WaitForSeconds(1f);
        animaton.SetTrigger("respawn");
        transform.position = newPos;
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().playerHealth = 3;
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().updateHealth();
         */ 

         // activating the bubble the player has
        bubble.SetActive(true);
        // disables the boxcollider the player has
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //saves the value of the player rotation (because player rotates when moving on planets, not the planets)
        Quaternion currentRotation = transform.rotation;
        // freezes the change of rotation of the player
        playerRB.freezeRotation = true;
        // adds an impulsing force to the player, in the direction of the bullet multiplied by the force of penetration
        playerRB.AddForce(bulletDir * penetrationForce, ForceMode2D.Impulse);
        // adds the force of floating so it looks like the player is floating
        playerRB.AddForce(transform.up * floatForce, ForceMode2D.Impulse);
        // freezes the rotation of the player again after force is applied
        playerRB.freezeRotation = true; 
        //  sits the rotation to what was captured before adding the force
        transform.rotation = currentRotation;
        // de-activating the in-hand gun for the player
        gun.SetActive(false);
        // changing the color of the gun image in the canvas to show that gun was un-equipped
        gunIMG.color = Color.black;
        // a delay for respawning
        yield return new WaitForSeconds(1.5f);
        // de=activating the bubble on respawn
        bubble.SetActive(false);
        // moving the player to the respawn position
        transform.position = newPos;
        // re-activating the player box collider
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        // reseting the health of the player to full in the canvas and updating it using the canvasmanager script
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().playerHealth = 3;
        GameObject.FindGameObjectWithTag("TransitionScene").GetComponent<CanvasManager>().updateHealth();

    }
}
