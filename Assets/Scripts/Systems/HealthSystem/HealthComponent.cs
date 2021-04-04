using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.HealthSystems;

public class HealthComponent : MonoBehaviour , IDamagable
{
    public float health => currentHealth;
    public float maxHealth => baseHealth;

    [SerializeField] private float currentHealth;
    [SerializeField] private float baseHealth;
    protected virtual void Start()
    {
        currentHealth = baseHealth;
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <=0)
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

}
