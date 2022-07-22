using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private GameObject projectileLocal;

    float reloadTime;
    float reloadRateLocal = 5f;

    float laserTime;
    float laserRate = 0.1f;

    int laserDistance = 50;
    public LineRenderer laserRenderer;
    int laserLimitLocal = 3;

    private bool displayLaser = false;

    public GameObject enemyTankParent;
    private bool insideWallBool = false;
    private float insideWallTimer = 0;

    private void Awake()
    {
        laserLimitLocal = enemyTankParent.GetComponent<EnemyTank>().laserBounceLimit;
        reloadRateLocal = enemyTankParent.GetComponent<EnemyTank>().reloadBounceRate;
        projectileLocal = enemyTankParent.GetComponent<EnemyTank>().bulletType;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckLaserRate();
    }

    //Shoots missile
    private void ShootMissile()
    {
        //Wait to reload
        if (Time.time > reloadTime)
        {
            //instantiate a missile and propel it
            GameObject currentInstantiated = Instantiate(projectileLocal, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0));
            //Reset reload time
            reloadTime = Time.time + reloadRateLocal;
        }
    }

    //Check whether you can fire a guidance laser
    private void CheckLaserRate()
    {
        if (laserTime < Time.time)
        {
            if (insideWallTimer < Time.time)
            {
                insideWallBool = false;
            }
            //if the laser returns a hit on the player
            if (insideWallBool == false && DrawLaser())
            {
                ShootMissile();
            }
            //Reset laser reload time
            laserTime = Time.time + laserRate;
        }
    }

    //Draws a bouncing laser 
    bool DrawLaser()
    {
        int laserReflected = 1; //How many times it got reflected
        int vertexCounter = 1; //How many line segments are there
        bool loopActive = true; //Is the reflecting loop active?

        Vector3 laserDirection = transform.right; //direction of the next laser
        Vector3 lastLaserPosition = transform.position; //origin of the next laser

        if (displayLaser)
        {
            laserRenderer.positionCount = 1;
            laserRenderer.SetPosition(0, transform.position);
        }
        

        while (loopActive)
        {
            //Spawn a raycast that detects what it hits
            RaycastHit[] hit = Physics.RaycastAll(lastLaserPosition, laserDirection, laserDistance);

            QuickSort(hit, 0, hit.Length - 1);
            if (hit.Length == 0) //if nothing hit then kill the laser
            {
                laserReflected++;
                vertexCounter++;

                //End laser line
                if (displayLaser)
                {
                    laserRenderer.positionCount = vertexCounter;
                    laserRenderer.SetPosition(vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
                }

                //end of laser
                loopActive = false;
            } else if (hit[0].transform.CompareTag("Player")) //if the laser hits the player, return true
            {
                return true;
            } else if (hit[0].transform.CompareTag("Enemy")) //if the laser hits an enemy, return false
            {
                if (enemyTankParent.GetComponent<EnemyTank>().targetTransform != null)
                {
                    if (enemyTankParent.GetComponent<EnemyTank>().targetTransform.tag == "Enemy")
                    {
                        return true;
                    }
                }
                
                return false;
            } else // if it hits something else then bounce
            {
                laserReflected++;
                vertexCounter += 3;
                
                //Render laser line
                if (displayLaser)
                {
                    laserRenderer.positionCount = vertexCounter;
                    laserRenderer.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit[0].point, lastLaserPosition, 0.01f));
                    laserRenderer.SetPosition(vertexCounter - 2, hit[0].point);
                    laserRenderer.SetPosition(vertexCounter - 1, hit[0].point);
                }
               
               //Uses the point of collision and direction to bounce the laser 
                lastLaserPosition = hit[0].point; 
                laserDirection = Vector3.Reflect(laserDirection, hit[0].normal);
            }
            //If the laser has had enough bounces then exit loop
            if (laserReflected > laserLimitLocal)
                loopActive = false;
        }
        //return false if player isnt hit
        return false;
    }

    void QuickSort(RaycastHit[] allHits, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(allHits, low, high);

            QuickSort(allHits, low, partitionIndex - 1);
            QuickSort(allHits, partitionIndex + 1, high);
        }
    }

    int Partition(RaycastHit[] partHits, int low, int high)
    {
        float pivot = partHits[high].distance;

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (partHits[j].distance <= pivot)
            {
                i++;
                RaycastHit swapHit = partHits[i];
                partHits[i] = partHits[j];
                partHits[j] = swapHit;
            }
        }
        RaycastHit swapAgain = partHits[i + 1];
        partHits[i + 1] = partHits[high];
        partHits[high] = swapAgain;

        return (i + 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "DestroyableWall" || other.transform.tag == "BouncyWall")
        {
            insideWallBool = true;
            insideWallTimer = Time.time + 0.1f;
        } 
    }
}
