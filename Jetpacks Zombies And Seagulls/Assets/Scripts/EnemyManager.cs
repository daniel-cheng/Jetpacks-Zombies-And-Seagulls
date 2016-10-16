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
    }
    
    void Update()
    {
        if (enemyType == EnemyTypes.Seagull && !sound.isPlaying)
        {
            sound.PlayDelayed(0.1f);
        }

        if (Vector3.Distance(transform.position, player.position) > despawnRange)
        {
            spawner.DespawnEnemy(gameObject);
            Destroy(gameObject);
        }
    }
}
