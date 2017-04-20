﻿using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    //Bomb to kill the enemies, not player.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach(var e in enemies)
            {
                if(Vector3.Distance(this.transform.position, e.transform.position) < 10)
                {
                    e.gameObject.SetActive(false);
                }
            }
        }

    }
}
