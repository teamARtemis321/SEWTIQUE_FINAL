using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to show/hide
    public GameObject cpanel;
    public TMP_Text warningLoginText;

    public void TogglePanel()
    {
        if (warningLoginText != null)
        {
            panel.SetActive(!panel.activeSelf);
            cpanel.SetActive(false);
        }
   
    }
}
