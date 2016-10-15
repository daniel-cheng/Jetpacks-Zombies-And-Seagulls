using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Respawn : MonoBehaviour
{

	public List<SpawnEnemy> spawnList = new List<SpawnEnemy>();
	
	void RespawnPlayer ()
    {
        Destroy(MainCharacterMovement.character);
        SpawnCharacter.spawner.SpawnPlayer();
	}
    void RespawnEnemies()
    {
		foreach (SpawnEnemy spawner in FindObjectsOfType(typeof(SpawnEnemy))) {
			spawner.KillEnemies ();
			spawner.Spawn(spawner.enemyCount);
		}
    }
    public void Restart()
	{
        RespawnPlayer();
        RespawnEnemies();
		Timer.ResetTime ();
    }
}
