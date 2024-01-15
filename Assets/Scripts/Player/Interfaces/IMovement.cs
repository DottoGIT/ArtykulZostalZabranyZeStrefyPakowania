using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void UpdatePosition(Vector2 movementInput, CharacterController characterController, StaminaController playerStamina);
}
