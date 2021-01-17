using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Weapon_Base Weapon;
    public GameObject DefaultWeapon;

    public Transform WeaponSlot;

    public Character_Base character;
    private void Start()
    {
        if (character == null)
            character = GetComponent<Character_Base>();
        if (DefaultWeapon != null)
        {
            GameObject g = Instantiate(DefaultWeapon);
            Weapon = g.GetComponent<Weapon_Base>();
            EquipWeapon(Weapon);
        }
    }

    public void EquipWeapon(Weapon_Base weapon)
    {
        weapon.transform.SetParent(WeaponSlot);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        Weapon.OnEquip(character);
    }
}
