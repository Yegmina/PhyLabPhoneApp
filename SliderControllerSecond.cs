using UnityEngine;
using UnityEngine.UI;
public class SliderControllerSecond : MonoBehaviour
{
    public Slider mvSlider;
    public Slider tvSlider;
    public Slider mtSlider;
    public Slider ttSlider;
    public Slider tSlider;
    public Text ctValueText;
    private void Update()
    {
        // Отримуємо значения змінних з слайдерів
        float mv = mvSlider.value; // m1
        float tv = tvSlider.value;//t1
        float mt = mtSlider.value;//m2
        float tt = ttSlider.value;//t2
        float t = tSlider.value;//tкінцеве
        // Перевірка на корректність
        if (Mathf.Approximately(tt - t, 0))
        {
            ctValueText.text = "c = некорректні данні";
        }
        // Обчислюємо значение ct
        float ct = (4200 * mv * (t - tv)) / (mt * (tt - t));
        // Відображаємо значення ct в текстовом поле
        ctValueText.text = "c = " + ct.ToString("F2");
    }
}
