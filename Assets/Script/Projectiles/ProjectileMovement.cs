using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls projectile movement
// Damage + triggering is applied by DamageTrigger.cs
// TODO: implement this
public class ProjectileMovement : MonoBehaviour
{
    public float speed = 2f;
    public bool destroySelfAfterTimeout = false;
    public bool destroySelfOnFirstCollision = false;
    public float timeoutLifetime = 10f;

    private float destroyTime;

    void Start()
    {
        destroyTime = Time.time + timeoutLifetime;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(destroySelfAfterTimeout && destroyTime <= Time.time)
            this.Destroy();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(destroySelfOnFirstCollision)
            this.Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
