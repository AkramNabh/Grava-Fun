using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{


    /*
    this script is for the ballons that are shot from the enemy in the space level
    */


    // a reference of the player object
    private GameObject player;
    //a reference of the bullet rigidbody prefab
    private Rigidbody2D bulletBody;
    // a float to determine the speed of the bullet
    public float bulletSpeed;

    private void OnCollisionEnter2D(Collision2D other) {
        // to make the bullet object get destroyed when it collides with anything
        Destroy(gameObject);
    }
    void Start()
    {
        // capturing the reference of the player object
        player = GameObject.FindGameObjectWithTag("Player");
        // capturing the rigidbody reference of the bullet
        bulletBody = GetComponent<Rigidbody2D>();
        // create a vector3 type of the distance  between the bullet and the player on instantiation
        Vector3 direction = player.transform.position - transform.position;
        // adds velocity to the bullet rigidbody as a normalized vector2 * by the determined bullet speed
        bulletBody.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        // creating a float that will calculate the rotation of the bullet to aim towards the player
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        // saves the rotation value to the rotation variable of the object
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
