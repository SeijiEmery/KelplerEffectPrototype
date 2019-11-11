using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabTestController : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f, bulletSpeed = 2.0f, rotateSpeed = 2.0f, barrelSpeed = 1.0f, firingPower = 8.0f, cooldown_in_seconds = 2.0f;
    [SerializeField]
    private GameObject MortarShell, barrel;
    
    private Transform barreltf;
    private float shootingGap = 0f;
    void Start()
    {
        barreltf = barrel.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        //Simple moving
        var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.right * Input.GetAxis("MoveX");
        transform.Translate(movement * speed * Time.fixedDeltaTime, Space.World);

        //Simple Rotation
        transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("TurnHorizontal"), Space.Self);

        //Barrel angle adjustment
        if (barreltf.localRotation.eulerAngles.z >= 60f && barreltf.localRotation.eulerAngles.z <= 210f)
            barreltf.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 60f));
        else if (barreltf.localRotation.eulerAngles.z > 210f && barreltf.localRotation.eulerAngles.z < 360f)
            barreltf.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        barreltf.Rotate(Vector3.forward * barrelSpeed * Input.GetAxis("MoveY"), Space.Self);

            //Start shooting if time gap is enough.
            if (shootingGap < cooldown_in_seconds)
        {
            shootingGap += Time.fixedDeltaTime;
        }
        else
        {
            shootingGap = 0f;
            //Shoot
            var clone = Instantiate(MortarShell, barreltf.position + 0.5f * barreltf.right, Quaternion.Euler(1,1,1));
            clone.GetComponent<MortarMovement>().speed = bulletSpeed;
            clone.GetComponent<MortarMovement>().firingPower = firingPower;
            clone.GetComponent<MortarMovement>().shootingPos = barreltf.right;
        }

    }
}
