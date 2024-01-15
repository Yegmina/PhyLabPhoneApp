using UnityEngine;
using UnityEngine.UI;
// не используется
// увеличение шарика в маятнике зависимости от изменения слайдера массы
public class CircleScaler : MonoBehaviour
{
    public Slider slider; // Ссылка на слайдер
    public GameObject circle; // Ссылка на объект круга

    private float initialRadius = 1f; // Начальный радиус круга
    private float scaleFactor = 0.5f; // Коэффициент масштабирования радиуса

    private void Start()
    {
        // Добавляем обработчик события изменения значения слайдера
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // Вычисляем новый радиус круга
        float newRadius = initialRadius + value * scaleFactor;

        // Изменяем радиус круга
        circle.transform.localScale = new Vector3(newRadius, newRadius, 1f);
    }
}
