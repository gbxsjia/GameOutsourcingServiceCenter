using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shooter :Weapon_Base
{
    [SerializeField]
    private GameObject ProjectilePrefab;

    public float ShootInterval;
    public float ShootCoolDown;

    private float FireInterval;
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
        for (int i = 0; i < shootTimes; i++)
        {
            CreateBullet();
            yield return new WaitForSeconds(FireInterval);
        }     
    }
    public void CreateBullet()
    {
        Quaternion shootRotation = transform.rotation * Quaternion.Euler(Random.Range(-2f,2f),Random.Range(-2f,2f),0);
        GameObject g = Instantiate(ProjectilePrefab, transform.position, shootRotation);
    }
}
