using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{
    public static Upgrades upgrade;
    private GameObject Player;
    public static int totalUpgrades = 0;

    float moveOriginal;
    Vector3 maxSpeedOriginal;
    float jumpOriginal;
    float fuelOriginal;
    float refuelOriginal;

    Transform playerCam;

    public static List<Action> functions = new List<Action>();

    void Awake()
    {
        if (upgrade == null)
        {
            upgrade = this;
        }
        else if (upgrade != this)
        {
            Debug.Log("I am not worthy");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        Player = MainCharacterMovement.character;
        playerCam = Player.transform.FindChild("Main Camera");

        moveOriginal = Player.GetComponent<MainCharacterMovement>().friction;
        maxSpeedOriginal = Player.GetComponent<MaxSpeed>().maxVelocity;
        jumpOriginal = Player.GetComponent<MainCharacterMovement>().jumpSpeed;
        fuelOriginal = Player.GetComponent<MainCharacterMovement>().jetPackFuel;
        refuelOriginal = Player.GetComponent<MainCharacterMovement>().refuelRate;

        functions.Add(addJetFuel);
        functions.Add(addJumpSpeed);
        functions.Add(addRefuelRate);
        functions.Add(addMoveSpeed);
        functions.Add(addShake);
        functions.Add(flipCamera);
    }

    void Update()
    {
        if (Player == null)
        {
            Initialize();
        }
    }

    public void AddUpgrade()
    {
        int rand = UnityEngine.Random.Range(0, functions.Count);
        functions[rand]();

        totalUpgrades++;
        Debug.Log("Total Upgrades= " + totalUpgrades + ", New Upgrade= " + functions[rand].Method.Name.ToString());
    }

    void addMoveSpeed()
    {
        Player.GetComponent<MainCharacterMovement>().friction += 10;
        Player.GetComponent<MaxSpeed>().maxVelocity += new Vector3(10, 0, 10);

    }

    void addJetFuel()
    {
        Player.GetComponent<MainCharacterMovement>().jetPackFuel += 10;

    }

    void addJumpSpeed()
    {
        Player.GetComponent<MainCharacterMovement>().jumpSpeed += 10;

    }

    void addRefuelRate()
    {
        Player.GetComponent<MainCharacterMovement>().refuelRate += 10;

    }

    void addShake()
    {
        CameraShake.shake_intensity += 0.1f;
    }

    void flipCamera()
    {
        playerCam.eulerAngles = new Vector3(playerCam.eulerAngles.x, playerCam.eulerAngles.y, playerCam.eulerAngles.z + 180);
    }

    public void resetStats()
    {
        Player.GetComponent<MainCharacterMovement>().refuelRate = refuelOriginal;
        Player.GetComponent<MaxSpeed>().maxVelocity = maxSpeedOriginal;
        Player.GetComponent<MainCharacterMovement>().jetPackFuel = fuelOriginal;
        Player.GetComponent<MainCharacterMovement>().friction = moveOriginal;
        Player.GetComponent<MainCharacterMovement>().jumpSpeed = jumpOriginal;
        totalUpgrades = 0;
        CameraShake.shake_intensity = 0;
    }

}