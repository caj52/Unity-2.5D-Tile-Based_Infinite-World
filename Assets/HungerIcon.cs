using UnityEngine;
using UnityEngine.UI;

public class HungerIcon : MonoBehaviour
{
    public static HungerIcon Instance;
    private Image image;
    public void Init()
    {
        Instance = this;
        image = GetComponent<Image>();
    }

    public void UpdateHungerIcon(float currentHungerValue)
    {
        var newAmount = currentHungerValue / 100;
        image.fillAmount = newAmount;
    }
}
