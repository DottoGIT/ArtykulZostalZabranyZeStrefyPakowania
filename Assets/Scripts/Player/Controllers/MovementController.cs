using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

/* Movement Controller is responsible for switching betweeen current movement type */

public class MovementController : MonoBehaviour
{
    public bool canMove { get; private set; } = true;

    [SerializeField] private CharacterController characterController;
    
    private StaminaController playerStamina;
    private IMovement currentMovement;
    
    private void Awake()
    {
        currentMovement = GetComponent<IMovement>();
    }

    public void SetStaminaController(StaminaController staminaController)
    {
        playerStamina = staminaController;
    }

    public void UpdatePosition()
    {
        LookForChangeInCurrentMovement();
        currentMovement.UpdatePosition(GetInput(), characterController, playerStamina);
    }

    private Vector2 GetInput()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void LookForChangeInCurrentMovement()
    {
        // Look for crouch
        if(Input.GetKey(GlobalInput.instance.crouchButton))
        {
            ChangeCurrentMovement<CrouchMovement>();
            return;
        }

        // Look for sprint
        if(Input.GetKey(GlobalInput.instance.sprintButton) && playerStamina.currentStamina > 0)
        {
            ChangeCurrentMovement<SprintMovement>();
            return;
        }

        // Otherwise change to normal movement
        ChangeCurrentMovement<NormalMovement>();
    }

    private void ChangeCurrentMovement<T>() where T : MonoBehaviour, IMovement
    {
        if (currentMovement is T)
        {
            return;
        }
        currentMovement = GetComponent<T>();
    }
}
