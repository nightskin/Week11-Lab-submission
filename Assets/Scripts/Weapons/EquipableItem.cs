using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipableItem : ItemScriptables
{
    public bool equipped
    {
        get => m_Equiped;
        set
        {
            m_Equiped = value;
            OnEquipStatusChange?.Invoke();
        }
    }

    private bool m_Equiped = false;

    public delegate void EquipStatusChange();

    public event EquipStatusChange OnEquipStatusChange;

    public override void UseItem(PlayerController controller)
    {
        equipped = !equipped;
    }
}
