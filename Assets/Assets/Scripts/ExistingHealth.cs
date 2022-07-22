using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistingHealth : MonoBehaviour
{
    private int healthValue;
    public int initialHealthValue;

    public int HealthValue
    {
        get { return healthValue; }
        set { healthValue = value;  }
    }

    public void TakeDamage(int damage)
    {
        healthValue -= damage;
        DestroyObjectCheck();
    }

    public void GainHealth(int healthGain)
    {
        healthValue += healthGain;
    }

    private void DestroyObjectCheck()
    {
        if (healthValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        healthValue = initialHealthValue;
    }
}
