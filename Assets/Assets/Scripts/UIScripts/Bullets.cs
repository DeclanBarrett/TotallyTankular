using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    void SetBullets()
    {
        if (GameManager.bulletsLeft <= 0)
        {
            foreach (Transform child in transform)
            {
                child.transform.localScale = new Vector3(0, 0, 0);
            }
        }
        else
        {
            for (int i = 0; i < GameManager.bulletsLeft; i++)
            {
                this.transform.GetChild(i).transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            if (GameManager.bulletsLeft != GameManager.bulletsCap)
            {
                for (int j = GameManager.bulletsLeft; j <= GameManager.bulletsCap; j++)
                {
                    this.transform.GetChild(j).transform.localScale = new Vector3(0f, 0f, 0f);
                }
            }
        }
    }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.transform.localScale = new Vector3(0, 0, 0);
        }
        SetBullets();
    }

    private void Update()
    {
        SetBullets();
    }
    private void OnEnable()
    {
        Turret.BulletNumberUpdated += SetBullets;
    }

    private void OnDisable()
    {
        Turret.BulletNumberUpdated -= SetBullets;
    }
}
