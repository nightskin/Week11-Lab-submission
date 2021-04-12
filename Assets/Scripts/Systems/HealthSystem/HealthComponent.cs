using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.HealthSystems;
using System;

public class HealthComponent : MonoBehaviour , IDamagable
{
    public float health => currentHealth;
    public float maxHealth => totalHealth;

    [SerializeField] private float currentHealth;
    [SerializeField] private float totalHealth;
    protected virtual void Awake()
    {
        currentHealth = totalHealth;
    }

    internal void HealPlayer(int effect)
    {
        if(currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += effect;
            if (currentHealth <= 0)
            {
                //Destroy();
            }
        }

    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <=0)
        {
            Destroy();
        }
    }



}
