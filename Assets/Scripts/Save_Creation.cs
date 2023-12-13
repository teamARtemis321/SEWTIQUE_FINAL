// save creation

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using TMPro;

public class SaveCreations : MonoBehaviour
{
    public GameObject saveNameOverlay;
    public GameObject enlargedOverlay;
    public GameObject DesignErrorPanel;
    public TMP_Text DesignErrorText;

    //^ Added Code:
    public CanvasGroup designHistoryCG;
    public CanvasGroup customDesignCG;
    //^

    public TMP_InputField userInputField;
    public string enteredText;
    public Transform cardsContainer;

    public Button saveCreation;
    public Button saveName;
    public Button close_X;
    public Button creationCardPrefab;

    public Image image1;
    public Image image2;
    public Image image3;

    public Image SmallImage1;
    public Image SmallImage2;
    public Image SmallImage3;

    public Image BigImage1;
    public Image BigImage2;
    public Image BigImage3;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite bodice;

    public CanvasGroup overlayCanvasGroup;

    public List<Button> creationCards;
    private List<List<Sprite>> allCreationSets = new List<List<Sprite>>();
    private List<string> creationNames = new List<string>();
    private List<DateTime> creationDates = new List<DateTime>();
    public GameObject customArrangeObject;



    void Start()
    {

    }

    public void save_name_and_style()
    {
        CustomDesign2 customDesignScript = customArrangeObject.GetComponent<CustomDesign2>();

        string styleName = userInputField.text;
        Sprite neckType = image1.sprite;
        Sprite sleeve = image2.sprite;
        Sprite bodice = image3.sprite;

        List<Sprite> creationSet = new List<Sprite>
        {
            neckType, sleeve, bodice
        };
        if (string.IsNullOrEmpty(styleName))
        {
            DesignErrorPanel.SetActive(true);
            DesignErrorText.text = "Please Enter a Name";
        closeSaveName();
            return;
        }

        creationNames.Add(styleName);
        creationDates.Add(DateTime.Now);
        allCreationSets.Add(creationSet);

        Button newCard = Instantiate(creationCardPrefab, cardsContainer);

        int latestIndex = allCreationSets.Count - 1;
        string setName = creationNames[latestIndex];
        DateTime setDate = creationDates[latestIndex];

        Transform setNamePlaceholder = newCard.transform.Find("Name Placeholder");
        Transform datePlaceholder = newCard.transform.Find("Date Placeholder");
        TMP_Text setNameText = setNamePlaceholder.GetComponent<TMP_Text>();
        TMP_Text setDateText = datePlaceholder.GetComponent<TMP_Text>();
        setNameText.text = setName;
        setDateText.text = setDate.ToString("MM/dd/yyyy");

        Transform imagePlaceholder1 = newCard.transform.Find("Technical Sketch Placeholder (1)");
        Transform imagePlaceholder2 = newCard.transform.Find("Technical Sketch Placeholder (2)");
        Transform imagePlaceholder3 = newCard.transform.Find("Technical Sketch Placeholder (3)");
        SmallImage1 = imagePlaceholder1.GetComponent<Image>();
        SmallImage2 = imagePlaceholder2.GetComponent<Image>();
        SmallImage3 = imagePlaceholder3.GetComponent<Image>();
        SmallImage1.sprite = neckType;
        SmallImage2.sprite = sleeve;
        SmallImage3.sprite = bodice;

        Transform viewCreationTrans = newCard.transform.Find("View Button");
        Button viewCreation = viewCreationTrans.GetComponent<Button>();
        viewCreation.onClick.AddListener(() => viewEnlarged(newCard));
        creationCards.Add(newCard);

        Transform deleteButtonTrans = newCard.transform.Find("Delete Button");
        Button deleteButton = deleteButtonTrans.GetComponent<Button>();
        deleteButton.onClick.AddListener(() => DeleteCreation(newCard, latestIndex));
        closeSaveName();
        customDesignScript.loadPatternPieces();
        customDesignScript.showArrangementFromCustom();
    }

    public void DeleteCreation(Button cardToDelete, int index)
    {
        // Remove the data associated with this card
        if (index >= 0 && index < creationCards.Count)
        {
            creationCards.RemoveAt(index);
            creationNames.RemoveAt(index);
            creationDates.RemoveAt(index);
            allCreationSets.RemoveAt(index);
        }

        // Destroy the card GameObject
        Destroy(cardToDelete.gameObject);
    }

    public void viewEnlarged(Button clickedCard)
    {
        int index = creationCards.IndexOf(clickedCard);
        List<Sprite> creations = allCreationSets[index];
        BigImage1.sprite = creations[0];
        BigImage2.sprite = creations[1];
        BigImage3.sprite = creations[2];
        enlargedOverlay.SetActive(true);
        //^Added Code:
        designHistoryCG.interactable = false;
        designHistoryCG.blocksRaycasts = false;
    }

    public void showSaveName()
    {
        
        Sprite neckType = image1.sprite;
        Sprite sleeve = image2.sprite;
        Sprite bodice = image3.sprite;
        if (neckType == null || sleeve == null)
        {
            DesignErrorPanel.SetActive(true);
            DesignErrorText.text = "Please select a Neckline/Collar and Sleeve";
            return;
        }
        else{

            saveNameOverlay.SetActive(true);
            //^Added Code:
            customDesignCG.interactable = false;
            customDesignCG.blocksRaycasts = false;
        }
    }

    public void closeSaveName()
    {
        saveNameOverlay.SetActive(false);
        //^Added Code:
        customDesignCG.interactable = true;
        customDesignCG.blocksRaycasts = true;
    }

    public void closeEnlarged()
    {
        enlargedOverlay.SetActive(false);
        //^Added Code:
        designHistoryCG.interactable = true;
        designHistoryCG.blocksRaycasts = true;
    }
}