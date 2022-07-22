using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingExplosion : MonoBehaviour
{
    public float explodingRadius = 1.5f;
    public int damage = 200;

    //private const float explosionLength = 0.3f;
    //private float explosionTimer;

    void Start()
    {
        Destroy(this.gameObject, 3f);
        ExplosionDamage();
    }

    void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explodingRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            i++;
        }
    }
}
