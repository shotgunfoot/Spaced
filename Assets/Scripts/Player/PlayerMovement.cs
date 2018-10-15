using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public MovementAttributes playerAttributes;
    public Transform target;
    public Rigidbody rb;
    public Animator anim;

    Vector3 input;

    private void FixedUpdate()
    {
        ///
        ///OLD WAY THAT FOLLOWS A TARGET
        ///
        //Vector3 desiredPosition;
        //float distance = Vector3.Distance(transform.position, target.position);
        //if (distance > 2.9f)
        //{
        //    desiredPosition = Vector3.Slerp(transform.position, target.position, Time.deltaTime * playerAttributes.Speed);
        //    rb.MovePosition(desiredPosition);
        //}

        //Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * playerAttributes.TurningSpeed);    

        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        
        if(input != Vector3.zero)
        {            
            input = input * playerAttributes.Speed;                  
            rb.MovePosition(rb.position + (transform.forward * playerAttributes.Speed) * Time.deltaTime);
            anim.SetFloat("Velocity", 1);   
        }
        else
        {
            anim.SetFloat("Velocity", 0);

        }        

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * playerAttributes.TurningSpeed);

        
    }

}
