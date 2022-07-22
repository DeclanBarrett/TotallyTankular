using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public delegate void UpdateUpgrade();
    public static UpdateUpgrade UpgradeEverything;

    public void UpgradeHealth()
    {
        if (GameManager.coins - GameManager.healthCoins >= 0)
        {
            GameManager.healthCap += 50;
            GameManager.coins -= GameManager.healthCoins;
            GameManager.healthCoins += 100;
            Debug.Log(GameManager.healthCoins.ToString());
            UpgradeEverything();
            TurnOffButton();
        }
    }

    public void UpgradeArmour()
    {
        if (GameManager.coins - GameManager.armourCoins >= 0)
        {
            GameManager.armour += 100;
            GameManager.coins -= GameManager.armourCoins;
            GameManager.armourCoins += 100;
            UpgradeEverything();
            TurnOffButton();
        }
            
    }

    public void UpgradeBulletCap()
    {
        if (GameManager.coins - GameManager.bulletCoins >= 0)
        {
            GameManager.bulletsCap += 1;
            GameManager.coins -= GameManager.bulletCoins;
            GameManager.bulletCoins += 100;
            Debug.Log(GameManager.bulletCoins.ToString());
            UpgradeEverything();
            TurnOffButton();
        }
    }

    public void UpgradeReloadTime()
    {
        if (GameManager.coins - GameManager.reloadCoins >= 0)
        {
            GameManager.reloadCap -= 0.4f;
            GameManager.coins -= GameManager.reloadCoins;
            GameManager.reloadCoins += 100;
            Debug.Log(GameManager.reloadCoins.ToString());
            UpgradeEverything();
            TurnOffButton();
        }
        
    }

    public void UpgradeSpeed()
    {
        if (GameManager.coins - GameManager.speedCoins >= 0)
        {
            GameManager.speed += 15f;
            GameManager.coins -= GameManager.speedCoins;
            GameManager.speedCoins += 50;
            Debug.Log(GameManager.speedCoins.ToString());
            UpgradeEverything();
            TurnOffButton();
        }
        
    } 

    public void UpgradeBulletType()
    {
        if (GameManager.coins - GameManager.bulletTypeCoins >= 0)
        {
            GameManager.bulletType += 1;
            GameManager.coins -= GameManager.bulletTypeCoins;
            UpgradeEverything();
            TurnOffButton();
        }
        
    }

    public void UpgradeMineStatus()
    {
        if (GameManager.coins - GameManager.mineCoins >= 0)
        {
            GameManager.minesEnabled = true;
            GameManager.coins -= GameManager.mineCoins;
            UpgradeEverything();
            TurnOffButton();
        }

    }

    private void TurnOffButton()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
}
