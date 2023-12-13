using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;

public class PreMadePanelControls : MonoBehaviour
{
    public TMP_Text premade_type;

//^CHOSEN PREFAB OBJECT
    public GameObject prefabToRetrieve;
    public GameObject MeasureError;
    public GameObject ArrangementError;
    //Name store
    public string chosenPattern;
    public Button okbutton;

//^CLICKED ON pattern piece:
    private GameObject selectedObject;

//List to store pattern image prefabs
    public List<GameObject> patternImages;

//un-inserted image position: 
    public Vector2 fallbackPosition = new Vector2(3000, 3000);

//PREFAB SETS
    //^ LONG SLEEVE TSHIRT - PREFABS
    public GameObject XS_LST;
    public GameObject S_LST;
    public GameObject M_LST;
    public GameObject L_LST;
    public GameObject XL_LST;
    public GameObject customMeasurementsError;
    public GameObject DesignError;

    //^ SHIRRED TOP - PREFABS
    public GameObject XS_ST;
    public GameObject S_ST;
    public GameObject M_ST;
    public GameObject L_ST;
    public GameObject XL_ST;

    //^ HALTER NECK TOP - PREFABS
    public GameObject XS_HNT;
    public GameObject S_HNT;
    public GameObject M_HNT;
    public GameObject L_HNT;
    public GameObject XL_HNT;

    //^ SHORT SLEEVE TSHIRT - PREFABS
    public GameObject XS_SST;
    public GameObject S_SST;
    public GameObject M_SST;
    public GameObject L_SST;
    public GameObject XL_SST;

    //^ PEPLUM TOP - PREFABS
    public GameObject XS_PPT;
    public GameObject S_PPT;
    public GameObject M_PPT;
    public GameObject L_PPT;
    public GameObject XL_PPT;

//Premade Pattern Size Buttons
    //^ LONG SLEEVE TSHIRT 
    public Button XS_LST_button;
    public Button S_LST_button;
    public Button M_LST_button;
    public Button L_LST_button;
    public Button XL_LST_button;

    //^ SHIRRED TOP 
    public Button XS_ST_button;
    public Button S_ST_button;
    public Button M_ST_button;
    public Button L_ST_button;
    public Button XL_ST_button;

    //^ HALTER NECK TOP
    public Button XS_HNT_button;
    public Button S_HNT_button;
    public Button M_HNT_button;
    public Button L_HNT_button;
    public Button XL_HNT_button;

    //^ SHORT SLEEVE TSHIRT 
    public Button XS_SST_button;
    public Button S_SST_button;
    public Button M_SST_button;
    public Button L_SST_button;
    public Button XL_SST_button;

    //^ PEPLUM TOP 
    public Button XS_PPT_button;
    public Button S_PPT_button;
    public Button M_PPT_button;
    public Button L_PPT_button;
    public Button XL_PPT_button;

//Panels and Overlays
    public GameObject fabricDimensionOverlay;
    public GameObject premadePanel;
    public GameObject arrangementPanel;
    public GameObject fabricPanel;
    public GameObject confirmBackArrangement;
    public GameObject homeScreenPanel;
    public CanvasGroup premadePanelCG;
    public CanvasGroup arrangementPanelCG;
    private RectTransform fabricRect;


//^ STORING CHOSEN PATTERN NAME
//* attached to the onclick of every size button. 

