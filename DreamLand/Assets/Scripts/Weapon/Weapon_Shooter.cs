using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shooter :Weapon_Base
{
    [SerializeField]
    private GameObject ProjectilePrefab;

    public float ShootInterval;
    public float ShootCoolDown;

    private float CoolDownTime;
    public void StartShooting(int times)
    {
        if (Time.time >= CoolDownTime)
        {
            CoolDownTime = Time.time;
            StartCoroutine(ShootProcess(times));
        }
    }
    private IEnumerator ShootProcess(int shootTimes)
    {

    }
}
