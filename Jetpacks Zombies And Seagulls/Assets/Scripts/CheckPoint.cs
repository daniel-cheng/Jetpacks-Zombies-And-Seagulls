using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
    GameObject waypoint;
    bool activeShop = true;
    
	void Start ()
    {
        waypoint = transform.FindChild("Wapoint Canvas").gameObject;
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
            //Call an upgrade

            activeShop = false;
            Destroy(waypoint); 
        }
    }
}
