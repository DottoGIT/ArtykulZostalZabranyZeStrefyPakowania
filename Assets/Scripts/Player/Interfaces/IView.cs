using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void UpdateCamera(Vector2 mouseInput, Camera playerCamera, Transform source);
}
