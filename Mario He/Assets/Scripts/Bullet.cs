using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Vector3 v = rb.velocity;
        v = transform.forward * Speed;

        rb.velocity = v;

    }

}
