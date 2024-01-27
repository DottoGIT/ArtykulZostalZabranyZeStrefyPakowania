using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractView : MonoBehaviour, IView
{
    [SerializeField, Range(1, 10)] private float mouseSensivity = 2.0f;
    [SerializeField, Range(1, 180)] private float lookLimit = 55.0f;


    public virtual void UpdateCamera(ref float cameraRotationX, Vector2 mouseInput, Camera playerCamera, Transform cameraAnchor, Transform source)
    {
        cameraRotationX -= mouseInput.y * mouseSensivity;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -lookLimit, lookLimit);

        source.rotation *= Quaternion.Euler(0, mouseInput.x * mouseSensivity, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }
}
