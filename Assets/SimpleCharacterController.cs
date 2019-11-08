using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 6.0f;                                      //Set speed
    public float bulletSpeed = 2.0f;
    public float cooldown_in_seconds = 2.0f;            //Set firing rate by cooldown
    public enum bulletType { regular, laser };            //Set bullet type
    public bulletType BulletType = bulletType.regular;
    public GameObject regularBullet;
    public GameObject laserBullet;

    private Vector3 moveDirection = Vector3.zero;
    private float shootingGap = 0f;
    void Start()
    {

    }
    void FixedUpdate()
    {
        //Simple moving
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        moveDirection *= speed;
        transform.Translate(moveDirection * Time.deltaTime);
        
        //Start shooting if time gap is enough.
        if (shootingGap < cooldown_in_seconds)
        {
            shootingGap += Time.deltaTime;
        }
        else
        {
            shootingGap = 0f;
            //Shoot
            if(BulletType == bulletType.regular){
                var clone = Instantiate(regularBullet, transform.position+new Vector3(0.8f,0f,0f), Quaternion.Euler(new Vector3 (0f,0f,-90f)));
                //Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());
                clone.GetComponent<BulletMovement>().speed = bulletSpeed;
            }
            if (BulletType == bulletType.laser)
            {
                var clone = Instantiate(laserBullet, transform.position + new Vector3(1.2f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, -90f)));
                //Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());
                clone.GetComponent<BulletMovement>().speed = bulletSpeed;
            }
        }

    }
}
