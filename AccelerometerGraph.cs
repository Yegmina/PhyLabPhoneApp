using UnityEngine;
/* скрипт поки що не використовується, був для лабораторної 4 для малювання графіка акселерометра для визначення прискорення сили тертя.*/
public class AccelerometerGraph : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public float graphHeight = 20f;
    public float graphWidth = 100f;
    public float timeScale = 0.1f;

    void Start()
    {
        lineRenderer.positionCount = 0;
        CreateAxisLabels();
        CreateAxes();
    }

    void Update()
    {
        float xAcceleration = Input.acceleration.x;
        float yAcceleration = Input.acceleration.y;
        float zAcceleration = Input.acceleration.z;

        float totalAcceleration = Mathf.Sqrt(Mathf.Pow(xAcceleration, 2) + Mathf.Pow(yAcceleration, 2) + Mathf.Pow(zAcceleration, 2));

        float currentTime = Time.time * timeScale;
        AddPointToGraph(currentTime, totalAcceleration);
    }

    void AddPointToGraph(float x, float y)
    {
        float scaledX = x * graphWidth;
        float scaledY = (y / 10f) * graphHeight;

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(scaledX, scaledY, 0f));
    }

    void CreateAxisLabels()
    {
        for (float x = 0f; x <= graphWidth; x += graphWidth / 10f)
        {
            GameObject label = new GameObject("XLabel");
            label.transform.parent = transform;
            label.transform.localPosition = new Vector3(x, -0.5f, 0f);
            TextMesh textMesh = label.AddComponent<TextMesh>();
            textMesh.text = x.ToString("0.##");
            textMesh.anchor = TextAnchor.MiddleCenter;
        }

        float scaleValue = graphHeight / 10f;
        for (float y = -graphHeight; y <= graphHeight; y += scaleValue)
        {
            GameObject label = new GameObject("YLabel");
            label.transform.parent = transform;
            label.transform.localPosition = new Vector3(-1f, y, 0f);
            TextMesh textMesh = label.AddComponent<TextMesh>();
            textMesh.text = (y * 0.1f).ToString("0.##") + " m/s²";
            textMesh.anchor = TextAnchor.MiddleRight;

            GameObject accelerationLabel = new GameObject("AccelerationLabel");
            accelerationLabel.transform.parent = label.transform;
            accelerationLabel.transform.localPosition = new Vector3(-1f, 0f, 0f);
            TextMesh accelerationTextMesh = accelerationLabel.AddComponent<TextMesh>();
            accelerationTextMesh.text = Mathf.Abs(y * 0.1f).ToString("0.##");
            accelerationTextMesh.anchor = TextAnchor.MiddleCenter;
        }
    }

    void CreateAxes()
    {
        GameObject xAxis = new GameObject("XAxis");
        xAxis.transform.parent = transform;
        LineRenderer xAxisLineRenderer = xAxis.AddComponent<LineRenderer>();
        xAxisLineRenderer.positionCount = 2;
        xAxisLineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
        xAxisLineRenderer.SetPosition(1, new Vector3(graphWidth, 0f, 0f));

        GameObject yAxis = new GameObject("YAxis");
        yAxis.transform.parent = transform;
        LineRenderer yAxisLineRenderer = yAxis.AddComponent<LineRenderer>();
        yAxisLineRenderer.positionCount = 2;
        yAxisLineRenderer.SetPosition(0, new Vector3(0f, -graphHeight, 0f));
        yAxisLineRenderer.SetPosition(1, new Vector3(0f, graphHeight, 0f));
    }
}
