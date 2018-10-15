using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 input;
    Vector3 targetPosition;

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(input != Vector3.zero)
        {
            input = input.normalized;

            targetPosition = target.position + (input * 3);

            transform.position = targetPosition;
        }        
    }
}
