using UnityEngine;
using System.Collections;

public class Throwable : Weapon {

    public bool isActive = false;

    
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
}
