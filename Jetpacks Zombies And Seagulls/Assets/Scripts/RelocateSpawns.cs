using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RelocateSpawns : MonoBehaviour {

	private GameObject PlayerSpawner;
	private Transform Player;
	private Vector2 currentChunk = new Vector2(0,0);
	private List<Vector2> chunkList = new List<Vector2>();
	private SpawnBuildings buildingSpawner;
	public int buildingCount = 100;
	public int gridSize = 800;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player").transform;
		buildingSpawner = (SpawnBuildings)GetComponentInChildren<SpawnBuildings> ();
		buildingSpawner.buildingCount = buildingCount;
		for (int i = -1; i <= 1; i++) {
			for (int j = -1; j <= 1; j++) {
				buildingSpawner.transform.position = new Vector3 (gridSize * i, 0, gridSize * j);
				Debug.Log (buildingSpawner.transform.position);
				buildingSpawner.BuildingSpawn (buildingCount);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
