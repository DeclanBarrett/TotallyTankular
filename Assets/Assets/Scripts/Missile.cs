using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int bounceCurrent = 2;

    public int damage = 20;

    public float missileSpeed = 5f;

    private Rigidbody usingRigidBody;

    private float antiKillSelfTime;
    private float antiKillSelfTotal = 0.1f;

    private float antiDoubleBounceTime;
    private float antiDoubleBounceTotal = 0.06f;

    private Vector3 totalTurn;

    public GameObject EndExplosionParticle;
    public GameObject spriteObject;
    public GameObject bulletSmokeTrail;
    public GameObject metalExplosion;

    private bool insideWall;

    private AudioSource bulletAudio;

    public AudioClip woodBounceClip;
    public AudioClip shootClip;

    //Find rigidbody component
    private void Awake()
    {
        
        usingRigidBody = this.GetComponent<Rigidbody>();
        //usingRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    //initialise time
    void Start()
    {
        bulletAudio = this.gameObject.GetComponent<AudioSource>();
        bulletAudio.PlayOneShot(shootClip);
        //Debug.Log("Bullet Audi Play");
        insideWall = false;
        antiKillSelfTime = antiKillSelfTotal + Time.time;
        usingRigidBody.AddForce(transform.forward * missileSpeed * 50);
        spriteObject.transform.rotation = Quaternion.LookRotation(transform.forward, new Vector3(0, 0, 1)) * Quaternion.Euler(90, 0, 0);
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        //spriteObject.transform.rotation = Quaternion.LookRotation(usingRigidBody.velocity);
        //spriteObject.transform.rotation = Quaternion.LookRotation(transform.forward);
        //spriteObject.transform.rotation = (Quaternion.LookRotation(usingRigidBody.velocity, new Vector3(0, 0, 1)) * Quaternion.Euler(90, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Enter");
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyTank>().TakeDamage(damage);
            DetachParticle();
            GameObject metalHitExplosion = Instantiate(metalExplosion, transform.position, transform.rotation);
            Destroy(metalHitExplosion, 2f);
            //Debug.Log("Enemy Hit Collision");
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            DetachParticle();

            //Debug.Log("Player Hit Collision");
            Destroy(this.gameObject);

        }

        if (collision.transform.tag == "Bullet")
        {
            DetachParticle();
            Destroy(this.gameObject);
        }

        //Stop bullets from bouncing and killing
        if (collision.transform.tag == "Wall" && antiKillSelfTime > Time.time)
        {
            insideWall = true;
            DetachParticle();
            //Debug.Log("Kill Bullet Hit Collision");
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Wall")
        {

            if (bulletAudio != null)
            {
                bulletAudio.PlayOneShot(woodBounceClip);
            }

            if (antiDoubleBounceTime < Time.time)
            {
                bounceCurrent -= 1;
                antiDoubleBounceTime = Time.time + antiDoubleBounceTotal;
            }

            if (bounceCurrent == 0)
            {
                //Debug.Log("Bullet Collided with Wall and Died " + Time.time);
                DetachParticle();
                Destroy(this.gameObject);
            }
        }

        if (collision.transform.tag == "DestroyableWall")
        {
            collision.gameObject.GetComponent<ExistingHealth>().TakeDamage(damage);
            DetachParticle();
            GameObject metalHitExplosion = Instantiate(metalExplosion, transform.position, transform.rotation);
            Destroy(metalHitExplosion, 2f);
            Debug.Log("Wall Hit Collision");
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "BouncyWall")
        {

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        spriteObject.transform.rotation = (Quaternion.LookRotation(usingRigidBody.velocity, new Vector3(0, 0, 1)) * Quaternion.Euler(90, 0, 0));
    }
    /*
    //One collision with another object, check
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter");
        if (other.transform.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyTank>().takeDamage(damage);
            DetachParticle();
            //Debug.Log("Enemy Hit Collision");
            Destroy(this.gameObject);
        }

        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerTank>().takeDamage(damage);
            DetachParticle();

            //Debug.Log("Player Hit Collision");
            Destroy(this.gameObject);

        }

        if (other.transform.tag == "Bullet")
        {
            DetachParticle();
            Destroy(this.gameObject);
        }

        //Stop bullets from bouncing and killing
        if (other.transform.tag == "Wall" && antiKillSelfTime > Time.time)
        {
            insideWall = true;
            DetachParticle();
            Debug.Log("Kill Bullet Hit Collision");
            Destroy(this.gameObject);
        }
        if (other.transform.tag == "Wall")
        {
            
            if (bulletAudio != null)
            {
                bulletAudio.PlayOneShot(woodBounceClip);
            }
            insideWall = true;
            Vector3 directionVector;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit) && antiDoubleBounceTime < Time.time)
            {
                Debug.Log("Rebound " + Time.time);
                directionVector = Vector3.Reflect(transform.forward, hit.normal);
                totalTurn = transform.forward;
                //Debug.Log("Point of contact: " + hit.point);
                //Debug.Log("Name: " + other.transform.name);
                transform.rotation = Quaternion.LookRotation(directionVector);
                bounceCurrent -= 1;
                antiDoubleBounceTime = Time.time + antiDoubleBounceTotal;
            }
            
            //antiDoubleBounceTime = Time.time + antiDoubleBounceTotal;

            if (bounceCurrent == 0)
            {
                Debug.Log("Bullet Collided with Wall and Died " + Time.time);
                DetachParticle();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall" && insideWall == false)
        {
            Debug.Log("Bullet Collided with Wall and was not inside " + Time.time);
            DetachParticle();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (antiDoubleBounceTime < Time.time && other.tag == "Wall")
        {
            Debug.Log("Bullet Stayed in wall" + Time.time);
            transform.rotation = Quaternion.LookRotation(-totalTurn);
            antiDoubleBounceTime = Time.time + antiDoubleBounceTotal;
            DetachParticle();
            Destroy(this.gameObject);
        }
    }
    */

    private void DetachParticle()
    {
        //Debug.Log(PE.name);
        bulletSmokeTrail.GetComponent<ParticleSystem>().Stop();
        bulletSmokeTrail.transform.parent = null;
        bulletSmokeTrail.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(bulletSmokeTrail, 2f);
        GameObject endExplosion = Instantiate(EndExplosionParticle, transform.position, transform.rotation);
        Destroy(endExplosion, 2f);
        endExplosion.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void TakeDamage(int damage)
    {
        DetachParticle();
        Destroy(this.gameObject);
    }
}
