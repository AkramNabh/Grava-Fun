using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPCmovement : MonoBehaviour
{


    /*
    
    naming of this script is wrong due to change of concepts, but this script deals with the interaction with the 
    NPC's ( the white aliens )
    
    */



    // a reference of the name object    
    public GameObject Name;
    // a reference of the conversation object
    public GameObject Conversation;
    // a reference of the instructions object
    public GameObject instructions;
    // an array of strings that will hold the conversation messages
    public string[] convo;
    // a counter
    private int counter = 0;
    // a length variable
    private int Length;
    // a bool to determine if text is shown or not
    private bool textShowing = false;

    // color variables to hold the original name color, and the other to hold the name color but with smaller alpha value
    private Color nameColor;
    private Color nameColorFaded;
    // a bool to determine if triggered
    private bool isTrigger = false;



    private void OnTriggerEnter2D(Collider2D other) {
        // checks if player is the one who triggered
        if(other.CompareTag("Player")){
            // sets istrigger to true
            isTrigger = true;
            // activates the name object
            Name.SetActive(true);
            // activates the instructions object
            instructions.SetActive(true);
            // activates the convesation object
             Conversation.SetActive(true);
             // sets the text showing bool to true
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
        // checks if player is leaving the trigger
         if(other.CompareTag("Player")){
            // sets the istrigger bool to false
            isTrigger = false;
            // de-activates the name object
            Name.SetActive(false);
            // de-activates the instructions object
            instructions.SetActive(false);
            // de-activates the conversations object
            Conversation.SetActive(false);
            // sets the textshowing bool to false
            textShowing = false;
            // resets the counter to 0
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

        //a keylistener with the textshowing bool
        if(Input.GetKeyDown(KeyCode.G) && textShowing){
            // de activating instructions object
            instructions.SetActive(false);
            // counts the number of presses, but never exceeding the length of the array of texts
               counter = (counter + 1) % convo.Length;
               // passes the counter to the convo array, and saves the text to the TMP_text component of the conversation
               Conversation.GetComponent<TMP_Text>().text = convo[counter];
            }

    }
}
