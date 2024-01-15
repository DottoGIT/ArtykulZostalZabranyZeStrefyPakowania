using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void UpdateCamera(ref float cameraRotationX, Vector2 mouseInput, Camera playerCamera, Transform cameraAnchor, Transform source);
}
