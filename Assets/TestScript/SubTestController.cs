using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTestController : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f, bulletSpeed = 2.0f, cooldown_in_seconds = 2.0f;
    [SerializeField]
    private GameObject regularBullet, laserBullet;

    public enum bulletType { regular, laser };            
    public bulletType BulletType = bulletType.regular;
    public Transform firePoint;

    private float shootingGap = 0f;
    void Start()
    {

    }
    void FixedUpdate()
    {
        //Simple moving
        var movement = Vector3.forward * Input.GetAxis("MoveX") + Vector3.up * Input.GetAxis("MoveY") + Vector3.right * -Input.GetAxis("MoveZ");
        transform.Translate(movement * speed * Time.fixedDeltaTime);

        //Start shooting if time gap is enough.
        if (shootingGap < cooldown_in_seconds)
        {
            shootingGap += Time.fixedDeltaTime;
        }
        else
        {
            shootingGap = 0f;
            //Shoot
            if (BulletType == bulletType.regular)
            {
                var clone = Instantiate(regularBullet, firePoint.position, firePoint.rotation);
                clone.GetComponent<ProjectileMovement>().speed = bulletSpeed;
            }
            if (BulletType == bulletType.laser)
            {
                var clone = Instantiate(laserBullet, firePoint.position, firePoint.rotation);
                clone.GetComponent<ProjectileMovement>().speed = bulletSpeed;
            }
        }

    }
    void OnCollisionExit(Collision other)
    {
        //Solving weird velocity upwards when pressed to the ground and moved a bit, but still glitchy (Sub could dive pass the ground sometimes)
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
