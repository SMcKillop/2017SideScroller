using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -6;
    public bool canFly = false;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    private Animator anim;
    private SpriteRenderer sr;
    public bool air;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        air = true;
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
     //Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        //rigidbody.velocity = new Vector2(x * speed, rigidbody.velocity.y);
        Vector2 v = rigidbody.velocity;
        v.x = x * speed; 

        //Running animation
        if(v.x != 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (v.x > 0)
            sr.flipX = false;
        else if (v.x < 0)
            sr.flipX = true;

        //Jumping Animation
        if (air)
        {
            anim.SetBool("air", true);
        }
        else
        {
            anim.SetBool("air", false);
        }

        //Space bar control jumping
        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly))
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

    public void powerup()
    {
        anim.SetTrigger("powered");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        air = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        air = true;
    }
   
}
