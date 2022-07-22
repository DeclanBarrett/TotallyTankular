using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    //Owner variable
    private string ownerGameObjectTag;

    //Detonation variables
    private const float detonationCountDownLength = 15f;
    private const float flashingTimeStart = 3f;
    private const float flashingFastTimeStart = 0.5f;
    private const float explosiveLiveTimeStart = 12f;
    private const float flashingOnOffLength = 0.15f;
    private const float flashingFastOnOffLength = 0.05f;
    private float detonationTimer;

    //variables attached
    public GameObject explosionWithDamagePrefab; //explosion that causes damage when set off
    public GameObject particle;
    public GameObject deathSound;
    public GameObject timerSound;
    public GameObject mineGraphics; //the graphics attached to the object
    public GameObject mineTrigger; //the sphere trigger surrounding the mine
    public GameObject mineCollisionTrigger;

    private GameObject mineExplosiveCheck;

    //Materials used to flip colours
    public Material yellowMaterial;
    public Material redMaterial;
    // Start is called before the first frame update
    void Awake()
    {
        //Setting the default material and timer length
        detonationTimer = detonationCountDownLength;
        mineGraphics.GetComponent<MeshRenderer>().material = yellowMaterial;
    }

    void Update()
    {
        //Counts down detonation timer
        detonationTimer -= Time.deltaTime;
        
        //If detonation is below 0 then destroy
        if (detonationTimer < 0f)
        {
            //Debug.Log("Detonation Timer");
            DestroyObject();
        } else if (detonationTimer < flashingFastTimeStart)
        {
            if (detonationTimer % (flashingFastOnOffLength * 2) < flashingFastOnOffLength)
            {
                mineGraphics.GetComponent<MeshRenderer>().material = yellowMaterial;
            }
            else
            {
                mineGraphics.GetComponent<MeshRenderer>().material = redMaterial;
            }
        } else if (detonationTimer < flashingTimeStart) //Handles flashing
        {
            if (detonationTimer % (flashingOnOffLength * 2) < flashingOnOffLength)
            {
                mineGraphics.GetComponent<MeshRenderer>().material = yellowMaterial;
            }
            else
            {
                mineGraphics.GetComponent<MeshRenderer>().material = redMaterial;
            }
        }
    }

    //Set time to the start of flashing
    void BeginTimerFlashing()
    {
        if (detonationTimer < explosiveLiveTimeStart && detonationTimer > flashingFastTimeStart)
        {
            //Debug.Log("Starts flashing");
            detonationTimer = flashingFastTimeStart;
        }
    }

    //Handles what happens when destroying
    void DestroyObject()
    {
        Instantiate(particle, transform.position, transform.rotation);
        GameObject soundObject = Instantiate(deathSound);
        Destroy(soundObject, 2f);
        Instantiate(explosionWithDamagePrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    //Receives event call from the detector trigger
    public void PullTrigger(GameObject childObject, Collider otherCollider)
    {
        if (childObject != null && otherCollider != null)
        {
            if (childObject == mineTrigger && ((detonationTimer < explosiveLiveTimeStart && otherCollider.transform.tag == ownerGameObjectTag)
            || (otherCollider.transform.tag != ownerGameObjectTag && (otherCollider.transform.tag == "Enemy" || otherCollider.transform.tag == "Player"))))
            {
                //Debug.Log("Child Receives Input");
                BeginTimerFlashing();
            }

            if (childObject == mineCollisionTrigger)
            {
                if (otherCollider.transform.tag == "Bullet" || ((detonationTimer < explosiveLiveTimeStart && otherCollider.transform.tag == ownerGameObjectTag)
                || (otherCollider.transform.tag != ownerGameObjectTag && (otherCollider.transform.tag == "Enemy" || otherCollider.transform.tag == "Player"))))
                {
                    //Debug.Log("Destroyed because of collision with mine");
                    //Debug.Log("Detonation Timer: " + detonationTimer);
                    DestroyObject();
                }
            }
        }
        
    }

    public void SetOwnerVariable(string ownerOfMine)
    {
        ownerGameObjectTag = ownerOfMine;
    }

    void OnEnable()
    {
        ChildTrigger.TriggerTransfer += PullTrigger;
    }

    void OnDisable()
    {
        ChildTrigger.TriggerTransfer -= PullTrigger;
    }
}
