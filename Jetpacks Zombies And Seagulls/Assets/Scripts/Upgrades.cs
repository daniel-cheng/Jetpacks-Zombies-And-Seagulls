using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour {

	public static Upgrades upgrade;
	private GameObject Player; 
	float moveOriginal;
	float jumpOriginal;
	float fuelOriginal;
	float refuelOriginal;
	public static int totalUpgrades = 0;

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
		jumpOriginal = Player.GetComponent<MainCharacterMovement> ().jumpSpeed;
		fuelOriginal = MainCharacterMovement.jetPackFuel;
		refuelOriginal = Player.GetComponent<MainCharacterMovement> ().refuelRate;

		functions.Add (addJetFuel);
		functions.Add (addJumpSpeed);
		functions.Add (addRefuelRate);
		functions.Add (addMoveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player == null)
			Player = MainCharacterMovement.character;
	}

	public static void addUpgrade() {
		functions [UnityEngine.Random.Range (0, functions.Count)]();
		totalUpgrades++;
		Debug.Log (totalUpgrades);
	}

	void addMoveSpeed() {
		Player.GetComponent<MainCharacterMovement>().friction += 10;

	}

	void addJetFuel() {
		MainCharacterMovement.jetPackFuel += 10;
	
	}

	void addJumpSpeed() {
		Player.GetComponent<MainCharacterMovement>().jumpSpeed += 10;

	}

	void addRefuelRate() {
		Player.GetComponent<MainCharacterMovement>().refuelRate += 10;

	}

	public void resetStats() {
		Player.GetComponent<MainCharacterMovement>().refuelRate = refuelOriginal;
		MainCharacterMovement.jetPackFuel = fuelOriginal;
		Player.GetComponent<MainCharacterMovement>().friction = moveOriginal;
		Player.GetComponent<MainCharacterMovement>().jumpSpeed = jumpOriginal;
		totalUpgrades = 0;
	}
		
}
