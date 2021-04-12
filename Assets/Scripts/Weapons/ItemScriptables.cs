using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptables : ScriptableObject
{
    public string name = "Item";
    public Categoary itemCategory = Categoary.None;
    public GameObject itemPrefab;
    public bool stacakable;
    public int maxStack = 1;

    public int Amount => m_Amount;
    private int m_Amount = 1;

    public PlayerController Controller { get; private set; }

    public void Initialize(PlayerController controller)
    {

    }

    public abstract void UseItem(PlayerController controller);
    public virtual void DeleteItem(PlayerController controller)
    {

    }

    public virtual void DropItem(PlayerController controller)
    {

    }

    public void ChangeAmount(int amount)
    {
        m_Amount += amount;
    }

    public void SetAmount(int amount)
    {
        m_Amount = amount;
    }

    public enum Categoary
    {
        None,
        Weapon,
        Equip,
        Consumable,
        Ammo
    }
}
