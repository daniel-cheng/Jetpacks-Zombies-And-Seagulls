using UnityEngine;
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

	void RespawnBuildings()
	{
        SpawnBuildings.buildingSpawnerRef.Reconstruct ();
        SpawnBuildings.buildingSpawnerRef.SpawnGrid();
	}
    public void Restart()
	{
        RespawnPlayer();
		RespawnBuildings ();
		Timer.ResetTime ();
        MainCharacterMovement.character.GetComponent<MainCharacterMovement>().jetPackFuel = 100;
    }
}
