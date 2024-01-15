using UnityEngine;
// скрипт для 3д обзора зміни ротації камери, використовувався в симуляції в 3д меню в лабораторній роботі 006
public class CameraRotation : MonoBehaviour
{
    public Transform target; // Цель для обзора
    public float rotationSpeed = 1f; // Скорость изменения ротации
    public float duration = 5f; // Продолжительность вращения в одном направлении

    private Vector3 desiredRotation; // Желаемая ротация
    private float elapsedTime = 0f; // Время, прошедшее с начала вращения в одном направлении

    void Start()
    {
        // Начальная ротация камеры
        desiredRotation = transform.eulerAngles;
    }

    void Update()
    {
        // Обновляем время, прошедшее с начала вращения в одном направлении
        elapsedTime += Time.deltaTime;

        // Проверяем, сколько времени прошло
        if (elapsedTime <= duration)
        {
            // Изменяем ротацию в одном направлении
            desiredRotation += new Vector3(rotationSpeed, rotationSpeed, 0f) * Time.deltaTime;
        }
        else if (elapsedTime <= duration * 2)
        {
            // Изменяем ротацию в противоположном направлении
            desiredRotation -= new Vector3(rotationSpeed, rotationSpeed, 0f) * Time.deltaTime;
        }
        else
        {
            // Сбрасываем время и меняем направление вращения
            elapsedTime = 0f;
        }

        // Плавно изменяем текущую ротацию камеры в направлении желаемой ротации
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(desiredRotation), Time.deltaTime);

        // Обновляем позицию камеры, чтобы она всегда смотрела на цель
        transform.LookAt(target);
    }
}