    public void storeChosenPatternName(Button button)
    {
        chosenPattern = button.name;

        if(string.IsNullOrEmpty(chosenPattern))
        {
            Debug.Log("Button name of chosen pattern not stored");
        }
        else
        {
            Debug.Log("chosen pattern is: " + chosenPattern);
            premadePanel.SetActive(false);
            arrangementPanel.SetActive(true);
            patternImages = new List<GameObject>();
            loadPatternPieces(chosenPattern, patternImages);
            resetChoice();
            clearImageList();
            Debug.Log("current local list count after loading and clearing global list: " + patternImages.Count);
        }   
    }

//^ LOADING PATTERN PREFABS INTO SCENE
        public void loadPatternPieces (string patternChoice, List<GameObject> imageList)
    {
        Debug.Log("loading the " + patternChoice + " pattern images");
        
        switch(patternChoice)
        {
            //^longsleeve
            case "XS_LST":
                prefabToRetrieve = XS_LST;
                break;
            
            case "S_LST":
                prefabToRetrieve = S_LST;
                break;
            
            case "M_LST":
                prefabToRetrieve = M_LST;
                break;
            
            case "L_LST":
                prefabToRetrieve = L_LST;
                break;

            case "XL_LST":
                prefabToRetrieve = XL_LST;
                break;

            //^shirredtop

            case "XS_ST":
                prefabToRetrieve = XS_ST;
                break;
            
            case "S_ST":
                prefabToRetrieve = S_ST;
                break;
            
            case "M_ST":
                prefabToRetrieve = M_ST;
                break;
            
            case "L_ST":
                prefabToRetrieve = L_ST;
                break;

            case "XL_ST":
                prefabToRetrieve = XL_ST;
                break;

            //^halterneck
            case "XS_HNT":
                prefabToRetrieve = XS_HNT;
                break;
            
            case "S_HNT":
                prefabToRetrieve = S_HNT;
                break;
            
            case "M_HNT":
                prefabToRetrieve = M_HNT;
                break;
            
            case "L_HNT":
                prefabToRetrieve = L_HNT;
                break;

            case "XL_HNT":
                prefabToRetrieve = XL_HNT;
                break;

            //^shortsleeve
            case "XS_SST":
                prefabToRetrieve = XS_SST;
                break;
            
            case "S_SST":
                prefabToRetrieve = S_SST;
                break;
            
            case "M_SST":
                prefabToRetrieve = M_SST;
                break;
            
            case "L_SST":
                prefabToRetrieve = L_SST;
                break;

            case "XL_SST":
                prefabToRetrieve = XL_SST;
                break;

            //^peplum
            case "XS_PPT":
                prefabToRetrieve = XS_PPT;
                break;
            
            case "S_PPT":
                prefabToRetrieve = S_PPT;
                break;
            
            case "M_PPT":
                prefabToRetrieve = M_PPT;
                break;
            
            case "L_PPT":
                prefabToRetrieve = L_PPT;
                break;

            case "XL_PPT":
                prefabToRetrieve = XL_PPT;
                break;
        }
        
        if (prefabToRetrieve == null)
        {
            Debug.Log("prefab could not be retrieved, not found");
        }

        else
        {   //^ INSTANTIATING PREFABS
            
            foreach (Transform child in fabricPanel.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (RectTransform child in prefabToRetrieve.transform)
            {
                Debug.Log("Prefab dimesions before instantiating: " + child.sizeDelta);
                imageList.Add(child.gameObject);
                Transform newImage = Instantiate(child, fabricPanel.transform).transform;
                newImage.localPosition = new Vector3(3000,0,0);
            }

            Debug.Log("List count after retrieving pattern images under prefab: " + imageList.Count);
            //! call optimization here
            AddClickEventToChildren();
            OptimizePanelChildren();
        }
    }

//^OPTIMIZE ARRANGEMENT ORIGINAL
/*
public void OptimizePanelChildren()
{
    fabricRect = fabricPanel.GetComponent<RectTransform>();
    List<RectTransform> children = new List<RectTransform>();
    foreach (RectTransform child in fabricPanel.transform)
    {
        children.Add(child.GetComponent<RectTransform>());
    }

    children.Sort((a, b) =>
    {
        bool isABodice = a.name.ToUpperInvariant().Contains("BODICE");
        bool isBBodice = b.name.ToUpperInvariant().Contains("BODICE");

        if (isABodice && !isBBodice) return -1;
        if (!isABodice && isBBodice) return 1;

        return b.sizeDelta.sqrMagnitude.CompareTo(a.sizeDelta.sqrMagnitude);
    });

    Vector2 currentPosition = new Vector2(0, 0);
    bool bodicePlaced = false;
    float rightmostX = 0; 

    foreach (RectTransform child in children)
    {
        child.pivot = new Vector2(0, 0);
        child.anchorMin = new Vector2(0, 0);
        child.anchorMax = new Vector2(0, 0);
        Vector2 size = child.sizeDelta;
        bool isBodice = child.name.ToUpperInvariant().Contains("BODICE");

        if (isBodice)
        {
            if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
            {
                child.anchoredPosition = currentPosition;
                currentPosition.y += size.y;
                bodicePlaced = true;
                rightmostX = Mathf.Max(rightmostX, size.x);
            }
            else
            {
                child.anchoredPosition = fallbackPosition; 
            }
        }
        else
        {
            if (bodicePlaced)
            {
                Vector2 newPosition = new Vector2(rightmostX, 0);
                if (newPosition.x + size.x <= fabricRect.sizeDelta.x)
                {
                    child.anchoredPosition = newPosition;
                }
                else
                {
                    newPosition = new Vector2(0, currentPosition.y);
                    if (newPosition.y + size.y <= fabricRect.sizeDelta.y)
                    {
                        child.anchoredPosition = newPosition;
                        currentPosition.y += size.y;
                    }
                    else
                    {
                        child.anchoredPosition = fallbackPosition;
                    }
                }
            }
            else
            {
                if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
                {
                    child.anchoredPosition = currentPosition;
                    currentPosition.y += size.y;
                    rightmostX = Mathf.Max(rightmostX, size.x);
                }
                else
                {
                    child.anchoredPosition = fallbackPosition;
                }
            }
        }
    }
}
*/
//!ATTEMPT 2 - WORKING FOR PREMADE
// public void OptimizePanelChildren()
// {
//     fabricRect = fabricPanel.GetComponent<RectTransform>();
//     List<RectTransform> children = new List<RectTransform>();

//     foreach (RectTransform child in fabricPanel.transform)
//     {
//         children.Add(child.GetComponent<RectTransform>());
//     }

//     children.Sort((a, b) =>
//     {
//         bool isABodice = a.name.ToUpperInvariant().Contains("BODICE");
//         bool isBBodice = b.name.ToUpperInvariant().Contains("BODICE");

//         if (isABodice && !isBBodice) return -1;
//         if (!isABodice && isBBodice) return 1;

//         float sizeA = a.sizeDelta.x * a.sizeDelta.y;
//         float sizeB = b.sizeDelta.x * b.sizeDelta.y;
//         return sizeB.CompareTo(sizeA);
//     });

//     Vector2 currentPosition = new Vector2(0, 0);
//     float rightmostX = 0; 
//     float currentMaxY = 0; 

//     foreach (RectTransform child in children)
//     {
//         Vector2 size = child.sizeDelta;
//         bool isBodice = child.name.ToUpperInvariant().Contains("BODICE");

//         child.pivot = new Vector2(0, 0);
//         child.anchorMin = new Vector2(0, 0);
//         child.anchorMax = new Vector2(0, 0);

//         if (isBodice)
//         {
//             if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
//             {
//                 child.anchoredPosition = currentPosition;
//                 currentPosition.y += size.y; 
//                 rightmostX = Mathf.Max(rightmostX, size.x); 
//                 currentMaxY = currentPosition.y; 
//             }
//             else
//             {
//                 child.anchoredPosition = fallbackPosition;
//             }
//         }
//     }

//     currentPosition = new Vector2(rightmostX, 0);

//     foreach (RectTransform child in children.Where(c => !c.name.ToUpperInvariant().Contains("BODICE")))
//     {
//         Vector2 size = child.sizeDelta;

//         if (currentPosition.x + size.x <= fabricRect.sizeDelta.x)
//         {
//             child.anchoredPosition = currentPosition;
//             currentPosition.x += size.x; 
//         }
//         else
//         {
//             currentPosition.x = 0;
//             currentPosition.y = currentMaxY;

//             if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
//             {
//                 child.anchoredPosition = currentPosition;
//                 currentMaxY += size.y; 
//             }
//             else
//             {
//                 child.anchoredPosition = fallbackPosition;
//             }
//         }
//     }
// }

//! ATTEMPT 3 - TRYING TO MAKE CUSTOM WORK
public void OptimizePanelChildren()
{
    fabricRect = fabricPanel.GetComponent<RectTransform>();
    List<RectTransform> children = new List<RectTransform>();

    foreach (RectTransform child in fabricPanel.transform)
    {
        children.Add(child.GetComponent<RectTransform>());
    }

    children.Sort((a, b) =>
    {
        bool isABodice = a.name.ToUpperInvariant().Contains("BODICE");
        bool isBBodice = b.name.ToUpperInvariant().Contains("BODICE");

        if (isABodice && !isBBodice) return -1;
        if (!isABodice && isBBodice) return 1;

        float sizeA = a.sizeDelta.x * a.sizeDelta.y;
        float sizeB = b.sizeDelta.x * b.sizeDelta.y;
        return sizeB.CompareTo(sizeA);
    });

    Vector2 currentPosition = new Vector2(0, 0);
    float rightmostX = 0; 
    float currentMaxY = 0; 

    foreach (RectTransform child in children)
    {
        Vector2 size = child.sizeDelta;
        bool isBodice = child.name.ToUpperInvariant().Contains("BODICE");

        child.pivot = new Vector2(0, 0);
        child.anchorMin = new Vector2(0, 0);
        child.anchorMax = new Vector2(0, 0);

        if (isBodice)
        {
            if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
            {
                child.anchoredPosition = currentPosition;
                currentPosition.y += size.y; 
                rightmostX = Mathf.Max(rightmostX, size.x); 
                currentMaxY = currentPosition.y; 
            }
            else
            {
                child.anchoredPosition = fallbackPosition;
            }
        }
    }

    currentPosition = new Vector2(rightmostX, 0);

    foreach (RectTransform child in children.Where(c => !c.name.ToUpperInvariant().Contains("BODICE")))
    {
        Vector2 size = child.sizeDelta;

        // Check horizontal space before placing
        if (currentPosition.x + size.x > fabricRect.sizeDelta.x)
        {
            currentPosition.x = 0;
            currentPosition.y = currentMaxY;
        }

        // Check vertical space before placing
        if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
        {
            child.anchoredPosition = currentPosition;
            currentPosition.x += size.x;

            // Update currentMaxY if needed
            if (currentPosition.x == 0)
            {
                currentMaxY += size.y;
            }
        }
        else
        {
            child.anchoredPosition = fallbackPosition;
        }
    }
}


//^ CLICK TO CONTROL PATTERN
    public void AddClickEventToChildren()
    {   
        OptimizePanelChildren();
        foreach (Transform child in fabricPanel.transform)
        {
            EventTrigger trigger = child.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((data)=>{OnObjectClicked((PointerEventData)data, child.gameObject);});
            trigger.triggers.Add(entry);
        }
    }

    public void OnObjectClicked(PointerEventData data, GameObject obj)
    {
        selectedObject = obj;
        Debug.Log("Selected object: " + selectedObject.name);
    }

    public void MoveObjectLeft()
    { 
            Debug.Log("moving piece left");
            RectTransform objRect = selectedObject.GetComponent<RectTransform>();
            RectTransform panelRect = fabricPanel.GetComponent<RectTransform>();

            Vector2 newPosition = objRect.anchoredPosition + new Vector2(-10, 0);
            if(newPosition.x >=0 &&
               newPosition.x<= panelRect.sizeDelta.x - objRect.sizeDelta.x &&
               newPosition.y >=0 &&
               newPosition.y <= panelRect.sizeDelta.y - objRect.sizeDelta.y)
            {
                objRect.anchoredPosition = newPosition;
            }
            
    }

    public void MoveObjectRight()
    {       
            Debug.Log("moving piece right");
            RectTransform objRect = selectedObject.GetComponent<RectTransform>();
            RectTransform panelRect = fabricPanel.GetComponent<RectTransform>();

            Vector2 newPosition = objRect.anchoredPosition + new Vector2(10, 0);
            if(newPosition.x >= 0 &&
               newPosition.x <= panelRect.sizeDelta.x - objRect.sizeDelta.x)
            {
                objRect.anchoredPosition = newPosition;
            }
    }

    public void MoveObjectUp()
    {
            Debug.Log("moving piece up");
            RectTransform objRect = selectedObject.GetComponent<RectTransform>();
            RectTransform panelRect = fabricPanel.GetComponent<RectTransform>();

            Vector2 newPosition = objRect.anchoredPosition + new Vector2(0, 10);
            if(newPosition.y >= 0 &&
               newPosition.y <= panelRect.sizeDelta.y - objRect.sizeDelta.y)
            {
                objRect.anchoredPosition = newPosition;
            }
    }

    public void MoveObjectDown()
    {
            Debug.Log("moving piece down");
            RectTransform objRect = selectedObject.GetComponent<RectTransform>();
            RectTransform panelRect = fabricPanel.GetComponent<RectTransform>();

            Vector2 newPosition = objRect.anchoredPosition + new Vector2(0, -10);
            if(newPosition.y >= 0 &&
               newPosition.y <= panelRect.sizeDelta.y - objRect.sizeDelta.y)
            {
                objRect.anchoredPosition = newPosition;
            }

    }

    
//^ MISC METHODS
    public void changeDimensionCallOverlay()
    {
        premadePanelCG.interactable = false;
        premadePanelCG.blocksRaycasts = false;
        fabricDimensionOverlay.SetActive(true);
    }

    public void clearImageList ()
    {   
        Debug.Log("Clearing the global image list - list currently has " + patternImages.Count + " elements.");
        patternImages.Clear(); 
        Debug.Log("After clearing: " + patternImages.Count + " elements");
    }

    public void resetChoice()
    {
        chosenPattern = "";
        Debug.Log("chosen pattern store name is reset to " + chosenPattern);
    }

//^AFTER PRESSING 'BACK' FROM ARRANGEMENT SCREEN
    public void backArrangement()
    {
        arrangementPanel.SetActive(true);
        arrangementPanelCG.interactable = false;
        arrangementPanelCG.blocksRaycasts = false;
        confirmBackArrangement.SetActive(true);
    }
    
    public void cancelBack()
    {
        confirmBackArrangement.SetActive(false);
        arrangementPanelCG.interactable = true;
        arrangementPanelCG.blocksRaycasts = true;
    }

    public void closeCustomMeasureError()
    {
        customMeasurementsError.SetActive(false);
    }
    public void showArrangeError()
    {
        ArrangementError.SetActive(true);
    }
    public void closeArrangeError()
    {
        ArrangementError.SetActive(false);
    }
    public void closeDesignError()
    {
        DesignError.SetActive(false);
    }
     public void closeMeasureError()
    {
        MeasureError.SetActive(false);
    }

    public void confirmBack()
    {
        var imageChildren = new System.Collections.Generic.List<GameObject>();
        foreach (Transform child in fabricPanel.transform)
        {
            Destroy(child.gameObject);
        }

        Debug.Log("Fabric Panel emptied.");
        resetChoice();
        confirmBackArrangement.SetActive(false);
        premadePanel.SetActive(false);
        homeScreenPanel.SetActive(true);
        arrangementPanel.SetActive(false);
        arrangementPanelCG.interactable = true;
        arrangementPanelCG.blocksRaycasts = true;

    }

    public void save_long()
    {
        premade_type.text = "long";
    }

    public void save_shirred()
    {
        premade_type.text = "shirred";
    }

    public void save_halter()
    {
        premade_type.text = "halter";
    }

    public void save_short()
    {
        premade_type.text = "short";
    }

    void Start()
    {   
        okbutton.onClick.AddListener(closeArrangeError);
    }

    void Update()
    {
        
    }
}
