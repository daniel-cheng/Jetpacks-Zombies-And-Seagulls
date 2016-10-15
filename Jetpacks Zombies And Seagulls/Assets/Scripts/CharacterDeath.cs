using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour
{
    
	public static bool isDead;
    GameObject deathUI;

    void Awake ()
    {
		MainCharacterMovement.character = gameObject;
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
        isDead = true;
        //Destroy(gameObject);
    }

    void OnDestroy ()
    {
        Destroy(deathUI);
    }
}
