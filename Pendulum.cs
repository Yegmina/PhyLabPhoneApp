using UnityEngine;
//з'єднання ліній objectA і objectB, використовується в симуляції маятника в лабі 002 та 007
public class Pendulum : MonoBehaviour
{
    public Transform objectA; // Перший об'єкт
    public Transform objectB; // Другий об'єкт
    public Color lineColor = Color.white; // Колір лінії

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        // Встановлюємо позиції точок лінії
        lineRenderer.SetPosition(0, objectA.position);
        lineRenderer.SetPosition(1, objectB.position);

        // Задаємо колір лінії
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }
}
