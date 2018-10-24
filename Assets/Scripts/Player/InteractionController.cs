using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{ 
    public HandLeft handLeft;
    public HandRight handRight;
    public InventoryWithSlots inventory;

    List<Item> objectsInPickupZone = new List<Item>();

    // Update is called once per frame
    void Update()
    {
        if (objectsInPickupZone.Count > 0)
        {
            if (Input.GetButtonDown("HandLeft"))
            {
                //check if item is pickupable in one hand or is even able to be picked up first before setting it to the hand.

                //check if item is not to be picked up but instead interacted with
                if (handLeft.GetObjectInHand() == null)
                {
                    CustomTag tag = objectsInPickupZone[0].GetComponent<CustomTag>();
                    if (tag.HasTag("MiscItem"))
                    {                        
                        //if the inventory can place the item in a slot it will return true.
                        if (inventory.AddToInventory(objectsInPickupZone[0]))
                        {                            
                            objectsInPickupZone.RemoveAt(0);
                        }                        
                    }
                    else if (tag.HasTag("SmallItem"))
                    {
                        handLeft.SetObjectInHand(objectsInPickupZone[0]);
                        objectsInPickupZone.RemoveAt(0);
                    }
                    else if (tag.HasTag("LargeItem"))
                    {

                    }
                    else if (tag.HasTag("Backpack"))
                    {                        
                        inventory.AddBackpackToInventory(objectsInPickupZone[0].GetComponent<BackpackContainer>());
                        objectsInPickupZone.RemoveAt(0);
                    }
                }
            }           
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            handLeft.DropItemInHand();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            handRight.DropItemInHand();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CustomTag tag = other.GetComponent<CustomTag>();              
        
        if (tag != null)
        {            
            if (tag.HasTag("CanPickUp"))
            {                
                if (!objectsInPickupZone.Contains(other.GetComponent<Item>()))
                {
                    objectsInPickupZone.Add(other.GetComponent<Item>());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {       
        CustomTag tag = other.GetComponent<CustomTag>();        
        if (tag != null)
        {            
            if (tag.HasTag("CanPickUp"))
            {                
                if (objectsInPickupZone.Contains(other.GetComponent<Item>()))
                {                    
                    objectsInPickupZone.Remove(other.GetComponent<Item>());
                }
            }
        }
    }
}
