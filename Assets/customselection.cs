using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor;
using System;
using System.Linq;

public class CustomSelection : MonoBehaviour
{
    public PreMadePanelControls preObj;
    public GameObject homescreenpanel;
    public GameObject arrangementPanelCustom;
    public GameObject confirmBackPanel;
    public GameObject custompanelmeasurementsinput;

    //public GameObject customDesignPanel;
    public TMP_Text bustsizetext;
    public TMP_Text hipsizetext;
    public TMP_Text necksizetext;
    public TMP_Text wristsizetext;
    public TMP_Text waistsizetext;
    public TMP_Text lowwaistsizetext;
    public TMP_Text toparmsizetext;
    public TMP_Text shouldersizetext;
    public TMP_Text armholedepthsizetext;
    public TMP_Text napshouldersizetext;
    public TMP_InputField customdesignname;

    // Button references for each selection
    public Button necklineButton1;
    public Button necklineButton2;
    public Button necklineButton3;
    public Button necklineButton4;
    public Button collarButton1;
    public Button collarButton2;
    public Button sleeveButton1; 
    public Button sleeveButton2; 
    public Button sleeveButton3; 
    public Button sleeveButton4; 
    public CanvasGroup arrangementPanelCG;
    
    private RectTransform fabricRect;
    
    public Vector2 fallbackPosition = new Vector2(3000, 3000);
    public GameObject fabricPanel;

    public Button saveButton;

    public List<Image> patternImages; //^

    // Pattern Piece Prefabs
    public GameObject bodicePrefab;      
    
    // Arrangement Panel
    public GameObject arrangementPanel;

    // Selected prefabs
    //private Image selectedNecklineImage1;
    //private Image selectedNecklineImage2;
    //private Image selectedCollarImage1;
    //private Image selectedCollarImage2;
    //private Image selectedSleeveImage1;
    //private Image selectedSleeveImage2;
    //private Image selectedCuffImage1;
    //private Image selectedCuffImage2;
    //private Image selectedSleeveImage3;
    public Image emptyimage;
    private GameObject selectedObject;
    
    public float  lowwaistfloatcode, toparmfloatcode,  waistfloatcode, bustfloatcode, neckfloatcode;
    void Start()
    {
        // Add listeners to neckline, collar, and sleeve buttons
        necklineButton1.onClick.AddListener(() => SelectNeckline(necklineButton1.name));
        necklineButton2.onClick.AddListener(() => SelectNeckline(necklineButton2.name));
        necklineButton3.onClick.AddListener(() => SelectNeckline(necklineButton3.name));
        necklineButton4.onClick.AddListener(() => SelectNeckline(necklineButton4.name));
        collarButton1.onClick.AddListener(() => SelectCollar(collarButton1.name));
        collarButton2.onClick.AddListener(() => SelectCollar(collarButton2.name));
        sleeveButton1.onClick.AddListener(() => SelectSleeve(sleeveButton1.name));
        sleeveButton2.onClick.AddListener(() => SelectSleeve(sleeveButton2.name));
        sleeveButton3.onClick.AddListener(() => SelectSleeve(sleeveButton3.name));
        sleeveButton4.onClick.AddListener(() => SelectSleeve(sleeveButton4.name));

        // Add listener to the save button
        saveButton.onClick.AddListener(LoaderFunction);
    }


    /*public void AddClickEventToChildren()
    {
        foreach (Transform child in fabricPanel.transform)
        {   
            Debug.Log("click event added to" + child.name);
            EventTrigger trigger = child.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((data)=>{OnObjectClicked((PointerEventData)data, child.gameObject);});
            trigger.triggers.Add(entry);
            Debug.Log("click event added to" + child.name);
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
    */

    // public bool isNeckLineSelected;
    // public bool isCollarSelected;
    // public bool isSleeveSelected;

