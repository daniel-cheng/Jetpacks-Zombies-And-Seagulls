﻿using UnityEngine;
using System.Collections;

public class SpawnBuildings : MonoBehaviour {

	public GameObject building;
	public int buildingCount = 5;
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
		for (int i = 0; i < buildingNumber; ++i) {
			spawnPoint.x = Random.Range (-25, 25);
			spawnPoint.z = Random.Range (-25, 25);
			GameObject tempBuild = (GameObject)Instantiate(building, spawnPoint, Quaternion.identity);
		}
	}
}