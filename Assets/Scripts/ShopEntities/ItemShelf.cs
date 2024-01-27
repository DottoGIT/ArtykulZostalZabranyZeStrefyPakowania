using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShelf : MonoBehaviour, IInteractable
{
    [SerializeField] private Item item;
    [SerializeField] private ParticleSystem particle;
    private bool canInteract = true;

    public string GetDescription()
    {
        return $"Take {item.itemName} [{GlobalInput.instance.interactButton}]";
    }

    public void Interact()
    {
        particle.Stop();
        canInteract = false;
    }

    public bool CanInteract()
    {
        return canInteract;
    }
}
