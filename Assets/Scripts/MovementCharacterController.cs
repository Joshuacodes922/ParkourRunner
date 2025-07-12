using System;
using Unity.VisualScripting;
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

    //Zipline Player Offset
    float yOffsetZipline = 5f;
    float xOffsetZipline = 1.5f;
    GameObject ziplineHandle;
    

    Vector3 originalPositionBeforeZipline;
    Quaternion originalRotationBeforeZipline;

    public bool isNearZipline = false;
    public bool jumpedNearZipline = false;
    bool isOnZipline = false;

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

        isNearZipline = false;
        jumpedNearZipline = false;
}

    private void Update()
    {
        Debug.Log(jumpedNearZipline);
        if (isOnZipline) return;
        MoveCharacter();
        SlideCharacter();
    }

    public void AttachToRope(Transform targetTransform, GameObject parent)
    {
        originalPositionBeforeZipline = transform.position;
        originalRotationBeforeZipline = transform.rotation;
        isOnZipline = true;
        //// Optionally disable the controller to avoid physics conflict
        //controller.enabled = false;

        // Snap the player to the handle's position and rotation
        transform.position = new Vector3(targetTransform.position.x - 1.5f, targetTransform.position.y - 3, targetTransform.position.z);

        ziplineHandle = parent;

        // Optional: parent to the handle if you want the player to move with it
        transform.parent = targetTransform;

        // Zero out movement
        verticalVelocity = 0f;
    }

    public void detachFromRope()
    {
        isOnZipline = false;
        controller.enabled = true;
        transform.position = originalPositionBeforeZipline;
        transform.rotation = originalRotationBeforeZipline;
        Destroy(ziplineHandle);
        transform.parent = null;
        
    }

    private void SlideCharacter()
    {
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

    private void MoveCharacter()
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
                verticalVelocity = jumpForce * 3;
                return;
            }

            if (isNearZipline)
            {
                jumpedNearZipline = true;
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
