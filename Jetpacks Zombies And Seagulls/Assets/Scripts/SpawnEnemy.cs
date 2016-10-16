using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public int enemyCount;
    public float thresholdPercent;  //Percent of total enemies left before spawning more
    int enemyThreshold;

    private Vector3 spawnPoint;
	public Vector2 enemyRange = new Vector2(100, 100);
    List<GameObject> enemyList = new List<GameObject>();
    
	void Start ()
    {
        Spawn(enemyCount);
        enemyThreshold = (int) (enemyCount * thresholdPercent);
	}

    void Update ()
    {
        if (enemyList.Count < enemyThreshold)
        {
            Spawn(enemyCount - enemyList.Count);
        }
    }

    public void Spawn(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; ++i)
        {
			spawnPoint.x = Random.Range(-enemyRange.x, enemyRange.y);
			spawnPoint.z = Random.Range(-enemyRange.x, enemyRange.y);
            GameObject tempEnemy = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.identity);
            tempEnemy.GetComponentInChildren<EnemyMovement>().Player = GameObject.FindWithTag("Player").transform;
            tempEnemy.GetComponent<EnemyManager>().spawner = this;

            enemyList.Add(tempEnemy);
            //Debug.Log(tempEnemy.GetComponent<EnemyMovement>().Player.name);
        }
    }
    public void KillEnemies()
    {
		Debug.Log (enemyList);
        foreach(GameObject enemyRef in enemyList)
        {
            Destroy(enemyRef);
        }
        enemyList.Clear();
    }

    public void DespawnEnemy (GameObject despawn)
    {
        enemyList.Remove(despawn);
    }
}
