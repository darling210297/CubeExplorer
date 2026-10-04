using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerCubeMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;
    public float sprintMultiplier = 1.8f;
    public float jumpForce = 6f;

    [Header("Detección de suelo")]
    public float groundCheckDistance = 0.6f;

    [Header("Reaparición")]
    public float fallLimitY = -20f;

    private Rigidbody rb;
    private Transform cam;
    private Vector3 input;
    private bool jumpRequested;
    private Vector3 spawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;          
        spawnPosition = transform.position;
        if (Camera.main != null) cam = Camera.main.transform;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        input = new Vector3(h, 0f, v).normalized;

        if (Input.GetKeyDown(KeyCode.Space)) jumpRequested = true;

        if (transform.position.y < fallLimitY) Respawn();
    }

    void FixedUpdate()
    {
        
        Vector3 dir = input;
        if (cam != null)
        {
            Vector3 forward = cam.forward; forward.y = 0f; forward.Normalize();
            Vector3 right = cam.right;     right.y = 0f;   right.Normalize();
            dir = (forward * input.z + right * input.x).normalized;
        }

        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f);

        Vector3 velocity = GetVelocity();
        Vector3 newVelocity = new Vector3(dir.x * speed, velocity.y, dir.z * speed);

        if (jumpRequested && IsGrounded())
        {
            newVelocity.y = jumpForce;
        }
        jumpRequested = false;

        SetVelocity(newVelocity);

        
        if (dir.sqrMagnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(dir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, target, 10f * Time.fixedDeltaTime));
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    void Respawn()
    {
        SetVelocity(Vector3.zero);
        transform.position = spawnPosition;
    }

    
    Vector3 GetVelocity()
    {
#if UNITY_6000_0_OR_NEWER
        return rb.linearVelocity;
#else
        return rb.velocity;
#endif
    }

    void SetVelocity(Vector3 v)
    {
#if UNITY_6000_0_OR_NEWER
        rb.linearVelocity = v;
#else
        rb.velocity = v;
#endif
    }
}
