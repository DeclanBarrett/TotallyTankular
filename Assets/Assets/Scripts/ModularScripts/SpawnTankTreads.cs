using UnityEngine;

public class SpawnTankTreads : MonoBehaviour
{
    private float tankTreadTime;
    private float tankTreadRate = 0.4f;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnTankTracks();
    }
}
