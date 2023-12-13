using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FabricInputControls : MonoBehaviour 
{
    //default unit is meters. 
    //always meters at the start. 
    //reset it to meters every single time the overlay is removed.
    //store the value they chose for unit once they click confirm.
    //accept fabric dimensions - convert cm values to m 
    //run checks on the input
    //if the checks are valid, use these values to resize the panel on
    //- the arrangement screen after user clicks confirm - disable the overlay panel. 
    //if checks are invalid, show an error
    //if the user clicks on cancel, navigate to homescreen - disable all else. 

//panels
    public GameObject arrangementFabricPanel;
    public GameObject fabricDimensionOverlay;
    public GameObject cancelConfirmationPanel;
    public GameObject homeScreenPanel;
    public GameObject premadeScreenPanel;

    public GameObject customDesignPanel;
    public GameObject plane;

    //public ImagePlacer uiARobj;


//canvas groups
    public CanvasGroup fabricDimensionOverlayCG;

    public CanvasGroup premadePanelCG;

    public CanvasGroup customDesignCG;

//input fields, variables
    public TMP_InputField widthInputField;
    public TMP_InputField lengthInputField;
    public float realWidth;
    public float realLength;
    public float maxPanelWidth = 1280;
    public float maxPanelLength = 2250;

//text
    public TextMeshProUGUI errorHolder;

//objects

    //public ImagePlacer ARobj;
    //public PreMadePanelControls preObj;

//dropdown
    public TMP_Dropdown unitDropDown;
    private string selectedUnitText = "Meter";
    
//overlay button methods

    public void OnUnitChange()
    {
        int currentSelection = unitDropDown.value;
        //dropdown.value = dropdown.value + 1;
        selectedUnitText = unitDropDown.options[currentSelection].text;
        Debug.Log("selected option" + selectedUnitText);
    }

//^after clicking CONFIRM 
    public void acceptDimensions()
    { 
        //check the inputs
        //accept the inputs, send them to the fabricresizer method
        //call a function to set the values of the local fwidth and flength to 0. 

        if(float.TryParse(widthInputField.text, out realWidth) && float.TryParse(lengthInputField.text, out realLength))
        {

            if (selectedUnitText=="Centimeter")
            {
                Debug.Log("Selected unit is centimeter, converting to meter");
                realWidth = realWidth/100;
                realLength = realLength/100;
            }

            if (realWidth > realLength)
            {   
                errorHolder.text = "enter the larger value in length";
            }

            else if (realWidth<=0.34 || realWidth>1.285 || realLength<=1.284 || realLength>2.0)
            {   
                Debug.Log("inside limit checker");
                Debug.Log("width: " + realWidth + " length" + realLength);
                if(selectedUnitText=="Meter")
                {   
                    Debug.Log("selected Unit is meter. limit crossed");
                    errorHolder.text = "0.35m < width < 2.0m /n 1.285m < length < 2.0m";
                }
                
                else if(selectedUnitText=="Centimeter")
                {
                    Debug.Log("selected Unit is centimeter. limit crossed");
                    errorHolder.text = "35cm < width < 200cm /n 128.5cm < length < 200cm";
                }

                else 
                {
                    Debug.Log("error in unit assignment");
                }
            }

            else 
            {
            //preObj.StoreRealPlaneValues(realWidth, realLength);
            //ARobj.StorePanelValues(realWidth, realLength);
            (float scaledWidth, float scaledLength) = metersToPixels(realWidth, realLength, 1280, 2250);
            

            //! send to panel < hide input overlay < premade interactable < reset fabric dimensions 
            //resizeFabricPanel((scaledWidth*1000), (scaledLength*1000)); //^send the width and length values to resize the panel
            resizeFabricPanel((realWidth * 1000), (realLength * 1000)); //^send the width and length values to resize the panel
            fabricDimensionOverlay.SetActive(false); //^hide the fabric input overlay
            premadePanelCG.interactable = true;      //^make premade panel interactable 
            premadePanelCG.blocksRaycasts = true;
            customDesignCG.interactable = true;
            customDesignCG.blocksRaycasts = true;
            resetFabricDimensions(); 
            //^reset the globally stored fabric dimensions + earlier values already passed to function
            }
        }

        else
        {
            errorHolder.text = "please enter integer or decimal values only!";
            Debug.Log("could not parse fabric inputs");
        }
    }


    public (float pWidth, float pLength) metersToPixels(float realWidth, float realLength, float maxWidth, float maxLength)
    {
        float aspectRatio = realWidth / realLength;
        //uiARobj.acceptAspect(aspectRatio);

        float pixelWidth = maxWidth;
        float pixelLength = maxWidth / aspectRatio;

        Vector3 newSize = new Vector3( realWidth * 0.1f, 1, realLength * 0.1f);
        plane.transform.localScale = newSize;
        if (pixelLength > maxLength)
        {
            pixelLength = maxLength;
            pixelWidth = maxLength * aspectRatio;
        }

        return (pixelWidth, pixelLength);
    }

//^after clicking CANCEL
    public void cancelFabricOverlay()
    {
        cancelConfirmationPanel.SetActive(true);
        fabricDimensionOverlayCG.interactable = false;
        fabricDimensionOverlayCG.blocksRaycasts = false;
    }

    public void noCancel()
    {
        cancelConfirmationPanel.SetActive(false);
        fabricDimensionOverlayCG.interactable = true;
        fabricDimensionOverlayCG.blocksRaycasts = true;
    }

    public void yesCancel()
    {
        cancelConfirmationPanel.SetActive(false);
        fabricDimensionOverlay.SetActive(false);
        fabricDimensionOverlayCG.interactable = true;
        fabricDimensionOverlayCG.blocksRaycasts = true;
        premadeScreenPanel.SetActive(false);
        customDesignPanel.SetActive(false);
        homeScreenPanel.SetActive(true);
        resetFabricDimensions();
    }

//^ resizing PANEL 
    public void resizeFabricPanel(float panelWidth, float panelLength)
    { //resizing happens on the fabric panel using the dimensions entered.
        RectTransform panelRectTransform = arrangementFabricPanel.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(panelWidth, panelLength);
        Debug.Log("panel was resized with pixel dimensions: " + panelWidth + " x " + panelLength);
        //preObj.StoreResizedPlaneValues(panelWidth, panelLength);
    }

//! NEED TO DO 
//^ reset PANEL 
    public void resetFabricPanel()
    {

    }


//^ reset FABRIC DIMENSIONS
    public void resetFabricDimensions()
    {
        realWidth = 0;
        realLength = 0;
        widthInputField.text = "";
        lengthInputField.text = "";
        unitDropDown.value = 0;
        selectedUnitText = "Meter";
        Debug.Log("fabric dimensions reset to 0");
        errorHolder.text="";
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
