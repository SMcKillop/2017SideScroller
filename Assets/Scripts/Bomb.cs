using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    //Bomb to kill the enemies, not player.


    public float blastZone = 5;
    public bool isActive = false;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }
 
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActive)
        {
            Throw();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null && !isActive)
        {
            GetPickedUp(player);
        }
        if (isActive && player == null)
        {
            Explode();
        }
    }

    public void Throw()
    {
        this.transform.parent = null;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5, 0);
        collider2D.enabled = true;
    }

    public void GetPickedUp(Player player)
    {
        Debug.Log("Got picked up");
        isActive = true;
        this.transform.parent = player.transform;
        transform.localScale = new Vector3(.1f, .1f);
        transform.localPosition = new Vector3(.2f, .2f);
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        collider2D.enabled = false;
    }

    public void Explode()
    {
       //get a reference to all enemies
       var enemies = FindObjectsOfType<Enemy>();
       foreach (var e in enemies)
        {
            // check if that enermy is within the blastZone.
            if (Vector3.Distance(this.transform.position, e.transform.position) < blastZone)
                {
                    //set the enemy to NOT active.
                    e.gameObject.SetActive(false);
                }
        }
            // So the bomb disappears once the player comes into contact with it.
            gameObject.SetActive(false);
    }
}
