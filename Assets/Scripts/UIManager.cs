using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject homeScreenUI;
    public GameObject forgotpasswordUI;
    public TextMeshProUGUI welcomeText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        forgotpasswordUI.SetActive(false);
    }
    public void RegisterScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        forgotpasswordUI.SetActive(false);
    }

    public void ShowHomeScreen()
    {
        homeScreenUI.SetActive(true); // Enable the home screen UI
        loginUI.SetActive(false); // Disable the login UI
    }

    public void ForgotPasswordScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        forgotpasswordUI.SetActive(true);

    }

    public void LoginWelcomeText(string username)
    {
        //testText.text = "WELCOMEEEEE";
        Debug.Log(username);
        welcomeText.text = $"Welcome {username}!";
    }
}
