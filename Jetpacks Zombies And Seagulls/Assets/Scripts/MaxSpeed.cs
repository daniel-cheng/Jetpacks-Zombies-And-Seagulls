using UnityEngine;
using System.Collections;

public class MaxSpeed : MonoBehaviour
{
    public Vector3 maxVelocity;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Max Speed Control

        //Strafe Speed
        if (transform.InverseTransformDirection(rigid.velocity).x >= maxVelocity.x)
        {
            rigid.AddRelativeForce(maxVelocity.x - transform.InverseTransformDirection(rigid.velocity).x, 0, 0, ForceMode.VelocityChange);
            //Debug.Log ("Hit Max X");
        }
        else if (transform.InverseTransformDirection(rigid.velocity).x <= -maxVelocity.x)
        {
            rigid.AddRelativeForce(-maxVelocity.x - transform.InverseTransformDirection(rigid.velocity).x, 0, 0, ForceMode.VelocityChange);
            //Debug.Log ("Hit Max -X");
        }

        //Forward Speed
        if (transform.InverseTransformDirection(rigid.velocity).z >= maxVelocity.z)
        {
            rigid.AddRelativeForce(0, 0, maxVelocity.z - transform.InverseTransformDirection(rigid.velocity).z, ForceMode.VelocityChange);
            ///Debug.Log ("Hit Max Z");
        }
        else if (transform.InverseTransformDirection(rigid.velocity).z <= -maxVelocity.z)
        {
            rigid.AddRelativeForce(0, 0, -maxVelocity.z - transform.InverseTransformDirection(rigid.velocity).z, ForceMode.VelocityChange);
            //Debug.Log ("Hit Max -Z");
        }
    }
}
