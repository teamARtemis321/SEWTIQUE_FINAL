using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public Button switchButton;

    public void Start()
    {
        // Attach a click event listener to the button
        switchButton.onClick.AddListener(SwitchPanels);

        // Ensure the next panel is initially inactive
        nextPanel.SetActive(false);
    }

    public void SwitchPanels()
    {
        // Deactivate the current panel and activate the next panel
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
