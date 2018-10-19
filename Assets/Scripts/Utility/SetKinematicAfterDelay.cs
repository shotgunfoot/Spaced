using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKinematicAfterDelay : MonoBehaviour
{

    TimeSince timer;
    public float delayTime;

    private void Start()
    {        
        StartCoroutine(SetKinematicAfterDelayCoroutine());
    }

    IEnumerator SetKinematicAfterDelayCoroutine()
    {
        timer = 0;

        while (timer < delayTime)
        {
            yield return null;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        yield return null;
    }
}
