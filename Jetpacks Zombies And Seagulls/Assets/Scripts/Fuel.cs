using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fuel : MonoBehaviour {

    // Use this for initialization
    private float currentFuel = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        currentFuel = MainCharacterMovement.jetPackFuel;

        if (currentFuel < 0 )
        {
            currentFuel = 0;
        }
        GetComponent<Text>().text = "Fuel: " + Mathf.Floor(currentFuel).ToString();
    }
}
