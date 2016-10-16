using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!CharacterDeath.isDead) {
			timer += Time.deltaTime;
		}
		GetComponent<Text>().text = "Survived: "+ Mathf.Floor(timer).ToString() +" seconds"; 
	}

	public static void ResetTime() {
		timer = 0;
	}
}
