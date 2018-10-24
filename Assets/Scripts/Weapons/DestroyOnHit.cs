using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        CustomTag tag = collision.gameObject.GetComponent<CustomTag>();

        if (tag != null && tag.HasTag("Enemy"))
        {
            //hurt em
        }
        else
        {
            Destroy(gameObject, 5);
        }
    }
}
