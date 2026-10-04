using UnityEngine;


public class Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 60f, 0f);
    public float floatAmplitude = 0.3f;
    public float floatSpeed = 2f;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, 10f); 
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        float y = Mathf.Sin((Time.time + offset) * floatSpeed) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, y, 0f);
    }
}
