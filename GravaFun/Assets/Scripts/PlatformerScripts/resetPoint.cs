using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.position = spawnPoint;
        }
    }


    public GameObject spawnPointObj;
    private Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = spawnPointObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
