using UnityEngine;
using UnityEngine.UI;

public class ObjectMover : MonoBehaviour
{
    public Slider slider;             // Ссылка на слайдер
    public Transform[] objects;       // Массив объектов, которые будут перемещаться

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);  // Привязываем метод к событию изменения значения слайдера
    }

    private void OnSliderValueChanged(float value)
    {
        foreach (Transform obj in objects)
        {
            // Вычисляем новую позицию объекта по оси Oy
            float newY = Mathf.Abs(value);
            
            // Обновляем позицию объекта
            obj.position = new Vector3(obj.position.x, newY, obj.position.z);
        }
    }
}
