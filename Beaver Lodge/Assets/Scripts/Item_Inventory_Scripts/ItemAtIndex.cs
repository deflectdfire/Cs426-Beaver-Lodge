using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAtIndex : MonoBehaviour
{
    public int index = 0;
    public ItemObject itemInstance = null;    
    public GameObject prefabInstance = null;    

 
    public void SetItem(ItemObject instance)
    {
        this.itemInstance = instance;
        this.prefabInstance = Instantiate(instance.item.inGameRep, transform);
    }

    public void RemoveItem()
    {
        this.itemInstance = null;
        Destroy(this.prefabInstance);
        this.prefabInstance = null;
    }
}
