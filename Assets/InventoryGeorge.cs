using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGeorge : MonoBehaviour
{

    #region Singleton
    public static InventoryGeorge instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventorygeorge found");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
