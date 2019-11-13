// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// 
// public class FriendlySubController : SubController
// {
//                                  
//     [SerializeField]
//     private GameObject regularBullet, laserBullet;
// 
//     public enum bulletType { regular, laser };            
//     public bulletType BulletType = bulletType.regular;
// 
//     private float shootingGap = 0f;
// 
//     void FixedUpdate()
//     {
//         //Simple moving
// 
// 
//         //Start shooting if time gap is enough.
//         if (shootingGap < cooldown_in_seconds)
//         {
//             shootingGap += Time.fixedDeltaTime;
//         }
//         else
//         {
//             shootingGap = 0f;
//             //Shoot
//             if (BulletType == bulletType.regular)
//             {
//                 var clone = Instantiate(regularBullet, transform.position + new Vector3(0.8f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, -90f)));
//                 clone.GetComponent<ProjectileMovement>().speed = bulletSpeed;
//             }
//             if (BulletType == bulletType.laser)
//             {
//                 var clone = Instantiate(laserBullet, transform.position + new Vector3(1.2f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, -90f)));
//                 clone.GetComponent<ProjectileMovement>().speed = bulletSpeed;
//             }
//         }
// 
//     }
//     void OnCollisionExit(Collision other)
//     {
//         //Solving weird velocity upwards when pressed to the ground and moved a bit, but still glitchy (Sub could dive pass the ground sometimes)
//         GetComponent<Rigidbody>().velocity = Vector3.zero;
//     }
// }
