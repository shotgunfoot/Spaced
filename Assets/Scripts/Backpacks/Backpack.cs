using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Backpack", menuName = "Backpack/Create Backpack")]
public class Backpack : ScriptableObject
{
    public int miscSlotCount;
    public int smallSlotCount;
    public int largeSlotCount;
    public Sprite inventoryIcon;
}
