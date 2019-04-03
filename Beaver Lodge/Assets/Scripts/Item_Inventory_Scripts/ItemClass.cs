using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ItemClass : ScriptableObject
{
    public string i_Name;
    public int weight;
    public int quantity;
    public GameObject inGameRep;
    //protected PlayerInventory holdingInventory;

    //public abstract void Use(); 
    public abstract int Use();
}

[System.Serializable]
public class ItemObject
{
    public ItemClass item;
    int quantity;
    //public xx   //otherFields that would help with the mutability issues

    public ItemObject(ItemClass item, int quantity)
    {
        this.item = item;
        this.quantity = item.quantity;
    }
}
