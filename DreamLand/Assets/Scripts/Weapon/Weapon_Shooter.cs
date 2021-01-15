using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shooter :Weapon_Base
{
    [SerializeField]
    private GameObject ProjectilePrefab;
    public ShootInfo[] ShootInfos;
    private int BulletIndex;

    public override void AttackCommand()
    {
        base.AttackCommand();
        BulletIndex = 0;
    }
    protected override void OnBehaviourTiming(Behaviour Behaviour, int Index)
    {
        CreateBullet();
    }

    public void CreateBullet()
    {
        Quaternion shootRotation = transform.rotation * Quaternion.Euler(0, ShootInfos[BulletIndex].AngleOffset, 0);
        Vector3 SpawnPosition = transform.position + transform.forward * 0.5f + Vector3.up * 0.5f;
        SpawnPosition += transform.forward * ShootInfos[BulletIndex].PositionOffset.z + transform.right * ShootInfos[BulletIndex].PositionOffset.x;
        GameObject g = Instantiate(ProjectilePrefab, SpawnPosition, shootRotation);
        BulletIndex++;
    }
}
[System.Serializable]
public class ShootInfo
{
    public float AngleOffset;
    public Vector3 PositionOffset;
}