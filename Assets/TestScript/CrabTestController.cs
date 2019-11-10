using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabTestController : MonoBehaviour
{
    public float speed = 6.0f;                                      //Set speed
    public float bulletSpeed = 2.0f;
    public float rotateSpeed = 2.0f;
    public float barrelSpeed = 1.0f;
    public float firingPower = 8.0f;                             //Set firing power
    public float cooldown_in_seconds = 2.0f;            //Set firing rate by cooldown
    public GameObject MortarShell;                          //Bullet type is mortar
    private GameObject barrel;                                   //Crab Mortar Barrel tracking aim
    private Transform barreltf;
    private float shootingGap = 0f;
    void Start()
    {
        barrel = this.transform.Find("Barrel").gameObject;
        barreltf = barrel.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        //Simple moving
        var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.right * Input.GetAxis("MoveX");
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.down * rotateSpeed, Space.Self);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * rotateSpeed, Space.Self);
        /*if (Input.GetKey(KeyCode.Tab))
        {
            if(barreltf.localRotation.eulerAngles.x <= 300f && barreltf.localRotation.eulerAngles.x > 0f)
            {
                barreltf.localRotation = Quaternion.Euler(new Vector3(-60f,0f, 0f));
            }
            else
                barreltf.Rotate(Vector3.left * barrelSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (barreltf.localRotation.eulerAngles.x >= 0f && barreltf.localRotation.eulerAngles.x<300)
            {
                barreltf.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
            else
                barreltf.Rotate(Vector3.right, Space.Self);
        }*/


        //Start shooting if time gap is enough.
        if (shootingGap < cooldown_in_seconds)
        {
            shootingGap += Time.deltaTime;
        }
        else
        {
            shootingGap = 0f;
            //Shoot
            var clone = Instantiate(MortarShell, barreltf.position + 0.5f * barreltf.forward, Quaternion.Euler(1,1,1));
            clone.GetComponent<MortarMovement>().speed = bulletSpeed;
            clone.GetComponent<MortarMovement>().firingPower = firingPower;
            clone.GetComponent<MortarMovement>().shootingPos = barreltf.forward;
        }

    }
    void OnCollisionExit(Collision other)
    {
        //Solving weird velocity upwards when pressed to the ground and moved a bit, but still glitchy
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