    void SelectNeckline(string Name)
    {   

        float.TryParse(lowwaistsizetext.text, out lowwaistfloatcode);
        float.TryParse(waistsizetext.text, out waistfloatcode);
        float.TryParse(bustsizetext.text, out bustfloatcode);
        float maxsizecodeneckline = Math.Max(Math.Max(lowwaistfloatcode, waistfloatcode), bustfloatcode);

            var (selectedNecklineImage1, selectedNecklineImage2, necktemp1, necktemp2) = CreateUIElement(Name, "NecklineImage"); // Helper function to create UI element
            
            string spritePathFrontBodice = "";
            string spritePathBackBodice = "";
            if (Name == "Square Neck Button") {
                spritePathFrontBodice = "SquareNeck_Front_Bodice_" + maxsizecodeneckline +"-removebg-preview";
                spritePathBackBodice = "SquareNeck_Back_Bodice_" + maxsizecodeneckline +"-removebg-preview";
            } else if (Name == "Bateau Neck Button") {
                spritePathFrontBodice = "BateauNeck_FrontBodice_" + maxsizecodeneckline +"-removebg-preview";
                spritePathBackBodice = "BateauNeck_BackBodice_" + maxsizecodeneckline +"-removebg-preview";
            } else if (Name == "Scoop Neck Button") {
                spritePathFrontBodice = "ScoopNeck_FrontBodice_" + maxsizecodeneckline +"-removebg-preview";
                spritePathBackBodice = "ScoopNeck_BackBodice_" + maxsizecodeneckline +"-removebg-preview";
            } else if (Name == "VNeck Button") {
                spritePathFrontBodice = "VNeck_Front_Bodice_" + maxsizecodeneckline +"-removebg-preview";
                spritePathBackBodice = "VNeck_Back_Bodice_" + maxsizecodeneckline +"-removebg-preview";
            }
            SetSpriteToImage(
            selectedNecklineImage1, 
            selectedNecklineImage2, 
            null, 
            null, 
            Name, 
            spritePathFrontBodice, 
            spritePathBackBodice,
            null,
            null); // Helper function to set sprite

            patternImages.Add(selectedNecklineImage1);
            patternImages.Add(selectedNecklineImage2);

    }

    void SelectCollar(string Name)
    {
        float.TryParse(necksizetext.text, out neckfloatcode);

        var (selectedFrontBodice, selectedBackBodice, selectedCollarImage1, temp1) = CreateUIElement(Name, "CollarImage"); // Helper function to create UI element

        string spritePathFrontBodice = "";
        string spritePathBackBodice = "";
        string spritePathCollar = "";
        if (Name == "Mandarin Collar Button") 
        {
          spritePathFrontBodice = "VNeck_Front_Bodice_" + neckfloatcode +"-removebg-preview";
          spritePathBackBodice = "VNeck_Back_Bodice_" + neckfloatcode +"-removebg-preview";
          spritePathCollar = "MandarinCollar" + neckfloatcode + "-removebg-preview";
        } 
        else if (Name == "Basic Collar Button") 
        {
          spritePathFrontBodice = "VNeck_Front_Bodice_" + neckfloatcode +"-removebg-preview";
          spritePathBackBodice = "VNeck_Back_Bodice_" + neckfloatcode +"-removebg-preview";
          spritePathCollar = "MandarinCollar" + neckfloatcode + "-removebg-preview";
        }

        SetSpriteToImage(selectedFrontBodice, selectedBackBodice, selectedCollarImage1, null , Name, spritePathFrontBodice, spritePathBackBodice, spritePathCollar, null); // Helper function to set sprite
        patternImages.Add(selectedCollarImage1);
        //patternImages.Add(selectedCollarImage2);
        patternImages.Add(selectedFrontBodice);
        patternImages.Add(selectedBackBodice);
    }

    void SelectSleeve(string Name)
    {
        float.TryParse(toparmsizetext.text, out toparmfloatcode);

        var (selectedSleeveImage1, selectedSleeveImage2, selectedCuffImage1, selectedCuffImage2) = CreateUIElement(Name, "SleeveImage"); // Helper function to create UI element
        
        string spritePathSleeve = "";
        string spritePathCuff = "";

        if (Name == "Puff Sleeve Button") {
            spritePathSleeve = "Puff_Sleeve_" + toparmfloatcode +"-removebg-preview";
            spritePathCuff = "Puff_Sleeve_Cuff_" + toparmfloatcode +"-removebg-preview";
        } else if (Name == "Bishop Sleeve Button") {
            spritePathSleeve = "BishopSleeve" + toparmfloatcode +"-removebg-preview";
            spritePathCuff = "BishopSleeveCuff" + toparmfloatcode +"-removebg-preview";
        } else if (Name == "LegMutton Sleeve Button") {
            spritePathSleeve = "LegOfMutton_Sleeve_" + toparmfloatcode +"-removebg-preview";
        } else if (Name == "Cap Sleeve Button") {
            spritePathSleeve = "Cap_Sleeve_" + toparmfloatcode +"-removebg-preview";
        }

        SetSpriteToImage(selectedSleeveImage1, selectedSleeveImage2, selectedCuffImage1, selectedCuffImage2, Name, null, null, spritePathSleeve, spritePathCuff); // Helper function to set sprite
        patternImages.Add(selectedSleeveImage1);
        patternImages.Add(selectedSleeveImage2);
    }

