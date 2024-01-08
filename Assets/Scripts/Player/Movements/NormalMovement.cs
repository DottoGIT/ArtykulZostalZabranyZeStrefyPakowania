using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NormalMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float movementSpeed = 2.0f;
    private Vector3 moveDirection;

    public void UpdatePosition(Vector2 movementInput, CharacterController characterController)
    {
        float directionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * movementInput.y) + (transform.TransformDirection(Vector3.right) * movementInput.x);
        moveDirection.y = directionY;
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

}
