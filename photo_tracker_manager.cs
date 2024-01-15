using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class photo_tracker_manager : MonoBehaviour
{
    public Image image;
    public List<Button> buttons = new List<Button>(); 
    public InputField kInputField; 
 public Text answerText;
    public List<RectTransform> pointPrefabs = new List<RectTransform>();
    private List<RectTransform> currentPointTypes = new List<RectTransform>(); 
    private List<bool> waitForClickList = new List<bool>(); 

    public float k = 1.0f; 
    public float distance = 0;

    public RectTransform imageRectTransform;

    void Start()
    {
        foreach (Button button in buttons)
        {
            int index = buttons.IndexOf(button);
            button.onClick.AddListener(() => StartWaitingForClick(index));
            currentPointTypes.Add(null);
            waitForClickList.Add(false);
        }

        if (kInputField != null)
        {
            kInputField.onValueChanged.AddListener(UpdateKValue);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 pointCoords = GetImageTouchPosition();
            if (IsPointInsideImage(pointCoords))
            {
                DrawPoint(pointCoords);
                CalculateDistance();
            }

            for (int i = 0; i < waitForClickList.Count; i++)
            {
                waitForClickList[i] = false;
            }
        }
    }

    private Vector2 GetImageTouchPosition()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageRectTransform,
            touchPosition,
            Camera.main,
            out localPoint
        );
        return localPoint;
    }

    private bool IsPointInsideImage(Vector2 point)
    {
        Rect imageRect = imageRectTransform.rect;
        return imageRect.Contains(point);
    }

    private void StartWaitingForClick(int index)
    {
        for (int i = 0; i < waitForClickList.Count; i++)
        {
            waitForClickList[i] = (i == index);
        }
    }

    private void DrawPoint(Vector2 position)
    {
        for (int i = 0; i < waitForClickList.Count; i++)
        {
            if (waitForClickList[i])
            {
                RemovePoint(currentPointTypes[i]);
                currentPointTypes[i] = Instantiate(pointPrefabs[i], imageRectTransform);
                currentPointTypes[i].localPosition = position;
            }
        }
    }

    private void RemovePoint(RectTransform point)
    {
        if (point != null)
        {
            Destroy(point.gameObject);
        }
    }

    private void CalculateDistance()
    {
        if (currentPointTypes.Count >= 3)
        {
            Vector2 pointA = currentPointTypes[2].localPosition;
            Vector2 pointB = currentPointTypes[3].localPosition;
            Vector2 pointC = currentPointTypes[4].localPosition;
			
			Vector2 pointZ = currentPointTypes[0].localPosition;
			Vector2 pointY = currentPointTypes[1].localPosition;

            distance = Vector2.Distance(pointZ, pointY);

            CalculateCircumscribedCircle(pointA, pointB, pointC);
			 Debug.Log(distance);
        }
        else
        {
            Debug.LogWarning("Not enough points to calculate the circle radius.");
        }
    }

    private void UpdateKValue(string newValue)
    {
        if (float.TryParse(newValue, out float parsedValue))
        {
            k = parsedValue;
        }
        else
        {
            Debug.LogWarning("Invalid input for k");
        }
    }

    private Vector2 CalculateCircleCenter(Vector2 pointA, Vector2 pointB)
    {
        Vector2 center = (pointA + pointB) / 2.0f;
        return center;
    }

    private float CalculateCircleRadius(Vector2 center, Vector2 point)
    {
        float radius = Vector2.Distance(center, point);
        return radius;
    }



private void DrawCircle(Vector2 center, float radius)
{
    float diameter = radius * 2;
    Image circleImage = new GameObject("CircleImage").AddComponent<Image>();
    circleImage.transform.SetParent(image.transform, false);
    circleImage.rectTransform.sizeDelta = new Vector2(diameter, diameter);
    circleImage.rectTransform.anchorMin = new Vector2(center.x / imageRectTransform.rect.width, center.y / imageRectTransform.rect.height);
    circleImage.rectTransform.anchorMax = new Vector2(center.x / imageRectTransform.rect.width, center.y / imageRectTransform.rect.height);
    circleImage.rectTransform.anchoredPosition = Vector2.zero;

    Color circleColor = new Color(1f, 0.5f, 0f, 0.5f); 
    circleImage.color = circleColor;

    RectTransform circleRectTransform = circleImage.rectTransform;
    circleRectTransform.sizeDelta = new Vector2(radius * 2, radius * 2);
}

private void CalculateCircumscribedCircle(Vector2 pointA, Vector2 pointB, Vector2 pointC)
{
    Vector2 center = CalculateCircleCenter(pointA, pointB);
    float radius = CalculateCircleRadius(center, pointC);

    Debug.Log("Radius of the circumscribed circle: " + radius);

    float answer = radius * k / distance;

    Debug.Log("Answer of the circumscribed circle: " + answer);

    DrawCircle(center, radius);

    answerText.text = $"Радіус кола: {answer}";
}
public void onvaluechanged(){CalculateDistance();}
 public void IncreaseImageSize(float scaleAmount)
    {
        imageRectTransform.localScale *= scaleAmount;
    }

    
    public void DecreaseImageSize(float scaleAmount)
    {
        imageRectTransform.localScale /= scaleAmount;
    }

    
    public void MoveImageLeft(float moveAmount)
    {
        imageRectTransform.localPosition += Vector3.left * moveAmount;
    }

    
    public void MoveImageRight(float moveAmount)
    {
        imageRectTransform.localPosition += Vector3.right * moveAmount;
    }

    
    public void MoveImageUp(float moveAmount)
    {
        imageRectTransform.localPosition += Vector3.up * moveAmount;
    }

    
    public void MoveImageDown(float moveAmount)
    {
        imageRectTransform.localPosition += Vector3.down * moveAmount;
    }
}
