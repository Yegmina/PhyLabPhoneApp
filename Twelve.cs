using UnityEngine;
using UnityEngine.UI;

public class Twelve : MonoBehaviour
{
    public Slider mvSlider;
    public Slider tvSlider;
    public Slider mtSlider;
    public Slider ttSlider;
    public Slider tSlider;
    public Text ctValueText;
   // public Text tValueText;

    private void Update()
    {
        // Получаем значения переменных с слайдеров
        float mv = mvSlider.value; // m1
        float tv = tvSlider.value;
        float mt = mtSlider.value;
        float tt = ttSlider.value;
        float t = tSlider.value;

        // Проверка деления на ноль
        if (Mathf.Approximately(tt - t, 0))
        {
            ctValueText.text = "c = некорректні данні";
            
            
        }

        // Вычисляем значение ct
        float ct = (4200 * mv * (t - tv)) / (mt * (tt - t));

        // Отображаем значение ct в текстовом поле
        ctValueText.text = "c = " + ct.ToString("F2");
		if(ct<=0 || float.IsInfinity(ct) || float.IsNegativeInfinity(ct)) {
			ctValueText.text = "c = некорректні данні";
		}
    }
}
