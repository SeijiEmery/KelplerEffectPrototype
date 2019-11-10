﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTestController : MonoBehaviour
{
    public float speed = 6.0f;                                      //Set speed
    public float bulletSpeed = 2.0f;
    public float cooldown_in_seconds = 2.0f;            //Set firing rate by cooldown
    public enum bulletType { regular, laser };            //Set bullet type
    public bulletType BulletType = bulletType.regular;
    public GameObject regularBullet;
    public GameObject laserBullet;

    private float shootingGap = 0f;
    void Start()
    {

    }
    void FixedUpdate()
    {
        //Simple moving
        var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.up * Input.GetAxis("MoveY") + Vector3.right * Input.GetAxis("MoveX");
        transform.Translate(movement * speed * Time.deltaTime);

        //Start shooting if time gap is enough.
        if (shootingGap < cooldown_in_seconds)
        {
            shootingGap += Time.deltaTime;
        }
        else
        {
            shootingGap = 0f;
            //Shoot
            if (BulletType == bulletType.regular)
            {
                var clone = Instantiate(regularBullet, transform.position + new Vector3(0.8f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, -90f)));
                clone.GetComponent<ProjectileMovement>().speed = bulletSpeed;
            }
            if (BulletType == bulletType.laser)
            {
                var clone = Instantiate(laserBullet, transform.position + new Vector3(1.2f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, -90f)));
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
