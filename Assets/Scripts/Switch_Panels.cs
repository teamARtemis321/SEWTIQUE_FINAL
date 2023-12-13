using UnityEngine;
using UnityEngine.UI;

public class Switch_Panels : MonoBehaviour
{
    public Button neckLine;
    public Button collar;
    public Button sleeve;

    public GameObject necklinePanel;
    public GameObject collarPanel;
    public GameObject sleevePanel;

    void Start()
    {
        // Add the listeners for each button
        neckLine.onClick.AddListener(() => SwitchPanel(necklinePanel));
        collar.onClick.AddListener(() => SwitchPanel(collarPanel));
        sleeve.onClick.AddListener(() => SwitchPanel(sleevePanel));

        // Optionally initialize to a certain panel being open
        HideAllPanels();
        // panel1.SetActive(true);
    }

    void SwitchPanel(GameObject panelToShow)
    {
        // Hide all panels
        necklinePanel.SetActive(false);
        collarPanel.SetActive(false);
        sleevePanel.SetActive(false);

        // Show the selected panel
        panelToShow.SetActive(true);
    }


    void HideAllPanels()
    {
        necklinePanel.SetActive(false);
        collarPanel.SetActive(false);
        sleevePanel.SetActive(false);
    }
}
