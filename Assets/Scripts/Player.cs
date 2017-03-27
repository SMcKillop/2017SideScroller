using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 100;

    new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(x, 0);
	}
}
