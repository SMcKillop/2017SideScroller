using UnityEngine;
using System.Collections;


public class StunGrenade : Throwable {
    //Bomb to kill the enemies, not player.


    public float blastZone = 5;
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
       
        if (isActive && player == null)
        {
            Explode();
        }
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
              StartCoroutine(Stun(e));
           }
        }
        // So the bomb disappears once the player comes into contact with it.
        collider2D.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Stun(Enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>();

        e.enabled = false;
        renderer.color = new Color(1, 1, 1, .4f);
        yield return new WaitForSeconds(5);
        
        e.enabled = true;
        renderer.color = new Color(1, 1, 1, 1);
    }
}
