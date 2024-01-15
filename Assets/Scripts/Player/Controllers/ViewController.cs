using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ViewController is responsible for visual effects and overall camera movement */

public class ViewController : MonoBehaviour
{
    public bool canLook { get; private set; } = true;

    [SerializeField] private Camera playerCamera;
    [SerializeField] Transform cameraAnchor;
    private IView currentView;
    private float cameraRotationX;

    private void Awake()
    {
        currentView = GetComponent<IView>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateCamera(Transform source)
    {
        LookForChangeInCurrentView();

        currentView.UpdateCamera(ref cameraRotationX, GetInput(), playerCamera, cameraAnchor, source);
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void LookForChangeInCurrentView()
    {
        // Look for crouch
        if (Input.GetKey(GlobalInput.instance.crouchButton))
        {
            ChangeCurrentView<CrouchView>();
            return;
        }

        ChangeCurrentView<NormalView>();
    }

    private void ChangeCurrentView<T>() where T : MonoBehaviour, IView
    {
        if (currentView is T)
        {
            return;
        }
        currentView = GetComponent<T>();
    }
}
