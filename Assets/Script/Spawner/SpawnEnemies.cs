using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject theEnemy;
	public int xPos;
	public int yPos;
	public int zPos;
	public int enemyCount;

	void Start() {
		while (enemyCount < 10)
		{
			xPos = Random.Range(1,5);
			yPos = Random.Range(0,1);
			zPos = Random.Range(1, 6);
			Instantiate(theEnemy, new Vector3(xPos,yPos,zPos), Quaternion.identity);
			enemyCount += 1;
		}

	}

	void Update(){
	}
}