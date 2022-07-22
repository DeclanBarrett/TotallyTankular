using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPivot : MonoBehaviour
{
    //Enemy Pivot private variables
    Quaternion targetRotation;
    Quaternion previousRotation;
    Quaternion startRotation;

    float turningTime;

    const float rotationBalance = 50f;

    float startRotationTime;
    int lookAtCounter;
    Transform playerTransform;

    //Public Pivot variables
    float rotationSpeedLocal = 1f;
    int lookAtRandomAngleTotalLocal = 1;

    public GameObject enemyTankParent;

    //Find player transform
    private void Awake()
    {
        rotationSpeedLocal = enemyTankParent.GetComponent<EnemyTank>().rotationSpeed;
        lookAtRandomAngleTotalLocal = enemyTankParent.GetComponent<EnemyTank>().lookAtRandomAngleTotal;
    }

    //Initiate a target rotation
    private void Start()
    {
        playerTransform = enemyTankParent.GetComponent<EnemyTank>().targetTransform;


        targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        previousRotation = transform.rotation;
        startRotation = transform.rotation;
    }

    //Update
    private void FixedUpdate()
    {
        SetRandomAngle();
        //transform.rotation = Quaternion.Lerp(previousRotation, targetRotation, (rotationSpeedLocal * Time.deltaTime);
        SetCurrentAngle();
    }

    //Set random angle to point towards
    void SetRandomAngle()
    {
        //If close to angle
        if (targetRotation.eulerAngles.y < transform.eulerAngles.y + 1 && targetRotation.eulerAngles.y > transform.eulerAngles.y - 1)
        {
            //1 out of 5 looks will be a random spot
            if (lookAtCounter == lookAtRandomAngleTotalLocal)
            {
                targetRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                lookAtCounter = 0;
                turningTime = 0;
                startRotation = transform.rotation;
            }
            else
            {
                //look at player
                if (playerTransform != null)
                {
                    Vector3 lookVector = playerTransform.position - transform.position;
                    lookVector.y = 0;
                    targetRotation = Quaternion.LookRotation(lookVector);
                    targetRotation *= Quaternion.Euler(0, -90, 0);
                    lookAtCounter += 1;
                    turningTime = 0;
                    startRotation = transform.rotation;
                }
            }

            //previousRotation = transform.rotation;
            
        }
    }

    void SetCurrentAngle()
    {
        float angleBetween = Quaternion.Angle(startRotation, targetRotation);
        turningTime += Time.deltaTime * rotationBalance * (rotationSpeedLocal/angleBetween);
        transform.rotation = Quaternion.Slerp(startRotation, targetRotation, turningTime);
    }
}
