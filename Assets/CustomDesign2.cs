using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor;
using System;
using System.Linq;

public class CustomDesign2 : MonoBehaviour
{   
    //^ OBJECTS 
    public PreMadePanelControls preObj;

    //^ PANELS
    public GameObject homescreenpanel;
    public GameObject arrangementPanel;
    public GameObject arrangementPanelParent;

    public GameObject CustomDesignPanel;
    public GameObject confirmBackPanel;
    public GameObject savePanel;
    public GameObject fabricInputPanel;
    public CanvasGroup designScreenCG;
    public RectTransform fabricRect;

    //^ TEXT FIELDS
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
    
    //^BUTTONS
    public Button SQUARE_NECK;
    public Button SCOOP_NECK;
    public Button V_NECK;
    public Button BATEAU;
    public Button MANDARIN_COLLAR;
    public Button BASIC_COLLAR;
    public Button PUFF_SLEEVE; 
    public Button BISHOP_SLEEVE; 
    public Button LEGOFMUTTON_SLEEVE; 
    public Button CAP_SLEEVE;

    public Button saveButton;

    public GameObject SQUARE_NECK_6;
    public GameObject SQUARE_NECK_8;
    public GameObject SQUARE_NECK_10;
    public GameObject SQUARE_NECK_12;
    public GameObject SQUARE_NECK_14;
    public GameObject SQUARE_NECK_16;
    public GameObject SQUARE_NECK_18;
    public GameObject SQUARE_NECK_20;
    public GameObject SQUARE_NECK_22;
    public GameObject SQUARE_NECK_24;
    public GameObject SQUARE_NECK_26;
    
    public GameObject SCOOP_NECK_6;
    public GameObject SCOOP_NECK_8;
    public GameObject SCOOP_NECK_10;
    public GameObject SCOOP_NECK_12;
    public GameObject SCOOP_NECK_14;
    public GameObject SCOOP_NECK_16;
    public GameObject SCOOP_NECK_18;
    public GameObject SCOOP_NECK_20;
    public GameObject SCOOP_NECK_22;
    public GameObject SCOOP_NECK_24;
    public GameObject SCOOP_NECK_26;

    public GameObject V_NECK_6;
    public GameObject V_NECK_8;
    public GameObject V_NECK_10;
    public GameObject V_NECK_12;
    public GameObject V_NECK_14;
    public GameObject V_NECK_16;
    public GameObject V_NECK_18;
    public GameObject V_NECK_20;
    public GameObject V_NECK_22;
    public GameObject V_NECK_24;
    public GameObject V_NECK_26;

    public GameObject BATEAU_6;
    public GameObject BATEAU_8;
    public GameObject BATEAU_10;
    public GameObject BATEAU_12;
    public GameObject BATEAU_14;
    public GameObject BATEAU_16;
    public GameObject BATEAU_18;
    public GameObject BATEAU_20;
    public GameObject BATEAU_22;
    public GameObject BATEAU_24;
    public GameObject BATEAU_26;

    public GameObject MANDARIN_COLLAR_6;
    public GameObject MANDARIN_COLLAR_8;
    public GameObject MANDARIN_COLLAR_10;
    public GameObject MANDARIN_COLLAR_12;
    public GameObject MANDARIN_COLLAR_14;
    public GameObject MANDARIN_COLLAR_16;
    public GameObject MANDARIN_COLLAR_18;
    public GameObject MANDARIN_COLLAR_20;
    public GameObject MANDARIN_COLLAR_22;
    public GameObject MANDARIN_COLLAR_24;
    public GameObject MANDARIN_COLLAR_26;

    public GameObject BASIC_COLLAR_6;
    public GameObject BASIC_COLLAR_8;
    public GameObject BASIC_COLLAR_10;
    public GameObject BASIC_COLLAR_12;
    public GameObject BASIC_COLLAR_14;
    public GameObject BASIC_COLLAR_16;
    public GameObject BASIC_COLLAR_18;
    public GameObject BASIC_COLLAR_20;
    public GameObject BASIC_COLLAR_22;
    public GameObject BASIC_COLLAR_24;
    public GameObject BASIC_COLLAR_26;

    public GameObject PUFF_SLEEVE_6;
    public GameObject PUFF_SLEEVE_8;
    public GameObject PUFF_SLEEVE_10;
    public GameObject PUFF_SLEEVE_12;
    public GameObject PUFF_SLEEVE_14;
    public GameObject PUFF_SLEEVE_16;
    public GameObject PUFF_SLEEVE_18;
    public GameObject PUFF_SLEEVE_20;
    public GameObject PUFF_SLEEVE_22;
    public GameObject PUFF_SLEEVE_24;
    public GameObject PUFF_SLEEVE_26;

