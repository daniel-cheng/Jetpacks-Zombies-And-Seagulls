using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public SpawnEnemy spawner;
    AudioSource sound;
    Transform player;

    [HideInInspector]
    public bool soundPlayer = false;

    public int despawnRange; //If farther than this, then despawn
    public float soundDelay;

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

    void Start ()
    {
        if (soundPlayer)
        {
            Invoke("PlaySound", Random.Range(0f, soundDelay));
        }
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > despawnRange)
        {
            //Debug.Log("Repositioning Enemy (Manager)");
            if (enemyType == EnemyTypes.Zombie)
            {
                spawner.RepositionEnemy(gameObject, true);
            }
            else if (enemyType == EnemyTypes.Seagull)
            {
                spawner.RepositionEnemy(gameObject, false);
            }
        }
    }

    void PlaySound ()
    {
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            Debug.Log("No audio source for " + name + " found.");
        }

        Invoke("PlaySound", Random.Range(sound.clip.length, soundDelay));
    }
}
