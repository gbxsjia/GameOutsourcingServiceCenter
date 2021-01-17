using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Base : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public float Speed;

    public Character_Base Owner;
    public Weapon_Shooter Weapon;

    public float Damage;

    float timer;

    public virtual void OnCreated(Character_Base owner, Weapon_Shooter weapon)
    {
        Owner = owner;
        Weapon = weapon;
        Damage = weapon.GetDamage();
    }

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
