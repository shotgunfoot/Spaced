using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWithSlots : MonoBehaviour {

    private List<Ammo> ammunition;

    private void Start()
    {
        ammunition = new List<Ammo>();
    }

    public void AddAmmo(GameObject ammoObject)
    {
        Ammo ammo = ammoObject.GetComponent<Ammo>();
        if (!ammunition.Contains(ammo))
        {
            ammunition.Add(ammo);
            return;
        }

        if (ammunition.Contains(ammo))
        {

        }
    }
}
