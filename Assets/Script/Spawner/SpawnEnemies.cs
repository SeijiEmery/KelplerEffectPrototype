using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject theEnemy;
    public float xPos;
    public float yPos;
    public float zPos;
    public int enemyCount;
    public int totalEnemies = 5;
    public float spawnTimer;

    void Start() {
            xPos = Random.Range(2.0f,2.3f);
            yPos = Random.Range(-1.1f,0.8f);
            zPos = Random.Range(-2.5f,-1.1f);
            Instantiate(theEnemy, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            enemyCount += 1;
            spawnTimer = 3;
    }

    void Update(){
        if (spawnTimer > 0) {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0) {
            xPos = Random.Range(2.0f,2.3f);
            yPos = Random.Range(-1.1f,0.8f);
            zPos = Random.Range(-2.5f,-1.1f);
            Instantiate(theEnemy, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            enemyCount += 1;
            spawnTimer = 5;

        }
    }
}