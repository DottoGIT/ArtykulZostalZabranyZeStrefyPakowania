using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalUI : MonoBehaviour
{
    public static GlobalUI instance;
    public TextMeshProUGUI interactionText;
    [Header("Items to collect")]
    [SerializeField] TextMeshProUGUI Broccoli;
    [SerializeField] TextMeshProUGUI PotatoChips;
    [SerializeField] TextMeshProUGUI Beans;
    [SerializeField] TextMeshProUGUI Coke;
    [SerializeField] TextMeshProUGUI Flour;
    [SerializeField] TextMeshProUGUI Liquor;
    [SerializeField] TextMeshProUGUI IceBag;
    [SerializeField] TextMeshProUGUI Shampoo;
    [SerializeField] TextMeshProUGUI Toy;
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

    public void CheckItem(Item item)
    {
        switch (item.name)
        {
            case "Broccoli":
                Broccoli.fontStyle |= FontStyles.Underline;
                break;
            case "PotatoChips":
                PotatoChips.fontStyle |= FontStyles.Underline;
                break;
            case "Beans":
                Beans.fontStyle |= FontStyles.Underline;
                break;
            case "Coke":
                Coke.fontStyle |= FontStyles.Underline;
                break;
            case "Flour":
                Flour.fontStyle |= FontStyles.Underline;
                break;
            case "Liquor":
                Liquor.fontStyle |= FontStyles.Underline;
                break;
            case "IceBag":
                IceBag.fontStyle |= FontStyles.Underline;
                break;
            case "Shampoo":
                Shampoo.fontStyle |= FontStyles.Underline;
                break;
            case "Toy":
                Toy.fontStyle |= FontStyles.Underline;
                break;
            default: Debug.LogError("Tried to check non existing item");
                break;
        }
    }
}
