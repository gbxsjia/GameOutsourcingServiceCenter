using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Base : MonoBehaviour
{
    public bool isAlive;

    public int HealthMax;
    public int HealthCurrent;

    public event System.Action<DamageInfo> DeathEvent;


    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        isAlive = true;
        HealthCurrent = HealthMax;
    }
    public void TakeDamage(DamageInfo info)
    {
        HealthCurrent -= info.damage;
        if (HealthCurrent <= 0)
        {
            if (DeathEvent != null)
            {
                DeathEvent(info);
            }
        }
    }
}

public class DamageInfo
{
    public int damage;
    public GameObject damageFrom;
    public Character_Base instigator;
}