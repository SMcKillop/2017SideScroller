using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enabled)
        {
            return;
        }

        var player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.GetOut();
        }

    }
}
