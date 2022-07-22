using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    NavMeshAgent npcNavMeshAgent;

    float dodgeWaitTime = 0f;
    public float dodgeWaitTotal = 0.2f;
    Vector3 incomingBulletPosition;

    Vector3 currentTarget;
    Vector3 previousTarget;

    // Start is called before the first frame update
    private void Awake()
    {
        npcNavMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //Check if nav mesh is attached
        if (npcNavMeshAgent == null)
        {
            //Debug.LogError("The nav mehs agent is not attach to " + gameObject.name);
        }
        else
        {
            //Pre determine a destination to move to
            SetDestination();
        }
    }

    private void FixedUpdate()
    {
        if (npcNavMeshAgent.remainingDistance <= 1f)
        {
            SetDestination();
            CheckForIncomingBullets(4f);
        }

        checkDodgeWaitTime();
    }

    
    private void checkDodgeWaitTime()
    {
        if (dodgeWaitTime < Time.time)
        {
            CheckForIncomingBullets(3f);
            dodgeWaitTime = dodgeWaitTotal + Time.time;
        }
    }
    

    private void SetDestination()
    {
        if (currentTarget != null)
        {
            previousTarget = currentTarget;
        }
        currentTarget = GetRandomLocation();
        npcNavMeshAgent.SetDestination(currentTarget);
    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }

    //Checks if a bullet is incoming
    void CheckForIncomingBullets(float radius)
    {
        //check within a physics sphere
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].transform.CompareTag("Explosives"))
            {
                incomingBulletPosition = hitColliders[i].transform.position;
                currentTarget = 2 * (transform.position - incomingBulletPosition) + transform.position;
                npcNavMeshAgent.SetDestination(currentTarget);
            } else if (hitColliders[i].transform.CompareTag("Bullet"))
            {
                //Debug.Log("Checking");
                incomingBulletPosition = hitColliders[i].transform.position;
                currentTarget = 2 * (transform.position - incomingBulletPosition) + transform.position;
                npcNavMeshAgent.SetDestination(currentTarget);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            SetDestination();
        }
    }
}
