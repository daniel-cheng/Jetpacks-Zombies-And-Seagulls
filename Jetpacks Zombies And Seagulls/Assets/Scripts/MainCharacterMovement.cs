using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {
	public static GameObject character;
    Rigidbody myRigidbody;
	public float friction = 40;
	public float jumpSpeed = 60;
    public float jetPackFuel = 100;
    public float refuelRate = 15;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        if (Input.GetButton("Vertical") && !CharacterDeath.isDead)
        {
            float zAxis = Input.GetAxis("Vertical");
			myRigidbody.AddRelativeForce(new Vector3(0,0,zAxis*friction));
        }

		if (Input.GetButton("Horizontal") && !CharacterDeath.isDead)
		{
			float zAxis = Input.GetAxis("Horizontal");
			myRigidbody.AddRelativeForce(new Vector3(zAxis*friction,0,0));
		}

		if (Input.GetButton ("Jump") && !CharacterDeath.isDead)
        {
			if (jetPackFuel > 0) {
				myRigidbody.AddForce (new Vector3 (0, jumpSpeed, 0));
				jetPackFuel = jetPackFuel - 100 * Time.fixedDeltaTime;
				CameraShake.shake_intensity = 0.03f;
				CameraShake.Shake ();
			} else {
				CameraShake.shake_intensity = 0f;
			}
		}
        if(jetPackFuel < 100 )
        {
            jetPackFuel = jetPackFuel + refuelRate * Time.fixedDeltaTime;
        }
    }
}
