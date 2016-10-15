using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    GameObject pauseUI;
    //bool isPaused;

    void Awake ()
    {
        pauseUI = (GameObject)Instantiate(Resources.Load("Pause UI"));
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
    }

    void PauseGame ()
    {
        pauseUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;

        pauseUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
