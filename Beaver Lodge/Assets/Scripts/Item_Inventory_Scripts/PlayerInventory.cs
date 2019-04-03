using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/PlayerInventory", fileName = "PlayerInventory.asset")]
[System.Serializable]
public class PlayerInventory : ScriptableObject
{
    private static PlayerInventory _instance;
    public static PlayerInventory Instance
    {
        get
        {
            if (!_instance)
            {
                PlayerInventory[] tmp = Resources.FindObjectsOfTypeAll<PlayerInventory>();
                if (tmp.Length > 0)
                {
                    _instance = tmp[0];
                    Debug.Log("Found inventory as: " + _instance);
                }
                else
                {
                    Debug.Log("Did not find inventory, loading from file or template.");
                }
            }
            return _instance;
        }
    }

    public static void InitializeFromDefault()
    {
        if (_instance) DestroyImmediate(_instance);
        _instance = Instantiate((PlayerInventory)Resources.Load("PlayerInventoryTemplate"));
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    /*Inventory*/
    public ItemObject[] inventory;

    public bool InveIndex(int index)
    {
        if (inventory[index] == null || inventory[index].item == null)
            return true;

        return false;
    }

    // Get an item if it exists.
    public bool GetItem(int index, out ItemObject item)
    {
        // inventory[index] doesn't return null, so check item instead.
        if (InveIndex(index))
        {
            item = null;
            return false;
        }

        item = inventory[index];
        return true;
    }

    // Remove an item at an index if one exists at that index.
    public bool RemoveItem(int index)
    {
        if (InveIndex(index))
        {
            // Nothing existed at the specified slot.
            return false;
        }

        inventory[index] = null;

        return true;
    }

    // Insert an item, return the index where it was inserted.  -1 if error.
    public int InsertItem(ItemObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (InveIndex(i))
            {
                inventory[i] = item;
                return i;
            }
        }

        // Couldn't find a free slot.
        return -1;
    }
}