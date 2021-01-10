﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState_Base : MonoBehaviour
{
    [Header("基础属性")]
    public bool isAlive;

    public int Camp;

    public int HealthMax;
    public int HealthCurrent;

    public event System.Action<DamageInfo> DeathEvent;

    [Header("AI需求值")]
    public float AIStamina;

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