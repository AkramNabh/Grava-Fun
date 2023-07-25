using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GUImanager : MonoBehaviour
{

    
    /*
    
    this script is for the start menu, takes all the functionalities for the buttons from the public
    functions in it

    */



    //references of the gameobjects (panels) that hold other objects in them
    public GameObject Main; // main panel
    public GameObject options; // options panel
    public GameObject startMenu; // start menu panel
    public GameObject selectMenu; //select menu panel
    // a reference of the animator
    public Animator animations;
    // a reference of the audiosources of the buttons.
    public AudioSource buttonSFX;
    public AudioSource buttonSFX2;
    
    void Start()
    {
        
    }

    private void Update() {

    }

    // a function that pops up the options panel
    public void optionsPopUp(){
        StartCoroutine(optionsUp());
    }

    // a function that pops out the options panel
        public void optionsPopDown(){
        StartCoroutine(optionsDown());
    }
    // a function that pops up the start menu panel
    public void StartMenuPopUp(){
        StartCoroutine(startMenuUp());
    }
    //a function that pops out the start menu panel
        public void StartMenuPopDown(){
        StartCoroutine(startMenuDown());
    }
    //a function that pops up the select menu panel
    public void selectmenuPopUp(){
        StartCoroutine(levelselectIN());
    }
    // a function that pops out the select menu panel
        public void selectmenuPopDown(){
        StartCoroutine(levelselectOUT());
    }
    // a function that starts the level depending on the scene build index num
    public void startGame(int sceneNum){
        StartCoroutine(startCutScene(sceneNum));
    }
    // a function to quit the game 
    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator startCutScene(int sceneNum){
        //stuff to do
        //play animation
        // plays the animation of starting
        buttonSFX2.Play();
        animations.SetTrigger("isStart");


        //wait for animation to finish


        yield return new WaitForSeconds(1.1f); // over here is the delay for the scene animation to finish

        // load the scene


        SceneManager.LoadScene(sceneNum);

    }


    //IEnumerator function for popping up the options panel
    private IEnumerator optionsUp(){
        // plays the button sound effect
        buttonSFX.Play();
        //triggers the animation that has the MainOut trigger name
        animations.SetTrigger("MainOUT");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the main panel
        Main.SetActive(false);
        //activating the options panel
        options.SetActive(true);
        //rescaling the options menu to be unseen
        options.transform.localScale = new Vector3(0f, 0f, 1f);
        // play the animation that has the optionsIN trigger
        animations.SetTrigger("optionsIN");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        // rescaling the options panel back to normal to be visible
        options.transform.localScale = new Vector3(1f, 1f, 1f);
        
    }

    //IEnumerator function for popping out the options panel
        private IEnumerator optionsDown(){
        //plays the button sound effect
        buttonSFX.Play();
        //sets the trigger of the animation optionsOut
        animations.SetTrigger("optionsOUT");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the options panel
        options.SetActive(false);
        //re-activating the menu panel
        Main.SetActive(true);
        //playing the animation that has the mainIN trigger
        animations.SetTrigger("MainIN");
        // wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        
    }

    //IEnumerator for the start menu pop up
    private IEnumerator startMenuUp(){
        // play the button sound effect
        buttonSFX.Play();
        //activating the animation that has the ManiOUT trigger
        animations.SetTrigger("MainOUT");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the main panel
        Main.SetActive(false);
        //activating the start menu panel
        startMenu.SetActive(true);
        //activating the animation that has the StartMenuIn trigger
        animations.SetTrigger("StartMenuIn");
        // wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
    }

    //IEnumerator for the start menu pop out
    private IEnumerator startMenuDown(){
        //play the button sound effect
        buttonSFX.Play();
        //activating the animation that has the startmenuout trigger
        animations.SetTrigger("StartMenuOut");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the startmenu panel
        startMenu.SetActive(false);
        //re-activating the main panel
        Main.SetActive(true);
        //activating the animation that has the mainin trigger
        animations.SetTrigger("MainIN");
    }

    //IEnumerator for the level select pop up
    private IEnumerator levelselectIN(){
        //play the button sound effect
        buttonSFX.Play();
        // activating the animation that has the trigger startmenuout
        animations.SetTrigger("StartMenuOut");
        //wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the start menu panel
        startMenu.SetActive(false);
        //activating the select menu panel
        selectMenu.SetActive(true);
        //activating the animation that has the trigger levelselectIN
        animations.SetTrigger("levelselectIN");
    }

    //IEnumerator for the level select pop out
    private IEnumerator levelselectOUT(){
        // play the button sound effects
        buttonSFX.Play();
        //activating the animation that has the levelselectout trigger
        animations.SetTrigger("levelselectOUT");
        //waiting for the animation to finish
        yield return new WaitForSeconds(0.5f);
        //de-activating the select menu panel
        selectMenu.SetActive(false);
        //activating the start menu panel
        startMenu.SetActive(true);
        // activating the animation that has the startmenuin trigger
        animations.SetTrigger("StartMenuIn");
    }
}
