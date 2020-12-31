using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Base : MonoBehaviour
{
    public Character_Base ownerCharacter;

    public Behaviour AttackBehaviour;

    private void Awake()
    {
        ownerCharacter = GetComponentInParent<Character_Base>();
        ownerCharacter.Weapon = this;
    }
    public virtual void AttackCommand()
    {
        Behaviour b = ownerCharacter.StartBehaviour(AttackBehaviour.AnimationName, AttackBehaviour.Duration, AttackBehaviour.Type, AttackBehaviour.EventTiming);
        b.BehaviourTimingEvent += OnBehaviourTiming;
    }

    protected virtual void OnBehaviourTiming(Behaviour Behaviour, int Index)
    {        
    }
}
