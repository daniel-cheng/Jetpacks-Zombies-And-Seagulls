﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Respawn : MonoBehaviour
{

	public List<SpawnEnemy> spawnList = new List<SpawnEnemy>();
	
	void RespawnPlayer ()
    {
        Destroy(MainCharacterMovement.character);
		CameraShake.shake_intensity = 0f;
        SpawnCharacter.spawner.SpawnPlayer();
	}
    void RespawnEnemies()
    {
		foreach (SpawnEnemy spawner in FindObjectsOfType(typeof(SpawnEnemy))) {
			spawner.KillEnemies ();
			spawner.Spawn(spawner.enemyCount);
		}
    }

	void RespawnBuildings()
	{
		foreach (SpawnBuildings spawn in FindObjectsOfType(typeof(SpawnBuildings))) {
			spawn.Reconstruct ();
			spawn.SpawnGrid();
		}
	}
    public void Restart()
	{
        RespawnPlayer();
		RespawnBuildings ();
        RespawnEnemies();
		Timer.ResetTime ();
        MainCharacterMovement.jetPackFuel = 100;
    }
}
