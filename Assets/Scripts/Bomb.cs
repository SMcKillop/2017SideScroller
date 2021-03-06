﻿using UnityEngine;
using System.Collections;

public class Bomb : Throwable {
    //Bomb to kill the enemies, not player.


    public float blastZone = 5;
    

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
