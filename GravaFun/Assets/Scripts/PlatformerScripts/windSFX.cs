using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windSFX : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private bool isActive;
    public AudioSource sfx;
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     isActive = boxCol.enabled;
     if(isActive){
        sfx.enabled = true;
     }   
    }
}
