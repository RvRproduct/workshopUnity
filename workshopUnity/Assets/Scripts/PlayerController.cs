using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerRotationSpeed = 15;
    [SerializeField] bool usePhysicsMovement = false;
    [SerializeField] bool fixedCamera = true;

    PlayerControls playerControls;
    Rigidbody playerRigidbody;
    CinemachineVirtualCamera virtualCamera;
    Camera mainCamera;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        if (!fixedCamera)
        {
            if (mainCamera != null)
            {
                mainCamera.GetComponent<CinemachineBrain>().enabled = true;
            }

            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }
        else
        {
            if (mainCamera != null)
            {
                mainCamera.GetComponent<CinemachineBrain>().enabled = false;
                mainCamera.transform.position = new Vector3(0, 23, 0);
                mainCamera.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
        }
        

        // Using Unity's New Input System here
        playerControls = new PlayerControls();

        playerControls.Player.Move.started += OnMovementInput;
        playerControls.Player.Move.canceled += OnMovementInput;
        playerControls.Player.Move.performed += OnMovementInput;
    }

    private void Update()
    {
        if (!usePhysicsMovement)
        {
            handleRotation();
            ApplyMovementTransform();
        }
    }

    private void FixedUpdate()
    {
        if (usePhysicsMovement)
        {
            handleRotation();
            ApplyMovementPhysics();
        }
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, playerRotationSpeed * Time.deltaTime);
        }
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void ApplyMovementPhysics()
    {
        if (isMovementPressed)
        {
            playerRigidbody.velocity = currentMovement.normalized * playerSpeed;
        }
    }

    void ApplyMovementTransform()
    {
        if (isMovementPressed)
        {
            transform.position += currentMovement.normalized * Time.deltaTime * playerSpeed;
        }
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }
}
