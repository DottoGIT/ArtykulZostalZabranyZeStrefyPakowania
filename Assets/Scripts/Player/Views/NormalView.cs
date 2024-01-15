using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalView : AbstractView
{
    [SerializeField] private float normalCameraPosition = 1.7f;
    [SerializeField] private float lerpSpeed = 0.5f;

    public override void UpdateCamera(ref float cameraRotationX, Vector2 mouseInput, Camera playerCamera, Transform cameraAnchor, Transform source)
    {
        LerpCamera(cameraAnchor);
        base.UpdateCamera(ref cameraRotationX, mouseInput, playerCamera, cameraAnchor, source);
    }

    private void LerpCamera(Transform cameraAnchor)
    {
        Vector3 cameraDestination = transform.position;
        cameraDestination.y = normalCameraPosition;
        cameraAnchor.position = Vector3.Lerp(cameraAnchor.position, cameraDestination, Time.deltaTime * lerpSpeed);
    }
}
