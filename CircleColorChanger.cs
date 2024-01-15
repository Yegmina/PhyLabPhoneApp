using UnityEngine;
using UnityEngine.UI;
// зміна кольору в маятнику в симуляції в лабі 002
public class CircleColorChanger : MonoBehaviour
{
    public Slider slider;
    public SpriteRenderer circleRenderer;

    private void Update()
    {
        float value = slider.value;

        // Преобразование значения слайдера в диапазон от 1 до 8
        float normalizedValue = (value - 1f) / 7f;

        // Изменение цвета круга на основе нормализованного значения
        circleRenderer.color = Color.Lerp(Color.white, Color.black, normalizedValue);
    }
}
