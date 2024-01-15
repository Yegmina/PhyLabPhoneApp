using UnityEngine;

public class FluidScaler : MonoBehaviour
{
    public Transform sphereTransform; // Посилання на Transform об'єкта Sphere
    public Vector3 initialScale; // Початковий масштаб об'єкта F_Liquid
    public Vector3 targetScale; // Цільовий масштаб при зануренні

    public float scalingSpeed = 1f; // Швидкість зміни масштаба

    private void Start()
    {
        // Збереження початкового масштаба
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Перевіряємо, якщо об'єкт знаходиться в триггері F_Liquid
        if (sphereTransform != null && GetComponent<Collider>().bounds.Contains(sphereTransform.position))
        {
            // Плавно збільшуємо масштабл до цільового значення
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scalingSpeed);
        }
        else
        {
            // Повертаємо масштаб до початкового значення
            transform.localScale = Vector3.Lerp(transform.localScale, initialScale, Time.deltaTime * scalingSpeed);
        }
    }
}
