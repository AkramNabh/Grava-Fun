using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{


    /*
    
    this script is for the pause menu that would show up while in-game with the ESC button
    
    */


    //a reference of the pause panel object
    public GameObject PausePanel;
    // a bool that will be used later on
    public bool isActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // a key listener for the ESC button
        if(Input.GetKeyDown(KeyCode.Escape)){
        // checks if the panel is not active
        if(!PausePanel.activeSelf){
            //activated the panel
            PausePanel.SetActive(true);
            //pauses the local time of the game
            // 0 is stop and 1 is run
            Time.timeScale = 0;
        }else{
            //if panel is active and ESC key is pressed, it de-activates the panel
            PausePanel.SetActive(false);
           //makes local time back to 1 
            Time.timeScale = 1;
    
        }


        }
    }


    // functions for the buttons in the panel


    //a function for the resume button
    public void Resume(){
        //de-activates the panel
        PausePanel.SetActive(false);
        //sets the bool to false
        isActive = false;
        //sets the time scale to 1
        Time.timeScale = 1;
    }

    //the function for quitting the game button
    public void Quit(){
        //quits the application
        Application.Quit();
    }

    //the function for going back to the start menu
    public void LoadMenu(){
        // loads the scene with the build index value
         SceneManager.LoadScene(0);
         //returns the timescale to 1
         Time.timeScale = 1f;
    }
}
