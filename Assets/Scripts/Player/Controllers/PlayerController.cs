using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Holds crucial information about player and manages his behaviour */

public class PlayerController : MonoBehaviour
{
    public bool canLook { get; private set; } = true;
    public bool canMove { get; private set; } = true;
    public bool canRegenerateStamina { get; private set; } = true;

    public StaminaController staminaController { get; private set; }
    public MovementController movementController { get; private set; }
    public ViewController viewController { get; private set; }

    Vector3 movementInput;
    Vector2 cameraInput;

    void Awake()
    {
        // Initialize Controllers
        staminaController = GetComponent<StaminaController>();
        movementController = GetComponentInChildren<MovementController>();
        viewController = GetComponentInChildren<ViewController>();

        // Assign StaminaController to appropriate controllers
        movementController.SetStaminaController(staminaController);
    }

    void Update()
    {
        UpdateInput();

        // Update Movement
        if (canMove)
        {
            movementController.UpdatePosition(movementInput);
        }
        // Update View
        if (canLook)
        {
            viewController.UpdateCamera(cameraInput, transform);
        }
        // Update Stamina
        if (canRegenerateStamina)
        {
            staminaController.RecoverStamina();
        } 
    }

    void UpdateInput()
    {
        cameraInput.x = Input.GetAxis("Mouse X");
        cameraInput.y = Input.GetAxis("Mouse Y");
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
    }
}
