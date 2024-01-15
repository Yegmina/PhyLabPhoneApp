using UnityEngine;
using UnityEngine.UI;
// таймер по звуку для ударів в лабораторній роботе 003
public class SoundTimer : MonoBehaviour
{
    public float minTimeThreshold = 0.5f; // Мінімальний інтервал часу між звуками
    public float maxTimeThreshold = 3.0f; // Максимальний інтервал часу між звуками
    public float volumeThreshold = 0.1f; // Поріг гучності улавлювання сигналів

    private float lastSoundTime; // Час останнього звука

    private AudioSource audioSource;
	public Text timerText; // Посилання на текстовый UI
	
		public Slider slider;

    private void Start()
    {
        lastSoundTime = Time.time; // Ініціація часу останнього звука

        if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Application.RequestUserAuthorization(UserAuthorization.Microphone); // Якщо нема дозволу на доступ к мікрофону, запросити його
        }

        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            StartMicrophoneRecording();
        }
        else
        {
			timerText.text = "Нема дозволу до мікрофону або він несправний";
            Debug.LogError("Нема дозволу до мікрофону або він несправний");
        }
    }

    private void Update()
    {
		 volumeThreshold = slider.value;
        if (Microphone.IsRecording(null)) // Перевірка, чи йде запис
        {
            float[] samples = new float[128]; // Массив для збереження аудіо-семплов
            audioSource.GetOutputData(samples, 0); // Отримання семплов

            float sumVolume = 0f;
            for (int i = 0; i < samples.Length; i++)
            {
                sumVolume += Mathf.Abs(samples[i]); // Сума гучності семплів
            }

            float averageVolume = sumVolume / samples.Length; // Середня гучність семплів

            if (averageVolume >= volumeThreshold)
            {
                float currentTime = Time.time; // Отримуємо теперішній час

                float timeSinceLastSound = currentTime - lastSoundTime; // Вираховуємо час з останнього звука

                if (timeSinceLastSound >= minTimeThreshold && timeSinceLastSound <= maxTimeThreshold)
                {
                    // якщо час між сигналами знаходиться в заданому часовому діапазоні
					string timeText = "Час падіння кульки: " + timeSinceLastSound.ToString("F2") + " секунд";
                    timerText.text = timeText; // обновлюємо текстове поле
                
                    Debug.Log("Час падіння кульки: " + timeSinceLastSound.ToString("F2") + " секунд");
                }

                lastSoundTime = currentTime; // Обновлюємо час останнього звука
            }
        }
    }

    private void StartMicrophoneRecording()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Додаємо компонент AudioSource
        audioSource.clip = Microphone.Start(null, true, 1, 44100); // Налаштовуємо AudioSource для запису з мікрофону
        audioSource.loop = true;
        audioSource.Play(); // Запускаємо
    }
}
