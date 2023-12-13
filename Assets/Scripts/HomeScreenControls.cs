using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//SCRIPT ATTACHED TO SCRIPTCONTAINER
public class HomeScreenControls : MonoBehaviour
{
//Button Cards
    public Button PremadePatternDesign;

//Panels
    public GameObject PremadePanel;
    public GameObject CustomDesignPanel;
    public GameObject HomeScreenPanel;
    public GameObject FabricInputOverlay;
    public GameObject GuideOverlay;
    public GameObject ChooseCustomMeasurementsOverlay;
    public GameObject DesignHistoryOverlay;
    public GameObject RecommendationsPanel;
    public GameObject UserDataPanel;
    public GameObject customMeasurementsError;
    public TMP_Text measurementsEnteredBool;

//Canvas Groups
    public CanvasGroup PremadePanelCG; 

    public CanvasGroup customPanelCG;

//Booleans
    //private bool isClickFabricConfirm = false;
 
    public void NavigateToRecommendations()
    {
        HomeScreenPanel.SetActive(false);
        RecommendationsPanel.SetActive(true);
    }



    public void NavigateHomeToPremade()
    {
        HomeScreenPanel.SetActive(false);
        PremadePanel.SetActive(true);
        PremadePanelCG.interactable = false;
        PremadePanelCG.blocksRaycasts = false;
        FabricInputOverlay.SetActive(true);
    }

    public void NavigateHomeToCustomDesign()
    {   
        if (measurementsEnteredBool.text == "False"){
            customMeasurementsError.SetActive(true);
        }
        else{
            customMeasurementsError.SetActive(false);
            FabricInputOverlay.SetActive(true);
            HomeScreenPanel.SetActive(false);
            CustomDesignPanel.SetActive(true);
            customPanelCG.interactable = false;
            customPanelCG.blocksRaycasts = false;
        }
    }

    public void NavigateHomeToGuide()
    {
        HomeScreenPanel.SetActive(false);
        GuideOverlay.SetActive(true);
    }
    
    public void NavigateMYSIZINGtoChooseMeasurement()
    {
        //HomeScreenPanel.SetActive(false);
        ChooseCustomMeasurementsOverlay.SetActive(true);
    }

    public void NavigateMYDESIGNStoDesignHistory()
    {   
        UserDataPanel.SetActive(false);
        HomeScreenPanel.SetActive(false);
        DesignHistoryOverlay.SetActive(true);
    }

//Navbar

    // Start is called before the first frame update
    void Start()
    {
        ChooseCustomMeasurementsOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
