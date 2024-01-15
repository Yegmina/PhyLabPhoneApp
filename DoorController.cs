using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform leftDoor;   // Ссылка на левую дверь
    public Transform rightDoor;  // Ссылка на правую дверь
    public float openDistance = 2.0f;   // Расстояние, на которое двери будут открыты
    public float openSpeed = 1.0f;      // Скорость открытия дверей

    private Vector3 initialLeftPos;     // Начальная позиция левой двери
    private Vector3 initialRightPos;    // Начальная позиция правой двери
    private Vector3 targetLeftPos;      // Целевая позиция левой двери при открытии
    private Vector3 targetRightPos;     // Целевая позиция правой двери при открытии
    private bool isOpening = false;     // Флаг, указывающий на состояние открытия дверей

    private void Start()
    {
        // Сохраняем начальные позиции дверей
        initialLeftPos = leftDoor.position;
        initialRightPos = rightDoor.position;

        // Вычисляем целевые позиции дверей при открытии
        targetLeftPos = initialLeftPos - Vector3.forward * openDistance;
        targetRightPos = initialRightPos + Vector3.forward * openDistance;
    }

    public void OpenDoors()
    {
        if (!isOpening)
        {
            StartCoroutine(OpenDoorsCoroutine());
        }
    }

    private IEnumerator OpenDoorsCoroutine()
    {
        isOpening = true;
        float elapsedTime = 0f;

        while (elapsedTime < openSpeed)
        {
            float t = elapsedTime / openSpeed;
            leftDoor.position = Vector3.Lerp(initialLeftPos, targetLeftPos, t);
            rightDoor.position = Vector3.Lerp(initialRightPos, targetRightPos, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Убеждаемся, что двери точно достигли целевых позиций
        leftDoor.position = targetLeftPos;
        rightDoor.position = targetRightPos;

        isOpening = false;
    }
}
