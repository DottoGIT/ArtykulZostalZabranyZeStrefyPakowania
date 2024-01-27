using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private Transform interactionSource;

    public void SearchForInteraction()
    {
        IInteractable interactiveObject = null;
        GlobalUI.instance.ChangeInteractionText(string.Empty);

        RaycastHit hit;
        Vector3 rayDirection = interactionSource.TransformDirection(Vector3.forward);

        // Find object
        if (Physics.Raycast(interactionSource.position, rayDirection, out hit, interactionDistance))
        {
            interactiveObject = hit.transform.GetComponent<IInteractable>();
            if(interactiveObject != null && interactiveObject.CanInteract())
            {
                InteractWith(interactiveObject);
            }
        }
    }

    private void InteractWith(IInteractable obj)
    {
        GlobalUI.instance.ChangeInteractionText(obj.GetDescription());
        if(Input.GetKey(GlobalInput.instance.interactButton))
        {
            obj.Interact();
        }
    }


}
