using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{

    /*
    
    this script is for loading the sound to in any furthur scene, saying you change volumes in scene 1,
    the changes will be passed to scene or any other scene.
    
    */


    // creating a static instance of the soundloader script
    public static SoundLoader instance;
private void Awake() {
    /*
    
    what happens in this block of code, awake function gets called similar to start, the way it works, it will
    istantiate the script, create an instance of it, and save it as a static, a new scene is loaded,
    it will check if the instance == null, it will save the static instance to itself again,
    and the object will not be destroyed, and on the else, it is for when the first time this script gets run,
    after it is used it will be destroyed automatically.
    
    */
    if(instance == null){
        instance = this;
        DontDestroyOnLoad(gameObject);
    } else {
        Destroy(gameObject);
    }
    
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
