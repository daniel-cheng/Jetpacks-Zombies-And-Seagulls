using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdjustSensitivity : MonoBehaviour
{
    Slider bar;

    void Awake () {
        bar = GetComponent<Slider>();
    }
    void Start ()
    {
        bar.value = PlayerPrefs.GetFloat("Sensitivity");
        if (bar.value < 0.1f)
        {
            bar.value = 0.1f;
        }
        MouseLook.lookSpeed = bar.value;
    }

    public void SetSensitivity(float value)
    {
        Debug.Log("Set Sensitivity");
        MouseLook.lookSpeed = value;
    }

    void OnDisable ()
    {
        PlayerPrefs.SetFloat("Sensitivity", bar.value);
    }
}