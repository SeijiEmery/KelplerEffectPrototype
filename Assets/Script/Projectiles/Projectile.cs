using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls projectile movement
// Damage + triggering is applied by DamageTrigger.cs
// TODO: implement this
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float timeoutLifetime = 10f;
    [SerializeField]
    private bool destroySelfAfterTimeout = false, destroySelfOnCollision = false;

    //Those would be called by Sub
    public float speed = 2f;

	public Vector3 direction { get; set; }

    private float destroyTime;

    void Start()
    {
        destroyTime = Time.time + timeoutLifetime;
    }
    void FixedUpdate()
    {
		transform.Translate(direction * Time.fixedDeltaTime * speed);
		if (destroySelfAfterTimeout && destroyTime <= Time.time)
            this.Destroy();
    }
    void OnCollisionEnter(Collision collision)
    {
		collision.gameObject.GetComponentInChildren<Health>()?.AddHealth(-10f);

		if (destroySelfOnCollision)
				this.Destroy();
	}
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
