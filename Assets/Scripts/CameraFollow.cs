using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 8f;
    public float height = 4f;
    public float mouseSensitivity = 3f;
    public float keyRotateSpeed = 90f;
    public float smooth = 10f;
    public float minDistance = 3f;
    public float maxDistance = 15f;

    private float yaw;

    void Start()
    {
        if (target != null) yaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(1)) yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        if (Input.GetKey(KeyCode.Q)) yaw -= keyRotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) yaw += keyRotateSpeed * Time.deltaTime;

        distance = Mathf.Clamp(distance - Input.mouseScrollDelta.y, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);
        Vector3 desired = target.position + rotation * new Vector3(0f, height, -distance);

        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1f);
    }
}
