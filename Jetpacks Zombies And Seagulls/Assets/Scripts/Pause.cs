using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    GameObject pauseUI;
    //bool isPaused;

    void Awake ()
    {
        pauseUI = (GameObject)Instantiate(Resources.Load("Pause UI"));

        ResumeGame();
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

        if (!CharacterDeath.isDead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnDestroy ()
    {
        Destroy(pauseUI);
    }
}
