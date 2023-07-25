using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyScript : MonoBehaviour
{

    /*
    
    this script is for the red key object that unlocks the activating lever for the black rocket
    
    */


    // a reference of the key image in the canvas
    public Image keyIMG;
    // a reference to the  lever that activates the black rocket
    public GameObject lever;
    // a reference to a sprite that holds a chosen texture
    public Sprite texture;
    // a reference to the player virtual camer
    public GameObject playerCam;
    //a reference to the lever virtual camera
    public GameObject leverCam;
    // a reference of the lockedlever object, that was put over the lever itself
    public GameObject lockedLever;
    // a reference of the sprite renderer of the lever
    private SpriteRenderer spRender;
    // a reference of the boxcollider of the lever
    private BoxCollider2D theTrigger;
    //a bool that will determine if is trigger
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other) {
        // checks if the player triggered the collider
        if(other.gameObject.CompareTag("Player")){
            keyIMG.color = Color.white;
            
            isTriggered = true;
        }
    }
    void Start()
    {
        // capturing references from the lever gameobject
        spRender = lever.GetComponent<SpriteRenderer>();
        theTrigger = lever.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if is triggered
        if(isTriggered){
            //starts the coroutine of the cutsceneactivation function
            StartCoroutine(cutSceneActivation());
        }
    }


        //IEnumerator function to create a cutscene effect
        IEnumerator cutSceneActivation(){
            // destroy the lockedlever object that was places on top of the lever
        Destroy(lockedLever);
        // switches between the player virtual camera and the lever virtual camera
        playerCam.SetActive(false);
        leverCam.SetActive(true);
        // a delay for 1 second and a half
        yield return new WaitForSeconds(1.5f);
        // change the lever texture
        spRender.sprite = texture;
        // activating the boxcollider of the lever
        theTrigger.enabled = true;
        // a delay for another 1 second and a half
        yield return new WaitForSeconds(1.5f);
        // switching back to the player virtual camera from the lever virtual camera
        leverCam.SetActive(false);
        // destroy the red key object
        Destroy(gameObject);
        playerCam.SetActive(true);
    }
}
