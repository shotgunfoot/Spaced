using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Item
{
    [SerializeField]
    private bool canStack;
    [SerializeField]
    private int stackLimit;    
    private int stackCount;

    private void Start()
    {
        if (!canStack)
        {
            stackLimit = 1;
        }
    }

    public void Add()
    {
        if(stackCount < stackLimit)
        {
            stackCount++;
        }
    }

    public void Remove()
    {
        if(stackCount > 0)
        {
            stackCount--;
        }
    }
}
