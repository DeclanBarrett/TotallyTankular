using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    public GameObject deathParticleEffect;
    public GameObject deathSound;

    public bool Die(string killerName)
    {
        Destroy(this.gameObject);
        Instantiate(deathParticleEffect, transform.position, transform.rotation);
        GameObject soundObject = Instantiate(deathSound);
        Destroy(soundObject, 2f);

        //Legacy
        PlayerDestroyed(this.gameObject);

        return true;
    }

    //Legacy
    public delegate void PlayerUpdated(GameObject deadGameObject);
    public static event PlayerUpdated PlayerDestroyed;
}
