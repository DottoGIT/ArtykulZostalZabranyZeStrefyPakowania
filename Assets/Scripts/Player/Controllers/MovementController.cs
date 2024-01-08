using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Movement Controller is responsible for switching betweeen current movement type */

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    
    [Header("Sprint settings")]
    [SerializeField] private KeyCode sprintButton = KeyCode.LeftShift;
    [SerializeField] private int staminaDrain = 10;
    
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

    public void UpdatePosition(Vector3 moveInput)
    {
        LookForChangeInCurrentMovement();

        currentMovement.UpdatePosition(moveInput, characterController);
    }

    private void LookForChangeInCurrentMovement()
    {
        // Look for sprint
        if(Input.GetKey(sprintButton) && playerStamina.currentStamina > 0)
        {
            ChangeCurrentMovement<SprintMovement>();
            playerStamina.DrainStamina(staminaDrain * Time.deltaTime);
            return;
        }

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
