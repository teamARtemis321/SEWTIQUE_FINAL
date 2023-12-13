using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ImagePlacer : MonoBehaviour
{
    public GameObject plane;
    public Transform planetransform;
    public RectTransform uiPanel;
    public GameObject ARPanel;
    public GameObject CustomDesignPanel;
    public GameObject homeScreenPanel;

    public GameObject arrangementPanelParent;
    
    public GameObject customdesignscreen;
    public Button FinishButton;
    public Button ExitButton;
    public Button BackButton;
    public Button ConfirmButton;
    public GameObject panelToClear;
    public GameObject ConfirmBackPanel;

    public float opacity = 0.5f;

    public GameObject askTutorials;

    public SpriteRenderer spriteRenderer;
    public GameObject guidesPanel;

    public GameObject panel;
    private Vector2 actualPlaneSize;

    public TMP_InputField lengthInputField;
    public TMP_InputField widthInputField;
    public GameObject homescreen;

    void Start()
    {
        if (plane == null || uiPanel == null)
        {
            Debug.LogError("Setup Incomplete: Please ensure all references are set in the Inspector.");
            return;
        }
        
        //FinishButton.onClick.AddListener(ResetValues);
        //BackButton.onClick.AddListener(LoadCustomDesignScreen); 
        //ExitButton.onClick.AddListener(ResetValues);
        FinishButton.onClick.AddListener(AdjustAnchorsToBottomLeft);
        ExitButton.onClick.AddListener(AdjustAnchorsToBottomLeft);
        ConfirmButton.onClick.AddListener(AdjustAnchorsToCenter);
        ConfirmButton.onClick.AddListener(OnButtonClicked);
    }
    
    void LoadCustomDesignScreen(){
        
        CustomDesignPanel.SetActive(false);
        ARPanel.SetActive(false);
        customdesignscreen.SetActive(true);
         foreach (Transform child in panelToClear.transform)
            {
                Destroy(child.gameObject);
            }
    }

    public void resetFabricDimensions()
    {
        widthInputField.text = "";
        lengthInputField.text = "";
    }

    void AdjustAnchorsToCenter()
    {
        foreach (Transform child in panel.transform)
        {
            // Check if the child is an image
            if (child.GetComponent<Image>() != null)
            {
                RectTransform rectTransform = child.GetComponent<RectTransform>();

                // Store the original position
                Vector3 originalPosition = rectTransform.localPosition;

                // Set the anchor to the middle
                rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

                // Reset the position to the original
                rectTransform.localPosition = originalPosition;
            }
        }
    }
    void AdjustAnchorsToBottomLeft()
    {
        foreach (Transform child in panel.transform)
        {
            // Check if the child is an image
            if (child.GetComponent<Image>() != null)
            {
                RectTransform rectTransform = child.GetComponent<RectTransform>();

                // Store the original position
                Vector3 originalPosition = rectTransform.localPosition;

                // Set the anchor to the bottom left
                rectTransform.anchorMin = new Vector2(0f, 0f);
                rectTransform.anchorMax = new Vector2(0f, 0f);

                // Reset the position to the original
                rectTransform.localPosition = originalPosition;
            }
        }
    }
    public void LoadPreviousScreen(){
        
        CustomDesignPanel.SetActive(true);
        ARPanel.SetActive(false);
    }

    public void AcceptTutorials()
    {
        askTutorials.SetActive(false);
        guidesPanel.SetActive(true);
        ARPanel.SetActive(false);
    }

    public void SkipTutorial()
    {
        askTutorials.SetActive(false);
        ARPanel.SetActive(false);
        homeScreenPanel.SetActive(true);
    }


    public void Finish()
    {
        ARPanel.SetActive(false);
        arrangementPanelParent.SetActive(false);
        customdesignscreen.SetActive(false);
        askTutorials.SetActive(true);

        for (int i = 0; i < planetransform.childCount; i++)
            {
                Transform child = planetransform.GetChild(i);
                Destroy(child.gameObject);
            }
    }

    public void ExitMethod()
    {
        ConfirmBackPanel.SetActive(true);
    }

    public void confirmBack()
    {
        ConfirmBackPanel.SetActive(false);
        ARPanel.SetActive(false);
        arrangementPanelParent.SetActive(false);
        customdesignscreen.SetActive(false);
        homeScreenPanel.SetActive(true);
        for (int i = 0; i < planetransform.childCount; i++)
        {
            Transform child = planetransform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    public void cancelBack()
    {
        ConfirmBackPanel.SetActive(false);
    }



    public void OnButtonClicked()
    {
        homescreen.SetActive(false);
        CustomDesignPanel.SetActive(false);
        ARPanel.SetActive(true);
        MeshRenderer planeRenderer = plane.GetComponent<MeshRenderer>();
        if (planeRenderer == null)
        {
            Debug.LogError("Component Missing: Plane object must have a MeshRenderer component.");
            return;
        }

        actualPlaneSize = new Vector2(planeRenderer.bounds.size.x, planeRenderer.bounds.size.z);

        // Automatically get all Image components that are children of uiPanel
        Image[] uiImages = uiPanel.GetComponentsInChildren<Image>();

        if (uiImages == null || uiImages.Length == 0)
        {
            Debug.LogError("No Images Found: Ensure there are Image components as children of the UI Panel.");
            return;
        }

        PlaceImagesOnPlane(uiImages);
    }

    private float yOffset = 0.001f;

    public void PlaceImagesOnPlane(Image[] uiImages)
{ 
    for (int i = 1; i < uiImages.Length; i++)
    {
         float cumulativeOffsetX = 0f;
        RectTransform rectTransform = uiImages[i].GetComponent<RectTransform>();

        // Calculate the normalized position within the panel, relative to the center
        Vector2 normalizedPosition = new Vector2(
            (rectTransform.anchoredPosition.x + uiPanel.rect.width * 0.5f) / uiPanel.rect.width, //!
            (rectTransform.anchoredPosition.y + uiPanel.rect.height * 0.5f) / uiPanel.rect.height  //!
        );
        
        GameObject imageGameObject = new GameObject("ImageObject" + i);
        spriteRenderer = imageGameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = uiImages[i].sprite;
        Vector2 size = spriteRenderer.sprite.bounds.size;

        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = opacity; // Set the alpha value
            spriteRenderer.color = color;
        }


        // Calculate the offset based on the sprite size
        Vector2 offset = new Vector2(
            size.x/2,
            size.y/2
        );

        // Convert the normalized position to the plane's world position and apply the offset
        Vector3 newPosition = new Vector3(
            plane.transform.position.x + (normalizedPosition.x -0.5f) * actualPlaneSize.x + offset.x,
            plane.transform.position.y + yOffset,
            plane.transform.position.z + (normalizedPosition.y -0.5f) * actualPlaneSize.y + offset.y
        );

        imageGameObject.transform.position = newPosition;
        imageGameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        imageGameObject.transform.SetParent(plane.transform, true);
        if (i > 1)
        {
            RectTransform prevRectTransform = uiImages[i - 1].GetComponent<RectTransform>();
            Vector2 prevSize = prevRectTransform.rect.size; // Size of the previous image
            cumulativeOffsetX += (prevSize.x / 1000f) + 1f; // Add the width of the previous image and 10 cm gap
        }
    }
}


}
































/*using UnityEngine;
using UnityEngine.UI;

public class ImagePlacer : MonoBehaviour
{
    public GameObject plane;
    public Transform planetransform;
    public RectTransform uiPanel;
    public GameObject ARPanel;
    public GameObject CustomDesignPanel;
    public Button FinishButton;
    public Button ExitButton;
    public Button BackButton;
    public Button ConfirmButton;
    public GameObject panelToClear;

    private Vector2 actualPlaneSize;

    void Start()
    {
        if (plane == null || uiPanel == null)
        {
            Debug.LogError("Setup Incomplete: Please ensure all references are set in the Inspector.");
            return;
        }
        
        FinishButton.onClick.AddListener(ResetValues);
        //BackButton.onClick.AddListener(LoadPreviousScreen);
        ExitButton.onClick.AddListener(ResetValues);
        ConfirmButton.onClick.AddListener(OnButtonClicked);
    }

    void LoadPreviousScreen()
    {
        CustomDesignPanel.SetActive(true);
        ARPanel.SetActive(false);
         foreach (Transform child in panelToClear.transform)
            {
                Destroy(child.gameObject);
            }
    }
    void ResetValues(){

        CustomDesignPanel.SetActive(true);
        ARPanel.SetActive(false);
        for (int i = 0; i < planetransform.childCount; i++)
            {
                Transform child = planetransform.GetChild(i);
                Destroy(child.gameObject);
            }
    }
    void OnButtonClicked()
    {
        CustomDesignPanel.SetActive(false);
        ARPanel.SetActive(true);
        MeshRenderer planeRenderer = plane.GetComponent<MeshRenderer>();
        if (planeRenderer == null)
        {
            Debug.LogError("Component Missing: Plane object must have a MeshRenderer component.");
            return;
        }

        actualPlaneSize = new Vector2(planeRenderer.bounds.size.x, planeRenderer.bounds.size.z);

        // Automatically get all Image components that are children of uiPanel
        Image[] uiImages = uiPanel.GetComponentsInChildren<Image>();

        if (uiImages == null || uiImages.Length == 0)
        {
            Debug.LogError("No Images Found: Ensure there are Image components as children of the UI Panel.");
            return;
        }

        PlaceImagesOnPlane(uiImages);
    }

    private float yOffset = 0.001f;
    public float aspectR;

    public void acceptAspect(float aRatio)
    {
        float aspectR = aRatio;
    }

/*
    private void PlaceImagesOnPlane(Image[] uiImages)
    {
        for (int i = 1; i < uiImages.Length; i++)
        {
            
            RectTransform rectTransform = uiImages[i].GetComponent<RectTransform>();

            // Calculate position ratio within the panel, from -1 to 1.
            Vector2 imagePositionInPanel = new Vector2(
                (rectTransform.anchoredPosition.x / (uiPanel.rect.width / 2)),
                (rectTransform.anchoredPosition.y / (uiPanel.rect.height / 2))
            );
            Debug.Log("image width: " + rectTransform.rect.width);
            Debug.Log("image height: " + rectTransform.rect.height);

            // Convert this position ratio to world position on the plane.
            Vector3 newPosition = new Vector3(
                plane.transform.position.x + (imagePositionInPanel.x * (actualPlaneSize.x / 2)),
                plane.transform.position.y + yOffset,
                plane.transform.position.z + (imagePositionInPanel.y * (actualPlaneSize.y / 2))
            );

            GameObject imageGameObject = new GameObject("ImageObject" + i);
            SpriteRenderer spriteRenderer = imageGameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = uiImages[i].sprite;

            imageGameObject.transform.position = newPosition;
            imageGameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            imageGameObject.transform.SetParent(plane.transform, true);
            Vector3 scale =new Vector3(rectTransform.rect.width, rectTransform.rect.height, 1);
            scale.x/=(aspectR*1000);
            scale.y/=(aspectR*1000);
            scale.z/=(aspectR*1000);
            imageGameObject.transform.localScale = scale;
        }
    }
}



//!!!!!!!! WORKING ONE !!!! 

private void PlaceImagesOnPlane(Image[] uiImages)
{
    for (int i = 1; i < uiImages.Length; i++)
    {
         float cumulativeOffsetX = 0f;
        RectTransform rectTransform = uiImages[i].GetComponent<RectTransform>();

        // Calculate the normalized position within the panel, relative to the center
        Vector2 normalizedPosition = new Vector2(
            (rectTransform.anchoredPosition.x + uiPanel.rect.width * 0.5f) / uiPanel.rect.width,
            (rectTransform.anchoredPosition.y + uiPanel.rect.height * 0.5f) / uiPanel.rect.height
        );
        
        GameObject imageGameObject = new GameObject("ImageObject" + i);
        SpriteRenderer spriteRenderer = imageGameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = uiImages[i].sprite;
        Vector2 size = spriteRenderer.sprite.bounds.size;
        // Calculate the offset based on the sprite size
        Vector2 offset = new Vector2(
            size.x/2,
            size.y/2
        );

        // Convert the normalized position to the plane's world position and apply the offset
        Vector3 newPosition = new Vector3(
            plane.transform.position.x + (normalizedPosition.x -0.5f) * actualPlaneSize.x + offset.x,
            plane.transform.position.y + yOffset,
            plane.transform.position.z + (normalizedPosition.y -0.5f) * actualPlaneSize.y + offset.y
        );

        imageGameObject.transform.position = newPosition;
        imageGameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        imageGameObject.transform.SetParent(plane.transform, true);
        if (i > 1)
        {
            RectTransform prevRectTransform = uiImages[i - 1].GetComponent<RectTransform>();
            Vector2 prevSize = prevRectTransform.rect.size; // Size of the previous image
            cumulativeOffsetX += (prevSize.x / 1000f) + 1f; // Add the width of the previous image and 10 cm gap
        }
    }
}

*/


// //^ WORKING ONE PT2 

// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// public class ImagePlacer : MonoBehaviour
// {
//     public GameObject plane;
//     public Transform planetransform;
//     public RectTransform uiPanel;
//     public GameObject ARPanel;
//     public GameObject CustomDesignPanel;
    
//     public GameObject customdesignscreen;
//     public Button FinishButton;
//     public Button ExitButton;
//     public Button BackButton;
//     public Button ConfirmButton;
//     public GameObject panelToClear;

//     public GameObject panel;
//     private Vector2 actualPlaneSize;

//     public TMP_InputField lengthInputField;
//     public TMP_InputField widthInputField;

//     void Start()
//     {
//         if (plane == null || uiPanel == null)
//         {
//             Debug.LogError("Setup Incomplete: Please ensure all references are set in the Inspector.");
//             return;
//         }
        
//         FinishButton.onClick.AddListener(ResetValues);
//         BackButton.onClick.AddListener(LoadCustomDesignScreen);
//         ExitButton.onClick.AddListener(ResetValues);
//         FinishButton.onClick.AddListener(AdjustAnchorsToBottomLeft);
//         ExitButton.onClick.AddListener(AdjustAnchorsToBottomLeft);
//         ConfirmButton.onClick.AddListener(AdjustAnchorsToCenter);
//         ConfirmButton.onClick.AddListener(OnButtonClicked);
//     }
    
//     void LoadCustomDesignScreen(){
        
//         CustomDesignPanel.SetActive(false);
//         ARPanel.SetActive(false);
//         customdesignscreen.SetActive(true);
//          foreach (Transform child in panelToClear.transform)
//             {
//                 Destroy(child.gameObject);
//             }
//     }

//     public void resetFabricDimensions()
//     {
//         widthInputField.text = "";
//         lengthInputField.text = "";
//     }

//     void AdjustAnchorsToCenter()
//     {
//         foreach (Transform child in panel.transform)
//         {
//             // Check if the child is an image
//             if (child.GetComponent<Image>() != null)
//             {
//                 RectTransform rectTransform = child.GetComponent<RectTransform>();

//                 // Store the original position
//                 Vector3 originalPosition = rectTransform.localPosition;

//                 // Set the anchor to the middle
//                 rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
//                 rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

//                 // Reset the position to the original
//                 rectTransform.localPosition = originalPosition;
//             }
//         }
//     }
//     void AdjustAnchorsToBottomLeft()
//     {
//         foreach (Transform child in panel.transform)
//         {
//             // Check if the child is an image
//             if (child.GetComponent<Image>() != null)
//             {
//                 RectTransform rectTransform = child.GetComponent<RectTransform>();

//                 // Store the original position
//                 Vector3 originalPosition = rectTransform.localPosition;

//                 // Set the anchor to the bottom left
//                 rectTransform.anchorMin = new Vector2(0f, 0f);
//                 rectTransform.anchorMax = new Vector2(0f, 0f);

//                 // Reset the position to the original
//                 rectTransform.localPosition = originalPosition;
//             }
//         }
//     }
//     void LoadPreviousScreen(){
        
//         CustomDesignPanel.SetActive(true);
//         ARPanel.SetActive(false);
//          foreach (Transform child in panelToClear.transform)
//             {
//                 Destroy(child.gameObject);
//             }
//     }
//     void ResetValues(){

//         CustomDesignPanel.SetActive(true);
//         ARPanel.SetActive(false);
//         for (int i = 0; i < planetransform.childCount; i++)
//             {
//                 Transform child = planetransform.GetChild(i);
//                 Destroy(child.gameObject);
//             }
//     }
//     void OnButtonClicked()
//     {
//         CustomDesignPanel.SetActive(false);
//         ARPanel.SetActive(true);
//         MeshRenderer planeRenderer = plane.GetComponent<MeshRenderer>();
//         if (planeRenderer == null)
//         {
//             Debug.LogError("Component Missing: Plane object must have a MeshRenderer component.");
//             return;
//         }

//         actualPlaneSize = new Vector2(planeRenderer.bounds.size.x, planeRenderer.bounds.size.z);

//         // Automatically get all Image components that are children of uiPanel
//         Image[] uiImages = uiPanel.GetComponentsInChildren<Image>();

//         if (uiImages == null || uiImages.Length == 0)
//         {
//             Debug.LogError("No Images Found: Ensure there are Image components as children of the UI Panel.");
//             return;
//         }

//         PlaceImagesOnPlane(uiImages);
//     }

//     private float yOffset = 0.001f;

//     private void PlaceImagesOnPlane(Image[] uiImages)
// {
//     for (int i = 1; i < uiImages.Length; i++)
//     {
//         float cumulativeOffsetX = 0f;
//         RectTransform rectTransform = uiImages[i].GetComponent<RectTransform>();

//         Vector2 normalizedPosition = new Vector2(
//             (rectTransform.anchoredPosition.x + uiPanel.rect.width * 0.5f) / uiPanel.rect.width,
//             (rectTransform.anchoredPosition.y + uiPanel.rect.height * 0.5f) / uiPanel.rect.height
//         );
        
//         GameObject imageGameObject = new GameObject("ImageObject" + i);
//         SpriteRenderer spriteRenderer = imageGameObject.AddComponent<SpriteRenderer>();
//         spriteRenderer.sprite = uiImages[i].sprite;

//         Vector2 size = spriteRenderer.sprite.bounds.size; // Size of the sprite
//         Debug.Log(size);
//         Debug.Log(normalizedPosition);

//         // Set the local scale of the imageGameObject to match the sprite's size
//         imageGameObject.transform.localScale = new Vector3(size.y/10, size.x/10, 1);
//         Debug.Log(imageGameObject.transform.localScale);

//         Vector2 offset = new Vector2(size.x/2, size.y/2);

//         Vector3 newPosition = new Vector3(
//             plane.transform.position.x + (normalizedPosition.x -0.5f) * actualPlaneSize.x + offset.x,
//             plane.transform.position.y + yOffset,
//             plane.transform.position.z + (normalizedPosition.y -0.5f) * actualPlaneSize.y + offset.y
//         );
//         Debug.Log(newPosition);
//         imageGameObject.transform.position = newPosition;
//         imageGameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
//         imageGameObject.transform.SetParent(plane.transform, true);

//         if (i > 1)
//         {
//             RectTransform prevRectTransform = uiImages[i - 1].GetComponent<RectTransform>();
//             Vector2 prevSize = prevRectTransform.rect.size; // Size of the previous image
//             cumulativeOffsetX += (prevSize.x / 1000f) + 1f; // Add the width of the previous image and 10 cm gap
//         }
//     }
// }



// }