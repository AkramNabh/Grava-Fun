using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunTrader : MonoBehaviour
{
 

    /*
    
    this script is for the npc that will give the player the gun.

    */


    // a reference of the name object
    public GameObject Name;
    // a reference of the conversation object
    public GameObject Conversation;
    // a reference of the instructions object
    public GameObject instructions;
    // a reference of the gun object
    public GameObject gun;
    // an array of strings that will hold the conversation, the text the npc will show
    public string[] convo;
    // a counter that will be used later on
    private int counter = 0;
    // a second counter to determine when the gun will spawn
    private int secondCounter = 0;
    //  a bool to determine if the text is showing or not
    private bool textShowing = false;
    // a color type variables for fading and for original color
    private Color nameColor;
    private Color nameColorFaded;
    // a bool to see if triggered or not
    private bool isTrigger = false;



    private void OnTriggerEnter2D(Collider2D other) {
        // if the player is the one who is triggering
        if(other.CompareTag("Player")){
            // the bool gets set to true
            isTrigger = true;
            // name object is activated
            Name.SetActive(true);
            // instructions object is activated
            instructions.SetActive(true);
            // conversation object is activated
             Conversation.SetActive(true);
             // the textshowing bool is set to true
            textShowing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isTrigger = true;
            Name.SetActive(true);
            instructions.SetActive(true);
             Conversation.SetActive(true);
           textShowing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
         if(other.CompareTag("Player")){
            isTrigger = false;
            Name.SetActive(false);
            instructions.SetActive(false);
            Conversation.SetActive(false);
            textShowing = false;
            counter = 0;
         }
    }
    void Start()
    {
        nameColor = new Color(25f, 214f, 208f, 255f);
        nameColorFaded = new Color(25f, 214f, 208f, 80f);
    }

    // Update is called once per frame
    void Update()
    {
        // a keylistener with textshowing bool 
        if(Input.GetKeyDown(KeyCode.G) && textShowing){
            // de-activating the instructions object
            instructions.SetActive(false);
            // starts the counter to iterate through the array of strings
               counter = (counter + 1) % convo.Length;
               // counts how many times player clicked
               secondCounter += 1;
               // changes the conversation text in the TMP_text component of the convesation object
               Conversation.GetComponent<TMP_Text>().text = convo[counter];
            }

        //checking if the player clicked until the number when the gun will spawn
        if(secondCounter == convo.Length - 3){
            gun.SetActive(true);
            secondCounter = 0;
        }
    }
}
