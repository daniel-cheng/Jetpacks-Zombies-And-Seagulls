using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public int enemyCount;
    public float thresholdPercent;  //Percent of total enemies left before spawning more
    int enemyThreshold;

    private Vector3 spawnPoint;
	public Vector2 enemyRange = new Vector2(100, 100);
    List<GameObject> enemyList = new List<GameObject>();

    public int safetyRadius;
    
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
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);

            spawnPoint.y = transform.position.y;
            do
            {
                spawnPoint.x = Random.Range(-enemyRange.x, enemyRange.y) + transform.position.x;
                spawnPoint.z = Random.Range(-enemyRange.x, enemyRange.y) + transform.position.z;
            }
            while (Vector3.Distance(spawnPoint, transform.position) < safetyRadius);
            
            GameObject tempEnemy = (GameObject)Instantiate(enemyPrefabs[enemyIndex], spawnPoint, Quaternion.identity);
            tempEnemy.GetComponentInChildren<EnemyMovement>().Player = GameObject.FindWithTag("Player").transform;
            tempEnemy.GetComponent<EnemyManager>().spawner = this;

            enemyList.Add(tempEnemy);
            //Debug.Log(tempEnemy.GetComponent<EnemyMovement>().Player.name);
        }
    }
    public void KillEnemies()
    {
        foreach(GameObject enemyRef in enemyList)
        {
            Destroy(enemyRef);
        }
        enemyList.Clear();
    }

    public void DespawnEnemy (GameObject despawn)
    {
        Debug.Log("Despawning Enemy (Spawner)");
        enemyList.Remove(despawn);
    }

    void OnDestroy()
    {
        KillEnemies();
    }
}
