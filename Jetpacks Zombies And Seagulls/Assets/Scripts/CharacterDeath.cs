using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour
{
    public static GameObject character;

    void Awake ()
    {
        character = gameObject;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Environment"))
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(Resources.Load("Death Canvas"));

        Destroy(gameObject);
    }
}
