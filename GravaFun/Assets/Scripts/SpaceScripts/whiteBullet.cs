using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteBullet : MonoBehaviour
{

    /*
    
    this script is for the bubbles object, that are shot from the player's gun

    */


    //a reference to the gun object
    private GameObject gun;
    // a reference to an object that will be used to get the bullet direction
    private GameObject bulletDir;
    //a reference to the bubble rigidbody
    private Rigidbody2D bullet;
    // a float to handle the bullet speed
    private float bulletSpeed;


private void OnCollisionEnter2D(Collision2D other) {
    // destroying the bubble if it collides with an enemy or the planet
                if(other.gameObject.CompareTag("Alien") || other.gameObject.CompareTag("planet")){
            Destroy(gameObject);
        }
}
    void Start()
    {
        // capturing the gun object reference
        gun = GameObject.FindGameObjectWithTag("Space Gun");
        // retrieving the bulletspeed from the gunscript attached to the gun
        bulletSpeed = gun.GetComponent<GunScript>().bulletSpeed;
        // captures the reference of the object that will act like a bullet direction
        bulletDir = GameObject.FindGameObjectWithTag("Bullet-Dir");
        // captures the bullet rigidbody
        bullet = GetComponent<Rigidbody2D>();
        // calculates the direction between the bullet and the bullet direction object
        Vector3 direction = bulletDir.transform.position - transform.position;
        // gives the bullet velocity that has a vector2 of the direction to the buller direction * the bullet speed
        bullet.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        // fixes the roation of the bullet to aim towards the bullet direction object
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the bullet reaches to the bullet direction object, it gets destroyed
        if(transform.position == bulletDir.transform.position){
            Destroy(gameObject);
        }
    }
}
