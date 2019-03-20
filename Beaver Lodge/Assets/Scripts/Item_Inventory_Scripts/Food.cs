using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Food", fileName = "Food.asset")]
public class Food : ItemClass
{
    int f_pointVal;
    int f_expirationLimit;

    /*public override void Use(int val)
    {
        val = f_pointVal;
        //holdingInventory.removeItem();
        return;
    }*/

    public override int Use()
    {
        //holdingInventory.removeItem();
        return f_pointVal;
    }
}
