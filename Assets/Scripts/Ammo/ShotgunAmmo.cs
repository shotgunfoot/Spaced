using System.Collections;
using UnityEngine;

public class ShotgunAmmo : Ammo, IVisibility, IInteractionSound
{
    private MeshRenderer mesh;
    private BoxCollider coll;
    private AudioSource source;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
        source = GetComponent<AudioSource>();
    }   

    public void SetVisible()
    {
        mesh.enabled = true;
        coll.enabled = true;
    }

    public void SetInvisible()
    {
        mesh.enabled = false;
        coll.enabled = false;
    }

    public void PlaySound()
    {
        source.Play();
    }
}
