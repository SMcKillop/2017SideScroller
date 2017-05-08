using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    //VARIABLES
    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -6;
    public bool canFly = false;

    public Weapon currentWeapon;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;
    private List<Weapon> weapons = new List<Weapon>();

    private Animator anim;
    private SpriteRenderer sr;
    public bool air;
    //END OF VARIABLES


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

   // Running animation in direction player is going
        if (v.x > 0)
        {
            sr.flipX = false;
        }
        else if (v.x < 0)
        {
            sr.flipX = true;
        }

       

    //Space bar control jumping
        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly))
        {
            v.y = jumpSpeed; 
        }

        rigidbody.velocity = v;
   //Jumping Animation
        if (v.y !=0)
        {
            anim.SetBool("air", true);
        }
        else
        {
            anim.SetBool("air", false);
        }

        // Attack with a weapon if you have one.
        if (Input.GetKeyDown(KeyCode.X) && currentWeapon != null)
        {
            currentWeapon.Attack();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }
        //Check for Out
        if (transform.position.y < deadZone)
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

    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }

    public void SetCurrentWeapon(Weapon w)
    {
        if(currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = w;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.GetPickedUp(this);
        }
        //HeatSeeking thing
        var stalker = coll.gameObject.GetComponent<HeatSeeking>();
        if (stalker != null)
        {
            stalker.Die();
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        air = true;

        //This is for the moving platform
        if (col.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

  void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.CompareTag("Coin"))
        {
            Destroy(coll.gameObject);
        }
    }
   
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }

    }


}
