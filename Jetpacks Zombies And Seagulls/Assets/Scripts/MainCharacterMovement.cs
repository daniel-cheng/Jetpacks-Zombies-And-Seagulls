using UnityEngine;
using System.Collections;

public class MainCharacterMovement : MonoBehaviour {

    Rigidbody myRigidbody;

    // Use this for initialization
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Vertical"))
        {
            float vertAxis = Input.GetAxis("Vertical");
            myRigidbody.AddForce(new Vector3(0,vertAxis*5,0));
        }
        Debug.Log(myRigidbody);
	}
}
