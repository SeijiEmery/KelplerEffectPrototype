using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour {
    public float speed;
    public GameObject enemy;
    private float xSpeed;
    private float divider;
    System.Random rand = new System.Random();

    void Start() {
    //Randomly Assigned MoveSpeed in x direction
    xSpeed = Mathf.Ceil(rand.Next(3) + 1);
    divider = rand.Next(8) + 2;
    speed = -(int)xSpeed*Time.deltaTime / (int)divider;
    }

    void Update() {
        transform.Translate(speed,0f,0f);
        if (enemy.transform.position.x <= -5.8) {
            Destroy(enemy);
        }
    }
}