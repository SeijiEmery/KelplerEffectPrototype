using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        GameObject[] subs = GameObject.FindGameObjectsWithTag("Sub");
        GameObject[] crabs = GameObject.FindGameObjectsWithTag("Crab");

        foreach (GameObject sub in subs)
        {
            Physics.IgnoreCollision(sub.GetComponent<Collider>(), GetComponent<Collider>());
        }
        foreach (GameObject crab in crabs)
        {
            Physics.IgnoreCollision(crab.GetComponent<Collider>(), GetComponent<Collider>());
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
