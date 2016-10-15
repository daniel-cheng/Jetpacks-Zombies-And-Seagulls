﻿using UnityEngine;
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

        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        CharacterDeath.isDead = false;
        character = (GameObject)Instantiate(characterPrefab, transform.position, transform.rotation);
    }
}
