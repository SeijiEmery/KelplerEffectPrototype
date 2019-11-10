using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2f;
    public float firingPower = 8.0f;
    public Vector3 shootingPos;
    public bool destroySelfAfterTimeout = false;
    public bool destroySelfOnFirstCollision = false;
    public float timeoutLifetime = 10f;

    private float destroyTime;

    void Start()
    {
        destroyTime = Time.time + timeoutLifetime;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(shootingPos * 8f, ForceMode.VelocityChange);
    }
    void FixedUpdate()
    {
        if (destroySelfAfterTimeout && destroyTime <= Time.time)
            this.Destroy();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (destroySelfOnFirstCollision)
            this.Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
