using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public delegate void EnemyUpdated(GameObject deadGameObject);
    public static event EnemyUpdated EnemyDestroyed;

    public delegate void EnemyCoins(int tankPayment);
    public static event EnemyCoins EnemyPayment;

    //public GameObject tankTreadPrefab;
    private string tagToShoot = "Track";
    public GameObject particle;
    public GameObject deathSound;

    private float tankTreadTime;
    private float tankTreadRate = 0.3f;

    public float health;
    public int coinReward;
    public int laserBounceLimit;
    public float reloadBounceRate;

    public float rotationSpeed;
    public int lookAtRandomAngleTotal;
    public GameObject bulletType;

    private Rigidbody usingRigidBody;

    public Transform targetTransform;

    //Get the rigidbody and limit its movement
    private void Awake()
    {
        usingRigidBody = this.GetComponent<Rigidbody>();
        usingRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        FindTarget();
    }

    private void Update()
    {
        if (targetTransform == null)
        {
            FindTarget();
        }
        SpawnTankTracks();
    }

    void FindTarget()
    {
        GameObject temporaryTarget = GameObject.FindGameObjectWithTag("Player");
        if (temporaryTarget != null)
        {
            targetTransform = temporaryTarget.transform;
        }
        else
        {
            temporaryTarget = GameObject.FindGameObjectWithTag("Enemy");
            if (temporaryTarget != null)
            {
                targetTransform = temporaryTarget.transform;
            }
            else
            {
                targetTransform = this.transform;
            }
        };
    }

    //Enable taking damage
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EnemyPayment(coinReward);
            EnemyDestroyed(this.gameObject);
            Destroy(this.gameObject);
            Instantiate(particle, transform.position, transform.rotation);
            GameObject soundObject = Instantiate(deathSound);
            Destroy(soundObject, 2f);
            //Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
    
    //Spawn tank tracks behind
    private void SpawnTankTracks()
    {
        if (tankTreadTime < Time.time)
        {
            GameObject instantiate = ObjectPool.GetPooledObject(tagToShoot);
            if (instantiate != null)
            {
                instantiate.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                instantiate.transform.rotation = transform.rotation;
                instantiate.SetActive(true);
            }
            
            tankTreadTime = Time.time + tankTreadRate;
        }
    }


}
