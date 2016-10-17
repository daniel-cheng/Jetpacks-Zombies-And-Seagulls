using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour
{
    public static UpgradeDisplay upgradeDisp;
    Text upgradeText;

    void Awake ()
    {
        if (upgradeDisp == null)
        {
            upgradeDisp = this;
        }
        else if (upgradeDisp != this)
        {
            Debug.Log("You had two upgrade displays.");
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        upgradeText = GetComponent<Text>();
    }

    public void UpgradeMessage(int num, string name)
    {
        upgradeText.text = "Upgrade #" + num.ToString() + " = '" + name + "'";
        Invoke("ClearMessage", 5);
    }

    void ClearMessage()
    {
        upgradeText.text = "";
    }
}
