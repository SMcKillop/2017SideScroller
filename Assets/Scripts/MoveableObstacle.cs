using UnityEngine;
using System.Collections;

public class MoveableObstacle : MonoBehaviour {

    //THIS IS THE MOVABLE PLATFORM

    public GameObject Platform;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointsSelection;


	// Use this for initialization
	void Start ()
    {
        currentPoint = points[pointsSelection];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if (Platform.transform.position == currentPoint.position)
        {
            pointsSelection++;
            if (pointsSelection == points.Length)
            {
                pointsSelection = 0;
            }
        }

        currentPoint = points[pointsSelection];
	
	}
}
