using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public InventoryWithSlots inventory;
    private void Start()
    {
        inventory.FillWithBlankItems();
    }
}
