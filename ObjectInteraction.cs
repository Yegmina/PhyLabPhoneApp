using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject cubeObject;     // Ссылка на объект "Cube (1)"
    public GameObject sphereObject;   // Ссылка на объект "Sphere"
    public Button button;             // Ссылка на кнопку
    public Text timerText;            // Ссылка на текстовое поле для отображения времени
    private bool countingTime;        // Флаг для отслеживания состояния отсчета времени
    private float startTime;          // Время начала отсчета
    private float endTime;            // Время окончания отсчета

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);  // Привязываем метод к событию нажатия кнопки
        countingTime = false;                        // Изначально отсчет времени не активен
        timerText.text = "";                         // Очищаем текстовое поле
    }

    private void Update()
    {
        if (countingTime)
        {
            float currentTime = Time.time - startTime;
            timerText.text = currentTime.ToString("F2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StopCollider") && countingTime)
        {
            countingTime = false;
            endTime = Time.time;
            float elapsedTime = endTime - startTime;
            timerText.text = "Час падіння становить "+elapsedTime.ToString("F2")+" секунд";
        }
    }

    private void OnButtonClick()
    {
        cubeObject.SetActive(false);     // Выключаем объект "Cube (1)"
        countingTime = true;              // Включаем отсчет времени
        startTime = Time.time;            // Запоминаем время начала отсчета
        timerText.text = "Counting...";   // Обновляем текстовое поле
    }
}
