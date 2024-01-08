using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ViewController is responsible for visual effects and overall camera movement */

public class ViewController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private IView currentView;

    private void Awake()
    {
        currentView = GetComponent<IView>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateCamera(Vector3 lookInput, Transform source)
    {
        LookForChangeInCurrentView();

        currentView.UpdateCamera(lookInput, playerCamera, source);
    }

    private void LookForChangeInCurrentView()
    {

    }
}
