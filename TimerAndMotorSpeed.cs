using UnityEngine;
using UnityEngine.UI;

public class TimerAndMotorSpeed : MonoBehaviour
{
    public Text timerText;          // Посилання та текстове поле для відображення часу
	public Text timer2Text;          // Посилання на текстове поле для відображення періода
    public GameObject circle;       // Посилання на об'єкт "circle" для встановлення motor speed

    private float startTime;        // Час початку відліку
    private HingeJoint2D hingeJoint; // Посилання на компонент HingeJoint2D

    private void Start()
    {
        startTime = Time.time;                   // Запам'ятаємо час для початку відліку
        hingeJoint = circle.GetComponent<HingeJoint2D>();  // Отримуємо компонент HingeJoint2D
        if (hingeJoint != null)
        {
            // Генеруємо випадкове значення motor speed
            float randomMotorSpeed = Random.Range(100f, 200f);

            // Встановлюємо motor speed для компонента HingeJoint2D
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = randomMotorSpeed;
            hingeJoint.motor = motor;
        }
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;
        timerText.text = currentTime.ToString("F2");
    }
    //обчислення періода обертання
    public void CalculateRotationPeriod()
    {
        if (hingeJoint != null)
        {
            float motorSpeed = hingeJoint.motor.motorSpeed;
            if (motorSpeed != 0)
            {
                float rotationPeriod = 360f / Mathf.Abs(motorSpeed);
				float rotationFrequency=1/rotationPeriod;
               timer2Text.text = "Період: " + rotationPeriod.ToString("F2") + "\nЧастота: " + rotationFrequency.ToString("F2");

				
            }
        }
    }
}
