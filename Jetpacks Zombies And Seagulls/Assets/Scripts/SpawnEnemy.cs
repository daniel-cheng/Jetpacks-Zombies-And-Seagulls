﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public int enemyCount;
    private GameObject enemyParent;
    //public float thresholdPercent;  //Percent of total enemies left before spawning more
    //int enemyThreshold;
    public Vector2 enemyRange = new Vector2(100, 100);
    List<GameObject> enemyList = new List<GameObject>();

    public int soundsNum;
    List<int> soundPlayerIndexes = new List<int>();

    public int safetyRadius;

    private Vector3 spawnPoint;
    Vector3 GetSpawnPoint ()
    {
        spawnPoint.y = transform.position.y;
        do
        {
            spawnPoint.x = Random.Range(-enemyRange.x, enemyRange.y) + transform.position.x;
            spawnPoint.z = Random.Range(-enemyRange.x, enemyRange.y) + transform.position.z;
        }
        while (Vector3.Distance(spawnPoint, transform.position) < safetyRadius);

        return spawnPoint;
    }
	
	void Start ()
    {
        enemyParent = new GameObject();
        enemyParent.name = "Enemy Parent Object";

        Spawn(enemyCount);
        //enemyThreshold = (int) (enemyCount * thresholdPercent);
	}

    public void Spawn(int enemyNumber)
    {
        for (int a = 0; a < soundsNum; a++)
        {
            soundPlayerIndexes.Add(Random.Range(0, enemyNumber));
        }

        for (int i = 0; i < enemyNumber; ++i)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            
            if (enemyParent == null)
            {
                Debug.Log("No enemy parent found for enemy #" + i.ToString());
            }

            GameObject tempEnemy = (GameObject)Instantiate(enemyPrefabs[enemyIndex], GetSpawnPoint(), Quaternion.identity,  enemyParent.transform);
            //tempEnemy.GetComponentInChildren<EnemyMovement>().Player = GameObject.FindWithTag("Player").transform;
            tempEnemy.GetComponent<EnemyManager>().spawner = this;

            if (soundPlayerIndexes.Contains(i))
            {
                tempEnemy.GetComponent<EnemyManager>().soundPlayer = true;
            }

            enemyList.Add(tempEnemy);
            //Debug.Log(tempEnemy.GetComponent<EnemyMovement>().Player.name);
        }
    }
    public void KillEnemies()
    {
        Destroy(enemyParent);
        enemyList.Clear();
        soundPlayerIndexes.Clear();
    }

    public void RepositionEnemy(GameObject reposEnemy, bool onGround)
    {
        //Debug.Log("Repositioning Enemy (Spawner)");
        Vector3 tempSpawn = GetSpawnPoint();
        if (onGround)
        {
            tempSpawn.y = reposEnemy.transform.position.y;
        }
        reposEnemy.transform.position = tempSpawn;
    }

    void OnDestroy()
    {
        KillEnemies();
    }
}
