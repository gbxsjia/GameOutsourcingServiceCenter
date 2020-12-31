using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Base : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public float Speed;

    float timer;
    private void Start()
    {
        timer = Time.time;
        rb.velocity = transform.forward * Speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - timer >= 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
