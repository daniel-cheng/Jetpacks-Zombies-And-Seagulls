using UnityEngine;
using System.Collections;

public class SpawnCharacter : MonoBehaviour
{
    public static SpawnCharacter spawner;
    public GameObject characterPrefab;
    GameObject character;

    void Awake()
    {
        if (spawner == null)
        {
            spawner = this;
        }
        else if (spawner != this)
        {
            Debug.Log("I am not worthy");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        character = (GameObject)Instantiate(characterPrefab, transform.position, transform.rotation);
    }
}
