using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {


    public Rigidbody2D rb;
    public Vector2 velocity;
    

	// Use this for initialization
	void Start ()
    {
        
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }
	
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        rb.velocity = new Vector2(velocity.x, -velocity.y);
        var enemy = col.gameObject.GetComponent<Enemy>();


        if (col.collider.tag =="deadly")
        {
            Destroy(col.gameObject);
            Explode();
        }

        if (col.contacts[0].normal.x != 0)
        {
            Explode();
        }

    }

    void Explode()
    {
        

    }

}
