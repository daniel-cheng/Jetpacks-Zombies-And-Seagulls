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
    public ParticleSystem leftJet;
    public ParticleSystem rightJet;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();

        if (character == null)
        {
            character = gameObject;
        }
        else if (character != gameObject)
        {
            Debug.Log("YOU HAD TWO CHARACTERS!!");
            Destroy(gameObject);
        }
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
                leftJet.Play();
                rightJet.Play();
                if (CameraShake.shake_intensity == 0) {
					CameraShake.shake_intensity = 0.03f;
					CameraShake.Shake ();
				}
			}
		}
        else
        {
            leftJet.Stop();
            rightJet.Stop();
        }
        if(jetPackFuel < 100 )
        {
            jetPackFuel = jetPackFuel + refuelRate * Time.fixedDeltaTime;
        }
    }
}
