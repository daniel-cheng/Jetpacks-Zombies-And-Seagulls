using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {
	public static GameObject character;
    Rigidbody myRigidbody;
	public float friction = 10;
	public float jumpSpeed = 20;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
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

		if (Input.GetButton ("Jump") && !CharacterDeath.isDead) {
			myRigidbody.AddForce(new Vector3(0,jumpSpeed,0));
		}
			
	}
}
