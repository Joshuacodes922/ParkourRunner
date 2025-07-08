using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float laneDistance = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float lateralSpeed = 10f;

    public bool isNearWall = false;

    private CharacterController controller;

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private int targetLane = 1;

    private float verticalVelocity = 0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // LANE POSITION in Z
        float targetZ = (targetLane - 1) * laneDistance;
        float deltaZ = targetZ - transform.position.z;
        float zMovement = Mathf.Clamp(deltaZ * lateralSpeed, -lateralSpeed, lateralSpeed);

        // JUMP + GRAVITY
        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f; // Keeps grounded
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 moveDirection = new Vector3(0f, verticalVelocity, zMovement);
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x < 0 && targetLane > 0)
            targetLane--;
        else if (input.x > 0 && targetLane < 2)
            targetLane++;
    }

    void OnJump(InputValue value)
    {
        if (controller.isGrounded)
        {
            if (isNearWall)
            {
                verticalVelocity = jumpForce * 5;
                return;
            }
            verticalVelocity = jumpForce;
        }
    }

    public void checkNearWall(bool value)
    {
        isNearWall = value;
    }
}
