using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float laneDistance = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float lateralSpeed = 10f;
    [SerializeField] int gravityMultiplier = 5;

    [Header("Slide settings")]
    [SerializeField] private Transform visualModel; // Assign your child model here
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float slideRadiusMultiplier = 0.5f; // shrink radius to 50% when sliding

    public bool isNearWall = false;

    private CharacterController controller;

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private int targetLane = 1;

    private float verticalVelocity = 0f;

    private float slideTimer = 0f;
    private bool isSliding = false;

    private Quaternion originalVisualRotation;
    private Quaternion targetVisualRotation;

    private float originalHeight;
    private Vector3 originalCenter;
    private float originalRadius;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        originalHeight = controller.height;
        originalCenter = controller.center;
        originalRadius = controller.radius;

        if (visualModel != null)
            originalVisualRotation = visualModel.localRotation;
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
            verticalVelocity += gravity * Time.deltaTime * gravityMultiplier;
        }

        Vector3 moveDirection = new Vector3(0f, verticalVelocity, zMovement);
        controller.Move(moveDirection * Time.deltaTime);

        // Slide logic
        if (isSliding)
        {
            slideTimer -= Time.deltaTime;

            // Smoothly rotate visual model to target rotation
            visualModel.localRotation = Quaternion.Lerp(visualModel.localRotation, targetVisualRotation, Time.deltaTime * rotationSpeed);

            if (slideTimer <= 0f)
            {
                // Slide finished - reset collider and rotation
                controller.height = originalHeight;
                controller.center = originalCenter;
                controller.radius = originalRadius;

                targetVisualRotation = originalVisualRotation;

                // Smoothly rotate back to original
                if (Quaternion.Angle(visualModel.localRotation, originalVisualRotation) < 0.1f)
                {
                    visualModel.localRotation = originalVisualRotation;
                    isSliding = false;
                }
            }
        }
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

    void OnSlide(InputValue value)
    {
        if (!isSliding && controller.isGrounded)
        {
            isSliding = true;
            slideTimer = slideDuration;

            // Shrink collider for slide: height, center, AND radius
            controller.height = originalHeight / 3f;
            controller.center = originalCenter - new Vector3(0, originalHeight / 4f, 0);
            controller.radius = originalRadius * slideRadiusMultiplier;

            // Set target visual rotation to tilt 90 degrees forward on X
            targetVisualRotation = originalVisualRotation * Quaternion.Euler(-90f, 0f, 0f);
        }
    }
}
