using UnityEngine;
/* збільшення зображення за допомогою пальців, розтягування, використовується в кількох лабах */
public class ImageZoom : MonoBehaviour
{
    private bool isZooming = false;
    private bool isTouching = false;
    private Vector3 originalScale;
    private Vector2 initialTouchPosition;
    private float touchStartTime;
    private float zoomDuration = 0.5f;
    private float holdDuration = 1f;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
                touchStartTime = Time.time;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;

                if (Time.time - touchStartTime > holdDuration)
                {
                    // Выключаем режим увеличения
                    transform.localScale = originalScale;
                    isZooming = false;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                float touchDeltaMag = (touch1.position - touch2.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                if (!isZooming)
                {
                    isZooming = true;
                    initialTouchPosition = (touch1.position + touch2.position) / 2f;
                }

                float zoomFactor = deltaMagnitudeDiff * 0.01f;
                Vector3 newScale = transform.localScale + new Vector3(zoomFactor, zoomFactor, 0f);
                transform.localScale = newScale;
            }
        }
    }
}
