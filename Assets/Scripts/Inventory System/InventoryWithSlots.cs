using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Create Inventory")]
public class InventoryWithSlots : ScriptableObject {

    public int miscSlotBaseCount;
    public int smallSlotBaseCount;
    public int largeSlotBaseCount;
    public Transform backpackFixPoint;
    public BackpackContainer backpackContainer;

    public List<Item> miscSlots;
    public List<Item> smallSlots;
    public List<Item> largeSlots;
    
    private Backpack backpack;

    public Item EmptyItemPrefab;
    public BackpackContainer emptyBackpackContainer;

    private int miscIndex;

    //requires checking if inventory is full before adding.
    public bool AddToInventory(Item item)
    {
        bool placedInInventory;        

        CustomTag tag = item.GetComponent<CustomTag>();        
        if (tag.HasTag("MiscItem"))
        {
            if (miscSlots.Contains(EmptyItemPrefab))
            {
                miscIndex = miscSlots.IndexOf(EmptyItemPrefab);
                miscSlots.RemoveAt(miscIndex);
                miscSlots.Insert(miscIndex, item);
                item.GetComponent<IVisibility>().SetInvisible();
                item.GetComponent<IInteractionSound>().PlaySound();
                placedInInventory = true;
            }
            else
            {
                placedInInventory = false;
            }
        }
        else if (tag.HasTag("LargeItem"))
        {
            largeSlots.Add(item);
            placedInInventory = true;
        }
        else if (tag.HasTag("SmallItem"))
        {
            smallSlots.Add(item);
            placedInInventory = true;
        }
        else
        {
            placedInInventory = false;
        }

        return placedInInventory;
    }

    public bool AddBackpackToInventory(BackpackContainer _packContainter)
    {
        if(backpackContainer == emptyBackpackContainer)
        {
            backpackContainer = _packContainter;
            backpackContainer.transform.parent = backpackFixPoint;
            backpackContainer.transform.SetPositionAndRotation(backpackFixPoint.position, backpackFixPoint.rotation);
            backpackContainer.SetEquipped();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FillWithBlankItems()
    {
        miscSlots.Clear();
        smallSlots.Clear();
        largeSlots.Clear();

        for(int i = 0; i < miscSlotBaseCount; i++)
        {
            miscSlots.Add(EmptyItemPrefab);
        }
        for (int i = 0; i < smallSlotBaseCount; i++)
        {
            smallSlots.Add(EmptyItemPrefab);
        }
        for (int i = 0; i < largeSlotBaseCount; i++)
        {
            largeSlots.Add(EmptyItemPrefab);
        }

        backpackContainer = emptyBackpackContainer;
    }
}
