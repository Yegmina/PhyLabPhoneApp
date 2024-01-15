using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public bool useCustomGravity = true; // Использовать кастомную гравитацию или системную
    public float customGravityScale = 5f; // Новое значение гравитации, если useCustomGravity установлено в true

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = !useCustomGravity; // Включаем или выключаем системную гравитацию
		FixedUpdate();
    }

    private void FixedUpdate()
    {
        if (useCustomGravity)
        {
            Vector3 customGravity = customGravityScale * Physics.gravity.normalized;
            rb.AddForce(customGravity, ForceMode.Acceleration);
        }
    }
}
