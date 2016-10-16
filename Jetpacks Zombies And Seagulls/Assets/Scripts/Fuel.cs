using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fuel : MonoBehaviour {

    // Use this for initialization
    private float currentFuel = 0;
    public float maxFuel;
    public GameObject fuelBar;
	void Start ()
    {
        maxFuel = MainCharacterMovement.character.GetComponent<MainCharacterMovement>().jetPackFuel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentFuel = MainCharacterMovement.character.GetComponent<MainCharacterMovement>().jetPackFuel;

        if (currentFuel < 0)
        {
            currentFuel = 0;
        }
        //GetComponent<Text>().text = "Fuel: " + Mathf.Floor(currentFuel).ToString();
        fuelBar.transform.localScale = new Vector3(CalculateFuel(currentFuel), fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);
    }
    float CalculateFuel(float currentFuel)
    {
        return currentFuel / maxFuel;
    }
}
