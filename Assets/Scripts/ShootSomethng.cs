using UnityEngine;
using System.Collections;

public class ShootSomethng : MonoBehaviour
{

    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(.4f, .1f);
    public float coolDown = 5;

    //Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canShoot)
        {
            GameObject gameObject = (GameObject) Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x , velocity.y);

        }
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
