using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 10f;
    [SerializeField] private int laneDistance = 5;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float groundedThreshold = 0.1f;
    public bool isNearWall=false;

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private int targetLane = 1;
    private bool isMoving = false;

    private float initialY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
        initialY = transform.position.y;
    }

    private void Update()
    {
        
    }


    private void FixedUpdate()
    {
        SideMovement();
    }

    private void SideMovement()
    {
        Vector3 targetPosition = new Vector3(rb.position.x, rb.position.y, (targetLane - 1) * laneDistance);

        if (Vector3.Distance(rb.position, targetPosition) > 0.1f)
        {
            Vector3 moveDirection = Vector3.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
            rb.MovePosition(moveDirection);
            isMoving = true;
        }
        else
        {
            rb.MovePosition(targetPosition); // snap to lane
            isMoving = false;
        }
    }

    void OnMove(InputValue value)
    {
        float movement = value.Get<Vector2>().x;

        if (isMoving) return;

        if (movement < 0 && targetLane > 0)
            targetLane--;
        else if (movement > 0 && targetLane < 2)
            targetLane++;
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && IsGrounded() )
        {

            if (isNearWall)
            {
                Debug.Log("JumpForce: " + (jumpForce * 5));
                rb.AddForce(Vector3.up * jumpForce * 5, ForceMode.Impulse);
                return;
            }
            Debug.Log("JumpForce: " + (jumpForce));
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
        
    }

    private bool IsGrounded()
    {
        bool grounded = Mathf.Abs(transform.position.y - initialY) < groundedThreshold && rb.linearVelocity.y <= 0.1f;
        return grounded;
    }

    public void checkNearWall(bool value)
    {
        isNearWall = value;
    }
}
