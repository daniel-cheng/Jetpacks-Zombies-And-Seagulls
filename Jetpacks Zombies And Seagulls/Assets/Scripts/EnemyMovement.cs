using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Transform Player;
    private Rigidbody myRigidbody;
    public float moveSpeed;
    public float senseDist;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //Debug.Log("Awaking");
    }

    void Start()
    {
        Player = MainCharacterMovement.character.transform;
    }

    void Update()
    {
        transform.LookAt(Player);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Player.position) <= senseDist && !CharacterDeath.isDead)
        {
            //transform.position += transform.forward * moveSpeed;
            myRigidbody.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
        }
        else
        {
            //myRigidbody.AddRelativeForce (Vector3.zero, ForceMode.VelocityChange);
            myRigidbody.velocity = Vector3.zero;
        }
    }
}
