using UnityEngine;
using System.Collections;

public class FlyingMovement : MonoBehaviour {

    public Vector3[] waypoints;
    private int waypointIndex = 0;
    public float speed = 5;
    new Rigidbody2D rigidbody;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex], Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < .2f)
        {
            waypointIndex++;
            waypointIndex = waypointIndex % waypoints.Length;
        }

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

    }
}
