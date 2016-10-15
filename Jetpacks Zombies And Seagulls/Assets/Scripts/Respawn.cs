using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

	
	void RespawnPlayer ()
    {
        Destroy(MainCharacterMovement.character);
        SpawnCharacter.spawner.SpawnPlayer();
	}
    void RespawnEnemies()
    {
        SpawnEnemy.enemySpawnerReference.KillEnemies();
        SpawnEnemy.enemySpawnerReference.Spawn(3);
    }
    void Restart()
    {
        RespawnPlayer();
        RespawnEnemies();
    }
}
