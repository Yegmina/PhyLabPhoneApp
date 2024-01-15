using UnityEngine;
using UnityEngine.UI;
//витяг данник зі слайдеров та їх обробка і вивід в текстове поле
public class SliderController : MonoBehaviour
{
    public Slider v1Slider;//об'єм води 1
    public Slider t1Slider;//температура води 1
    public Slider v2Slider;//об'єм води 2
    public Slider t2Slider;//температура води 2
    public Text tValueText;//текстове поле

    private void Update()
    {
        // Отримуємо значення змінних зі слайдерів
        float v1 = v1Slider.value;
        float t1 = t1Slider.value;
        float v2 = v2Slider.value;
        float t2 = t2Slider.value;

        // Вычисляем значение t
        float t = (t1 * v1 + t2 * v2) / (v1 + v2);

        // Отображаем значение t в текстовом поле
        tValueText.text = "t = " + t.ToString("F2");
		if(v1+v2==0) {
			tValueText.text = "вода відсутня";
		}
    }
}
