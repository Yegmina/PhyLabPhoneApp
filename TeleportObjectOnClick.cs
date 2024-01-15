using UnityEngine;

public class TeleportObjectOnClick : MonoBehaviour
{
    public GameObject objectToTeleport;
    public Vector3 teleportPosition;

    // Вызывается при клике на объект, который должен быть телепортирован
    public void TeleportObject()
    {
        if (objectToTeleport != null)
        {
            Rigidbody rb = objectToTeleport.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Обнуляем скорость объекта
                rb.angularVelocity = Vector3.zero; // Обнуляем угловую скорость объекта
            }

            objectToTeleport.transform.position = teleportPosition;
            objectToTeleport.transform.rotation = Quaternion.identity; // Обнуляем поворот объекта
        }
    }
}
