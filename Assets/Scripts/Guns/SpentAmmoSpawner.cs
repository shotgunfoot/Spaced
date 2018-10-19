using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpentAmmoSpawner : MonoBehaviour {

    public GameObject spentAmmoPrefab;    
    public float expulsionForce;

    public void SpawnWithForce()
    {
        GameObject obj = Instantiate(spentAmmoPrefab, transform.position, transform.rotation);
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * expulsionForce);
    }
}
