using UnityEngine;
using UnityEngine.UI;
using System.Linq;
/* для лаби 001 - дослідження дифузії */
public class ColorDiffusion : MonoBehaviour 
{
    public RawImage displayImage; // UI елемент для відображення відео (фото)
    public Text resultText; // текстове поле для виводу результатів

    private WebCamTexture webCamTexture; // камера
	public Text timerText; // текстове поле для відображення таймеру

    private float timer = 0.0f; // таймер
    private bool isTimerOn = true; // змінна стану таймера
	
	public float tolerance = 0.15f; // допустиме відхилення (коефіцієнт строгості оцінки)
	public Slider toleranceSlider; // слайдер для налаштування tolerance


    // старт 
    void Start()
    {
		 toleranceSlider.onValueChanged.AddListener(UpdateTolerance);

        // ініціація камери
        webCamTexture = new WebCamTexture();
        displayImage.texture = webCamTexture;
        webCamTexture.Play();
		 webCamTexture.Play();
		 StartTimer();
		 
    }
	
private void UpdateTolerance(float newValue)
{
    tolerance = newValue;
}
	 // обновлювання таймера
    void Update()
    {
		
        // тільки якщо таймер ввімкнений, додаємо час
        if (isTimerOn)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2") + " секунд";
			
        }
    }

    // фіксація камери при натисканні на кнопку "готово"
    public void StopCamera()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
           // webCamTexture.Stop(); // для зупинки камери, потрібно для дебагу
        }

        
		//вираховуємо "середній колір"
        Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
        snapshot.SetPixels(webCamTexture.GetPixels());
        snapshot.Apply();
        
        Rect upperRect = new Rect(0, snapshot.height/2, snapshot.width, snapshot.height/2);
        Rect lowerRect = new Rect(0, 0, snapshot.width, snapshot.height/2);

        Color averageUpperColor = GetAverageColorFromRegion(snapshot, upperRect);
        Color averageLowerColor = GetAverageColorFromRegion(snapshot, lowerRect);

        bool areColorsSimilar = AreColorsSimilar(averageUpperColor, averageLowerColor);

        // виводимо результат
        resultText.text = areColorsSimilar ? "Дифузія завершена" : "Дифузія не завершена";
		if (areColorsSimilar) StopTimer();
    }
//функція отримання "середнього кольору" по RGBA
    private Color GetAverageColorFromRegion(Texture2D image, Rect region)
    {
        Color[] colors = new Color[(int)region.width * (int)region.height];

        for (int y = (int)region.y; y < (int)(region.y + region.height); y++)
        {
            for (int x = (int)region.x; x < (int)(region.x + region.width); x++)
            {
                colors[(y - (int)region.y) * (int)region.width + (x - (int)region.x)] = image.GetPixel(x, y);
            }
        }

        float averageR = colors.Average(color => color.r);
        float averageG = colors.Average(color => color.g);
        float averageB = colors.Average(color => color.b);
        float averageA = colors.Average(color => color.a);

        return new Color(averageR, averageG, averageB, averageA);
    }
//перевірка на "рівність кольору" по RGBA з урахуванням допустимого відхилення
    private bool AreColorsSimilar(Color color1, Color color2)
    {
       
        return Mathf.Abs(color1.r - color2.r) <= tolerance &&
               Mathf.Abs(color1.g - color2.g) <= tolerance &&
               Mathf.Abs(color1.b - color2.b) <= tolerance;
    }
	// функція ввімкнення таймеру
    public void StartTimer()
    {
        isTimerOn = true;
    }

    // функція для відключення таймеру
    public void StopTimer()
    {
        isTimerOn = false;
    }
}
