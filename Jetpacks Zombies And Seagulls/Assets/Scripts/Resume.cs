using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour
{
    //Goes on resume button
    public void ResumeGame()
    {
        MainCharacterMovement.character.GetComponent<Pause>().ResumeGame();
    }
}
