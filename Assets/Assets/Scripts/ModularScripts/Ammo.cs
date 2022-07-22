using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float reloadRate;
    private float reloadTime;

    public int maxAmmo;
    protected int currentAmmo;

    private void Start()
    {
        reloadRate = GameManager.reloadCap;
        reloadTime = GameManager.reloadTime;

        maxAmmo = GameManager.bulletsCap;
        currentAmmo = GameManager.bulletsLeft;
    }

    public bool CheckAmmo()
    {
        return currentAmmo > 0;
    }

    //Decreases ammo and resets reload
    public void UseBullet()
    {
        currentAmmo--;
        reloadTime = Time.time + reloadRate;

        LegacyBulletUsage();
    }

    //Reloads constantly 1 bullet at a time
    private void AutoReload()
    {
        if (reloadTime < Time.time && currentAmmo < maxAmmo)
        {
            reloadTime = Time.time + reloadRate;
            currentAmmo++;

            LegacyReload();
        }
    }

    private void FixedUpdate()
    {
        AutoReload();
    }

    //LEGACY
    public delegate void BulletDelegate();
    public static event BulletDelegate BulletNumberUpdated;

    private void LegacyReload()
    {
        if (GameManager.bulletsLeft < GameManager.bulletsCap)
        {
            GameManager.reloadTime = Time.time + GameManager.reloadCap;
            GameManager.bulletsLeft++;
            //BulletNumberUpdated();
        }
    }

    private void LegacyBulletUsage()
    {
        GameManager.reloadTime = Time.time + GameManager.reloadCap;
        GameManager.bulletsLeft--;
        //BulletNumberUpdated();
    }

}
