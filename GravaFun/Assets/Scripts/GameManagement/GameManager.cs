using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   
    /*
    
    
    this is the script that holds the functions that switch between scenes, and play the transition animation

    

    quick info:-

    unity manages the scenes in two ways:-
    1- after adding the scene to the build, it will give it a reference number (build index number), and using this 
    number it is more accurate to switch to the right scenes without any errors
    2- referring to the scene with its name, since the name of the scene is saved as a string data of the scene,
    it can be used for such purposes.
    
    but method 1 is much more accurate and effecient for the compiler to compile
    */


    //reference to the animator that holds the transition animations
    public Animator transition;

    // delay that will be used later on
    public float transitionDuration = 1f;

    //a variable to save the scene number for later uses
    public int SceneNum;
    void Update()
    {
       
    }


    // a function for starting the coroutine function loadLevel
    public void loadNextLevel(){
        StartCoroutine(loadLevel(SceneNum));
    }


    //a function that will restart the level when activate it
    public void loadSameLevel(){
        // capturing reference tothe pause panel 
        GameObject.FindGameObjectWithTag("Panel").SetActive(false);
        //returning the timescale to 1f.
        Time.timeScale = 1f;
        //start the loadlevel coroutine and passing the current scene build index to its parameter
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator loadLevel(int levelIndex){
        
        //stuff to do
        //play animation
        // plays the animation of starting
        transition.SetTrigger("Start");


        //wait for animation to finish


        yield return new WaitForSeconds(transitionDuration); // over here is the delay for the scene animation to finish

        // load the scene


        SceneManager.LoadScene(levelIndex);
    }

}
