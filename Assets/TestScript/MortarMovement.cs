using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2f;
    public float firingPower = 8.0f;
    public Vector3 shootingPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.AddForce(shootingPos * 8f, ForceMode.VelocityChange);
    }
    void FixedUpdate()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (!(collision.gameObject.tag == "RedShip"))
        //{
            Destroy(gameObject);
       // }
    }
}
