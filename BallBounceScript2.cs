using UnityEngine;
using UnityEngine.UI;

public class BallBounceScript2 : MonoBehaviour
{
    public float minTimeThreshold = 0.5f;
    public float maxTimeThreshold = 3.0f;
    public float accelerometerThreshold = 0.1f;

    private float lastVibrationTime;
    public Text timerText;
    public Slider slider;

    private Vector3 lastAcceleration;
    private bool isFalling = false;

    private void Start()
    {
        lastVibrationTime = Time.time;
    }

    private void Update()
    {
        accelerometerThreshold = slider.value;

        Vector3 currentAcceleration = Input.acceleration;

        if (!isFalling)
        {
            lastAcceleration = currentAcceleration;
            isFalling = true;
        }
        else
        {
            float accelerationDelta = Vector3.Distance(currentAcceleration, lastAcceleration);

            if (accelerationDelta >= accelerometerThreshold)
            {
                float currentTime = Time.time;
                float timeSinceLastVibration = currentTime - lastVibrationTime;

                if (timeSinceLastVibration >= minTimeThreshold && timeSinceLastVibration <= maxTimeThreshold)
                {
                    Debug.Log("Час падіння кульки: " + timeSinceLastVibration.ToString("F2") + " секунд");
					
                    string timeText = timerText.text + CalculateBounceHeight(timeSinceLastVibration).ToString("F2") + "м; ";
                    timerText.text = timeText;
                }

                lastVibrationTime = currentTime;
            }
            isFalling = false;
        }
    }

    private float CalculateBounceHeight(float time)
    {
        float g = 9.8f;
        float bounceHeight = 0.5f * g * Mathf.Pow(time, 2);
        return bounceHeight;
    }
}
