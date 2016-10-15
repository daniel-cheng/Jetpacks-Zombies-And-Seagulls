using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {
	public static GameObject character;
    Rigidbody myRigidbody;
	public float friction = 10;
	public float jumpSpeed = 10;
	public bool Jump;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (Input.GetButton("Vertical") && !CharacterDeath.isDead)
        {
            float zAxis = Input.GetAxis("Vertical");
			myRigidbody.AddForce(new Vector3(0,0,zAxis*friction));
        }

		if (Input.GetButton("Horizontal") && !CharacterDeath.isDead)
		{
			float zAxis = Input.GetAxis("Horizontal");
			myRigidbody.AddForce(new Vector3(zAxis*friction,0,0));
		}

		if (Input.GetButtonDown ("Jump") && !CharacterDeath.isDead) {
			Jump = true;
		}
			
	}

	void FixedUpdate() {
		if (Jump) {
			myRigidbody.AddForce(new Vector3(0,1*jumpSpeed,0));
		}
	}
}
