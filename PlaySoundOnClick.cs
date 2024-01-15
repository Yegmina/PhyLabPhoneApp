using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource; // Компонент AudioSource, до якого прив'язана звукова доріжка
    public Text text;
    public string textValue;

    public void OnButtonClick()
    {
        // Перевіримо, чи AudioSource і звукова доріжка задані
        if (audioSource != null && audioSource.clip != null)
        {
            // відтворюємо звукову доріжку
            audioSource.Play();
        }

        // Перевіримо, якщо текстове поле і значення текста задані
        if (text != null && !string.IsNullOrEmpty(textValue))
        {
            // Встановлюємо значення текста
            text.text = textValue;
        }
    }
}
