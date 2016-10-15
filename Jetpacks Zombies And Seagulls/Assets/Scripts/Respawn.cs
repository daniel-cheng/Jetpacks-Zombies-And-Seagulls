using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

	
	void RespawnPlayer ()
    {
        Destroy(MainCharacterMovement.character);
        SpawnCharacter.spawner.SpawnPlayer();
	}
}
