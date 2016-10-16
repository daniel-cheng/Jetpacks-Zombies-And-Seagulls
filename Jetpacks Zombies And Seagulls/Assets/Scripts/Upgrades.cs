using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour {

	public static Upgrades upgrade;
	private GameObject Player;
    public static int totalUpgrades = 0;

    float moveOriginal;
    Vector3 maxSpeedOriginal;
	float jumpOriginal;
	float fuelOriginal;
	float refuelOriginal;

	public static List<Action> functions = new List<Action>();

	void Awake() {
		if (upgrade == null) {
			upgrade = this;
		} else if (upgrade != this) {
			Debug.Log ("I am not worthy");
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Player = MainCharacterMovement.character;

		moveOriginal = Player.GetComponent<MainCharacterMovement> ().friction;
        maxSpeedOriginal = Player.GetComponent<MaxSpeed>().maxVelocity;
        jumpOriginal = Player.GetComponent<MainCharacterMovement> ().jumpSpeed;
		fuelOriginal = Player.GetComponent<MainCharacterMovement>().jetPackFuel;
		refuelOriginal = Player.GetComponent<MainCharacterMovement> ().refuelRate;

		functions.Add (addJetFuel);
		functions.Add (addJumpSpeed);
		functions.Add (addRefuelRate);
		functions.Add (addMoveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            Player = MainCharacterMovement.character;
        }
	}

	public void AddUpgrade() {
        int rand = UnityEngine.Random.Range(0, functions.Count);
        functions [rand]();

		totalUpgrades++;
        Debug.Log("Total Upgrades= " + totalUpgrades + ", New Upgrade= " + functions[rand].Method.Name.ToString());
	}

	void addMoveSpeed() {
		Player.GetComponent<MainCharacterMovement>().friction += 10;
        Player.GetComponent<MaxSpeed>().maxVelocity += new Vector3(10, 0, 10);

    }

	void addJetFuel() {
        Player.GetComponent<MainCharacterMovement>().jetPackFuel += 10;
	
	}

	void addJumpSpeed() {
		Player.GetComponent<MainCharacterMovement>().jumpSpeed += 10;

	}

	void addRefuelRate() {
		Player.GetComponent<MainCharacterMovement>().refuelRate += 10;

	}

	public void resetStats() {
		Player.GetComponent<MainCharacterMovement>().refuelRate = refuelOriginal;
        Player.GetComponent<MaxSpeed>().maxVelocity = maxSpeedOriginal;
        Player.GetComponent<MainCharacterMovement>().jetPackFuel = fuelOriginal;
		Player.GetComponent<MainCharacterMovement>().friction = moveOriginal;
		Player.GetComponent<MainCharacterMovement>().jumpSpeed = jumpOriginal;
		totalUpgrades = 0;
	}
		
}