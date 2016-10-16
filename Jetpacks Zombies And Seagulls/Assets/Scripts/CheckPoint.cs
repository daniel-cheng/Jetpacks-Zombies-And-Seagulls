using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    GameObject waypoint;
    bool activeShop = true;
    
	void Start ()
    {
        waypoint = transform.FindChild("Waypoint Canvas").gameObject;
	}

    void Update ()
    {
        if (activeShop)
        {
            waypoint.transform.LookAt(MainCharacterMovement.character.transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && activeShop)
        {
            Upgrades.upgrade.AddUpgrade();

            activeShop = false;
            Destroy(waypoint); 
        }
    }
}
