using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public bool canRegenerateStamina { get; private set; } = true;

    public float currentStamina { get; private set; }
    [SerializeField] private float staminaRegen = 20;
    [SerializeField] private float maxStamina = 100;

    private void Awake()
    {
        currentStamina = maxStamina;
    }

    public void UpdateStamina()
    {
        float desiredStamina = currentStamina + staminaRegen * Time.deltaTime;
        if(desiredStamina >= maxStamina)
        {
            desiredStamina = maxStamina;
        }
        currentStamina = desiredStamina;
    }

    public void DrainStamina(float value)
    {
        float desiredStamina = currentStamina - value;
        if(desiredStamina <= 0)
        {
            desiredStamina = 0;
        }
        currentStamina = desiredStamina;
    }
}
