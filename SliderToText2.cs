using UnityEngine;
using UnityEngine.UI;

public class SliderToText2 : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
	public Slider slider4;
	public Slider slider5;
    public Text text1;
    public Text text2;
    public Text text3;
	public Text text4;
	public Text text5;

    private void Start()
    {
        // Назначить метод-обработчик для события изменения значений слайдеров
        slider1.onValueChanged.AddListener(OnSlider1ValueChanged);
        slider2.onValueChanged.AddListener(OnSlider2ValueChanged);
        slider3.onValueChanged.AddListener(OnSlider3ValueChanged);
		slider4.onValueChanged.AddListener(OnSlider4ValueChanged);
		slider5.onValueChanged.AddListener(OnSlider5ValueChanged);
    }

    private void OnSlider1ValueChanged(float value)
    {
        // Обновить текстовое поле 1 значением слайдера 1
		value=Mathf.Round(value*100)/100;
        text1.text = value.ToString()+" кг";
    }

    private void OnSlider2ValueChanged(float value)
    {
        // Обновить текстовое поле 2 значением слайдера 2
		value=Mathf.Round(value*100)/100;
        text2.text = value.ToString()+" градусів";
    }

    private void OnSlider3ValueChanged(float value)
    {
        // Обновить текстовое поле 3 значением слайдера 3
		value=Mathf.Round(value*100)/100;
        text3.text = value.ToString()+" кг";
    }
	 private void OnSlider4ValueChanged(float value)
    {
        // Обновить текстовое поле 3 значением слайдера 3
		value=Mathf.Round(value*100)/100;
        text4.text = value.ToString()+" градусів";
    }
	private void OnSlider5ValueChanged(float value)
    {
        // Обновить текстовое поле 3 значением слайдера 3
		value=Mathf.Round(value*100)/100;
        text5.text = value.ToString()+" градусів";
    }
}
