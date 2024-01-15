using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : AbstractMovement
{
    [SerializeField] private int staminaDrain = 10;
    public override void UpdatePosition(Vector2 movementInput, CharacterController characterController, StaminaController playerStamina)
    {
        playerStamina.DrainStamina(staminaDrain);
        base.UpdatePosition(movementInput, characterController, playerStamina);
    }
}
