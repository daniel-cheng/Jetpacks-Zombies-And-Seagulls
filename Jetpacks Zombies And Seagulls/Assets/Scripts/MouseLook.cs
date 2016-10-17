using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    Transform playerTransform;

    public Vector2 rotLimit;    //X=max, Y=min

    public static float lookSpeed;
    float lookX;
    float lookY;

    void Awake()
    {
        playerTransform = transform;
    }

    void Update()
    {
        lookX = Input.GetAxis("Mouse X") * lookSpeed;
        lookY = Input.GetAxis("Mouse Y") * -lookSpeed;

        //Restrict camera angle
        if (transform.localEulerAngles.x < rotLimit.x - 1  && transform.localEulerAngles.x > 180) //CamMax-1 > RotX && RotX > 180
        {
            transform.localEulerAngles =
                new Vector3(rotLimit.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else if(transform.localEulerAngles.x > rotLimit.y + 1 && transform.localEulerAngles.x < 180)//180 > RotX && RotX > CamMin+1
        {
            transform.localEulerAngles =
                new Vector3(rotLimit.y, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }

    void FixedUpdate()
    {
        if (!CharacterDeath.isDead)
        {
            //transform.Rotate(lookY, lookX, 0, Space.Self);
            transform.localEulerAngles = new Vector3(playerTransform.localEulerAngles.x, playerTransform.localEulerAngles.y, 0);
            transform.localRotation *= Quaternion.Euler(lookY, lookX, 0);
        }
    }
}
