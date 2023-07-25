using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endGame : MonoBehaviour
{

    /*
    
    
    this script is for the last scene after completing the space level, it will show the credits of my work on it

    
    */



    //a reference to the panel that will hold the texts inside of it
    public GameObject panel;
    // a reference to the animator that has the boy, girl, ESC to exit, panel opening animation
    private Animator EndAnimation;

    //a reference to the animator that has the texts switching animation.
    private Animator EndAnimation2;

    void Start()
    {
        // capturing the animators from the objects
        EndAnimation = GetComponent<Animator>();
        EndAnimation2 = panel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //start the coroutine function animationActivator.
        StartCoroutine(animationActivator());
        //a key listener to get back to the start menu
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }


    IEnumerator animationActivator(){
        //a delay to wait for the starting animation to finish
        yield return new WaitForSeconds(0.8f);
        //activating the trigger for the first animator 
        EndAnimation.SetTrigger("Activator");
        //activating the trigger for the second animator
        EndAnimation2.SetTrigger("activator");

    }
}
