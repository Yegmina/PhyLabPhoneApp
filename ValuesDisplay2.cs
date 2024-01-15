using UnityEngine;
using UnityEngine.UI;

public class ValuesDisplay2 : MonoBehaviour
{
    public Text valuesText;
    public Text sliderValueText; 
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
	public float I1=0f;
	public float I2=0f;
	
	   

    void Update()
    {
        
        currentI = currentSlider.value;

        currentR = (R1*R2)/(R1+R2); 
		
        currentU = currentI * currentR; 
		
		U1 = currentU;
		U2 = currentU;
		I1=U1/R1;
		I2=U2/R2;
    
	valuesText.text = $"I: {currentI} A\nR: {currentR} kΩ\nU=U1=U2: {currentU} V\nI1:{I1}A\nI2: {I2}A";
        sliderValueText.text = $"I: {currentI} A";
    }
	
	
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
