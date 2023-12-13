using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MeasurementsHandler : MonoBehaviour
{
    public Button okbutton;
    public Button saveMeasurements;
    public Button savedData;
    public Button changeSet;
    public Button viewRecommendedStyles;
    public Button addMeasurementSetButton;
    public Button cancelMeasurementInputButton;   
    public Button cancelMeasurementConfirmationButton; 
    public Button cancelMeasurementRejectionButton;   
    public Button measurementCardPrefab;
    public Button viewmeasurementscancelButton;

        //* BUTTON LISTS 
        public List<Button> showMeasurementsButtons;
        public List<Button> measurementCards;

        //^GAME OBJECTS
    public GameObject chooseMeasurementSetPanel;
    public GameObject inputCustomMeasurementsPanel;
    public GameObject viewCustomMeasurementsPanel;
    public GameObject cancelMeasurementInputPanel;
    public GameObject homeScreenPanel;
    public GameObject styleRecommendationPanel;
    public GameObject measurementserror;
    public GameObject premadePanel;

    //^INPUT FIELDS
    public TMP_InputField measurementSetName, bustField, waistField, 
    lowWaistField, hipsField, shoulderField, neckField, topArmField, napeWaistField, armscyeField, wristField;

    //^DROP DOWN 
    public TMP_Dropdown measurementUnits;
    public TMP_Text measurementsEnteredBool;

    //^IMAGES 
        //*NECKLINE
            public Image necklineImage1, necklineImage2, necklineImage3, necklineImage4;
        //*SILLHOUETTES
            public Image silhouttesImage1, silhouttesImage2, silhouttesImage3, silhouttesImage4,silhouttesImage5;
        //*COLLARS
            public Image collarImage1, collarImage2;
        //*SLEEVES
            public Image sleevesImage1, sleevesImage2, sleevesImage3, sleevesImage4;

    //^ ON SCREEN TEXT
        //* NECKLINES
            public TMP_Text necklinetext1, necklinetext2, necklinetext3, necklinetext4;
        //* SILHOUETTES
            public TMP_Text silhouttestext1, silhouttestext2, silhouttestext3, silhouttestext4, silhouttestext5;
        //* SLEEVES
            public TMP_Text sleevetext1, sleevetext2, sleevetext3, sleevetext4;
        //* COLLARS 
            public TMP_Text collartext1, collartext2, collartext3, collartext4;
        //* BODYTYPE
            public TMP_Text bodytypetext;
        //* MEASUREMENT VALUES TEXT
            public TMP_Text measurementNameText, bustText, waistText, lowWaistText, hipsText, shoulderText, neckText, topArmText, napeWaistText, armscyeText, wristText, measurementUnitText;
            public TMP_Text bustsizetext, hipssizetext, necksizetext, wristsizetext, waistsizetext, lowwaistsizetext, toparmsizetext, shouldersizetext, armholedepthsizetext, napshouldersizetext;    
        
        //* RECOMMENDATION NAME 
            public TMP_Text nameRecommendation;

        //* ERROR 
            public TMP_Text errorText;


    //^ CARD CONTAINER
    public Transform cardsContainer;

    //^ LISTS
    private List<List<float>> allMeasurementSets = new List<List<float>>();
    private List<string> measurementSetNames = new List<string>();
    private List<string> measurementUnitsArray = new List<string>();
    private List<DateTime> measurementSetDates = new List<DateTime>();

//^ NAVIGATION METHODS
    public void CloseChooseMeasurementSet()
    {
        chooseMeasurementSetPanel.SetActive(false);
    }

    public void CloseViewMeasurementSet()
    {
        viewCustomMeasurementsPanel.SetActive(false);
    }

    public void ViewPremadePatterns()
    {
        styleRecommendationPanel.SetActive(false);
        premadePanel.SetActive(true);
    }

    public void ShowChooseMeasurementSetPanel()
    {
        inputCustomMeasurementsPanel.SetActive(false);
        chooseMeasurementSetPanel.SetActive(true);
    }

    public void ShowInputCustomMeasurementsPanel()
    {
        inputCustomMeasurementsPanel.SetActive(true);
    }

    public void showViewCustomMeasurementsPanel()
    {
         viewCustomMeasurementsPanel.SetActive(true);
    }

    public void showHomeScreenPanel()
    {

    }

    public void showStyleRecommendationPanel()
    {
        styleRecommendationPanel.SetActive(true);
    }

    public void ShowCancelMeasurementInputPanel()
    {
        cancelMeasurementInputPanel.SetActive(true);
    }


//^ CALCULATION METHODS

    public void CalculateMeasurements()
    {
        errorText.text = "";

        if(AnyFieldsNotAssigned())
        {
            Debug.Log("Calculating measurements, One or more fields have not been assigned");
        }

        float bust;
        float waist;
        float lowwaist;
        float hips;
        float shoulder;
        float neck;
        float toparm;
        float napetowaist;
        float armscyedepth;
        float wrist;

        string measurementName = measurementSetName.text;
        int index = measurementUnits.value;
        String measurementUnit = measurementUnits.options[index].text;

        //^ FINDING OUT CONVERSION UNIT
        float conversionamount = 0;

        if(measurementUnit == "Centimeters")
        {
            conversionamount = 1;
        }

        else 
        if(measurementUnit == "Inches")
        {
            conversionamount = (float)2.54;
        }

        bool TryParseInputField(TMP_InputField inputField, out float result)
        {
            if(!float.TryParse(inputField.text, out result))
            {
                measurementserror.SetActive(true);
                errorText.text = $"Missing input in field: {inputField.name}";
                //inputField.Select(); // Highlight the input field with the error
                return false;
            }
            return true;
        }


        //^ TRYING TO PARSE INPUTS 

        if (!TryParseInputField(bustField, out bust) ||
            !TryParseInputField(waistField, out waist) ||
            !TryParseInputField(lowWaistField, out lowwaist) ||
            !TryParseInputField(hipsField, out hips) ||
            !TryParseInputField(shoulderField, out shoulder) ||
            !TryParseInputField(neckField, out neck) ||
            !TryParseInputField(topArmField, out toparm) ||
            !TryParseInputField(napeWaistField, out napetowaist) ||
            !TryParseInputField(armscyeField, out armscyedepth) ||
            !TryParseInputField(wristField, out wrist))
            {
                return;
            }
        
        //^ CONVERTING UNITS 
        bust=bust*conversionamount;
        waist=waist*conversionamount;
        lowwaist=lowwaist*conversionamount;
        hips=hips*conversionamount;
        shoulder=shoulder*conversionamount;
        neck=neck*conversionamount;
        toparm=toparm*conversionamount;
        napetowaist=napetowaist*conversionamount;
        armscyedepth=armscyedepth*conversionamount;
        wrist=wrist*conversionamount;

        //^ CALCULATING SIZE CODES FOR EACH ENTRY
        int bustSizeCode = CalculateSizeCode(bust, new float[] { 76, 80, 84, 88, 92, 96, 100, 104, 110, 116, 122 });
        int waistSizeCode = CalculateSizeCode(waist, new float[] { 60, 64, 68, 72, 76, 80, 84, 88, 94, 100, 106 });
        int lowwaistSizeCode = CalculateSizeCode(lowwaist, new float[] { 70, 74, 78, 82, 86, 90, 94, 98, 104, 110, 116 });
        int hipsSizeCode = CalculateSizeCode(hips, new float[] { 84, 88, 92, 96, 100, 104, 108, 112, 117, 122, 127 });
        int shoulderSizeCode = CalculateSizeCode(shoulder, new float[] { 11.5f, 11.75f, 12, 12.25f, 12.5f, 12.75f, 13, 13.25f, 13.6f, 13.9f, 14.2f });
        int neckSizeCode = CalculateSizeCode(neck, new float[] { 34, 35, 36, 37, 38, 39, 40, 41, 42.4f, 43.8f, 45.2f });
        int topArmSizeCode = CalculateSizeCode(toparm, new float[] { 24.8f, 26, 27.2f, 28.4f, 29.6f, 30.8f, 32, 33.2f, 35.2f, 37.2f, 39.2f });
        int napewaistSizeCode = CalculateSizeCode(napetowaist, new float[] { 39.8f, 40.2f, 40.6f, 41, 41.4f, 41.8f, 42.2f, 42.6f, 43f, 43.4f, 43.8f });
        int armscyeSizeCode = CalculateSizeCode(armscyedepth, new float[] { 19.8f, 20.2f, 20.6f, 21, 21.4f, 21.8f, 22.2f, 22.6f, 23.2f, 23.8f, 24.4f });
        int wristSizeCode = CalculateSizeCode(wrist, new float[] { 14.5f, 15, 15.5f, 16, 16.5f, 17, 17.5f, 18, 18.7f, 19.4f, 20.1f });

        string bustsizeCodeName = GetSizeCodeName(bustSizeCode);
        if (bustsizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Bust Field";
            return;
        }
        string waistsizeCodeName = GetSizeCodeName(waistSizeCode);
        if (waistsizeCodeName == "Invalid"){
            
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Waist Field";
            return;
        }
        string lowwaistsizeCodeName = GetSizeCodeName(lowwaistSizeCode);
        if (lowwaistsizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Low Waist Field";
            return;
        }
        string hipssizeCodeName = GetSizeCodeName(hipsSizeCode);
        if (hipssizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Hips Field";
            return;
        }
        string shouldersizeCodeName = GetSizeCodeName(shoulderSizeCode);
        if (shouldersizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Shoulders Field";
            return;
        }
        string necksizeCodeName = GetSizeCodeName(neckSizeCode);
        if (necksizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Neck Field";
            return;
        }
        string topArmsizeCodeName = GetSizeCodeName(topArmSizeCode);
        if (topArmsizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Top Arm Field";
            return;
        }
        string napewaistsizeCodeName = GetSizeCodeName(napewaistSizeCode);
        if (napewaistsizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Nape/Waist Field";
            return;
        }
        string armscyesizeCodeName = GetSizeCodeName(armscyeSizeCode);
        if (armscyesizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Armscye Field";
            return;
        }
        string wristsizeCodeName = GetSizeCodeName(wristSizeCode);
        if (wristsizeCodeName == "Invalid"){
            measurementserror.SetActive(true);
            errorText.text = "Invalid input in field: Wrist Field";
            return;
        }
    
        bustsizetext.text = bustsizeCodeName;
        hipssizetext.text = hipssizeCodeName;
        necksizetext.text = necksizeCodeName;
        wristsizetext.text = wristsizeCodeName;
        waistsizetext.text = waistsizeCodeName;
        lowwaistsizetext.text = lowwaistsizeCodeName;
        toparmsizetext.text = topArmsizeCodeName;
        shouldersizetext.text = shouldersizeCodeName;
        armholedepthsizetext.text = armscyesizeCodeName;
        napshouldersizetext.text = napewaistsizeCodeName;
        measurementsEnteredBool.text = "True";


        Debug.Log("Bust Size: " + bustSizeCode + " which corresponds to Size Code: " + bustsizeCodeName);
        Debug.Log("Waist Size: " + waistSizeCode + " which corresponds to Size Code: " + waistsizeCodeName);
        Debug.Log("Low Waist Size: " + lowwaistSizeCode + " which corresponds to Size Code: " + lowwaistsizeCodeName);
        Debug.Log("Hips Size: " + hipsSizeCode + " which corresponds to Size Code: " + hipssizeCodeName);
        Debug.Log("Shoulder Size: " + shoulderSizeCode + " which corresponds to Size Code: " + shouldersizeCodeName);
        Debug.Log("Neck Size: " + neckSizeCode + " which corresponds to Size Code: " + necksizeCodeName);
        Debug.Log("Top Arm Size: " + topArmSizeCode + " which corresponds to Size Code: " + topArmsizeCodeName);
        Debug.Log("Nape to Waist Size: " + napewaistSizeCode + " which corresponds to Size Code: " + napewaistsizeCodeName);
        Debug.Log("Armscye Size: " + armscyeSizeCode + " which corresponds to Size Code: " + armscyesizeCodeName);
        Debug.Log("Wrist Size: " + wristSizeCode + " which corresponds to Size Code: " + wristsizeCodeName);

        int[] allSizeCodes = new int[] { bustSizeCode, waistSizeCode, lowwaistSizeCode, hipsSizeCode, shoulderSizeCode, neckSizeCode, topArmSizeCode, napewaistSizeCode, armscyeSizeCode, wristSizeCode };
        int averageSizeCode = CalculateAverageSizeCode(allSizeCodes);
        string overallSize = GetSizeCodeName(averageSizeCode);
        Debug.Log("Overall standard size is: " + overallSize);
        string bodyType = DetermineBodyType(bust, waist, lowwaist, hips, shoulder * 2); // shoulder width is doubled as you described
        Debug.Log("Determined body type is: " + bodyType);

        SetImageRecommendations(bodyType);
        List<float> newMeasurementSet = new List<float>
        {
            bust, waist, lowwaist, hips, shoulder, neck, toparm, napetowaist, armscyedepth, wrist
        };
        allMeasurementSets.Add(newMeasurementSet);
        measurementSetNames.Add(measurementName);  // Replace with desired name
        measurementSetDates.Add(DateTime.Now);
        measurementUnitsArray.Add(measurementUnit);

        // Instantiate a new card from the prefab
        Button newCard = Instantiate(measurementCardPrefab, cardsContainer);
        if(newCard == null) 
        {
            Debug.LogError("Failed to instantiate card");
            return;
        }

        int latestIndex = allMeasurementSets.Count - 1;  // Index of the latest measurement set
        string setName = measurementSetNames[latestIndex]; // Name of the latest measurement set
        DateTime setDate = measurementSetDates[latestIndex]; // Date of the latest measurement set

        Transform setNamePlaceholder = newCard.transform.Find("Set Name Placeholder");
        Transform datePlaceholder = newCard.transform.Find("Date Placeholder");

        TMP_Text setNameText = setNamePlaceholder.GetComponent<TMP_Text>();
        TMP_Text setDateText = datePlaceholder.GetComponent<TMP_Text>();

        setNameText.text = setName;
        if (setDateText != null && setDate != null)
        {
            setDateText.text = "Date Added: " + setDate.ToString("MM/dd/yyyy");
        }

        else
        {
            if (setDateText == null) 
            {
                Debug.LogError("setDateText is null. Please ensure it is correctly assigned.");
            }
            if (setDate == null) 
            {
                Debug.LogError("setDate is null. Please ensure it has a valid value.");
            }
        }

            measurementCards.Add(newCard);
            nameRecommendation.text=setName;
            newCard.onClick.AddListener(() => OnCardClicked(newCard));
            ShowChooseMeasurementSetPanel();
    }    
    
    //^ WHEN A CARD IS CLICKED 
    public void OnCardClicked(Button clickedCard)
    {
        showViewCustomMeasurementsPanel();
        int index = measurementCards.IndexOf(clickedCard);
        // Check if any of the input fields are not assigned
        if (AnyFieldsNotAssigned())
        {
            Debug.LogError("One or more input fields are not assigned.");
            return;
        }

        // Load the measurements from the allMeasurementSets array
        List<float> measurements = allMeasurementSets[index];
        if(measurements.Count >= 10) // Assuming there are 10 measurements
        {
            // Perform the calculate function on these measurement sets
            float bust = measurements[0];
            float waist = measurements[1];
            float lowwaist = measurements[2];
            float hips = measurements[3];
            float shoulder = measurements[4];
            float neck = measurements[5];
            float toparm = measurements[6];
            float napetowaist = measurements[7];
            float armscyedepth = measurements[8];
            float wrist = measurements[9];
            string measurementUnit = measurementUnitsArray[index];
            Debug.Log(measurementUnit);
        string measurementName = measurementSetNames[index];
        
        nameRecommendation.text=measurementName;
        float conversionamount = 0;
        if (measurementUnit == "Centimeters"){
            conversionamount = 1;
        }
        else if (measurementUnit == "Inches"){
            conversionamount = (float)2.54;
        }
        
        Debug.Log(bust);
        bust=bust/conversionamount;
        Debug.Log(bust);
        waist=waist/conversionamount;
        lowwaist=lowwaist/conversionamount;
        hips=hips/conversionamount;
        shoulder=shoulder/conversionamount;
        neck=neck/conversionamount;
        toparm=toparm/conversionamount;
        napetowaist=napetowaist/conversionamount;
        armscyedepth=armscyedepth/conversionamount;
        wrist=wrist/conversionamount;

        measurementNameText.text=measurementName;
        bustText.text=bust.ToString();
        waistText.text=waist.ToString();
        lowWaistText.text=lowwaist.ToString();
        hipsText.text=hips.ToString();
        shoulderText.text=shoulder.ToString();
        neckText.text=neck.ToString();
        topArmText.text=toparm.ToString();
        napeWaistText.text=napetowaist.ToString();
        armscyeText.text=armscyedepth.ToString();
        wristText.text=wrist.ToString();
        measurementUnitText.text=measurementUnit;

        int bustSizeCode = CalculateSizeCode(bust, new float[] { 76, 80, 84, 88, 92, 96, 100, 104, 110, 116, 122 });
        int waistSizeCode = CalculateSizeCode(waist, new float[] { 60, 64, 68, 72, 76, 80, 84, 88, 94, 100, 106 });
        int lowwaistSizeCode = CalculateSizeCode(lowwaist, new float[] { 70, 74, 78, 82, 86, 90, 94, 98, 104, 110, 116 });
        int hipsSizeCode = CalculateSizeCode(hips, new float[] { 84, 88, 92, 96, 100, 104, 108, 112, 117, 122, 127 });
        int shoulderSizeCode = CalculateSizeCode(shoulder, new float[] { 11.5f, 11.75f, 12, 12.25f, 12.5f, 12.75f, 13, 13.25f, 13.6f, 13.9f, 14.2f });
        int neckSizeCode = CalculateSizeCode(neck, new float[] { 34, 35, 36, 37, 38, 39, 40, 41, 42.4f, 43.8f, 45.2f });
        int topArmSizeCode = CalculateSizeCode(toparm, new float[] { 24.8f, 26, 27.2f, 28.4f, 29.6f, 30.8f, 32, 33.2f, 35.2f, 37.2f, 39.2f });
        int napewaistSizeCode = CalculateSizeCode(napetowaist, new float[] { 39.8f, 40.2f, 40.6f, 41, 41.4f, 41.8f, 42.2f, 42.6f, 43f, 43.4f, 43.8f });
        int armscyeSizeCode = CalculateSizeCode(armscyedepth, new float[] { 19.8f, 20.2f, 20.6f, 21, 21.4f, 21.8f, 22.2f, 22.6f, 23.2f, 23.8f, 24.4f });
        int wristSizeCode = CalculateSizeCode(wrist, new float[] { 14.5f, 15, 15.5f, 16, 16.5f, 17, 17.5f, 18, 18.7f, 19.4f, 20.1f });

        string bustsizeCodeName = GetSizeCodeName(bustSizeCode);
        string waistsizeCodeName = GetSizeCodeName(waistSizeCode);
        string lowwaistsizeCodeName = GetSizeCodeName(lowwaistSizeCode);
        string hipssizeCodeName = GetSizeCodeName(hipsSizeCode);
        string shouldersizeCodeName = GetSizeCodeName(shoulderSizeCode);
        string necksizeCodeName = GetSizeCodeName(neckSizeCode);
        string topArmsizeCodeName = GetSizeCodeName(topArmSizeCode);
        string napewaistsizeCodeName = GetSizeCodeName(napewaistSizeCode);
        string armscyesizeCodeName = GetSizeCodeName(armscyeSizeCode);
        string wristsizeCodeName = GetSizeCodeName(wristSizeCode);

        bustsizetext.text = bustsizeCodeName;
        hipssizetext.text = hipssizeCodeName;
        necksizetext.text = necksizeCodeName;
        wristsizetext.text = wristsizeCodeName;
        waistsizetext.text = waistsizeCodeName;
        lowwaistsizetext.text = lowwaistsizeCodeName;
        toparmsizetext.text = topArmsizeCodeName;
        shouldersizetext.text = shouldersizeCodeName;
        armholedepthsizetext.text = armscyesizeCodeName;
        napshouldersizetext.text = napewaistsizeCodeName;
        measurementsEnteredBool.text = "True";
    

        Debug.Log("Bust Size: " + bustSizeCode + " which corresponds to Size Code: " + bustsizeCodeName);
        Debug.Log("Waist Size: " + waistSizeCode + " which corresponds to Size Code: " + waistsizeCodeName);
        Debug.Log("Low Waist Size: " + lowwaistSizeCode + " which corresponds to Size Code: " + lowwaistsizeCodeName);
        Debug.Log("Hips Size: " + hipsSizeCode + " which corresponds to Size Code: " + hipssizeCodeName);
        Debug.Log("Shoulder Size: " + shoulderSizeCode + " which corresponds to Size Code: " + shouldersizeCodeName);
        Debug.Log("Neck Size: " + neckSizeCode + " which corresponds to Size Code: " + necksizeCodeName);
        Debug.Log("Top Arm Size: " + topArmSizeCode + " which corresponds to Size Code: " + topArmsizeCodeName);
        Debug.Log("Nape to Waist Size: " + napewaistSizeCode + " which corresponds to Size Code: " + napewaistsizeCodeName);
        Debug.Log("Armscye Size: " + armscyeSizeCode + " which corresponds to Size Code: " + armscyesizeCodeName);
        Debug.Log("Wrist Size: " + wristSizeCode + " which corresponds to Size Code: " + wristsizeCodeName);

        int[] allSizeCodes = new int[] { bustSizeCode, waistSizeCode, lowwaistSizeCode, hipsSizeCode, shoulderSizeCode, neckSizeCode, topArmSizeCode, napewaistSizeCode, armscyeSizeCode, wristSizeCode };
        int averageSizeCode = CalculateAverageSizeCode(allSizeCodes);
        string overallSize = GetSizeCodeName(averageSizeCode);
        Debug.Log("Overall standard size is: " + overallSize);
        string bodyType = DetermineBodyType(bust, waist, lowwaist, hips, shoulder * 2); // shoulder width is doubled as you described
        Debug.Log("Determined body type is: " + bodyType);
        SetImageRecommendations(bodyType);
    }
    }

    //^ METHOD CALLED TO CALCULATE THE SIZE CODE FOR THE MEASUREMENT ENTERED
        private int CalculateSizeCode(float measurement, float[] sizes)
    {
        for (int i = 0; i < sizes.Length; i++)
        {
            if (measurement <= sizes[i])
            {
                return i + 6; // The size codes start at 6 and increment by 1.
            }
        }
        return sizes.Length + 6; // If it's larger than all predefined sizes.
    }

    //^ METHOD TO CALCULATE AVERAGE SIZE FROM SIZE LIST
    private int CalculateAverageSizeCode(int[] sizeCodes)
    {
        int sum = 0;
        for (int i = 0; i < sizeCodes.Length; i++)
        {
            sum += sizeCodes[i];
        }
        int averageSizeCode = Mathf.RoundToInt(sum / (float)sizeCodes.Length); // Use Mathf.RoundToInt to get the nearest whole number.

        return averageSizeCode;
    }

    //^ METHOD TO GET SIZE CODE
    private string GetSizeCodeName(int sizecode)
    {
        // Array of string representations of size codes
        string[] sizeCodes = { "6", "8", "10", "12", "14", "16", "18", "20", "22", "24", "26" };

        int index = sizecode - 6; // Because our size codes start at 6.

        if (index >= 0 && index < sizeCodes.Length)
        {
            return sizeCodes[index];
        }
        else
        {
            Debug.LogError("Invalid size code: " + sizecode);
            return "Invalid";
        }
    }

    private string DetermineBodyType(float bust, float waist, float lowwaist, float hips, float shoulders)
    {
        bool isHourglass = (Math.Abs(bust - hips) <= 2.54f) && (Math.Abs(hips - bust) < 9.144f) && ((bust - waist) >= 22.86f || (hips - waist) >= 25.4f);
        bool isPear = (hips - bust) > 5.08f && (hips - waist) >= 17.78f && (lowwaist / waist) >= 1.193f; // Assuming lowwaist is the "high hip" measurement
        bool isInvertedTriangle = (bust - hips) >= 9.144f && (bust - waist) < 22.86f;
        bool isRectangle = (Math.Abs(hips - bust) < 9.144f) && (Math.Abs(bust - hips) < 9.144f) && (bust - waist) < 22.86f && (hips - waist) < 25.4f;
        bool isApple = (waist >= bust) && (waist >= hips) && (Math.Abs(shoulders - bust) < 2.54f) && (Math.Abs(shoulders - hips) < 2.54f);

        if (isHourglass)
        {
            bodytypetext.text="According to your measurement set, You are a Hourglass Body Type!";
            return "Hourglass";

        }
        else if (isPear)
        {
            bodytypetext.text="According to your measurement set, You are a Pear Body Type!";
            return "Pear";
        }
        else if (isInvertedTriangle)
        {
            bodytypetext.text="According to your measurement set, You are a Inverted Triangle Body Type!";
            return "Inverted Triangle";
        }
        else if (isRectangle)
        {
            bodytypetext.text="According to your measurement set, You are a Rectangle Body Type!";
            return "Rectangle";
        }
        else if (isApple)
        {
            bodytypetext.text="According to your measurement set, You are a Apple Body Type!";
            return "Apple";
        }
        else
    {
        bodytypetext.text = "According to your measurement set, You are a Hourglass Body Type";
        return "Hourglass";
    }
    }

    private bool AnyFieldsNotAssigned()
    {
        return bustField == null || waistField == null || lowWaistField == null || hipsField == null || shoulderField == null ||
               neckField == null || topArmField == null || napeWaistField == null || armscyeField == null || wristField == null;
    }

    private bool TryParseFloat(TMP_InputField inputField, out float result)
    {
        return float.TryParse(inputField.text, out result);
    }

    private void SetImageRecommendations(string bodyType)
    {
        // Clear all image recommendations
        ClearImageRecommendations();

        // Determine recommendations based on body type
        switch (bodyType)
        {
            case "Pear":
                // Set necklines
                necklineImage1.sprite = LoadImage("squareimage");
                necklinetext1.text="Square";
                necklineImage2.sprite = LoadImage("bateauimage");
                necklinetext2.text="Bateau";

                // Set collars
                collarImage1.sprite = LoadImage("basiccollarimage");
                collartext1.text="Basic";
                collarImage2.sprite = LoadImage("mandarinimage");
                collartext2.text="Mandarin";

                // Set sleeves
                sleevesImage1.sprite = LoadImage("capimage");
                sleevetext1.text="Cap";
                sleevesImage2.sprite = LoadImage("legofmuttonimage");
                sleevetext2.text="Leg of Mutton";

                // Set silhouttes
                silhouttesImage1.sprite = LoadImage("buttondown");
                silhouttestext1.text="Button Down";
                silhouttesImage2.sprite = LoadImage("crop");
                silhouttestext2.text="Crop";
                silhouttesImage3.sprite = LoadImage("rufflepear");
                silhouttestext3.text="Ruffle";
                silhouttesImage4.sprite = LoadImage("wrapbust");
                silhouttestext4.text="Wrap";
                break;



            case "Hourglass":
                // Set necklines
                necklineImage1.sprite = LoadImage("scoopimage");
                necklinetext1.text="Scoop";
                necklineImage2.sprite = LoadImage("vneckimage");
                necklinetext2.text="V-Neck";
                necklineImage3.sprite = LoadImage("squareimage");
                necklinetext3.text="Square";

                // Set collars
                collarImage1.sprite = LoadImage("basiccollarimage");
                collartext1.text="Basic";

                // Set sleeves
                sleevesImage1.sprite = LoadImage("capimage");
                sleevetext1.text="Cap";
                sleevesImage2.sprite = LoadImage("legofmuttonimage");
                sleevetext2.text="Leg of Mutton";
                sleevesImage3.sprite = LoadImage("bishopimage");
                sleevetext2.text="Bishop";
                
                // Set silhouttes
                silhouttesImage1.sprite = LoadImage("buttondown");
                silhouttestext1.text="Button Down";
                silhouttesImage2.sprite = LoadImage("belted");
                silhouttestext2.text="Belted";
                silhouttesImage3.sprite = LoadImage("fittedt"); //asd
                silhouttestext3.text="Fitted T";
                silhouttesImage4.sprite = LoadImage("peplum");
                silhouttestext4.text="Peplum";
                silhouttesImage5.sprite = LoadImage("wrap");
                silhouttestext5.text="Wrap";
                break;

            case "Inverted Triangle":
                // Set necklines
                necklineImage1.sprite = LoadImage("scoopimage");
                necklinetext1.text="Scoop";
                necklineImage2.sprite = LoadImage("vneckimage");
                necklinetext2.text="V-Neck";

                // Set collars
                collarImage1.sprite = LoadImage("basiccollarimage");
                collartext1.text="Basic";
                collarImage2.sprite = LoadImage("mandarinimage");
                collartext2.text="Mandarin";

                // Set sleeves
                sleevesImage1.sprite = LoadImage("capimage");
                sleevetext1.text="Cap";
                sleevesImage2.sprite = LoadImage("puffimage");
                sleevetext2.text="Puff";
                
                // Set silhouttes
                silhouttesImage1.sprite = LoadImage("fittedtriangle");
                silhouttestext1.text="Fitted";
                silhouttesImage2.sprite = LoadImage("trapeze");
                silhouttestext2.text="Trapeze";
                silhouttesImage3.sprite = LoadImage("fittedt");
                silhouttestext3.text="Fitted T";
                silhouttesImage4.sprite = LoadImage("peplum");
                silhouttestext4.text="Peplum";
                silhouttesImage5.sprite = LoadImage("wrap");
                silhouttestext5.text="Wrap";
                break;

            case "Apple":
                // Set necklines
                necklineImage1.sprite = LoadImage("scoopimage");
                necklinetext1.text="Scoop";
                necklineImage2.sprite = LoadImage("vneckimage");
                necklinetext2.text="V-Neck";

                // Set collars
                collarImage1.sprite = LoadImage("basiccollarimage");
                collartext1.text="Basic";

                // Set sleeves
                sleevesImage1.sprite = LoadImage("capimage");
                sleevetext1.text="Cap";
                sleevesImage2.sprite = LoadImage("puffimage");
                sleevetext1.text="Puff";
                sleevesImage3.sprite = LoadImage("bishopimage");
                sleevetext1.text="Bishop";
                
                // Set silhouttes
                silhouttesImage1.sprite = LoadImage("draping");
                silhouttestext1.text="Draping";
                silhouttesImage2.sprite = LoadImage("swing");
                silhouttestext2.text="Swing";
                silhouttesImage3.sprite = LoadImage("trapeze");
                silhouttestext3.text="Fitted T";
                silhouttesImage4.sprite = LoadImage("tunic");
                silhouttestext4.text="Tunic";
                silhouttesImage5.sprite = LoadImage("wrap");
                silhouttestext5.text="Wrap";
                break;

            case "Rectangle":
                // Set necklines
                necklineImage1.sprite = LoadImage("scoopimage");
                necklinetext1.text="Scoop";
                necklineImage2.sprite = LoadImage("vneckimage");
                necklinetext2.text="V-Neck";
                necklineImage3.sprite = LoadImage("bateauimage");
                necklinetext3.text="Bateau";

                // Set collars
                collarImage1.sprite = LoadImage("basiccollarimage");
                collartext1.text="Basic";

                // Set sleeves
                sleevesImage1.sprite = LoadImage("capimage");
                sleevetext1.text="Cap";
                sleevesImage2.sprite = LoadImage("puffimage");
                sleevetext2.text="Puff";
                sleevesImage3.sprite = LoadImage("legofmuttonimage");
                sleevetext3.text="Leg of Mutton";
                
                // Set silhouttes
                silhouttesImage1.sprite = LoadImage("belted");
                silhouttestext1.text="Belted";
                silhouttesImage2.sprite = LoadImage("buttondown");
                silhouttestext2.text="Button Down";
                silhouttesImage3.sprite = LoadImage("pussybow");
                silhouttestext3.text="Pussy Bow";
                silhouttesImage4.sprite = LoadImage("rufflerectangle");
                silhouttestext4.text="Ruffle";
                silhouttesImage5.sprite = LoadImage("wrap");
                silhouttestext5.text="Wrap";
                break;

            default:
                Debug.LogWarning("Undefined body type: " + bodyType);
                break;
        }
    }

    private void ClearImageRecommendations()
    {
        // Set all images to null or an empty sprite
        necklineImage1.sprite = null;
        necklineImage2.sprite = null;
        necklineImage3.sprite = null;
        necklineImage4.sprite = null;

        collarImage1.sprite = null;
        collarImage2.sprite = null;

        sleevesImage1.sprite = null;
        sleevesImage2.sprite = null;
        sleevesImage3.sprite = null;
        sleevesImage4.sprite = null;
    }

    private Sprite LoadImage(string imageName)
{

    Sprite newSprite = Resources.Load<Sprite>(imageName);
    if (newSprite == null)
    {
        Debug.LogError("Sprite not found for image name: " + imageName);
    }

    return newSprite;
}

public void rejectCancelAddMeasurement()
{
    cancelMeasurementInputPanel.SetActive(false);
}

public void acceptCancelAddMeasurement()
{
    cancelMeasurementInputPanel.SetActive(false);
    inputCustomMeasurementsPanel.SetActive(false);
}
public 
    // Start is called before the first frame update
    void Start()
    {
        changeSet.onClick.AddListener(ShowChooseMeasurementSetPanel);
        measurementserror.SetActive(false);
        // Ensure the button is connected to the method
        viewmeasurementscancelButton.onClick.AddListener(ShowChooseMeasurementSetPanel);
        //savedData.onClick.AddListener(ShowChooseMeasurementSetPanel);
        saveMeasurements.onClick.AddListener(CalculateMeasurements);
        addMeasurementSetButton.onClick.AddListener(ShowInputCustomMeasurementsPanel);
        cancelMeasurementInputButton.onClick.AddListener(ShowCancelMeasurementInputPanel);
        cancelMeasurementConfirmationButton.onClick.AddListener(ShowChooseMeasurementSetPanel);
        cancelMeasurementRejectionButton.onClick.AddListener(ShowInputCustomMeasurementsPanel);
        viewRecommendedStyles.onClick.AddListener(showStyleRecommendationPanel);
        okbutton.onClick.AddListener(ShowInputCustomMeasurementsPanel);

        // Show the Choose Measurement Set panel by default
        homeScreenPanel.SetActive(true);
        chooseMeasurementSetPanel.SetActive(false);
        inputCustomMeasurementsPanel.SetActive(false);
        cancelMeasurementInputPanel.SetActive(false);
        styleRecommendationPanel.SetActive(false);
        viewCustomMeasurementsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
