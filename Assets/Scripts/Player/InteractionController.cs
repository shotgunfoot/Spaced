using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    public HandLeft handLeft;
    public HandRight handRight;

    List<GameObject> objectsInPickupZone = new List<GameObject>();

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
                    handLeft.SetObjectInHand(objectsInPickupZone[0]);
                    objectsInPickupZone.RemoveAt(0);
                }
            }

            if (Input.GetButtonDown("HandRight"))
            {
                //check if item is pickupable in one hand or is even able to be picked up first before setting it to the hand.

                //check if item is not to be picked up but instead interacted with
                if (handRight.GetObjectInHand() == null)
                {
                    handRight.SetObjectInHand(objectsInPickupZone[0]);
                    objectsInPickupZone.RemoveAt(0);
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
                if (!objectsInPickupZone.Contains(other.gameObject))
                {
                    objectsInPickupZone.Add(other.gameObject);
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
                if (objectsInPickupZone.Contains(other.gameObject))
                {                    
                    objectsInPickupZone.Remove(other.gameObject);
                }
            }
        }
    }
}
