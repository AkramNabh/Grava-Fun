using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunActivator : MonoBehaviour
{

    /*
    
    this script is for the spawning gun the player picks up

    */


    // a reference of the gun image in the canvas
    public Image gunIMG;
    // a reference to the child gun in the player object
    public GameObject playerGun;
    // bools to check if the player isHolding the gun and if the the player is in the trigger zone to pick up the gun
    private bool isHoldingGun = false;
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        //checks if the player is in the trigger zone
        if(other.gameObject.CompareTag("Player")){
            isTriggered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        //checks if the player is still in the trigger zone
                if(other.gameObject.CompareTag("Player")){
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //checks if the player left the trigger zone
                if(other.gameObject.CompareTag("Player")){
            isTriggered = false;
        }
    }
    void Start()
    {
        //returning if the child gun of the player is active or not
        isHoldingGun = playerGun.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        //if in the trigger zone
        if(isTriggered){
            // a keyListener and if player is not holding a gun already
            if(Input.GetKeyDown(KeyCode.G) && !isHoldingGun){
                // change the gun image in the canvas to its original color
                gunIMG.color = Color.white;
                // activating the child gun in the player object
                playerGun.SetActive(true);
                // de-activating the pick up gun
                gameObject.SetActive(false);
            }

        }
    }
}
