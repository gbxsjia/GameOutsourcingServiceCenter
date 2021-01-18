using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Base : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public Character_Base Owner;
    public Weapon_Shooter Weapon;

    public float LifeTime;

    float LifeSpan;

    [Header("属性")]
    public float Speed;
    public int Damage;
    public bool CanDestroyWall;
    public bool DestroyOnHit;

    public virtual void OnCreated(Character_Base owner, Weapon_Shooter weapon)
    {
        Owner = owner;
        Weapon = weapon;
        Damage = weapon.GetDamage();
        LifeTime = weapon.Range / Speed;
        LifeSpan = LifeTime;
    }

    private void Start()
    {        
        rb.velocity = transform.forward * Speed;
    }

    private void Update()
    {
        LifeSpan -= Time.deltaTime;
        if (LifeSpan <= 0)
        {
            BulletDestroy();
        }
    }
    public void BulletDestroy()
    {
        Destroy(gameObject);
    }
    public void BulletHit(GameObject g)
    {
        BulletDestroy();
    }
    private void OnTriggerEnter(Collider other)
    {
        DamageReceiver receiver = other.GetComponent<DamageReceiver>();
        if (receiver)
        {
            OnBulletHit(receiver);
        }
    }
    protected virtual void OnBulletHit(DamageReceiver receiver)
    {
        switch (receiver.DRType)
        {
            case DRType.Character:
                if (receiver.Camp != Owner.CState.Camp)
                {
                    receiver.TakeDamage(MakeDamageInfo());
                    if (DestroyOnHit)
                    {
                        BulletDestroy();
                    }
                }
                break;
            case DRType.Wall:
                receiver.TakeDamage(MakeDamageInfo());
                if (DestroyOnHit)
                {
                    BulletDestroy();
                }
                break;
        }        
    }
    public DamageInfo MakeDamageInfo()
    {
        DamageInfo info = new DamageInfo();
        info.damage = Damage;
        info.damageFrom = gameObject;
        info.instigator = Owner;
        info.canDestroyWall = CanDestroyWall;
        return info;
    }
}
