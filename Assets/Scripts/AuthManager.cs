using System.Collections;
using System;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField nameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    [Header("Forget Password")]
    public TMP_InputField resetPasswordEmailField;
    public TMP_Text warningForgetPasswordText;

    [Header("Home Screen")]
    public TextMeshProUGUI welcomeText;
    public TextMeshProUGUI initialTextTMP;

    [Header("Settings Panel")]
    public TextMeshProUGUI initialTextSettings;
    public TextMeshProUGUI fullNameTextSettings;
    public TextMeshProUGUI emailTextSettings;




    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;

        // Update the settings panel with user info if the user is already logged in
        if (auth.CurrentUser != null)
        {
            UpdateSettingsPanel(auth.CurrentUser);
        }
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));


    }
    //Function for the register button
    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text));
    }
   

    public void ForgetPasswordButton()
    {
        // Call the forgetPassword coroutine passing the email
        StartCoroutine(ForgetPassword(resetPasswordEmailField.text));
    }

    public string passwordFormat(string password, string email)
    {

        string message = "";
        if (password.Length < 8)
        { message = "Password must contain atleast 8 characters"; }
        else if (!Regex.IsMatch(password, @"[A-Z]"))
        { message = "Password must contain atleast 1 uppercase character"; }
        else if (!Regex.IsMatch(password, @"[a-z]"))
        { message = "Password must contain atleast 1 lowercase character"; }
        else if (!Regex.IsMatch(password, @"\d"))
        { message = "Password must contain atleast 1 number"; }
        else if (!Regex.IsMatch(password, @"[^A-Za-z0-9]"))
        { message = "Password must contain atleast 1 special character"; }
        else if (password.Contains(" "))
        { message = "Password cannot contain spaces"; }
        //else if(password.Contains(email))
        //{ message = "Password cannot contain email"; }

        return (message);
    }

    private IEnumerator Login(string _email, string _password)
    {
        Task<AuthResult> LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);
        warningLoginText.text = "";
        //string message = "Login Failed!";
        if (LoginTask.Exception != null)
        {
            Debug.Log("if entered ");
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";

            if (errorCode == AuthError.MissingEmail)
            {
                message = "Missing Email";
            }
            else if (errorCode == AuthError.MissingPassword)
            {
                message = "Missing Password";
            }
            else if (errorCode == AuthError.WrongPassword)
            {
                message = "Wrong Password";
            }
            else if (errorCode == AuthError.InvalidEmail)
            {
                message = "Invalid Email";
            }
            else if (errorCode == AuthError.UserNotFound)
            {
                message = "Account does not exist";
            }

            warningLoginText.text = message;
            Debug.Log("Login failed: " + message);
        }
        else
        {
            
            Debug.Log("else entered ");

            // User is now logged in successfully
            User = LoginTask.Result.User;

            // Check if DisplayName is not null or empty, otherwise, use the email as a fallback
            string displayName = !string.IsNullOrEmpty(User.DisplayName) ? User.DisplayName : User.Email;
            Debug.LogFormat("User signed in successfully: {0} ({1})", displayName, User.Email);

            welcomeText.text = $"Welcome {displayName}!";
            SetUserInitial(displayName);

            // Update the settings panel
            UpdateSettingsPanel(User);

            // Ensure there is no warning text before showing the home screen
            if (string.IsNullOrEmpty(warningLoginText.text))
            {
                UIManager.instance.ShowHomeScreen();
            }
        }
    }


    public void LogoutButton()
    {
        Debug.Log("LogoutButton clicked"); // Add this line for debugging

        if (auth.CurrentUser != null)
        {
            auth.SignOut();
            // Clear login fields
            ClearLoginFields();

            // Reset UI elements to their default state
            ResetUIElements();
           
            Debug.Log("User logged out successfully"); // Add this line for debugging

            // ... Additional UI updates or scene transitions
        }
        else
        {
            Debug.Log("No user is currently logged in"); // Add this line for debugging
        }
    }

    private void ClearLoginFields()
    {
        emailLoginField.text = "";
        passwordLoginField.text = "";
        warningLoginText.text = "";
        confirmLoginText.text = "";
    }

    private void ResetUIElements()
    {
        // Reset any UI elements that were changed during the user's session
        // Example:
        welcomeText.text = "Welcome!";
        initialTextTMP.text = "";

        // Reset settings panel or other UI elements as needed
        initialTextSettings.text = "";
        fullNameTextSettings.text = "";
        emailTextSettings.text = "";
    }


    private IEnumerator Register(string _email, string _password)
    {
        string passwordValidationMessage = passwordFormat(_password, _email);

        if (!string.IsNullOrEmpty(passwordValidationMessage))
        {
            warningRegisterText.text = passwordValidationMessage;
        }
        if (String.IsNullOrEmpty(nameRegisterField.text)){
            warningRegisterText.text = "Missing Name";
        }
        else if (_email == "")
        {
            // If the email field is blank show a warning
            warningRegisterText.text = "Missing Email";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            // If the password does not match show a warning
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            // Call the Firebase auth signin function passing the email and password
            Task<AuthResult> RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            // Wait until the task completes
            //!!!!!
            Debug.Log("loading.. please wait");
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {   
                warningRegisterText.text ="email invalid or already registered.";
                Debug.Log(RegisterTask.Exception);
                Debug.Log("registration error!");
                // Handle registration errors
                // ...
            }
            else
            {
                // User has now been created
                // Now get the result
                Debug.Log("getting result");
                User = RegisterTask.Result.User;

                if (User != null)
                {
                    // Create a user profile and set the Email
                    UserProfile profile = new UserProfile { DisplayName = nameRegisterField.text };

                    // Call the Firebase auth update user profile function passing the profile with the email
                    Task ProfileTask = User.UpdateUserProfileAsync(profile);
                    // Wait until the task completes
                    //!!!!
                    Debug.Log("registering the user..");
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
                    
                    if (ProfileTask.Exception != null)
                    {
                        // Handle profile update errors
                        // ...
                    }
                    else
                    {
                        //!!!!
                        Debug.Log("user registered.");
                        UpdateWelcomeMessage(User.DisplayName);
                        SetUserInitial(User.DisplayName);
                        // Email is now set
                        ClearRegistrationFields();
                        // Now return to the login screen
                        UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                    }
                }
            }
        }
    }

    private void ClearRegistrationFields()
    {
        nameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";
        warningRegisterText.text = "";
    }



    private IEnumerator ForgetPassword(string _email)
    {
        if (string.IsNullOrEmpty(_email))
        {
            // If the email field is empty, display a warning and stop the coroutine
            warningForgetPasswordText.text = "Please enter your email address.";
            yield break; // Stop the coroutine here
        }

        // Call the Firebase auth send password reset email function
        Task ResetPasswordTask = auth.SendPasswordResetEmailAsync(_email);

        // Wait until the task completes
        yield return new WaitUntil(predicate: () => ResetPasswordTask.IsCompleted);

        if (ResetPasswordTask.Exception != null)
        {
            // If there are errors handle them
            Debug.LogWarning(message: $"Failed to send password reset email with {ResetPasswordTask.Exception}");
            FirebaseException firebaseEx = ResetPasswordTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Failed to send password reset email.";
            switch (errorCode)
            {
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
  
                    // Handle other potential errors...
            }
            warningForgetPasswordText.text = message;
        }
        else
        {
            // Password reset email sent successfully
            Debug.Log("Password reset email sent successfully.");
            warningForgetPasswordText.text = "Password reset email sent successfully. Please check your email.";
        }
    }

    
    private void UpdateWelcomeMessage(string userName)
    {
        // Update the UI with the welcome message and the user's name
        welcomeText.text = $"Welcome {userName}!";
        // Update the settings panel with user info if the user is already logged in
        if (auth.CurrentUser != null)
        {
            UpdateSettingsPanel(auth.CurrentUser);
        }
    }

    private void SetUserInitial(string userName)
    {
        if (!string.IsNullOrEmpty(userName) && userName.Length > 0)
        {
            // Extract the first letter of the userName
            char firstLetter = userName[0];
            initialTextTMP.text = firstLetter.ToString().ToUpper(); // Set the initial text to the first letter, capitalized
        }
        else
        {
            // If userName is null or empty, maybe set it to a default initial or leave it blank
            initialTextTMP.text = ""; // Or some default value
        }
    }

    private void UpdateSettingsPanel(FirebaseUser user)
    {
        // Set the initial of user's name
        if (!string.IsNullOrEmpty(user.DisplayName) && user.DisplayName.Length > 0)
        {
            char initial = user.DisplayName[0];
            initialTextSettings.text = initial.ToString().ToUpper();
        }
        else
        {
            initialTextSettings.text = "";
        }

        // Set the full name
        fullNameTextSettings.text = user.DisplayName ?? "";

        // Set the email
        emailTextSettings.text = user.Email ?? "";
    }



}

