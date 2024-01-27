using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalUI : MonoBehaviour
{
    public static GlobalUI instance;
    public TextMeshProUGUI interactionText;

    string currInteractionText;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeInteractionText(string text)
    {
        if(currInteractionText != text)
        {
            interactionText.text = text;
            currInteractionText = text;
        }
    }
}
