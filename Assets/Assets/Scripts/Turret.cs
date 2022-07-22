using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    
    private GameObject projectile;

    private float bulletsAntiSelfDestroyTime;
    private float bulletsAntiSelfDestroyRate = 0.01f;

    public delegate void BulletDelegate();
    public static event BulletDelegate BulletNumberUpdated;

    private void Awake()
    {
        //Debug.Log(GameManager.bulletType);
        projectile = bulletPrefabs[GameManager.bulletType];
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ShootMissile();
        if (GameManager.reloadTime < Time.time)
        {
            if (GameManager.bulletsLeft < GameManager.bulletsCap)
            {
                GameManager.reloadTime = Time.time + GameManager.reloadCap;
                GameManager.bulletsLeft += 1;
                BulletNumberUpdated();
            }
        }
        
    }

    //Shoot the missile
    private void ShootMissile()
    {
        if (Input.GetAxis("Fire1") > 0 && GameManager.bulletsLeft > 0 && bulletsAntiSelfDestroyTime < Time.time)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.3f);
            bool dontShootNear = false;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].transform.CompareTag("Bullet") || hitColliders[i].transform.CompareTag("Wall"))
                {
                    dontShootNear = true;
                }
            }

            if (dontShootNear == false)
            {
                bulletsAntiSelfDestroyTime = Time.time + bulletsAntiSelfDestroyRate;
                GameManager.reloadTime = Time.time + GameManager.reloadCap;
                GameManager.bulletsLeft -= 1;
                BulletNumberUpdated();
                GameObject currentInstantiated = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0));
            }
        }


    }

}
