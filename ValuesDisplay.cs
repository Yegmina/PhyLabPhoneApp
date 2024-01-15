using UnityEngine;
using UnityEngine.UI;

public class ValuesDisplay : MonoBehaviour
{
    public Text valuesText;
    public Text sliderValueText; // Текстове поле для виводу значення слайдера (сила струму)
    public Slider currentSlider;
	public Image leftImage;
    public Image rightImage;
	public Sprite new1LeftImageSprite; 
    public Sprite new1RightImageSprite; 
	
	public Sprite new2LeftImageSprite; 
    public Sprite new2RightImageSprite; 
	
	public Sprite new3LeftImageSprite; 
    public Sprite new3RightImageSprite; 

    public float currentI = 0f;
    public float currentR = 0f;
    public float currentU = 0f;
	public float R1=10f;
	public float R2=10f;
	public float U1=0f;
	public float U2=0f;
	   

    void Update()
    {
        // Отримуємо значення I із слайдера
        currentI = currentSlider.value;

        currentR = R1+R2; // Значення опору для послідовного з'єднання
		
        currentU = currentI * currentR; //  U = I * R
		
		U1 = (currentU*R1)/(R1+R2);
		U2 = currentU-U1;

        // Обновлення текстового поля з I, R и U
        valuesText.text = $"I=I1=I2: {currentI} A\nR: {currentR} kΩ\nU: {currentU} V\nU1:{U1}V\nU2:{U2}V ";

        // Обновлення текстового поля з значення слайдера
        sliderValueText.text = $"I: {currentI} A";
    }
	
	//ченджери зображень
	public void Change1LeftImage()
    {
		R1=100f;
        leftImage.sprite = new1LeftImageSprite;
    }

    public void Change1RightImage()
    {
		R2=100f;
        rightImage.sprite = new1RightImageSprite;
    }
	
	public void Change2LeftImage()
    {
		R1=10f;
        leftImage.sprite = new2LeftImageSprite;
    }

    public void Change2RightImage()
    {	R2=10f;
        rightImage.sprite = new2RightImageSprite;
    }
	
	public void Change3LeftImage()
    {	R1=1f;
        leftImage.sprite = new3LeftImageSprite;
    }

    public void Change3RightImage()
    {	R2=1f;
        rightImage.sprite = new3RightImageSprite;
    }
	
}
