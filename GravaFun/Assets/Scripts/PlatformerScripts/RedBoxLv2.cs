using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

this script is for the red box container ( the one in the hidden room ) in level 1.

and it activates the 3 stages lever, that drops the boulder in the middle of the level.

*/




public class RedBoxLv2 : MonoBehaviour
{
    
    public GameObject lever; // reference of the lever
    public GameObject leverNotActive;
    public GameObject Message;
    public AudioSource leverActivated;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Grabable"){
        lever.GetComponent<BoxCollider2D>().enabled = true; // activating the box collider of the lever
        leverNotActive.SetActive(false);
        Message.SetActive(true);
        leverActivated.Play();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
                
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
