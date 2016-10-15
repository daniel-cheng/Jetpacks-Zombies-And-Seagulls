﻿using UnityEngine;
using System.Collections;

public class SpawnBuildings : MonoBehaviour {

	public GameObject building;
	public int buildingCount = 100;
    public Vector2 buildingRange = new Vector2(100, 100);
    private Vector3 spawnPoint;
	public static SpawnBuildings buildingSpawnerRef;


	void Awake()
	{
		if(buildingSpawnerRef == null)
		{
			buildingSpawnerRef = this;
		}
		else if (buildingSpawnerRef != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		BuildingSpawn (buildingCount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuildingSpawn(int buildingNumber) {
		int half = buildingNumber / 2;
		for (int i = 0; i < half; ++i) {
			spawnPoint.x = Random.Range (-buildingRange.x, buildingRange.y);
			spawnPoint.z = Random.Range (-buildingRange.x, buildingRange.y);
			float scaleFactor = Random.Range (1, 40);
			float bulkFactor = Random.Range (10, 30);
			float bulkOther = Random.Range (1, 20);
			GameObject tempBuild = (GameObject)Instantiate(building, spawnPoint, Quaternion.identity);
			//tempBuild.transform.position = new Vector3 (spawnPoint.x, scaleFactor, spawnPoint.z);
			tempBuild.transform.localScale = new Vector3 (bulkFactor, scaleFactor, bulkOther);
		}

		for (int i = half; i < buildingNumber; ++i) {
			spawnPoint.x = Random.Range (-buildingRange.x, buildingRange.y);
			spawnPoint.z = Random.Range (-buildingRange.x, buildingRange.y);
			float scaleFactor = Random.Range (1, 120);
			float bulkFactor = Random.Range (10, 30);
			float bulkOther = Random.Range (1, 20);
			GameObject tempBuild = (GameObject)Instantiate(building, spawnPoint, Quaternion.identity);
			//tempBuild.transform.position = new Vector3 (spawnPoint.x, scaleFactor, spawnPoint.z);
			tempBuild.transform.localScale = new Vector3 (bulkFactor, scaleFactor, bulkOther);
		}
	}
}
