using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class Health : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    public int CurrentHealth { get; }

    private DeathHandler DeathHandler;

    private void Awake()
    {
        DeathHandler = GetComponent<DeathHandler>();
        PlayerHealthUpdated();
    }

    public void TakeDamage(int damage, string attackersName = "Unknown")
    {
        damage = CheckArmour(damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DeathHandler.Die(attackersName);
        }

        //Legacy
        GameManager.health -= damage;
        PlayerHealthUpdated();
    }

    public void Heal(int health)
    {
        currentHealth += health;

        //Legacy
        GameManager.health += health;
        PlayerHealthUpdated();
    }

    //Returns damage left over after armour is hit
    private int CheckArmour(int damage)
    {
        if (GetComponent<Armour>() != null)
        {
            damage = GetComponent<Armour>().HitArmour(damage);
        }

        return damage;
    }

    //Legacy
    public delegate void PlayerHealth();
    public static event PlayerHealth PlayerHealthUpdated;

    private void Start()
    {
        //LEGACY
        maxHealth = (int)GameManager.healthCap;
        currentHealth = (int)GameManager.health;
    }
}

/*
using System;
using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class Health : MonoBehaviour
{
    private int maxHealth;
    public int MaxHealth { get;  }
    private int currentHealth;
    public int CurrentHealth { get; }

    private DeathHandler DeathHandler;

    public event Action<int, int> HealthChanged;

    private void Awake()
    {
        DeathHandler = GetComponent<DeathHandler>();
    }

    public void TakeDamage(int damage, string attackersName = "Unknown")
    {
        damage = CheckArmour(damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DeathHandler.Die(attackersName);
        }

        //Legacy
        GameManager.health -= damage;
        HealthChanged(currentHealth, maxHealth);
    }

    public void Heal(int health)
    {
        currentHealth += health;

        //Legacy
        GameManager.health += health;
        HealthChanged(currentHealth, maxHealth);
    }

    //Returns damage left over after armour is hit
    private int CheckArmour(int damage)
    {
        if (GetComponent<Armour>() != null)
        {
            damage = GetComponent<Armour>().HitArmour(damage);
        }

        return damage;
    }

    private void Start()
    {
        //LEGACY
        maxHealth = (int)GameManager.healthCap;
        currentHealth = (int)GameManager.health;
    }
}

*/
