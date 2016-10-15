using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public int enemyCount = 1;
    private Vector3 spawnPoint;
    List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        Spawn(enemyCount);       
	}

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Spawn(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; ++i)
        {
            spawnPoint.x = Random.Range(-150, 150);
            spawnPoint.z = Random.Range(-150, 150);
            GameObject tempEnemy = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.identity);
            tempEnemy.GetComponentInChildren<EnemyMovement>().Player = GameObject.FindWithTag("Player").transform;
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
}
