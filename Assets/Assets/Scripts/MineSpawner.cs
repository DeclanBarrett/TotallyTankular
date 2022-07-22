using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    private GameObject currentMine;
    public GameObject minePrefab;

    public float delayMinePlacement;
    private float delayTimer;

    void Start()
    {
        delayTimer = delayMinePlacement + Random.Range(0f, 5f);
    }

    private void ShootMine()
    {
        if (this.gameObject.transform.tag == "Player")
        {
            if (Input.GetAxis("Fire2") > 0 && GameManager.minesEnabled == true && currentMine == null)
            {
                currentMine = Instantiate(minePrefab, new Vector3(transform.position.x, 0, transform.position.z), new Quaternion(0, 0, 0, 0));
                currentMine.transform.GetComponent<Mine>().SetOwnerVariable(this.gameObject.transform.tag);
            }
        } else if (this.gameObject.transform.tag == "Enemy")
        {
            if (currentMine == null)
            {
                delayTimer -= Time.deltaTime;
                if (delayTimer < 0)
                {
                    currentMine = Instantiate(minePrefab, new Vector3(transform.position.x, 0, transform.position.z), new Quaternion(0, 0, 0, 0));
                    currentMine.transform.GetComponent<Mine>().SetOwnerVariable(this.gameObject.transform.tag);
                    delayTimer = delayMinePlacement + Random.Range(0f, 5f);
                }
                
            }
        }
    }

    private void FixedUpdate()
    {
        ShootMine();
    }
}
