using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {

    Rigidbody myRigidbody;
	public float friction = 10;

    public bool isDead;
    
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (Input.GetButton("Vertical") && !isDead)
        {
            float zAxis = Input.GetAxis("Vertical");
			myRigidbody.AddForce(new Vector3(0,0,zAxis*friction));
        }

		if (Input.GetButton("Horizontal") && !isDead)
		{
			float zAxis = Input.GetAxis("Horizontal");
			myRigidbody.AddForce(new Vector3(zAxis*friction,0,0));
		}

	}
}