    // Helper function to create a UI element
    public (Image, Image, Image, Image) CreateUIElement(string pName, string name)
    {
        GameObject uiObject1 = new GameObject(name, typeof(Image));
        GameObject uiObject2 = new GameObject(name, typeof(Image));
        GameObject uiObject3 = new GameObject(name, typeof(Image));
        GameObject uiObject4 = new GameObject(name, typeof(Image));

        bool exists=false;
        foreach (RectTransform child in fabricPanel.transform)
        { 
            if(child.name==name+"(Clone)")
            {
                exists=true;
                break;
            }

            if(exists==false)
            {
                if(name=="CollarImage")
                {
                    if (name=="CollarImage" && child.name=="NecklineImage(Clone)")
                    {
                        Destroy(child);
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //FRONT BODICE
                        Debug.Log("instantiated in fabricpaanel");
                        Transform newPattern2 = Instantiate(uiObject2, fabricPanel.transform).transform; //BACK BODICE 
                        Transform newPattern3 = Instantiate(uiObject3, fabricPanel.transform).transform; //COLLAR
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                        newPattern3.localPosition = fallbackPosition;
                    }
                    else
                    {
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //FRONT BODICE
                        Transform newPattern2 = Instantiate(uiObject2, fabricPanel.transform).transform; //BACK BODICE 
                        Transform newPattern3 = Instantiate(uiObject3, fabricPanel.transform).transform; //COLLAR
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                    }
                }
            
                else 
                if(name=="NecklineImage")
                {
                    if (name=="NecklineImage" && child.name=="CollarImage(Clone)")
                    {
                        Destroy(child);
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //FRONT BODICE
                        Transform newPattern2 = Instantiate(uiObject2, fabricPanel.transform).transform; //BACK BODICE
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                    }
                    else
                    {
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //FRONT BODICE
                        Transform newPattern2 = Instantiate(uiObject2, fabricPanel.transform).transform; //BACK BODICE
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                    }
                }
            
                else 
                if (name=="SleeveImage")
                {
                    if (name=="SleeveImage" && pName=="Puff Sleeve Button")
                    {
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //SLEEVE1
                        Transform newPattern2 = Instantiate(uiObject1, fabricPanel.transform).transform; //SLEEVE2
                        Transform newPattern3 = Instantiate(uiObject3, fabricPanel.transform).transform; //CUFF
                        Transform newPattern4 = Instantiate(uiObject4, fabricPanel.transform).transform; //CUFF2
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                        newPattern3.localPosition = fallbackPosition;
                        newPattern4.localPosition = fallbackPosition;
                        
                    }

                    else
                    if (name=="SleeveImage" && pName=="Bishop Sleeve Button")
                    {
                        Transform newPattern = Instantiate(uiObject1, fabricPanel.transform).transform; //SLEEVE1
                        Transform newPattern2 = Instantiate(uiObject2, fabricPanel.transform).transform; //SLEEVE2
                        Transform newPattern3 = Instantiate(uiObject3, fabricPanel.transform).transform; //CUFF1
                        Transform newPattern4 = Instantiate(uiObject4, fabricPanel.transform).transform; //CUFF2
                        newPattern.localPosition = fallbackPosition;
                        newPattern2.localPosition = fallbackPosition;
                        newPattern3.localPosition = fallbackPosition;
                        newPattern4.localPosition = fallbackPosition;
                    }
                }
    
            }

            else
            {
                Debug.Log("name already instantiated in panel");
            }
        
        }

        return (uiObject1.GetComponent<Image>(), uiObject2.GetComponent<Image>(), uiObject3.GetComponent<Image>(), uiObject4.GetComponent<Image>());

    }

