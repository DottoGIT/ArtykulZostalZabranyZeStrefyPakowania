using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalInput : MonoBehaviour
{
    public static GlobalInput instance;

    public KeyCode sprintButton;
    public KeyCode crouchButton;
    public KeyCode interactButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
