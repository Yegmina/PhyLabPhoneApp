using UnityEngine;

public class ZoomCameraOnClick : MonoBehaviour
{
    public Camera zoomCamera;
    public float zoomSpeed = 5f;
    public float minFieldOfView = 1f;
    public float maxFieldOfView = 179f;

    // Вызывается при нажатии на кнопку увеличения
    public void ZoomIn()
    {
        if (zoomCamera != null)
        {
            zoomCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            zoomCamera.fieldOfView = Mathf.Clamp(zoomCamera.fieldOfView, minFieldOfView, maxFieldOfView);
        }
    }

    // Вызывается при нажатии на кнопку уменьшения
    public void ZoomOut()
    {
        if (zoomCamera != null)
        {
            zoomCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            zoomCamera.fieldOfView = Mathf.Clamp(zoomCamera.fieldOfView, minFieldOfView, maxFieldOfView);
        }
    }
}
