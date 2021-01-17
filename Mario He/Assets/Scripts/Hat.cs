using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;
    public float Accleration;
    private bool isForward = true;
    private float CurrentSpeed;
    private Transform ownerTransform;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ownerTransform = PlayerController.instance.currentCharacter.transform;
        CurrentSpeed = Speed;
    }



    private void Update()
    {
        Vector3 v = rb.velocity;
        if (isForward)
        {          
            v = transform.forward * CurrentSpeed;

            rb.velocity = v;

            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, 0, Accleration * Time.deltaTime);
            
            
            if (CurrentSpeed == 0)
            {
                isForward = false;
            }
        }



        else
        {
            Vector3 direction = (ownerTransform.position - transform.position).normalized;

            v = direction * CurrentSpeed;
            rb.velocity = v;

            CurrentSpeed = Mathf.MoveTowards(CurrentSpeed, Speed, Accleration * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        Character body = other.gameObject.GetComponent<Character>();
        if (body != null)
        {
            if(body == PlayerController.instance.currentCharacter)
            {
                Mario theMario = other.GetComponent<Mario>();
                if (theMario && !isForward)
                {
                    theMario.HatBack(this);
                }
            }
            else
            {
                PlayerController.instance.ChangeBody(body);
                Destroy(gameObject);
            }           
        }
    }

}
