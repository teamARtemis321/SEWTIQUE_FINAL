// SBS guides

using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using System;

public class Tutorials_options : MonoBehaviour
{
    public TMP_Text premade_type;

    public GameObject premadeScreen;
    public GameObject sbs_overlay;
    public GameObject homeScreen;
    public GameObject tutorial_Option_Overlay;
    public GameObject tutorials_screen;

    public Button comprehensive;
    public Button step_by_step;
    public Button skip;

    public SBS_Halter halter_sbs;
    public SBS_Long long_sbs;
    public SBS_Shirred shirred_sbs;
    public SBS_Short short_sbs;
    public TMP_Text sbsheader;
    public GameObject ARscreen;

    public void show_tutorials()
    {
        tutorials_screen.SetActive(true);
        tutorial_Option_Overlay.SetActive(false);
    }


    public void SetInstructions(TMP_Text premade_type)
    {
        sbs_overlay.SetActive(true);
        tutorial_Option_Overlay.SetActive(false);
        switch (premade_type.text)
        {
            case "shirred":
                shirred_sbs.Start();
                sbsheader.text = "Shirred Instructions";
                break;
            case "long":
                long_sbs.Start();
                sbsheader.text = "Long Instructions";
                break;
            case "halter":
                halter_sbs.Start();
                sbsheader.text = "Halter Instructions";
                break;
            case "short":
                short_sbs.Start();
                sbsheader.text = "Short Instructions";
                break;
            default:
                Debug.LogError("Invalid");
                return;
        }
    }

    public void show_home()
    {
        ARscreen.SetActive(false);
        homeScreen.SetActive(true);
        tutorial_Option_Overlay.SetActive(false);
    }

    public void hide_options()
    {
        ARscreen.SetActive(true);
        tutorial_Option_Overlay.SetActive(false);
    }


    public void Start()
    {
        
    }
}
