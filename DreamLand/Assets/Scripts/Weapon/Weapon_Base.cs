﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Base : MonoBehaviour
{
    public Character_Base ownerCharacter;

    public Behaviour AttackBehaviour;

    public int BaseDamage;
    protected Vector3 AttackDirection;
    public float Range;
    [Header("AI信息")]
    public float FitRangeMax;
    public float FitRangeMin;

    public void OnEquip(Character_Base owner)
    {
        ownerCharacter = owner;
    }
    public virtual void AttackCommand(Vector3 direction)
    {
        AttackDirection = direction;
        Behaviour b = ownerCharacter.StartBehaviour(AttackBehaviour.AnimationName, AttackBehaviour.Duration, AttackBehaviour.Type, AttackBehaviour.EventTiming);
        if (b != null)
        {
            b.BehaviourTimingEvent += OnBehaviourTiming;
        }          
    }
    public virtual int GetDamage()
    {
        int result = BaseDamage;
        result = (int)(result * (ownerCharacter.CState.GetDamageBuff() + 1));
        return result;
    }

    protected virtual void OnBehaviourTiming(Behaviour Behaviour, int Index)
    {        
    }
}
