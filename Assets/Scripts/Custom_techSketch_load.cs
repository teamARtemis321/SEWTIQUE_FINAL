//custom tech sketch 222222

using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;


    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button redo;
    
    public Sprite bodice;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;

    private void Start()
    {
        // Assign the initial sprites to the Image components
        image1.sprite = null;
        image2.sprite = null;
        image3.sprite = null;

        // Set all images to transparent
        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 0);
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 0);
        image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 0);

       // Register the buttons' onClick listeners
        button1.onClick.AddListener(() => SetImageToSprite1(sprite1));
        button2.onClick.AddListener(() => SetImageToSprite2(sprite2));
        button3.onClick.AddListener(() => SetImageToSprite3(sprite3));
        button4.onClick.AddListener(() => SetImageToSprite4(sprite4));
        button5.onClick.AddListener(() => SetImageToSprite5(sprite5));
        button6.onClick.AddListener(() => SetImageToSprite6(sprite6));
        button7.onClick.AddListener(() => SetImageToSprite7(sprite7));
        button8.onClick.AddListener(() => SetImageToSprite8(sprite8));
        button9.onClick.AddListener(() => SetImageToSprite9(sprite9));
        button10.onClick.AddListener(() => SetImageToSprite10(sprite10));
        redo.onClick.AddListener(() => SetImageToNull());
    }

    public void SetImageToNull()
    {
        image1.sprite = null;
        image2.sprite = null;
        image3.sprite = null;

        image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 0);
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 0);
        image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 0);
    }

    public void SetImageToSprite1(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }

    public void SetImageToSprite2(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }

    public void SetImageToSprite3(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }
    public void SetImageToSprite4(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }

    public void SetImageToSprite5(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }

    public void SetImageToSprite6(Sprite newSprite)
    {
        if (image1 != null && newSprite != null)
        {
            image1.sprite = newSprite;
            image3.sprite = bodice;
            image3.color = new Color(image3.color.r, image3.color.g, image3.color.b, 1);
            image1.color = new Color(image1.color.r, image1.color.g, image1.color.b, 1);
        }
    }

    public void SetImageToSprite7(Sprite newSprite)
    {
        if (image2 != null && newSprite != null)
        {
            image2.sprite = newSprite;
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 1);
        }
    }

    public void SetImageToSprite8(Sprite newSprite)
    {
        if (image2 != null && newSprite != null)
        {
            image2.sprite = newSprite;
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 1);
        }
    }

    public void SetImageToSprite9(Sprite newSprite)
    {
        if (image2 != null && newSprite != null)
        {
            image2.sprite = newSprite;
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 1);
        }
    }

    public void SetImageToSprite10(Sprite newSprite)
    {
        if (image2 != null && newSprite != null)
        {
            image2.sprite = newSprite;
            image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, 1);
        }
    }
}