    public GameObject BISHOP_SLEEVE_6;
    public GameObject BISHOP_SLEEVE_8;
    public GameObject BISHOP_SLEEVE_10;
    public GameObject BISHOP_SLEEVE_12;
    public GameObject BISHOP_SLEEVE_14;
    public GameObject BISHOP_SLEEVE_16;
    public GameObject BISHOP_SLEEVE_18;
    public GameObject BISHOP_SLEEVE_20;
    public GameObject BISHOP_SLEEVE_22;
    public GameObject BISHOP_SLEEVE_24;
    public GameObject BISHOP_SLEEVE_26;

    public GameObject LEGOFMUTTON_SLEEVE_6;
    public GameObject LEGOFMUTTON_SLEEVE_8;
    public GameObject LEGOFMUTTON_SLEEVE_10;
    public GameObject LEGOFMUTTON_SLEEVE_12;
    public GameObject LEGOFMUTTON_SLEEVE_14;
    public GameObject LEGOFMUTTON_SLEEVE_16;
    public GameObject LEGOFMUTTON_SLEEVE_18;
    public GameObject LEGOFMUTTON_SLEEVE_20;
    public GameObject LEGOFMUTTON_SLEEVE_22;
    public GameObject LEGOFMUTTON_SLEEVE_24;
    public GameObject LEGOFMUTTON_SLEEVE_26;

    public GameObject CAP_SLEEVE_6;
    public GameObject CAP_SLEEVE_8;
    public GameObject CAP_SLEEVE_10;
    public GameObject CAP_SLEEVE_12;
    public GameObject CAP_SLEEVE_14;
    public GameObject CAP_SLEEVE_16;
    public GameObject CAP_SLEEVE_18;
    public GameObject CAP_SLEEVE_20;
    public GameObject CAP_SLEEVE_22;
    public GameObject CAP_SLEEVE_24;
    public GameObject CAP_SLEEVE_26;

    //^MISC
    public string chosenNecklineName;
    public string chosenSleeveName;
    public GameObject selectedCollarNeckLine;
    public GameObject selectedSleeve;

    public float lowwaistfloatcode = 0.0f;
    public float toparmfloatcode = 0.0f;
    public float waistfloatcode = 0.0f;
    public float bustfloatcode = 0.0f;
    public float neckfloatcode = 0.0f;

    public float maxsizecodeneckline=0.0f;




    //^attach this method to each neckline or collar button 
    
    public void SelectNeckLine(Button button)
    {
        //once clicked, take the name of the button, take the size code, and find the suitable prefab. store it in the selectedneckline field.
        //do not send anywhere or do anything 
        float.TryParse(lowwaistsizetext.text, out lowwaistfloatcode);
        float.TryParse(waistsizetext.text, out waistfloatcode);
        float.TryParse(bustsizetext.text, out bustfloatcode);
        maxsizecodeneckline = Math.Max(Math.Max(lowwaistfloatcode, waistfloatcode), bustfloatcode);
        chosenNecklineName = button.name;
    }

    public void SelectSleeve(Button button)
    {
        float.TryParse(lowwaistsizetext.text, out lowwaistfloatcode);
        float.TryParse(waistsizetext.text, out waistfloatcode);
        float.TryParse(bustsizetext.text, out bustfloatcode);
        float.TryParse(toparmsizetext.text, out toparmfloatcode);
        chosenSleeveName = button.name;
    }

