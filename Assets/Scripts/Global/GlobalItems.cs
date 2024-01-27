using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalItems : MonoBehaviour
{
    public static GlobalItems instance;

    [SerializeField] List<Item> availableItems;

    Dictionary<Item, bool> collectedDict = new Dictionary<Item, bool>();

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

    private void Start()
    {
        // Initialize collectedDict
        foreach (Item i in availableItems)
        {
            collectedDict.Add(i, false);
        }
    }

    public void CollectItem(Item item)
    {
        if(!collectedDict.ContainsKey(item))
        {
            Debug.LogError("Tried to add non existing item!");
            return;
        }

        collectedDict[item] = true;
        GlobalUI.instance.CheckItem(item);
        if(AreAllItemsCollected())
        {
            AllItemsCollected();
        }
    }

    bool AreAllItemsCollected()
    {
        foreach (KeyValuePair<Item, bool> kv in collectedDict)
        {
            if (!kv.Value)
                return false;
        }
        return true;
    }

    void AllItemsCollected()
    {
        Debug.Log("Win!");
    }

}
