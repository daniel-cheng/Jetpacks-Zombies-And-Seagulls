using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

	
	void RespawnPlayer ()
    {
        Destroy(CharacterDeath.character);
        SpawnCharacter.spawner.SpawnPlayer();
	}
}
