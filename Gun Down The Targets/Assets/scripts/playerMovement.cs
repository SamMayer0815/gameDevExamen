using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Ground movement")]
    private float speed;
    public float walkSpeed = 20f;
    public float runSpeed = 40f;
    public float groundDrag = 2f;
    bool grounded;
    bool isRunning;

    [Header("Air movement")]
    public float airSpeed = 0.4f;
    public float jumpForce = 10f;

    [Header("Direction")]
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;


    public float playerHeight = 2f;
    public LayerMask ground;
    public Transform orientation;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    void Update()
    {
        //Gets look direction
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        rb.drag = groundDrag;
    }

    // Updates depending on the frame rate
    void FixedUpdate()
    {
        // calls movePlayer
        run();
        movePlayer();
        jump();
        speedLimiter();
    }

    void movePlayer()
    {
        // checks if player is grounded and the direction it is facing
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight + 0.2f, ground);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if walking forward
        if(Input.GetKey(KeyCode.W) && grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        //if walking sideway and backwards move slower
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && grounded)
        {
            rb.AddForce(0.8f * (moveDirection.normalized * speed * 10f), ForceMode.Force);
        }

        //Move slower in air
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && !grounded)
        {
            rb.AddForce(0.4f * (moveDirection.normalized * speed * 10f), ForceMode.Force);
        }
    }


    void run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        else
        {
            speed = walkSpeed;
            isRunning = false;
        }
    }

    void jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void speedLimiter()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(flatVel.magnitude > walkSpeed && !isRunning)
        {
            Vector3 limitedVel = flatVel.normalized * walkSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        if (flatVel.magnitude > runSpeed && isRunning)
        {
            Vector3 limitedVel = flatVel.normalized * runSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