    // Helper function to set sprite to an Image component
    void SetSpriteToImage(Image imageComponent1, Image imageComponent2, Image imageComponent3, Image imageComponent4, string pName, string spritePathFrontBodice, string spritePathBackBodice, string spritePathSleeve, string spritePathCuff)
    {
        try
        {
        Sprite spriteFBodice = Resources.Load<Sprite>(spritePathFrontBodice);
        Sprite spriteBBodice = Resources.Load<Sprite>(spritePathBackBodice);
        Sprite spriteSleeve = Resources.Load<Sprite>(spritePathSleeve);
        Sprite spriteCuff = Resources.Load<Sprite>(spritePathCuff);

        //if (sprite != null) 
        //{

            if (pName == "Square Neck Button" || pName == "Bateau Neck Button" || pName == "Scoop Neck Button" || pName == "VNeck Button" ) 
            {
                imageComponent1.sprite = spriteFBodice;
                imageComponent2.sprite = spriteBBodice;
                RectTransform rectTransform1 = imageComponent1.GetComponent<RectTransform>();
                rectTransform1.sizeDelta = new Vector2(spriteFBodice.rect.width, spriteFBodice.rect.height);
                RectTransform rectTransform2 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteBBodice.rect.width, spriteBBodice.rect.height);
            } 
            else if (pName == "Mandarin Collar Button" || pName == "Basic Collar Button") 

            {
                imageComponent1.sprite = spriteFBodice;
                imageComponent2.sprite = spriteBBodice;
                imageComponent3.sprite = spriteSleeve;
                RectTransform rectTransform1 = imageComponent1.GetComponent<RectTransform>();
                rectTransform1.sizeDelta = new Vector2(spriteFBodice.rect.width, spriteBBodice.rect.height);
                RectTransform rectTransform2 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteFBodice.rect.width, spriteBBodice.rect.height);
                RectTransform rectTransform3 = imageComponent3.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteSleeve.rect.width, spriteSleeve.rect.height);
            }

            else if (pName == "Puff Sleeve Button" || pName == "Bishop Sleeve Button")
            {
                imageComponent1.sprite = spriteSleeve;
                imageComponent2.sprite = spriteSleeve;
                imageComponent3.sprite = spriteCuff;
                imageComponent4.sprite = spriteCuff;
                RectTransform rectTransform1 = imageComponent1.GetComponent<RectTransform>();
                rectTransform1.sizeDelta = new Vector2(spriteSleeve.rect.width, spriteSleeve.rect.height);
                RectTransform rectTransform2 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteSleeve.rect.width, spriteSleeve.rect.height);
                RectTransform rectTransform3 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteCuff.rect.width, spriteCuff.rect.height);
                RectTransform rectTransform4 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteCuff.rect.width, spriteCuff.rect.height);
            }

            else if (pName == "LegMutton Sleeve Button" || pName == "Cap Sleeve Button")
            {
                imageComponent1.sprite = spriteSleeve;
                imageComponent2.sprite = spriteSleeve;
                RectTransform rectTransform1 = imageComponent1.GetComponent<RectTransform>();
                rectTransform1.sizeDelta = new Vector2(spriteSleeve.rect.width, spriteSleeve.rect.height);
                RectTransform rectTransform2 = imageComponent2.GetComponent<RectTransform>();
                rectTransform2.sizeDelta = new Vector2(spriteSleeve.rect.width, spriteSleeve.rect.height);
            }
        }
        catch (NullReferenceException e)
        {
            // Handle the exception (e.g., log it, set default values, etc.)
            Debug.Log("NullReferenceException caught: " + e.Message);
        }
        
        //}
    }
    public void LoaderFunction()
    {
        //customDesignPanel.SetActive(false);
        arrangementPanelCustom.SetActive(true);
        //custompanelmeasurementsinput.SetActive(true);
        preObj.AddClickEventToChildren();
        OptimizePanelChildren();
    }

    public void CancelSave()
    {
    

    }

    //^ OG OPTI
    // public void OptimizePanelChildren()
    // {
        
    //     fabricRect = fabricPanel.GetComponent<RectTransform>();
    //      foreach (Image patternImage in patternImages)
    //     {
    //         Image instantiatedPattern = Instantiate(patternImage, fabricPanel.transform);
    //     instantiatedPattern.transform.SetParent(fabricRect, false);
    //     }

        
    //     AddClickEventToChildren();

    //     List<RectTransform> children = new List<RectTransform>();
        
    //     foreach (Transform child in fabricPanel.transform)
    //     {
    //         children.Add(child.GetComponent<RectTransform>());
    //     }

    //     children.Sort((a, b) => b.sizeDelta.y.CompareTo(a.sizeDelta.y));

    //     Vector2 currentPosition = new Vector2(0, 0);
    //     float nextYLevel = 0;

    //     bool firstBodicePlaced = false;
    //     RectTransform firstBodice = null;

    //     foreach (RectTransform child in children)
    //     {
    //         child.pivot = new Vector2(0, 0);
    //         child.anchorMin = new Vector2(0, 0);
    //         child.anchorMax = new Vector2(0, 0);
    //         Vector2 size = child.sizeDelta;
    //         bool isBodice = child.name.Contains("FRONTBODICE") || child.name.Contains("BACKBODICE");

    //         if (!firstBodicePlaced || !isBodice)
    //         {
    //             if (currentPosition.x + size.x <= fabricRect.sizeDelta.x && currentPosition.y + size.y <= fabricRect.sizeDelta.y)
    //             {
    //                 child.anchoredPosition = currentPosition;

    //                 currentPosition.x += size.x;

    //                 if (isBodice)
    //                 {
    //                     nextYLevel = size.y;
    //                     firstBodicePlaced = true;
    //                     firstBodice = child;
    //                 }
    //             }
    //             else
    //             {
    //                 child.anchoredPosition = fallbackPosition;
    //                 if (isBodice)
    //                 {
    //                     Debug.LogWarning("One of the bodices does not fit.");
    //                     if (!firstBodicePlaced)
    //                     {
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             if (firstBodicePlaced)
    //             {
    //                 Vector2 newPosition = new Vector2(0, firstBodice.anchoredPosition.y + nextYLevel);
    //                 if (newPosition.y + size.y <= fabricRect.sizeDelta.y)
    //                 {
    //                     child.anchoredPosition = newPosition;
    //                 }
    //                 else
    //                 {
    //                     child.anchoredPosition = fallbackPosition;
    //                     Debug.LogWarning("One of the bodices does not fit.");
    //                 }

    //                 firstBodicePlaced = false;
    //             }
    //         }

    //         if (currentPosition.x + size.x > fabricRect.sizeDelta.x)
    //         {
    //             currentPosition.x = 0;
    //             currentPosition.y += nextYLevel;
    //             nextYLevel = 0;
    //         }
    //     }
    // }

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

            if (currentPosition.x + size.x <= fabricRect.sizeDelta.x)
            {
                child.anchoredPosition = currentPosition;
                currentPosition.x += size.x; 
            }
            else
            {
                currentPosition.x = 0;
                currentPosition.y = currentMaxY;

                if (currentPosition.y + size.y <= fabricRect.sizeDelta.y)
                {
                    child.anchoredPosition = currentPosition;
                    currentMaxY += size.y; 
                }
                else
                {
                    child.anchoredPosition = fallbackPosition;
                }
            }
        }
    }


    public void backArrangement()
    {
        arrangementPanelCG.interactable = false;
        arrangementPanelCG.blocksRaycasts = false;
        confirmBackPanel.SetActive(true);
    }

    public void cancelBack()
    {
        confirmBackPanel.SetActive(false);
        arrangementPanelCG.interactable = true;
        arrangementPanelCG.blocksRaycasts = true;
    }
    public void confirmBack()
    {
        var imageChildren = new System.Collections.Generic.List<GameObject>();
        foreach (Transform child in fabricPanel.transform)
        {
            imageChildren.Add(child.gameObject);
        }
        foreach (GameObject child in imageChildren)
        {
            Destroy(child);
        }
        Debug.Log("Fabric panel emptied.");

        imageChildren.Clear();

        homescreenpanel.SetActive(true);
        confirmBackPanel.SetActive(false);
        arrangementPanelCustom.SetActive(false);
        arrangementPanelCG.interactable = true;
        arrangementPanelCG.blocksRaycasts = true;

    }

    }





