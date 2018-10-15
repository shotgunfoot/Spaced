using Sirenix.OdinInspector;
using UnityEngine;

public class HandRight : MonoBehaviour
{

    /// <summary>
    /// How the hand stuff works.
    /// -The hand will activate whatever is being held in it.
    /// </summary>
    /// 

    [ShowInInspector]
    private GameObject itemInHand;
    private SingleHandItem itemBase;
    public Transform HandPoint;
    public Transform DropPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("HandRight"))
        {
            if (itemInHand != null)
            {
                itemInHand.GetComponent<SingleHandItem>().Action();
            }
            else
            {
                Debug.Log("Right Hand is empty!");
            }
        }
    }

    public void SetObjectInHand(GameObject obj)
    {
        itemInHand = obj;
        itemBase = itemInHand.GetComponent<SingleHandItem>();

        itemInHand.transform.parent = HandPoint.transform;
        itemInHand.transform.localPosition = itemBase.RightHandPosition;
        itemInHand.transform.localEulerAngles = itemBase.RightHandRotation;

        itemInHand.GetComponent<Rigidbody>().isKinematic = true;
        itemBase.DisableColliders();

        //set the parent and transform to the position of the hand.

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

    public GameObject GetObjectInHand()
    {
        return itemInHand;
    }
}
