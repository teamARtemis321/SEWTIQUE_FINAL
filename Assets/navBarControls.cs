using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class navBarControls : MonoBehaviour
{   
    // Start is called before the first frame update
    public GameObject HomeScreen;
    public GameObject PremadePanel;
    public GameObject InputFabric;
    public GameObject Arrangement;
    public GameObject CancelMeasurementInput;
    public GameObject ArrangementConfirm;
    public GameObject DesignHistory;
    public GameObject EnlargedTechSketch;
    public GameObject EnlargedPremadeTechSketch;
    public GameObject CustomDesignScreen;
    public GameObject InputDesign;
    public GameObject Guides;
    public GameObject SizingGuide;
    public GameObject Guide2;
    public GameObject StitchGuide;
    public GameObject LongSleeveInstruction;
    public GameObject ShortSleeveInstruction;
    public GameObject CuttingGuide;
    public GameObject ShirredTopGuide;
    //public GameObject PeplumGuide;
    public GameObject HalterGuide;
    public GameObject Guide1;
    public GameObject Settings;
    public GameObject chooseMeasurement;
    public GameObject InputCustom;
    public GameObject cancelMeasurementInput1;
    public GameObject viewCustom;
    public GameObject StyleRecc;
    public GameObject ARScreen;
    public GameObject DualNAV;
    public GameObject SaveData;

    public void NavToHomeScreen()
    {
        SaveData.SetActive(false);
        HomeScreen.SetActive(true);
        PremadePanel.SetActive(false);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(false);
        InputDesign.SetActive(false);
        Guides.SetActive(false);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        Settings.SetActive(false);
        chooseMeasurement.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);

    }

    public void NavToGuides()
    {
        SaveData.SetActive(false);
        HomeScreen.SetActive(false);
        PremadePanel.SetActive(false);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(false);
        InputDesign.SetActive(false);
        Guides.SetActive(true);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        Settings.SetActive(false);
        chooseMeasurement.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);

    }

    public void NavToDualNav()
    {
        DualNAV.SetActive(true);
    }

    public void DualToPremade()
    {
        HomeScreen.SetActive(false);
        PremadePanel.SetActive(true);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(false);
        InputDesign.SetActive(false);
        Guides.SetActive(false);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        Settings.SetActive(false);
        chooseMeasurement.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);
        SaveData.SetActive(false);

    }

    public void DualToCustom()
    {
        HomeScreen.SetActive(false);
        PremadePanel.SetActive(false);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(true);
        InputDesign.SetActive(false);
        Guides.SetActive(false);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        Settings.SetActive(false);
        chooseMeasurement.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);
        SaveData.SetActive(false);
    
    }
   
    public void NavToSavedData()
    {
        chooseMeasurement.SetActive(false);
        Debug.Log("choose mes inactive");
        SaveData.SetActive(true);
        HomeScreen.SetActive(false);
        PremadePanel.SetActive(false);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(false);
        InputDesign.SetActive(false);
        Guides.SetActive(false);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        Settings.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);

    }

    public void NavToSettings()
    {
        SaveData.SetActive(false);
        Settings.SetActive(true);
        HomeScreen.SetActive(false);
        PremadePanel.SetActive(false);
        InputFabric.SetActive(false);
        Arrangement.SetActive(false);
        CancelMeasurementInput.SetActive(false);
        ArrangementConfirm.SetActive(false);
        DesignHistory.SetActive(false);
        EnlargedTechSketch.SetActive(false);
        EnlargedPremadeTechSketch.SetActive(false);
        CustomDesignScreen.SetActive(false);
        InputDesign.SetActive(false);
        Guides.SetActive(false);
        SizingGuide.SetActive(false);
        Guide2.SetActive(false);
        StitchGuide.SetActive(false);
        LongSleeveInstruction.SetActive(false);
        ShortSleeveInstruction.SetActive(false);
        CuttingGuide.SetActive(false);
        ShirredTopGuide.SetActive(false);
        //PeplumGuide.SetActive(false);
        HalterGuide.SetActive(false);
        Guide1.SetActive(false);
        chooseMeasurement.SetActive(false);
        InputCustom.SetActive(false);
        cancelMeasurementInput1.SetActive(false);
        viewCustom.SetActive(false);
        StyleRecc.SetActive(false);
        ARScreen.SetActive(false);
        DualNAV.SetActive(false);
        

    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
