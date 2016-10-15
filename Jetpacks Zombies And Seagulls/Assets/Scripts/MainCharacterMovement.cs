using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {

    Rigidbody myRigidbody;
    
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    
    void Start () {
	
	}
	
	void Update () {
        if (Input.GetButton("Vertical"))
        {
            float vertAxis = Input.GetAxis("Vertical");
            myRigidbody.AddForce(new Vector3(0,vertAxis*5,0));
        }
	}
}
