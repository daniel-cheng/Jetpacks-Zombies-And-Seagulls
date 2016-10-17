using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreGetter : MonoBehaviour
{
    GameObject[] highscores = new GameObject[10];

    void Start()
    {
        CreateScoreList();
    }

    void CreateScoreList()
    {
        for (int a = 1; a <= 10; a++)
        {
            //Debug.Log("Loading score #" + a.ToString() + " = " + PlayerPrefs.GetInt("Score " + a.ToString()).ToString());
            GameObject scoreText = (GameObject)Instantiate(Resources.Load("Text"), transform, false);
            scoreText.GetComponent<Text>().text = a.ToString() + ") " + PlayerPrefs.GetInt("Score " + a.ToString()).ToString() + " seconds";
            highscores[a - 1] = scoreText;
        }
    }

    public void ClearHighscores()
    {
        for (int a = 1; a <= 10; a++)
        {
            PlayerPrefs.DeleteKey("Score " + a.ToString());
        }
        foreach (GameObject aScore in highscores)
        {
            Destroy(aScore);
        }
        CreateScoreList();
    }
}
