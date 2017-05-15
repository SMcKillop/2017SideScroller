using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

    public Transform warpTarget;

    public Transform WarpTarget
    {
        get
        {
            return warpTarget;
        }

        set
        {
            warpTarget = value;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("An object collided");
        
         other.gameObject.transform.position = WarpTarget.transform.position;
        
        
        
    }
    
}
