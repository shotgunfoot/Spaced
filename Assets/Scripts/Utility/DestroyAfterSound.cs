using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSound : MonoBehaviour {

    AudioSource sound;
    MeshRenderer mesh;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
    }

    public void SelfDestruct()
    {
        StartCoroutine(DestroyAfterSoundEnumerator());
    }

    IEnumerator DestroyAfterSoundEnumerator()
    {
        sound.Play();
        while (sound.isPlaying)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
