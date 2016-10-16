using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fuel : MonoBehaviour {
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        GetComponent<Text>().text = "Fuel: " + Mathf.Floor(MainCharacterMovement.jetPackFuel).ToString();
    }
}
