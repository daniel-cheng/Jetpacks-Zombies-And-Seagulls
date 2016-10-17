using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        CameraShake.shaking = false;
        CameraShake.shake_intensity = 0f;
        SceneManager.LoadScene(sceneName);
    }
}
