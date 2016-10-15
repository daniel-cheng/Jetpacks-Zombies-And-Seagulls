using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour
{
    public static GameObject character;
    GameObject deathUI;

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
        if (deathUI == null)
        {
            deathUI = (GameObject)Instantiate(Resources.Load("Death Canvas"));
        }
        GetComponent<MainCharacterMovement>().isDead = true;
        //Destroy(gameObject);
    }
}
