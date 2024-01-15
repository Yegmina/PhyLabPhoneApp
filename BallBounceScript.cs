using UnityEngine;
using UnityEngine.UI;
/* скрипт для фіксації часу між падінням кульки для лаби 003 */
public class BallBounceScript : MonoBehaviour
{
    public float minTimeThreshold = 0.5f; // Минимальное время между звуками
    public float maxTimeThreshold = 3.0f; // Максимальное время между звуками
    public float volumeThreshold = 0.1f; // Порог громкости для улавливания звука
private bool firstBounce = false;

    private float lastSoundTime; // Время последнего звука

    private AudioSource audioSource;
	public Text timerText; // Ссылка на текстовый UI
	
		public Slider slider;

    private void Start()
    {
        lastSoundTime = Time.time; // Инициализируем время последнего звука

        if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Application.RequestUserAuthorization(UserAuthorization.Microphone); // Запрашиваем разрешение на доступ к микрофону
        }

        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            StartMicrophoneRecording();
        }
        else
        {
			timerText.text = "Нема дозволу до мікрофону або він несправний";
            Debug.LogError("Нет разрешения на доступ к микрофону!");
        }
    }

    private void Update()
    {
		 volumeThreshold = slider.value;
        if (Microphone.IsRecording(null)) // Проверяем, идет ли запись с микрофона
        {
            float[] samples = new float[128]; // Массив для хранения аудио-сэмплов
            audioSource.GetOutputData(samples, 0); // Получаем аудио-сэмплы

            float sumVolume = 0f;
            for (int i = 0; i < samples.Length; i++)
            {
                sumVolume += Mathf.Abs(samples[i]); // Суммируем громкость сэмплов
            }

            float averageVolume = sumVolume / samples.Length; // Средняя громкость сэмплов

            if (averageVolume >= volumeThreshold)
            {
                 float currentTime = Time.time; // Получаем текущее время

    if (!firstBounce)
    {
        firstBounce = true; // Устанавливаем флаг первого удара
        lastSoundTime = currentTime; // Запоминаем время первого удара
    }
    else
    {
        float timeSinceLastSound = currentTime - lastSoundTime; // Вычисляем время, прошедшее с последнего звука

        if (timeSinceLastSound >= minTimeThreshold && timeSinceLastSound <= maxTimeThreshold)
        {
            // Время между звуками находится в заданном диапазоне
            Debug.Log("Час падіння кульки: " + timeSinceLastSound.ToString("F2") + " секунд");
            string timeText = timerText.text + CalculateBounceHeight(timeSinceLastSound).ToString("F2") + "м; ";
            timerText.text = timeText; // Обновляем текстовый UI с временем между звуками
        }

        lastSoundTime = currentTime; // Обновляем время последнего звука
    }
            }
        }
    }

    private void StartMicrophoneRecording()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Добавляем компонент AudioSource
        audioSource.clip = Microphone.Start(null, true, 1, 44100); // Настраиваем AudioSource для записи с микрофона
        audioSource.loop = true;
        audioSource.Play(); // Запускаем запись
    }
	private float CalculateBounceHeight(float time)
    {
        
        float g = 9.8f; // Ускорение свободного падения в м/с^2
        float bounceHeight = 0.5f * g * Mathf.Pow(time, 2);
        return bounceHeight;
    }

}
