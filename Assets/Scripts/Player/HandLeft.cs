using Sirenix.OdinInspector;
using UnityEngine;

public class HandLeft : MonoBehaviour
{

    /// <summary>
    /// How the hand stuff works.
    /// -The hand will activate whatever is being held in it.
    /// </summary>
    /// 

    [ShowInInspector]
    private Item itemInHand;
    private SingleHandItem itemBase;
    public Transform HandPoint;
    public Transform DropPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("HandLeft"))
        {
            if (itemInHand != null)
            {
                itemInHand.GetComponent<SingleHandItem>().Action();
            }
        }
    }

    public void SetObjectInHand(Item item)
    {
        itemInHand = item;
        itemBase = itemInHand.GetComponent<SingleHandItem>();

        itemInHand.transform.parent = HandPoint.transform;
        itemInHand.transform.localPosition = itemBase.LeftHandPosition;
        itemInHand.transform.localEulerAngles = itemBase.LeftHandRotation;

        itemInHand.GetComponent<Rigidbody>().isKinematic = true;
        itemBase.DisableColliders();
    }

    public void DropItemInHand()
    {
        if (itemInHand != null)
        {
            itemInHand.transform.parent = null;
            itemInHand.transform.position = DropPoint.position;
            itemInHand.GetComponent<Rigidbody>().isKinematic = false;
            itemBase.EnableColliders();
            itemInHand = null;
            itemBase = null;
        }
    }

    public Item GetObjectInHand()
    {
        return itemInHand;
    }
}
