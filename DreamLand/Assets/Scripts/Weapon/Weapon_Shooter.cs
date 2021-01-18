using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shooter :Weapon_Base
{
    [SerializeField]
    private GameObject ProjectilePrefab;
    public ShootInfo[] ShootInfos;
    private int BulletIndex;

    public override void AttackCommand(Vector3 direction)
    {
        base.AttackCommand(direction);
        BulletIndex = 0;
    }
    protected override void OnBehaviourTiming(Behaviour Behaviour, int Index)
    {
        CreateBullet();
    }

    public void CreateBullet()
    {
        Quaternion attackRotation = Quaternion.LookRotation(AttackDirection);
        Vector3 attackRight = Quaternion.Euler(0, 90, 0) * AttackDirection;

        Quaternion bulletRotation = attackRotation * Quaternion.Euler(0, ShootInfos[BulletIndex].AngleOffset, 0);
        Vector3 SpawnPosition = ownerCharacter.transform.position + AttackDirection * 0.5f + Vector3.up * 0.5f;
        SpawnPosition += AttackDirection * ShootInfos[BulletIndex].PositionOffset.z + attackRight * ShootInfos[BulletIndex].PositionOffset.x;

        GameObject g = Instantiate(ProjectilePrefab, SpawnPosition, bulletRotation);
        g.GetComponent<Projectile_Base>().OnCreated(ownerCharacter, this);

        BulletIndex++;
    }
}
[System.Serializable]
public class ShootInfo
{
    public float AngleOffset;
    public Vector3 PositionOffset;
}