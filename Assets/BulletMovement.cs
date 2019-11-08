using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        GameObject[] redShips = GameObject.FindGameObjectsWithTag("RedShip");
        foreach (GameObject redship in redShips)
        {
            Physics.IgnoreCollision(redship.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (!(collision.gameObject.tag == "RedShip"))
        //{
            Destroy(gameObject);
       // }
    }
}
