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
        isDead = true;

        if (deathUI == null)
        {
            deathUI = (GameObject)Instantiate(Resources.Load("Death Canvas"));
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void OnDestroy ()
    {
        Destroy(deathUI);
    }
}
