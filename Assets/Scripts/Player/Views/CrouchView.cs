using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrouchView : AbstractView
{
    [SerializeField] private float crouchCameraPosition = 0.5f;
    [SerializeField] private float lerpSpeed = 2f;

    public override void UpdateCamera(ref float cameraRotationX, Vector2 mouseInput, Camera playerCamera, Transform cameraAnchor, Transform source)
    {
        LerpCamera(cameraAnchor);
        base.UpdateCamera(ref cameraRotationX, mouseInput, playerCamera, cameraAnchor, source);
    }

    private void LerpCamera(Transform cameraAnchor)
    {
        Vector3 cameraDestination = transform.position;
        cameraDestination.y = crouchCameraPosition;
        cameraAnchor.position = Vector3.Lerp(cameraAnchor.position, cameraDestination, Time.deltaTime * lerpSpeed);
    }

}
