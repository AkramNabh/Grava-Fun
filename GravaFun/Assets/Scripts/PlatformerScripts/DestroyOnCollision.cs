using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*

this script is for the boulder that collides with the box that gets destoryed in level 1

*/

public class DestroyOnCollision : MonoBehaviour
{

    public int ticks = 5; // a counter
    private SpriteRenderer spRender; // sprite renderer reference 

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Destroyable"){ //comparing the object tag on the collision to work perfectly
                    this.gameObject.GetComponent<CircleCollider2D>().enabled = false; // disabling the collider of the object
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; // sitting the rigidbody type to static
    StartCoroutine(Fader());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spRender = GetComponent<SpriteRenderer>(); //capturing the reference of the sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Fader() // another fader function with type ienumerator
    {
        Color originalColor = spRender.color;
        float t = 0f;
        while(t < ticks){
            t += Time.deltaTime;
            float normalizedTime = t / ticks;
            spRender.color = Color.Lerp(originalColor, Color.clear, normalizedTime);
            yield return null;
        }
        Destroy(this.gameObject); // ends with destroying the object
    }
}
