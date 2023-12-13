using UnityEngine;
using UnityEngine.UI; 

public class SpriteChanger : MonoBehaviour
{
    public GameObject overlay;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button hide;


    public Image prefabImage;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    public void SetToSprite1() { SetSpriteToPrefab(sprite1); }
    public void SetToSprite2() { SetSpriteToPrefab(sprite2); }
    public void SetToSprite3() { SetSpriteToPrefab(sprite3); }
    public void SetToSprite4() { SetSpriteToPrefab(sprite4); }
    public void SetToSprite5() { SetSpriteToPrefab(sprite5); }

    public void SetSpriteToPrefab(Sprite newSprite)
    {
        prefabImage.sprite = newSprite;
        overlay.SetActive(true);
    }

    public void hideOverlay()
    {
        overlay.SetActive(false);
    }
}
