using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Holds crucial information about player and manages his behaviour */

public class PlayerController : MonoBehaviour
{

    public StaminaController staminaController { get; private set; }
    public MovementController movementController { get; private set; }
    public ViewController viewController { get; private set; }

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
        movementController.UpdatePosition();
        viewController.UpdateCamera(transform);
        staminaController.UpdateStamina();
    }
}
