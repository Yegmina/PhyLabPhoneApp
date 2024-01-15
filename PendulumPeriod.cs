using UnityEngine;
using UnityEngine.UI;
// определение периода колебаний телефона в лабе 002 через акселерометр или гироскоп
public class PendulumPeriod : MonoBehaviour
{
    public enum SensorType { Accelerometer, Gyroscope }
    public SensorType sensorType = SensorType.Accelerometer;
    public Text periodText; // UI Text field to display the average period
	public Slider slider;

    private float startTime;
    private bool isTiming;
    private int oscillationCount;
    private float totalPeriod;
	public float pohibka;

public Toggle acceleromT;
public Toggle gyroscT;
public void accelerom() 
{
	
	
	sensorType = SensorType.Accelerometer;
	  // Установить значение isOn без вызова события onValueChanged
        gyroscT.SetIsOnWithoutNotify(false);
}
public void gyrosc() 
{
	
	
	sensorType = SensorType.Gyroscope;
	// Установить значение isOn без вызова события onValueChanged
        acceleromT.SetIsOnWithoutNotify(false);
}

public void tryagain() // функція перезапуску (кнопка з кружечком)
    {
        
		
		Debug.Log("tryagain()");
	   startTime = Time.time;
        isTiming = false;
        oscillationCount = 0;
        totalPeriod = 0f;
		

        if (sensorType == SensorType.Accelerometer)
        {
            if (!SystemInfo.supportsAccelerometer)
            {
             periodText.text="Акселерометр не підтримується або нема дозволу";
                return;
            }

            Input.gyro.enabled = true;
        }
        else if (sensorType == SensorType.Gyroscope)
        {
            if (!SystemInfo.supportsGyroscope)
            {
                periodText.text="Гіроскоп не підтримується або нема дозволу.";
                return;
            }

            Input.gyro.enabled = true;
        }
		periodText.text="Розрахунок";
		
    }

	
    void Start()
    {
        startTime = Time.time;
        isTiming = false;
        oscillationCount = 0;
        totalPeriod = 0f;
		pohibka=1f;

        if (sensorType == SensorType.Accelerometer)
        {
            if (!SystemInfo.supportsAccelerometer)
            {
               periodText.text="Акселерометр не підтримується або нема дозволу";
                return;
            }

            Input.gyro.enabled = true;
        }
        else if (sensorType == SensorType.Gyroscope)
        {
            if (!SystemInfo.supportsGyroscope)
            {
                periodText.text="Гіроскоп не підтримується або нема дозволу.";
                return;
            }

            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
		 pohibka = slider.value;
        if (Time.time - startTime < 3f)
        {
            // очікування 3 секунди перед стартом калькуляції
            return;
        }

        if (sensorType == SensorType.Accelerometer)
        {
            Vector3 acceleration = Input.acceleration;
            float magnitude = acceleration.magnitude;

            if (!isTiming && magnitude > pohibka)
            {
                isTiming = true;
                startTime = Time.time;
            }
            else if (isTiming && magnitude < pohibka)
            {
                isTiming = false;
                float period = Time.time - startTime;
                totalPeriod += period;
                oscillationCount++;

                if (oscillationCount == 5)
                {
                    float averagePeriod = totalPeriod / 5f;
                    periodText.text = "Average Period: " + (averagePeriod/2).ToString("F2") + " seconds";
                }
            }
        }
        else if (sensorType == SensorType.Gyroscope)
        {
            Vector3 rotationRate = Input.gyro.rotationRateUnbiased;
            float magnitude = rotationRate.magnitude;

            if (!isTiming && magnitude > pohibka)
            {
                isTiming = true;
                startTime = Time.time;
            }
            else if (isTiming && magnitude < pohibka)
            {
                isTiming = false;
                float period = Time.time - startTime;
                totalPeriod += period;
                oscillationCount++;

                if (oscillationCount == 5)
                {
                    float averagePeriod = totalPeriod / 5f;
                    periodText.text = "Average Period: " + (averagePeriod/2).ToString("F2") + " seconds";
                }
            }
        }
    }
	
	public void slider_change_value() {
		Debug.Log("debug:slider_change_value()");
		 pohibka = slider.value;
		 startTime = Time.time;
        isTiming = false;
        oscillationCount = 0;
        totalPeriod = 0f;
		

        if (sensorType == SensorType.Accelerometer)
        {
            if (!SystemInfo.supportsAccelerometer)
            {
               periodText.text="Accelerometer is not supported on this device.";
                return;
            }

            Input.gyro.enabled = true;
        }
        else if (sensorType == SensorType.Gyroscope)
        {
            if (!SystemInfo.supportsGyroscope)
            {
                periodText.text="Gyroscope is not supported on this device.";
                return;
            }

            Input.gyro.enabled = true;
        }
		periodText.text="Розрахунок";
	}
}
