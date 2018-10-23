using System.Collections;
using UnityEngine;

public class ShotgunAmmo : Ammo
{    
    public GameEventWithParameter ShotgunAmmoPickupEvent;
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
            ShotgunAmmoPickupEvent.Raise();
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
