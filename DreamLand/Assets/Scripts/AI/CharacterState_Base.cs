using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageReceiver))]
public class CharacterState_Base : MonoBehaviour
{
    private DamageReceiver damageReceiver;

    [Header("基础属性")]
    public bool isAlive;

    public int Camp;

    public int HealthMax;
    public int HealthCurrent;

    public float WillPowerMax;
    public float WillPowerCurrent;

    public event System.Action<DamageInfo> DeathEvent;

    [Header("AI需求值")]
    public float AIStamina;

    private List<float> DamageBuff=new List<float>();
 
    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        damageReceiver = GetComponent<DamageReceiver>();
        damageReceiver.TakeDamageEvent += TakeDamage;
        damageReceiver.CState = this;
        isAlive = true;
        HealthCurrent = HealthMax;
        WillPowerCurrent = WillPowerMax;
    }
    public void TakeDamage(DamageInfo info)
    {
        HealthCurrent -= info.damage;
        if (HealthCurrent <= 0)
        {
            isAlive = false;
            if (DeathEvent != null)
            {
                DeathEvent(info);
            }
        }
    }
    public void AddDamageBuff(float amount)
    {
        DamageBuff.Add(amount);
    }
    public void RemoveDamageBuff(float amount)
    {
        DamageBuff.Remove(amount);
    }
    public float GetDamageBuff()
    {
        float result = 0;
        foreach(float f in DamageBuff)
        {
            if (f > result)
            {
                result = f;
            }
        }
        return result;
    }
}

