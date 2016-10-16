using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public SpawnEnemy spawner;
    AudioSource sound;
    Transform player;

    public int despawnRange; //If farther than this, then despawn

    public enum EnemyTypes
    {
        Seagull, Zombie
    }
    public EnemyTypes enemyType;

    void Awake()
    {
        sound = GetComponent<AudioSource> ();
        player = MainCharacterMovement.character.transform;

        InvokeRepeating("PlaySound", Random.Range (0f, 1f), 1);
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > despawnRange)
        {
            Debug.Log("Despawning Enemy (Manager)");
            spawner.DespawnEnemy(gameObject);
            Destroy(gameObject);
        }
    }

    void PlaySound ()
    {
        if (sound != null)
        {
            if (enemyType == EnemyTypes.Seagull && !sound.isPlaying)
            {
                sound.Play();
            }
            else if (enemyType == EnemyTypes.Zombie && !sound.isPlaying)
            {
                //sound.Play();
            }
        }
        else
        {
            //Debug.Log("No audio source for " + name + " found.");
        }
    }
}
