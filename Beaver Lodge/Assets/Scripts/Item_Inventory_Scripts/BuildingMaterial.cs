using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/BuildingMat", fileName = "BuildingMaterial.asset")]
public class BuldingMaterials : ItemClass
{
    int durability;
    public override int Use()
    {
        return -1;
    }
}
