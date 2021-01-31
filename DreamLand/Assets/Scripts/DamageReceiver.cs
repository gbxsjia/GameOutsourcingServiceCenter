using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public CharacterState_Base CState;
    public DRType DRType;
    public event System.Action<DamageInfo> TakeDamageEvent;
    public void TakeDamage(DamageInfo info) 
    {
        if (TakeDamageEvent != null)
        {
            TakeDamageEvent(info);
        }
    }
}
public enum DRType
{
    Character,
    Wall
}
public class DamageInfo
{
    public bool canDestroyWall;
    public int damage;
    public GameObject damageFrom;
    public Character_Base instigator;
}