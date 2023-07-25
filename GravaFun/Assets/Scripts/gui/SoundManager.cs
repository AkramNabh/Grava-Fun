using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    /*
    
    
    this script is for the sliders that control the sound system of the game in the options menu and in the pause panel
    
    
    */


    //a reference to the audio mixer

    /*
    audio mixer is a sound controller that combine multiple sound effects in a one controller, where a
    change in the controller will affect on all sound effects that are attached to this controller.
    */
    [SerializeField] AudioMixer mixer;
    //a reference to the SFX slider
    [SerializeField] Slider SFXslider;
    // a reference to the background music slider
    [SerializeField] Slider backgroundSlider;
    //strings that contain the reference names of the controllers in the mixers
    private string mixer_background = "BackgroundVol";
    private string mixer_SFX = "SFXVol";
    

    private void Awake() {
        /*
        unity sliders support mouse listener by default (built-in), the lines on the bottom listens for any change
        in the slyder value and pass it to the mixer, sliders can be fixed to change the minimum value and the maximum
        value, and the desired value gets passed to the function that is passed as a parameter in the AddListener function
        */
        SFXslider.onValueChanged.AddListener(setVolume);
        backgroundSlider.onValueChanged.AddListener(setVolumeBG);
    }

    /*
    both functions on the bottom work similarly, where they recieve a float value from the awake above, and it gets
    setto the mixer, with a simple calculation of the value, where in setFloat function, it takes 2 parameters,
    the first is the reference name of the controller in the mixer, and second, takes the value, and the value
    gets calculated to be on max = 0, and on minimum = -80, so change in the slider value will be changing smoothly
    instead of jumps and big differences with small changes in the slider.
    */
    private void setVolume(float vol){
        mixer.SetFloat(mixer_SFX, Mathf.Log10(vol) * 20);
    }
    private void setVolumeBG(float vol){
        mixer.SetFloat(mixer_background, Mathf.Log10(vol) * 20);
    }

}
