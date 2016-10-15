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
		timer += Time.deltaTime;
		GetComponent<Text>().text = "Survived: "+ Mathf.Floor(timer).ToString(); 
	}

	public static void ResetTime() {
		timer = 0;
	}
}
