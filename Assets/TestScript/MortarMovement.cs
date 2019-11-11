using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMovement : MonoBehaviour
{
    [SerializeField]
    private float timeoutLifetime = 10f;
    [SerializeField]
    private bool destroySelfAfterTimeout = false, destroySelfOnCollision = false;

    //Those would be called by Crab
    public float speed = 2f;
    public float firingPower = 8.0f;
    public Vector3 shootingPos;

    private float destroyTime;
    Rigidbody rb;

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
        if (destroySelfOnCollision)
            this.Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
