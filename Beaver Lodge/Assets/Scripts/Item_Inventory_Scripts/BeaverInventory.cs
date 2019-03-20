using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverInventory : MonoBehaviour
{
    public List<ItemAtIndex> inventorySlots;

    // Use this for initialization
    void Start()
    {
        // Load example.
        inventorySlots = new List<ItemAtIndex>();
        inventorySlots.AddRange(GameObject.FindObjectsOfType<ItemAtIndex>());

        // Maintain some order (just in case it gets screwed up).
        inventorySlots.Sort((a, b) => a.index - b.index);

        PopulateInitial();
    }

    public void PopulateInitial()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            ItemObject instance;
            // If an object exists at the specified location.
            if (PlayerInventory.Instance.GetItem(i, out instance))
            {
                inventorySlots[i].SetItem(instance);
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].RemoveItem();
        }
    }
}
