using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("Movement Logic")]
    public float jumpForce;
    public float playerSpeed;
    public LayerMask walkable;
    Rigidbody rb;
    public bool isGrounded;
    [Header("Objects")]
    public Transform groundCheck;
    [Header("Keys")]
    public KeyCode jumpKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, walkable);

        jump();
        move();
        if (isGrounded)
        {
            rb.linearDamping = 5f;
        }
        else
        {
            rb.linearDamping = 0f;
        }
    }
    public void jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce * 2f, ForceMode.Impulse);
        }
    }
    public void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * playerSpeed * 2f, ForceMode.Force);
        }

        Vector3 rbVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (rbVelocity.magnitude > playerSpeed)
        {
            rb.linearVelocity = rbVelocity.normalized * playerSpeed;
        }
    }
}
