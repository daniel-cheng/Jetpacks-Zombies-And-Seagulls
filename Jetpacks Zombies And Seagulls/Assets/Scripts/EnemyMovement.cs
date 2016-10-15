using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform Player;
	private Rigidbody myRigidbody;
	public float moveSpeed = 7;
	public float senseDist = 10;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Player);

		if (Vector3.Distance (transform.position, Player.position) <= senseDist) {

			//transform.position += transform.forward * moveSpeed;
			myRigidbody.AddRelativeForce (Vector3.forward * moveSpeed, ForceMode.Impulse);
		} else {
			//myRigidbody.AddRelativeForce (Vector3.zero, ForceMode.VelocityChange);
			myRigidbody.velocity = Vector3.zero;
		}
	}
}
