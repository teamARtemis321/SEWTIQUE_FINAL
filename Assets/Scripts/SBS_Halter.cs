// SBS guides

using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class SBS_Halter : MonoBehaviour
{
    public TMP_Text instructionText; 
    public GameObject premadeScreen;
    public GameObject SBS_Overlay;
    public GameObject ARScreen;

    public Button nextButton;
    public Button backButton;
    public Button backButton1;
    public Button finishButton;
    public GameObject instructionchoice;
   
    public int currentIndex = 0;
    public string[] instructions = {
        // HALTER TOP
        @"<b><size=110%>Step 1:</b> <i>Sewing the Bodice</i></size>

<b>1.1</b>  Match the right sides of the front and back bodice pieces.
<b>1.2</b>  Sew the central seam. Use a zigzag stitch with a long and wide stitch setting.
<b>1.3</b>  Fold the fabric on the opening to create a seam allowance of 1cm.
<b>1.4</b>  Fold the fabric for the armholes and hem the armholes with a 1cm zigzag stitch.",

        @"<b><size=110%>Step 2:</b> <i>Sewing the Neckband</i></size>

<b>2.1</b>  To gather both sides on the front of the top, set your machine to the widest stitch setting and the lowest tension. Gather each piece to around 16-20 centimeters.
<b>2.2</b>  Fold the neckband strip in half lengthwise with the right side down. Fold the edges and sew a hem of 0.5cm allowance to secure the edges.
<b>2.3</b>  Place the top with the right side up and the strip with the right side down.
<b>2.4</b>  Ensure the center points match.
<b>2.5</b>  Sew a straight stitch along the neckline.
<b>2.6</b>  Sew the edges of the neckband together at the back with an overlap of 1.5cm",

        @"<b><size=110%>Step 3:</b> <i>Hemming</i></size>

Hem the bottom of the top by folding the edge over and sew a zigzag stitch with a 1cm seam allowance.",

        @"<b><size=110%><i>Thats it! Your Halter Top is now ready for you to wear to create a chic and fun ensemble.</i></size></b>",
    };

    public void NextInstruction()
    {
        if (currentIndex < instructions.Length - 1)
        {
            currentIndex++;
            UpdateInstructionText();
        }
    }

    public void PreviousInstruction()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateInstructionText();
        }
    }

    public void UpdateInstructionText()
    {
        instructionText.text = instructions[currentIndex];
        backButton.gameObject.SetActive(currentIndex > 0);
        nextButton.gameObject.SetActive(currentIndex < instructions.Length - 1);
    }

    public void showPremade()
    {
        premadeScreen.SetActive(true);
        SBS_Overlay.SetActive(false);
        ARScreen.SetActive(false);
    }
    public void ShowPrevious(){
        SBS_Overlay.SetActive(false);
        instructionchoice.SetActive(true);
    }

    public void Start()
    {
        currentIndex = 0; // Reset to the first instruction
        UpdateInstructionText();
        nextButton.onClick.AddListener(() => NextInstruction());
        backButton.onClick.AddListener(() => PreviousInstruction());
        finishButton.onClick.AddListener(() => showPremade());
    }
}
