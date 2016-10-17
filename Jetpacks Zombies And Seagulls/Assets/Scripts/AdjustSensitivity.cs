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
        MouseLook.lookSpeed = bar.value;
            
    }

    public void SetSensitivity(float value)
    {
        MouseLook.lookSpeed = value;
    }

    void OnDisable ()
    {
        PlayerPrefs.SetFloat("Sensitivity", bar.value);
    }
}