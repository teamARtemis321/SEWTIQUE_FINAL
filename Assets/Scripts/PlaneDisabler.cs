using UnityEngine;
using UnityEngine.UI;

public class PanelDisabler : MonoBehaviour
{
    public Button disableButton; // Reference to the button that will disable the panel
    public GameObject panelToDisable; // Reference to the panel you want to disable

    private void Start()
    {
        // Add a listener to the button's onClick event
        disableButton.onClick.AddListener(DisablePanel);
    }

    public void DisablePanel()
    {
        // Check if the panelToDisable is not null
        if (panelToDisable != null)
        {
            // Disable the panel by setting its active state to false
            panelToDisable.SetActive(false);
        }
    }
}
