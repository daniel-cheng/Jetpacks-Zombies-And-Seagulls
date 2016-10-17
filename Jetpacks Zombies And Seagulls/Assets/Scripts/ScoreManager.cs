using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    List<int> scores = new List<int>();
    public static ScoreManager scoreKeeper;

    void Awake ()
    {
        if (scoreKeeper == null)
        {
            scoreKeeper = this;
        }
        else if (scoreKeeper != this)
        {
            Debug.Log("You HAD two score managers.");
            Destroy(gameObject);
        }

        for (int a = 1; a <= 10; a++)
        {
            scores.Add(PlayerPrefs.GetInt("Score " + a.ToString()));
        }
    }

    public void AddScore(int newScore)
    {
        scores.Add(newScore);
    }
    
    void OnDestroy()
    {
        scores.Sort();
        foreach (int f in scores)
        {
            Debug.Log(f);
        }
        for (int a = 1; a <= 10; a++)
        {
            PlayerPrefs.SetInt("Score " + a.ToString(), scores[scores.Count - a]);
        }
    }
}
