using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBasic : MonoBehaviour {

    private float shells;

    public void AddShells(int _amount)
    {
        shells += _amount;
    }    
    
    public float GetShellsRemaining()
    {
        return shells;
    }
}
