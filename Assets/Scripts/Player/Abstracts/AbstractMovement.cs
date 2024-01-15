using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 2.0f;
    private Vector3 moveDirection;

    public virtual void UpdatePosition(Vector2 movementInput, CharacterController characterController, StaminaController playerStamina)
    {
        float directionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * movementInput.y) + (transform.TransformDirection(Vector3.right) * movementInput.x);
        moveDirection.y = directionY;
        characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
    }
}
