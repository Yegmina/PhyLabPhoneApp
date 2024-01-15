using UnityEngine;
using UnityEngine.UI;

public class ToggleImageChanger : MonoBehaviour
{
    public ToggleGroup leftToggleGroup;
    public ToggleGroup rightToggleGroup;

    public Image[] leftImages; // Массив изображений для Toggle слева
    public Image[] rightImages; // Массив изображений для Toggle справа

    public Sprite[] leftDefaultSprites; // Массив спрайтов для Toggle слева по умолчанию
    public Sprite[] rightDefaultSprites; // Массив спрайтов для Toggle справа по умолчанию

    private void Start()
    {
        foreach (Toggle toggle in leftToggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener(delegate { OnLeftToggleChanged(toggle); });
        }

        foreach (Toggle toggle in rightToggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener(delegate { OnRightToggleChanged(toggle); });
        }
    }

    private void OnLeftToggleChanged(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            int index = GetActiveToggleIndex(leftToggleGroup);
            if (index >= 0 && index < leftImages.Length)
            {
                leftImages[index].sprite = leftDefaultSprites[index];
            }
        }
    }

    private void OnRightToggleChanged(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            int index = GetActiveToggleIndex(rightToggleGroup);
            if (index >= 0 && index < rightImages.Length)
            {
                rightImages[index].sprite = rightDefaultSprites[index];
            }
        }
    }

    private int GetActiveToggleIndex(ToggleGroup toggleGroup)
    {
        int index = -1;
        foreach (Toggle toggle in toggleGroup.ActiveToggles())
        {
            index = toggle.transform.GetSiblingIndex();
        }
        return index;
    }
}
