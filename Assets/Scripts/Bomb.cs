using UnityEngine;
using System.Collections;

public class Bomb : Weapon {
    //Bomb to kill the enemies, not player.


    public float blastZone = 5;
    public bool isActive = false;

    
 
    private void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
       
        if (isActive && player == null)
        {
            Explode();
        }
    }

    
    public override void Attack()
    {
        this.transform.parent = null;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5, 0);
        collider2D.enabled = true;
    }

    public override void GetPickedUp(Player player)
    {
        if (isActive)
        {
            return;
        }
        isActive = true;
        base.GetPickedUp(player);
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
