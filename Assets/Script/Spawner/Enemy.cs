using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour {
	public float xSpeed;
	public float ySpeed;
	public float zSpeed;
	public float divider;
	System.Random rand = new System.Random();

	void Start() {
	//Randomly Assigned MoveSpeed in x direction
	xSpeed = Mathf.Ceil(rand.Next(4));
	divider = rand.Next(4) + 1;
	}

	void Update() {
		transform.Translate(0f,0f,-(int)xSpeed*Time.deltaTime / (int)divider);
	}
}