    //^RUN THIS WHEN YOU HIT SAVE
    public void loadPatternPieces()
    {
        var imageChildren = new System.Collections.Generic.List<GameObject>();
        foreach (Transform child in arrangementPanel.transform)
        {
            imageChildren.Add(child.gameObject);
        }
        foreach (GameObject child in imageChildren)
        {
            Destroy(child);
        }
        Debug.Log("Fabric panel emptied before loading.");

        imageChildren.Clear();
        Debug.Log("Loading the selected pieces");
        if(maxsizecodeneckline == 0.0f || toparmfloatcode == 0.0f)
        {
            Debug.Log("No user measurements input!");
        }
        switch(chosenNecklineName+"_"+maxsizecodeneckline)
        {
            case "SQUARE_NECK_6":
                selectedCollarNeckLine = SQUARE_NECK_6;
                break;
            case "SQUARE_NECK_8":
                selectedCollarNeckLine = SQUARE_NECK_8;
                break;            
            case "SQUARE_NECK_10":
                selectedCollarNeckLine = SQUARE_NECK_10;
                break;            
            case "SQUARE_NECK_12":
                selectedCollarNeckLine = SQUARE_NECK_12;
                break;
            case "SQUARE_NECK_14":
                selectedCollarNeckLine = SQUARE_NECK_14;
                break;
            case "SQUARE_NECK_16":
                selectedCollarNeckLine = SQUARE_NECK_16;
                break;
            case "SQUARE_NECK_18":
                selectedCollarNeckLine = SQUARE_NECK_18;
                break;
            case "SQUARE_NECK_20":
                selectedCollarNeckLine = SQUARE_NECK_20;
                break;
            case "SQUARE_NECK_22":
                selectedCollarNeckLine = SQUARE_NECK_22;
                break;
            case "SQUARE_NECK_24":
                selectedCollarNeckLine = SQUARE_NECK_24;
                break;
            case "SQUARE_NECK_26":
                selectedCollarNeckLine = SQUARE_NECK_26;
                break;


            case "SCOOP_NECK_6":
                selectedCollarNeckLine = SCOOP_NECK_6;
                break;
            case "SCOOP_NECK_8":
                selectedCollarNeckLine = SCOOP_NECK_8;
                break;
            case "SCOOP_NECK_10":
                selectedCollarNeckLine = SCOOP_NECK_10;
                break;
            case "SCOOP_NECK_12":
                selectedCollarNeckLine = SCOOP_NECK_12;
                break;
            case "SCOOP_NECK_14":
                selectedCollarNeckLine = SCOOP_NECK_14;
                break;
            case "SCOOP_NECK_16":
                selectedCollarNeckLine = SCOOP_NECK_16;
                break;
            case "SCOOP_NECK_18":
                selectedCollarNeckLine = SCOOP_NECK_18;
                break;
            case "SCOOP_NECK_20":
                selectedCollarNeckLine = SCOOP_NECK_20;
                break;
            case "SCOOP_NECK_22":
                selectedCollarNeckLine = SCOOP_NECK_22;
                break;
            case "SCOOP_NECK_24":
                selectedCollarNeckLine = SCOOP_NECK_24;
                break;
            case "SCOOP_NECK_26":
                selectedCollarNeckLine = SCOOP_NECK_26;
                break;

            case "V_NECK_6":
                selectedCollarNeckLine = V_NECK_6;
                break;
            case "V_NECK_8":
                selectedCollarNeckLine = V_NECK_8;
                break;
            case "V_NECK_10":
                selectedCollarNeckLine = V_NECK_10;
                break;
            case "V_NECK_12":
                selectedCollarNeckLine = V_NECK_12;
                break;
            case "V_NECK_14":
                selectedCollarNeckLine = V_NECK_14;
                break;
            case "V_NECK_16":
                selectedCollarNeckLine = V_NECK_16;
                break;
            case "V_NECK_18":
                selectedCollarNeckLine = V_NECK_18;
                break;
            case "V_NECK_20":
                selectedCollarNeckLine = V_NECK_20;
                break;
            case "V_NECK_22":
                selectedCollarNeckLine = V_NECK_22;
                break;
            case "V_NECK_24":
                selectedCollarNeckLine = V_NECK_24;
                break;
            case "V_NECK_26":
                selectedCollarNeckLine = V_NECK_26;
                break;

            case "BATEAU_6":
                selectedCollarNeckLine = BATEAU_6;
                break;
            case "BATEAU_8":
                selectedCollarNeckLine = BATEAU_8;
                break;
            case "BATEAU_10":
                selectedCollarNeckLine = BATEAU_10;
                break;
            case "BATEAU_12":
                selectedCollarNeckLine = BATEAU_12;
                break;
            case "BATEAU_14":
                selectedCollarNeckLine = BATEAU_14;
                break;
            case "BATEAU_16":
                selectedCollarNeckLine = BATEAU_16;
                break;
            case "BATEAU_18":
                selectedCollarNeckLine = BATEAU_18;
                break;
            case "BATEAU_20":
                selectedCollarNeckLine = BATEAU_20;
                break;
            case "BATEAU_22":
                selectedCollarNeckLine = BATEAU_22;
                break;
            case "BATEAU_24":
                selectedCollarNeckLine = BATEAU_24;
                break;
            case "BATEAU_26":
                selectedCollarNeckLine = BATEAU_26;
                break;

            case "MANDARIN_COLLAR_6":
                selectedCollarNeckLine = MANDARIN_COLLAR_6;
                break;
            case "MANDARIN_COLLAR_8":
                selectedCollarNeckLine = MANDARIN_COLLAR_8;
                break;
            case "MANDARIN_COLLAR_10":
                selectedCollarNeckLine = MANDARIN_COLLAR_10;
                break;
            case "MANDARIN_COLLAR_12":
                selectedCollarNeckLine = MANDARIN_COLLAR_12;
                break;
            case "MANDARIN_COLLAR_14":
                selectedCollarNeckLine = MANDARIN_COLLAR_14;
                break;
            case "MANDARIN_COLLAR_16":
                selectedCollarNeckLine = MANDARIN_COLLAR_16;
                break;
            case "MANDARIN_COLLAR_18":
                selectedCollarNeckLine = MANDARIN_COLLAR_18;
                break;
            case "MANDARIN_COLLAR_20":
                selectedCollarNeckLine = MANDARIN_COLLAR_20;
                break;
            case "MANDARIN_COLLAR_22":
                selectedCollarNeckLine = MANDARIN_COLLAR_22;
                break;
            case "MANDARIN_COLLAR_24":
                selectedCollarNeckLine = MANDARIN_COLLAR_24;
                break;
            case "MANDARIN_COLLAR_26":
                selectedCollarNeckLine = MANDARIN_COLLAR_26;
                break;

            case "BASIC_COLLAR_6":
                selectedCollarNeckLine = BASIC_COLLAR_6;
                break;
            case "BASIC_COLLAR_8":
                selectedCollarNeckLine = BASIC_COLLAR_8;
                break;
            case "BASIC_COLLAR_10":
                selectedCollarNeckLine = BASIC_COLLAR_10;
                break;
            case "BASIC_COLLAR_12":
                selectedCollarNeckLine = BASIC_COLLAR_12;
                break;
            case "BASIC_COLLAR_14":
                selectedCollarNeckLine = BASIC_COLLAR_14;
                break;
            case "BASIC_COLLAR_16":
                selectedCollarNeckLine = BASIC_COLLAR_16;
                break;
            case "BASIC_COLLAR_18":
                selectedCollarNeckLine = BASIC_COLLAR_18;
                break;
            case "BASIC_COLLAR_20":
                selectedCollarNeckLine = BASIC_COLLAR_20;
                break;
            case "BASIC_COLLAR_22":
                selectedCollarNeckLine = BASIC_COLLAR_22;
                break;
            case "BASIC_COLLAR_24":
                selectedCollarNeckLine = BASIC_COLLAR_24;
                break;
            case "BASIC_COLLAR_26":
                selectedCollarNeckLine = BASIC_COLLAR_26;
                break;
        }

        if(selectedCollarNeckLine==null)
        {
            Debug.Log("selected neckline/collar pattern could not be found");
        }

        else
        {
            foreach (Transform child in selectedCollarNeckLine.transform)
            {
                Transform newImage = Instantiate(child, arrangementPanel.transform).transform;
                newImage.localPosition = new Vector3(3000,0,0);
            }
        }

        switch(chosenSleeveName+"_"+toparmfloatcode)
        {
            case "PUFF_SLEEVE_6":
                selectedSleeve = PUFF_SLEEVE_6;
                break;
            case "PUFF_SLEEVE_8":
                selectedSleeve = PUFF_SLEEVE_8;
                break;
            case "PUFF_SLEEVE_10":
                selectedSleeve = PUFF_SLEEVE_10;
                break;
            case "PUFF_SLEEVE_12":
                selectedSleeve = PUFF_SLEEVE_12;
                break;
            case "PUFF_SLEEVE_14":
                selectedSleeve = PUFF_SLEEVE_14;
                break;
            case "PUFF_SLEEVE_16":
                selectedSleeve = PUFF_SLEEVE_16;
                break;
            case "PUFF_SLEEVE_18":
                selectedSleeve = PUFF_SLEEVE_18;
                break;
            case "PUFF_SLEEVE_20":
                selectedSleeve = PUFF_SLEEVE_20;
                break;
            case "PUFF_SLEEVE_22":
                selectedSleeve = PUFF_SLEEVE_22;
                break;
            case "PUFF_SLEEVE_24":
                selectedSleeve = PUFF_SLEEVE_24;
                break;
            case "PUFF_SLEEVE_26":
                selectedSleeve = PUFF_SLEEVE_26;
                break;


            case "BISHOP_SLEEVE_6":
                selectedSleeve = BISHOP_SLEEVE_6;
                break;            
            case "BISHOP_SLEEVE_8":
                selectedSleeve = BISHOP_SLEEVE_8;
                break;   
            case "BISHOP_SLEEVE_10":
                selectedSleeve = BISHOP_SLEEVE_10;
                break;   
            case "BISHOP_SLEEVE_12":
                selectedSleeve = BISHOP_SLEEVE_12;
                break;   
            case "BISHOP_SLEEVE_14":
                selectedSleeve = BISHOP_SLEEVE_14;
                break;   
            case "BISHOP_SLEEVE_16":
                selectedSleeve = BISHOP_SLEEVE_16;
                break;   
            case "BISHOP_SLEEVE_18":
                selectedSleeve = BISHOP_SLEEVE_18;
                break;   
            case "BISHOP_SLEEVE_22":
                selectedSleeve = BISHOP_SLEEVE_22;
                break;   
            case "BISHOP_SLEEVE_24":
                selectedSleeve = BISHOP_SLEEVE_24;
                break;   
            case "BISHOP_SLEEVE_26":
                selectedSleeve = BISHOP_SLEEVE_26;
                break;   

            case "LEGOFMUTTON_SLEEVE_6":
                selectedSleeve = LEGOFMUTTON_SLEEVE_6;
                break; 
            case "LEGOFMUTTON_SLEEVE_8":
                selectedSleeve = LEGOFMUTTON_SLEEVE_8;
                break; 
            case "LEGOFMUTTON_SLEEVE_10":
                selectedSleeve = LEGOFMUTTON_SLEEVE_10;
                break;             
            case "LEGOFMUTTON_SLEEVE_12":
                selectedSleeve = LEGOFMUTTON_SLEEVE_12;
                break; 
            case "LEGOFMUTTON_SLEEVE_14":
                selectedSleeve = LEGOFMUTTON_SLEEVE_14;
                break; 
            case "LEGOFMUTTON_SLEEVE_16":
                selectedSleeve = LEGOFMUTTON_SLEEVE_16;
                break; 
            case "LEGOFMUTTON_SLEEVE_18":
                selectedSleeve = LEGOFMUTTON_SLEEVE_18;
                break; 
            case "LEGOFMUTTON_SLEEVE_20":
                selectedSleeve = LEGOFMUTTON_SLEEVE_20;
                break; 
            case "LEGOFMUTTON_SLEEVE_22":
                selectedSleeve = LEGOFMUTTON_SLEEVE_22;
                break; 
            case "LEGOFMUTTON_SLEEVE_24":
                selectedSleeve = LEGOFMUTTON_SLEEVE_24;
                break; 
            case "LEGOFMUTTON_SLEEVE_26":
                selectedSleeve = LEGOFMUTTON_SLEEVE_26;
                break; 

            case "CAP_SLEEVE_6":
                selectedSleeve = CAP_SLEEVE_6;
                break; 
            case "CAP_SLEEVE_8":
                selectedSleeve = CAP_SLEEVE_8;
                break; 
            case "CAP_SLEEVE_10":
                selectedSleeve = CAP_SLEEVE_10;
                break; 
            case "CAP_SLEEVE_12":
                selectedSleeve = CAP_SLEEVE_12;
                break; 
            case "CAP_SLEEVE_14":
                selectedSleeve = CAP_SLEEVE_14;
                break; 
            case "CAP_SLEEVE_16":
                selectedSleeve = CAP_SLEEVE_16;
                break; 
            case "CAP_SLEEVE_18":
                selectedSleeve = CAP_SLEEVE_18;
                break; 
            case "CAP_SLEEVE_20":
                selectedSleeve = CAP_SLEEVE_20;
                break; 
            case "CAP_SLEEVE_22":
                selectedSleeve = CAP_SLEEVE_22;
                break; 
            case "CAP_SLEEVE_24":
                selectedSleeve = CAP_SLEEVE_24;
                break; 
            case "CAP_SLEEVE_26":
                selectedSleeve = CAP_SLEEVE_26;
                break; 
        }

        if(selectedSleeve==null)
        {
            Debug.Log("selected sleeve pattern could not be found");
        }

        else
        {
            foreach (Transform child in selectedSleeve.transform)
            {
                Transform newImage = Instantiate(child, arrangementPanel.transform).transform;
                newImage.localPosition = new Vector3(3000,0,0);
            }
        }

        preObj.AddClickEventToChildren();
        preObj.OptimizePanelChildren();
        resetChoice();
    }

    public void resetChoice()
    {
        selectedCollarNeckLine=null;
        selectedSleeve=null;
        chosenNecklineName="";
        chosenSleeveName="";
    }

    public void showArrangementFromCustom()
    {
        arrangementPanelParent.SetActive(true);
        CustomDesignPanel.SetActive(false);
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
