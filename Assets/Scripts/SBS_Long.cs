// SBS guides

using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class SBS_Long : MonoBehaviour
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
        // TSHIRT 1
        @"<b><size=110%>Step 1:</b> <i>Sewing the Main Bodice</i></size>

<b>1.1</b>  Place the front and back pieces with right sides together.
<b>1.2</b>  Pin along the shoulder and side seams.
<b>1.3</b>  Use a serger or a wide zigzag stitch on your sewing machine to sew the seams with a 1cm seam allowance.",

        @"<b><size=110%>Step 2:</b> <i>Pressing the Seams</i></size>

Press the seams toward the back to flatten them.",

        @"<b><size=110%>Step 3:</b> <i>Sewing the Sleeves</i></size>

<b>3.1</b>  Fold the sleeve pieces with right sides together, matching the side seams.
<b>3.2</b>  Sew these seams on the serger with a 1cm seam allowance.
<b>3.3</b>  Run overlocking stitches around the cuff of each sleeve and the bottom hem of the shirt.",

        @"<b><size=110%>Step 4:</b> <i>Attaching Sleeves to the Bodice</i></size>

<b>4.1</b>  Match the side seam on the sleeve to the side seam on the shirt.
<b>4.2</b>  Match the center of the sleeve to the shoulder seam.
<b>4.3</b>  Pin the sleeve into the armhole.
<b>4.4</b>  Sew the sleeve to the armhole with a 1cm seam allowance using a serger or overlocker.",

        @"<b><size=110%>Step 5:</b> <i>Hemming</i></size>

<b>5.1</b>  Fold the edges of the cuffs and the bottom hem over about 1cm, making sure to tuck the serged edges under.
<b>5.2</b>  Pin the hems in place.
<b>5.3</b>  Sew the hems, ensuring a straight line.",

        @"<b><size=110%><i>Your T-shirt is ready! It's easy to tuck into jeans for a stylish outfit.</i></size></b>",
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
