using System.Collections.Generic;
using UnityEngine;

public class ElectricField : MonoBehaviour
{
    public Transform positiveCharge;
    public Transform negativeCharge;
    public int fieldLinesCount = 10;
    public float fieldStrength = 1.0f;
    public float fieldLineLength = 1.0f;

    public List<Vector3> linePositions = new List<Vector3>();

    private void Start()
    {
        GenerateFieldLines();
    }

    private void GenerateFieldLines()
    {
        Vector3 chargeDelta = negativeCharge.position - positiveCharge.position;

        for (int i = 0; i < fieldLinesCount; i++)
        {
            float t = (float)i / (fieldLinesCount - 1);
            Vector3 position = Vector3.Lerp(positiveCharge.position, negativeCharge.position, t);
            Vector3 electricField = CalculateElectricFieldAtPoint(position, chargeDelta);

            Vector3 lineEndPoint = position + electricField.normalized * fieldLineLength;
            linePositions.Add(position);
            linePositions.Add(lineEndPoint);
        }

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = linePositions.Count;
        lineRenderer.SetPositions(linePositions.ToArray());
    }

    private Vector3 CalculateElectricFieldAtPoint(Vector3 point, Vector3 chargeDelta)
    {
        Vector3 deltaPositive = point - positiveCharge.position;
        Vector3 deltaNegative = point - negativeCharge.position;

        float positiveDistance = deltaPositive.magnitude;
        float negativeDistance = deltaNegative.magnitude;

        Vector3 electricField = Vector3.zero;

        if (positiveDistance > 0.1f)
            electricField += fieldStrength * deltaPositive.normalized / (positiveDistance * positiveDistance);

        if (negativeDistance > 0.1f)
            electricField -= fieldStrength * deltaNegative.normalized / (negativeDistance * negativeDistance);

        return electricField;
    }
}
