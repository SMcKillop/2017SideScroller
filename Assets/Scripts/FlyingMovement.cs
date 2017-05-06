using UnityEngine;
using System.Collections;

public class FlyingMovement : MonoBehaviour {

    public Vector3[] waypoints;
    private int waypointIndex = 0;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex], Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex]) < .2f)
        {
            waypointIndex++;
            waypointIndex = waypointIndex % waypoints.Length;
        }
    }
}
