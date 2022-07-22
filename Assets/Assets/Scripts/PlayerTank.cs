using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    //Shooting variables
    //private Vector3 position;

    private float tankTreadTime;
    private float tankTreadRate = 0.3f;

    //Movement Variables
    //private Vector3 movementForce;
    //private Rigidbody usingRigidBody;
    // Start is called before the first frame update
    //public delegate void PlayerUpdated(GameObject deadGameObject);
    //public static event PlayerUpdated PlayerDestroyed;

    //public delegate void PlayerHealth();
    //public static event PlayerHealth PlayerHealthUpdated;

    public GameObject ParticleExplosion;
    public GameObject deathSound;

    private void Awake()
    {
        GameManager.health = GameManager.healthCap;
        GameManager.bulletsLeft = GameManager.bulletsCap;
        //PlayerHealthUpdated();
        //usingRigidBody = this.GetComponent<Rigidbody>();
        //usingRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    void Start()
    {
        //Debug.Log(usingRigidBody.constraints);
        //PlayerHealthUpdated();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position = transform.position;
        //Movement();
        SpawnTankTracks();
    }

    /*
    private void Movement()
    {
        //8 direction movement
        movementForce = new Vector3(0, 0, 0);
        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
        {
            movementForce.x = movementSpeed * 0.75f;
            movementForce.z = movementSpeed * 0.75f;
            rotation = 45f;
        }
        else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
        {
            movementForce.x = movementSpeed * 0.75f;
            movementForce.z = -movementSpeed * 0.75f;
            rotation = 135f;
        }
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
        {
            movementForce.x = -movementSpeed * 0.75f;
            movementForce.z = movementSpeed * 0.75f;
            rotation = 315f;
        }
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
        {
            movementForce.x = -movementSpeed * 0.75f;
            movementForce.z = -movementSpeed * 0.75f;
            rotation = 225f;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            movementForce.x = movementSpeed;
            rotation = 90f;
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            movementForce.x = -movementSpeed;
            rotation = 270f;
        } else if (Input.GetAxis("Vertical") > 0)
        {
            movementForce.z = movementSpeed;
            rotation = 0f;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            movementForce.z = -movementSpeed;
            rotation = 180f;
        }

        

        //Rotate the base to an angle and then move
        targetRotation = Quaternion.Euler(0, rotation, 0);
        usingRigidBody.rotation = Quaternion.Slerp(usingRigidBody.rotation, targetRotation, 0.2f);
        usingRigidBody.AddForce(movementForce);
    }

*/

    public GameObject tankTreadPrefab;

    //Spawn tank tracks behind
    private void SpawnTankTracks()
    {
        if (tankTreadTime < Time.time)
        {
            GameObject instantiate = Instantiate(tankTreadPrefab, new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);
            tankTreadTime = Time.time + tankTreadRate;
        }
    }

    /*
    public void TakeDamage(float damage)
    {
        if (GameManager.armour > 0)
        {
            GameManager.armour -= damage;
        } else
        {
            GameManager.health -= damage;
        }

        PlayerHealthUpdated();

        if (GameManager.health <= 0)
        {
            PlayerDestroyed(this.gameObject);
            Destroy(this.gameObject);
            Instantiate(ParticleExplosion, transform.position, transform.rotation);
            GameObject soundObject = Instantiate(deathSound);
            Destroy(soundObject, 2f);
        }

        
    }
    */
}
