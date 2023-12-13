// SBS guides

using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class SBS_Shirred : MonoBehaviour
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
        @"
        
<size=110%>To sew this Premade Pattern, you will require some additional materials: </size>

•  Elastic thread: Size XS & S = 7m, Size M = 8m, Size L = 9m, Size XL = 10m

•  Bobbin casing",
        @"<b><size=110%>Step 1:</b> <i>Sew Side Seams of the Bodice</i></size>

Sew up the side seams of the shirt with a 1cm seam allowance, ensuring the right sides are together. This forms a tube.",
        @"<b><size=110%>Step 2:</b> <i>Hemming</i></size>

<b>2.1</b>  Hem both the top and bottom of the shirt. 
<b>2.2</b>  Fold the fabric over about 0.5cm and press. 
<b>2.3</b>  Then fold it over again, creating a 1cm hem, and press. 
<b>2.4</b>  Sew the hems in place.",

        @"<b><size=110%>Step 3:</b> <i>Shirring</i></size>

<b>3.1</b>  Wind the elastic thread onto the bobbin by hand. Make sure you do not stretch the elastic when winding.
<b>3.2</b>  Set your sewing machine's stitch length to the longest setting.
<b>3.3</b>  Adjust your machine's tension to be loose.
<b>3.4</b>  Sew rows of shirring by stitching on the right side of the fabric. Ensure you backstitch at the beginning and end of each seam. The more rows of shirring you add, the more stretchy and gathered the fabric will become. Experiment with the number of rows based on your preference.",
        @"<b><size=110%>Note: </size></b>

You may need to wind the bobbin multiple times with the elastic thread during this process if you did not wind the entire stated amount in the beginning.",
        @"<b><size=110%>Step 4:</b> <i>Sewing the Straps</i></size>

<b>4.1</b>  Create the straps by folding the sleeve rectangle of fabric in half along its long side. 
<b>4.2</b>  Hem both short ends with a double fold to prevent unravelling. 
<b>4.3</b>  Use your serger to secure the raw edges.",
        @"<b><size=110%>Step 5:</b> <i>Shirring the Straps</i></size>

Shirr one end of each strap by adding rows of shirring to create a ruffled effect.",
        @"<b><size=110%>Step 6:</b> <i>Attaching the Straps to the Bodice</i></size>

6.1  Pin the straps to the top, ensuring they overlap the shoulder area by 1.5cm.
6.2  When pinning, gently stretch the fabric to ensure a smooth fit that lays evenly on the bodice.
6.3  Sew the straps in place, concealing the seam with the previous hem on the edge of the shirt.

<b><size=110%><i>Your shirred top is now complete, and you can wear it with style!</i></size></b>",

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
        backButton.onClick.AddListener(() => PreviousInstruction());
        finishButton.onClick.AddListener(() => showPremade());
    }
}
