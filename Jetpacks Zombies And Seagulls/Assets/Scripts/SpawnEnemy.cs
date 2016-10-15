using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public int enemyCount = 1;
    private Vector3 spawnPoint;
    List<GameObject> enemyList = new List<GameObject>();
    public static SpawnEnemy enemySpawnerReference;

	// Use this for initialization
	void Start ()
    {
        Spawn(enemyCount);       
	}

    void Awake()
    {
        if(enemySpawnerReference == null)
        {
            enemySpawnerReference = this;
        }
        else if (enemySpawnerReference != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Spawn(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; ++i)
        {
            spawnPoint.x = Random.Range(-25, 25);
            spawnPoint.z = Random.Range(-25, 25);
            GameObject tempEnemy = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.identity);
            tempEnemy.GetComponentInChildren<EnemyMovement>().Player = GameObject.FindWithTag("Player").transform;
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
}
