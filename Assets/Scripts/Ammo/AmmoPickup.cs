using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int ammoPerPickup;
    AudioSource sound;
    MeshRenderer mesh;
    
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CustomTag>().HasTag("Player"))
        {
            InventoryBasic inventory = other.GetComponentInParent<InventoryBasic>();
            inventory.AddShells(ammoPerPickup);
            mesh.enabled = false;
            StartCoroutine(DestroyAfterSound());
        }
    }

    IEnumerator DestroyAfterSound()
    {
        sound.Play();
        while (sound.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);        
    }

}
