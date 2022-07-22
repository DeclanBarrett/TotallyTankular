using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    private int maxArmour;
    private int currentArmour;

    public int HitArmour(int damage)
    {
        if (currentArmour < damage)
        {
            //Legacy
            GameManager.armour = 0;
            //End Legacy

            damage -= currentArmour;
            currentArmour = 0;
        }
        else
        {
            //Legacy
            GameManager.armour -= damage;
            //End Legacy

            currentArmour -= damage;
            damage = 0;
        }

        return damage;
    }

    //Legacy
    private void Start()
    {
        maxArmour = (int) GameManager.armourCap;
        currentArmour = (int)GameManager.armour;
    }
}
