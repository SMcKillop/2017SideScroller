using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -6;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
     //Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        //rigidbody.velocity = new Vector2(x * speed, rigidbody.velocity.y);
        Vector2 v = rigidbody.velocity;
        v.x = x * speed; 

        if (Input.GetButtonDown("Jump"))
        {
            v.y = jumpSpeed; 
        }

        rigidbody.velocity = v;

    //Check for Out
        if(transform.position.y < deadZone)
        {
            Debug.Log("Current Position " + transform.position.y + "is lower than " + deadZone);
            GetOut();
        }
    
        //rigidbody.AddForce(new Vector2(x * speed, 0));
	}

    public void GetOut()
    {
        _GM.SetLives(_GM.GetLives() - 1);
        transform.position = startingPosition;
        Debug.Log("You are out!");
    }
   
}
