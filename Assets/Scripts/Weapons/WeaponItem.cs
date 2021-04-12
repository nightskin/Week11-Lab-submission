using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Weapon", order = 1)]
public class WeaponItem : EquipableItem
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController controller)
    {
        base.UseItem(controller);
        if(equipped)
        {
            controller.Weapon.UnEquipWeapon();
        }
        else
        {
            controller.Weapon.EquipWeapon(this);
        }
    }
}
