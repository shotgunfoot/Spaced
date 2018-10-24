using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackContainer : Item
{
    public Backpack backpack;
    private BoxCollider coll;
    private Rigidbody rb;

    private void Start()
    {
        coll = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    public void SetEquipped()
    {
        coll.isTrigger = true;
        rb.isKinematic = true;
    }

    public void SetUnequipped()
    {
        coll.isTrigger = false;
        rb.isKinematic = false;
    }
}
