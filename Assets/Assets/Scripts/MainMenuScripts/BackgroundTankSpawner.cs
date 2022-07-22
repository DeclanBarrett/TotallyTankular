using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTankSpawner : MonoBehaviour
{
    public List<GameObject> tanks;

    public List<GameObject> walls;

    public List<GameObject> tankPrefabs;

    public List<GameObject> wallPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomLevel();
    }

    void Update()
    {
        if (tanks.Count <= 1)
        {
            DestroyRandomLevel();
            SpawnRandomLevel();
        }
    }

    void SpawnRandomLevel()
    {
        for (int i = -7; i < 5; i++)
        {
            for (int j = -12; j < 12; j++)
            {
                int randomChoice = Random.Range(0, 200);
                if (randomChoice <= 5)
                {
                    tanks.Add(Instantiate(tankPrefabs[randomChoice], new Vector3(j, 0.5f, i), new Quaternion(0, 0, 0, 0)));
                }
                else if (randomChoice <= 25)
                {
                    randomChoice -= 6;
                    randomChoice %= 4;
                    Debug.Log(randomChoice);
                    walls.Add(Instantiate(wallPrefabs[randomChoice], new Vector3(j, 0.5f, i), new Quaternion(0, 0, 0, 0)));
                }
            }
        }
    }

    void DestroyRandomLevel()
    {
        for (int i = 0; i < tanks.Count; i++)
        {
            GameObject currentTank = tanks[i];
            tanks.Remove(currentTank);
            Destroy(currentTank.gameObject);
        }

        for (int i = 0; i < walls.Count; i++)
        {
            GameObject currentWalls = walls[i];
            tanks.Remove(currentWalls);
            Destroy(currentWalls.gameObject);
        }
    }

    void FakeMoney(int moneyFake)
    {

    }

    void RemoveTarget(GameObject deadParents)
    {
        tanks.Remove(deadParents);
    }

    private void OnEnable()
    {
        EnemyTank.EnemyPayment += FakeMoney;
        EnemyTank.EnemyDestroyed += RemoveTarget;
    }

    private void OnDisable()
    {
        EnemyTank.EnemyPayment -= FakeMoney;
        EnemyTank.EnemyDestroyed -= RemoveTarget;
    }


}
