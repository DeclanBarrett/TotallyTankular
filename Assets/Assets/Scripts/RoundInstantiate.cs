using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundInstantiate : MonoBehaviour
{
    public List<GameObject> tanks;

    public List<GameObject> walls;

    public List<GameObject> tankPrefabs;

    public List<GameObject> wallPrefabs;

    public GameObject[] upgradePrefabs;

    private List<Vector3[]> spawnPoints = new List<Vector3[]>
    {
        //Stores x and y location with z determining type (0 being a spawn point, 1 being a wall)
        new Vector3[] {new Vector3(-7f, 2f, 0f), //1
                        new Vector3(7f, -5f, 0f), //2
                        new Vector3(7f, 2f, 0f), //3
                        new Vector3(3f, 2f, 0f), //4
                        new Vector3(10f, 2f, 0f), //5
                        new Vector3(10f, -5f, 0f), //6
                        new Vector3(3f, -5f, 0f), //7
                        new Vector3(7f, -1f, 0f), //8

                        new Vector3(0f, 6f, 1f),
                        new Vector3(0f, 5f, 1f),
                        new Vector3(0f, 4f, 1f),
                        new Vector3(0f, 3f, 1f),
                        new Vector3(0f, 2f, 1f),
                        new Vector3(0f, 1f, 1f),
                        new Vector3(0f, 0f, 1f),
                        new Vector3(0f, -1f, 1f),
                        new Vector3(0f, -2f, 1f),
                        new Vector3(0f, -5f, 1f),
                        new Vector3(0f, -6f, 1f),
                        new Vector3(0f, -7f, 1f),
                        new Vector3(0f, -8f, 1f),
                        new Vector3(0f, -9f, 1f)}, //1

        new Vector3[] {new Vector3(-3f, 4f, 0f), //1
                        new Vector3(3f, 4f, 0f), //2
                        new Vector3(10f, 4f, 0f), //3
                        new Vector3(10f, -7f, 0f), //4
                        new Vector3(3f, -7f, 0f), //5
                        new Vector3(-2f, -7f, 0f), //6
                        new Vector3(0f, -2f, 0f), //7
                        new Vector3(8f, -2f, 0f),//8

                        new Vector3(7f, 1f, 1f),
                        new Vector3(6f, 1f, 1f),
                        new Vector3(5f, 1f, 1f),
                        new Vector3(4f, 1f, 1f),
                        new Vector3(3f, 1f, 1f),
                        new Vector3(2f, 1f, 1f),
                        new Vector3(1f, 1f, 1f),
                        new Vector3(-1f, 1f, 1f),
                        new Vector3(-2f, 1f, 1f),
                        new Vector3(-3f, 1f, 1f),
                        new Vector3(-4f, 1f, 1f),
                        new Vector3(-5f, 1f, 1f),
                        new Vector3(-6f, 1f, 1f),
                        new Vector3(-7f, 1f, 1f),

                        new Vector3(0f, -6f, 1f),
                        new Vector3(0f, -7f, 1f),
                        new Vector3(0f, -8f, 1f),
                        new Vector3(0f, -9f, 1f),

                        new Vector3(0f, 6f, 1f),
                        new Vector3(0f, 5f, 1f),
                        new Vector3(0f, 4f, 3f),
                        new Vector3(0f, 3f, 3f),
                        new Vector3(0f, 2f, 1f),
                        new Vector3(0f, 1f, 1f)}, //2

        new Vector3[] {new Vector3(-9f, -1f, 0f), //1
                        new Vector3(9f, -1f, 0f), //2
                        new Vector3(9f, 3f, 0f), //3
                        new Vector3(9f, -6f, 0f), //4
                        new Vector3(0f, -6f, 0f), //5
                        new Vector3(0f, 6f, 0f), //6
                        new Vector3(0f, -1f, 0f), //7
                        new Vector3(11f, -1f, 0f), //8

                        new Vector3(6f, 1f, 1f),
                        new Vector3(6f, 0f, 1f),
                        new Vector3(6f, -1f, 1f),
                        new Vector3(6f, -2f, 2f),
                        new Vector3(6f, -3f, 1f),
                        new Vector3(6f, -4f, 1f),

                        new Vector3(-6f, 1f, 1f),
                        new Vector3(-6f, 0f, 1f),
                        new Vector3(-6f, -1f, 1f),
                        new Vector3(-6f, -2f, 3f),
                        new Vector3(-6f, -3f, 3f),
                        new Vector3(-6f, -4f, 3f)}, //3

        new Vector3[] {new Vector3(-10f, 3f, 0f), //1
                        new Vector3(11f, -1f, 0f), //2
                        new Vector3(3f, 4f, 0f), //3
                        new Vector3(11f, -7f, 0f), //4
                        new Vector3(-10f, -5f, 0f), //5
                        new Vector3(-3f, -5f, 0f), //6
                        new Vector3(11f, 4f, 0f), //7
                        new Vector3(7f, 4f, 0f), //8

                        new Vector3(0f, 6f, 1f),
                        new Vector3(0f, 5f, 3f),
                        new Vector3(0f, 4f, 3f),
                        new Vector3(0f, 3f, 3f),
                        new Vector3(0f, 1f, 1f),

                        new Vector3(8f, 1f, 1f),
                        new Vector3(8f, 0f, 1f),
                        new Vector3(8f, -1f, 1f),
                        new Vector3(8f, -2f, 1f),
                        new Vector3(8f, -3f, 1f),
                        new Vector3(8f, -4f, 1f),

                        new Vector3(-12f, -1f, 1f),
                        new Vector3(-11f, -1f, 1f),
                        new Vector3(-10f, -1f, 1f),
                        new Vector3(-9f, -1f, 3f),
                        new Vector3(-8f, -1f, 3f),
                        new Vector3(-7f, -1f, 1f),
                        new Vector3(-6f, -1f, 1f)}, //4

        new Vector3[] {new Vector3(-10f, -1f, 0f), //1
                        new Vector3(10f, -1f, 0f), //2
                        new Vector3(10f, 3f, 0f), //3
                        new Vector3(10f, -6f, 0f), //4
                        new Vector3(10f, 1f, 0f), //5
                        new Vector3(10f, -4f, 0f), //6
                        new Vector3(0f, 4f, 0f), //7
                        new Vector3(0f, -7f, 0f), //8

                        new Vector3(-8f, 2f, 1f),
                        new Vector3(-7f, 2f, 1f),
                        new Vector3(-6f, 2f, 1f),
                        new Vector3(-5f, 2f, 2f),
                        new Vector3(-4f, 2f, 2f),
                        new Vector3(-3f, 2f, 1f),
                        new Vector3(-2f, 2f, 1f),
                        new Vector3(-1f, 2f, 1f),
                        new Vector3(0f, 2f, 1f),
                        new Vector3(1f, 2f, 1f),
                        new Vector3(2f, 2f, 1f),
                        new Vector3(3f, 2f, 3f),
                        new Vector3(4f, 2f, 3f),
                        new Vector3(5f, 2f, 1f),
                        new Vector3(6f, 2f, 1f),
                        new Vector3(7f, 2f, 3f),
                        new Vector3(8f, 2f, 1f),

                        new Vector3(-8f, -5f, 1f),
                        new Vector3(-7f, -5f, 1f),
                        new Vector3(-6f, -5f, 1f),
                        new Vector3(-5f, -5f, 1f),
                        new Vector3(-4f, -5f, 1f),
                        new Vector3(-3f, -5f, 1f),
                        new Vector3(-2f, -5f, 1f),
                        new Vector3(-1f, -5f, 1f),
                        new Vector3(0f, -5f, 1f),
                        new Vector3(1f, -5f, 1f),
                        new Vector3(2f, -5f, 1f),
                        new Vector3(3f, -5f, 4f),
                        new Vector3(4f, -5f, 4f),
                        new Vector3(5f, -5f, 4f),
                        new Vector3(6f, -5f, 4f),
                        new Vector3(7f, -5f, 4f),
                        new Vector3(8f, -5f, 1f),}, //5

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(11f, 4f, 0f), //2
                        new Vector3(11f, 0f, 0f), //3
                        new Vector3(11f, -4f, 0f), //4
                        new Vector3(9f, -7f, 0f), //5
                        new Vector3(6f, -4f, 0f), //6
                        new Vector3(6f, 0f, 0f), //7
                        new Vector3(6f, 4f, 0f), //8

                        new Vector3(-9f, 5f, 1f),
                        new Vector3(-9f, 4f, 1f),
                        new Vector3(-9f, 3f, 1f),
                        new Vector3(-9f, 2f, 1f),
                        new Vector3(-9f, 1f, 1f),
                        new Vector3(-9f, 0f, 1f),
                        new Vector3(-9f, -1f, 1f),
                        new Vector3(-9f, -2f, 4f),
                        new Vector3(-9f, -3f, 4f),
                        new Vector3(-9f, -4f, 4f),
                        new Vector3(-9f, -5f, 4f),

                        new Vector3(9f, 5f, 1f),
                        new Vector3(9f, 4f, 1f),
                        new Vector3(9f, 3f, 1f),
                        new Vector3(9f, 2f, 1f),
                        new Vector3(9f, 1f, 1f),
                        new Vector3(9f, 0f, 1f),
                        new Vector3(9f, -1f, 1f),
                        new Vector3(9f, -2f, 1f),
                        new Vector3(9f, -3f, 1f),
                        new Vector3(9f, -4f, 1f),
                        new Vector3(9f, -5f, 1f)}, //6

        new Vector3[] {new Vector3(-10f, -7f, 0f), //1
                        new Vector3(10f, -7f, 0f), //2
                        new Vector3(10f, -3f, 0f), //3
                        new Vector3(10f, 1f, 0f), //4
                        new Vector3(7f, 4f, 0f), //5
                        new Vector3(3f, 1f, 0f), //6
                        new Vector3(3f, -3f, 0f), //7
                        new Vector3(3f, -7f, 0f), //8

                        new Vector3(-7f, 1f, 1f),
                        new Vector3(-7f, 0f, 1f),
                        new Vector3(-7f, -1f, 1f),
                        new Vector3(-7f, -2f, 1f),
                        new Vector3(-7f, -3f, 1f),
                        new Vector3(-7f, -4f, 1f),
                        new Vector3(-7f, -5f, 1f),
                        new Vector3(-7f, -6f, 1f),
                        new Vector3(-7f, -7f, 1f),
                        new Vector3(-7f, -8f, 1f),

                        new Vector3(0f, 6f, 4f),
                        new Vector3(0f, 5f, 1f),
                        new Vector3(0f, 4f, 1f),
                        new Vector3(0f, 3f, 1f),
                        new Vector3(0f, 1f, 1f),
                        new Vector3(0f, 0f, 1f),
                        new Vector3(0f, -1f, 3f),
                        new Vector3(0f, -2f, 3f),
                        new Vector3(0f, -3f, 1f),
                        new Vector3(0f, -4f, 1f),

                        new Vector3(7f, 1f, 1f),
                        new Vector3(7f, 0f, 1f),
                        new Vector3(7f, -1f, 1f),
                        new Vector3(7f, -2f, 1f),
                        new Vector3(7f, -3f, 3f),
                        new Vector3(7f, -4f, 3f),
                        new Vector3(7f, -5f, 1f),
                        new Vector3(7f, -6f, 1f),
                        new Vector3(7f, -7f, 4f),
                        new Vector3(7f, -8f, 4f),
                        new Vector3(7f, -9f, 1f)}, //7

        new Vector3[] {new Vector3(-5f, -6f, 0f), //1
                        new Vector3(-10f, 4f, 0f), //2
                        new Vector3(10f, 4f, 0f), //3
                        new Vector3(-4f, 4f, 0f), //4
                        new Vector3(6f, 4f, 0f), //5
                        new Vector3(10f, -6f, 0f), //6
                        new Vector3(10f, -1f, 0f), //7
                        new Vector3(5f, -6f, 0f), //8

                        new Vector3(-12f, 1f, 1f),
                        new Vector3(-11f, 1f, 1f),
                        new Vector3(-10f, 1f, 1f),
                        new Vector3(-9f, 1f, 1f),
                        new Vector3(-8f, 1f, 1f),
                        new Vector3(-7f, 1f, 1f),
                        new Vector3(-6f, 1f, 1f),
                        new Vector3(-5f, 1f, 1f),
                        new Vector3(-4f, 1f, 1f),
                        new Vector3(-3f, 1f, 1f),
                        new Vector3(-2f, 1f, 1f),

                        new Vector3(5f, 1f, 1f),
                        new Vector3(6f, 1f, 1f),
                        new Vector3(7f, 1f, 1f),
                        new Vector3(8f, 1f, 1f),
                        new Vector3(9f, 1f, 1f),
                        new Vector3(10f, 1f, 1f),
                        new Vector3(11f, 1f, 1f),
                        new Vector3(12f, 1f, 1f),

                        new Vector3(-2f, -3f, 1f),
                        new Vector3(-2f, -4f, 1f),
                        new Vector3(-2f, -5f, 1f),
                        new Vector3(-2f, -6f, 1f),
                        new Vector3(-2f, -7f, 1f),
                        new Vector3(-2f, -8f, 1f),
                        new Vector3(-2f, -9f, 1f),

                        new Vector3(-8f, -3f, 1f),
                        new Vector3(-7f, -3f, 1f),

                        new Vector3(2f, -3f, 1f),
                        new Vector3(5f, -3f, 1f),
                        new Vector3(8f, -3f, 1f)}, //8

        new Vector3[] {new Vector3(-10f, 3f, 0f), //1
                        new Vector3(10f, -6f, 0f), //2
                        new Vector3(3f, -4f, 0f), //3
                        new Vector3(-3f, -4f, 0f), //4
                        new Vector3(10f, -3f, 0f), //5
                        new Vector3(3f, 2f, 0f), //6
                        new Vector3(7f, -6f, 0f), //7
                        new Vector3(7f, -3f, 0f), //8

                        new Vector3(0f, 2f, 1f),
                        new Vector3(0f, 1f, 1f),
                        new Vector3(0f, 0f, 1f),
                        new Vector3(0f, -1f, 1f),
                        new Vector3(0f, -2f, 1f),
                        new Vector3(0f, -3f, 1f),
                        new Vector3(0f, -4f, 1f),

                        new Vector3(-1f, -1f, 3f),
                        new Vector3(-2f, -1f, 3f),
                        new Vector3(-3f, -1f, 3f),
                        new Vector3(-4f, -1f, 3f),

                        new Vector3(4f, -1f, 3f),
                        new Vector3(3f, -1f, 3f),
                        new Vector3(2f, -1f, 3f),
                        new Vector3(1f, -1f, 3f)}, //9

        new Vector3[] {new Vector3(-6f, 3f, 0f), //1
                        new Vector3(10f, -7f, 0f), //2
                        new Vector3(10f, -2f, 0f), //3
                        new Vector3(10f, 3f, 0f), //4
                        new Vector3(5f, 3f, 0f), //5
                        new Vector3(-10f, -6f, 0f), //6
                        new Vector3(-6f, -6f, 0f), //7
                        new Vector3(-2f, -6f, 0f), //8

                        new Vector3(7f, -4f, 3f),
                        new Vector3(7f, -5f, 3f),
                        new Vector3(7f, -6f, 3f),
                        new Vector3(7f, -7f, 3f),
                        new Vector3(7f, -8f, 4f),
                        new Vector3(7f, -9f, 4f),

                        new Vector3(1f, 6f, 1f),
                        new Vector3(1f, 5f, 1f),
                        new Vector3(1f, 4f, 1f),
                        new Vector3(1f, 3f, 1f),
                        new Vector3(1f, 2f, 1f),
                        new Vector3(1f, 1f, 1f),
                        new Vector3(1f, 0f, 1f)}, //10

        new Vector3[] {new Vector3(-11f, 1f, 0f), //1
                        new Vector3(11f, -6f, 0f), //2
                        new Vector3(11f, -3f, 0f), //3
                        new Vector3(11f, 0f, 0f), //4
                        new Vector3(11f, 3f, 0f), //5
                        new Vector3(6f, -6f, 0f), //6
                        new Vector3(6f, -3f, 0f), //7
                        new Vector3(6f, 0f, 0f), //8

                        new Vector3(-9f, 2f, 1f),
                        new Vector3(-9f, 1f, 1f),
                        new Vector3(-9f, 0f, 1f),
                        new Vector3(-9f, -1f, 1f),

                        new Vector3(9f, -2f, 3f),
                        new Vector3(9f, -3f, 3f),
                        new Vector3(9f, -4f, 3f),
                        new Vector3(9f, -5f, 3f)}, //11

        new Vector3[] {new Vector3(-10f, -6f, 0f), //1
                        new Vector3(3f, -1f, 0f), //2
                        new Vector3(-10f, -1f, 0f), //3
                        new Vector3(-10f, 3f, 0f), //4
                        new Vector3(3f, 3f, 0f), //5
                        new Vector3(-4f, -1f, 0f), //6
                        new Vector3(-4f, 3f, 0f), //7
                        new Vector3(-4f, 1f, 0f), //8

                        new Vector3(6f, -3f, 1f),
                        new Vector3(6f, -2f, 1f),
                        new Vector3(6f, -1f, 1f),
                        new Vector3(6f, 0f, 1f),

                        new Vector3(-12f, -4f, 4f),
                        new Vector3(-11f, -4f, 1f),
                        new Vector3(-10f, -4f, 4f),
                        new Vector3(-9f, -4f, 1f),
                        new Vector3(-8f, -4f, 4f),
                        new Vector3(-7f, -4f, 1f),
                        new Vector3(-6f, -4f, 4f),
                        new Vector3(-5f, -4f, 1f),
                        new Vector3(-4f, -4f, 4f),
                        new Vector3(-3f, -4f, 1f),
                        new Vector3(-2f, -4f, 4f),
                        new Vector3(-1f, -4f, 1f),
                        new Vector3(0f, -4f, 4f),
                        new Vector3(1f, -4f, 1f),
                        new Vector3(2f, -4f, 4f),
                        new Vector3(3f, -4f, 1f),
                        new Vector3(4f, -4f, 4f),
                        new Vector3(5f, -4f, 1f),
                        new Vector3(6f, -4f, 4f)}, //12

        new Vector3[] {new Vector3(-11f, -6f, 0f), //1
                        new Vector3(-11f, -1f, 0f), //2
                        new Vector3(-11f, 4f, 0f), //3
                        new Vector3(-3f, 4f, 0f), //4
                        new Vector3(-3f, -1f, 0f), //5
                        new Vector3(3f, 4f, 0f), //6
                        new Vector3(3f, -1f, 0f), //7
                        new Vector3(11f, 0f, 0f), //8

                        new Vector3(8f, 3f, 1f),
                        new Vector3(8f, 2f, 1f),
                        new Vector3(8f, 1f, 1f),
                        new Vector3(8f, 0f, 1f),
                        new Vector3(8f, -1f, 1f),
                        new Vector3(8f, -2f, 1f),
                        new Vector3(8f, -3f, 1f),
                        new Vector3(8f, -4f, 1f),

                        new Vector3(0f, 6f, 1f),
                        new Vector3(0f, 5f, 1f),
                        new Vector3(0f, 4f, 1f),
                        new Vector3(0f, 3f, 1f),
                        new Vector3(0f, 2f, 1f),
                        new Vector3(0f, 1f, 1f),

                        new Vector3(-12f, -4f, 1f),
                        new Vector3(-11f, -4f, 1f),
                        new Vector3(-10f, -4f, 1f),
                        new Vector3(-9f, -4f, 1f),
                        new Vector3(-8f, -4f, 1f),
                        new Vector3(-7f, -4f, 2f),
                        new Vector3(-6f, -4f, 2f),
                        new Vector3(-5f, -4f, 2f),
                        new Vector3(-4f, -4f, 2f),
                        new Vector3(-3f, -4f, 2f),
                        new Vector3(-2f, -4f, 2f),
                        new Vector3(-1f, -4f, 1f),
                        new Vector3(0f, -4f, 1f),
                        new Vector3(1f, -4f, 1f),
                        new Vector3(2f, -4f, 1f),
                        new Vector3(3f, -4f, 1f),
                        new Vector3(4f, -4f, 1f)}, //13

        new Vector3[] {new Vector3(0f, -1f, 0f), //1
                        new Vector3(0f, -7f, 0f), //2
                        new Vector3(-8f, -7f, 0f), //3
                        new Vector3(8f, -7f, 0f), //4
                        new Vector3(11f, 2f, 0f), //5
                        new Vector3(-11f, 2f, 0f), //6
                        new Vector3(-11f, -3f, 0f), //7
                        new Vector3(11f, -3f, 0f), //8

                        new Vector3(-8f, 2f, 1f),
                        new Vector3(-7f, 2f, 1f),
                        new Vector3(-6f, 2f, 1f),
                        new Vector3(-5f, 2f, 1f),
                        new Vector3(-4f, 2f, 1f),
                        new Vector3(-3f, 2f, 1f),
                        new Vector3(-2f, 2f, 1f),

                        new Vector3(2f, 2f, 1f),
                        new Vector3(3f, 2f, 1f),
                        new Vector3(4f, 2f, 1f),
                        new Vector3(5f, 2f, 1f),
                        new Vector3(6f, 2f, 1f),
                        new Vector3(7f, 2f, 1f),
                        new Vector3(8f, 2f, 1f),

                        new Vector3(8f, 1f, 2f),
                        new Vector3(8f, 0f, 1f),
                        new Vector3(8f, -1f, 1f),
                        new Vector3(8f, -2f, 1f),
                        new Vector3(8f, -3f, 1f),
                        new Vector3(8f, -4f, 1f),

                        new Vector3(-8f, 1f, 1f),
                        new Vector3(-8f, 0f, 3f),
                        new Vector3(-8f, -1f, 3f),
                        new Vector3(-8f, -2f, 3f),
                        new Vector3(-8f, -3f, 3f),
                        new Vector3(-8f, -4f, 1f),

                        new Vector3(-8f, -5f, 1f),
                        new Vector3(-7f, -5f, 1f),
                        new Vector3(-6f, -5f, 1f),
                        new Vector3(-5f, -5f, 1f),
                        new Vector3(-4f, -5f, 1f),
                        new Vector3(-3f, -5f, 1f),
                        new Vector3(-2f, -5f, 1f),
                        new Vector3(-1f, -5f, 1f),
                        new Vector3(0f, -5f, 1f),
                        new Vector3(1f, -5f, 1f),
                        new Vector3(2f, -5f, 1f),
                        new Vector3(2f, -5f, 1f),
                        new Vector3(3f, -5f, 1f),
                        new Vector3(4f, -5f, 1f),
                        new Vector3(5f, -5f, 1f),
                        new Vector3(6f, -5f, 1f),
                        new Vector3(7f, -5f, 1f),
                        new Vector3(8f, -5f, 1f)}, //14

        new Vector3[] {new Vector3(0f, -7f, 0f), //1
                        new Vector3(0f, 4f, 0f), //2
                        new Vector3(11f, -7f, 0f), //3
                        new Vector3(-11f, -7f, 0f), //4
                        new Vector3(11f, 4f, 0f), //5
                        new Vector3(-11f, -1f, 0f), //6
                        new Vector3(11f, -1f, 0f), //7
                        new Vector3(-11f, 4f, 0f), //8

                        new Vector3(-2f, -6f, 1f),
                        new Vector3(-2f, -7f, 1f),
                        new Vector3(-2f, -8f, 1f),
                        new Vector3(-2f, -9f, 1f),

                        new Vector3(2f, -6f, 1f),
                        new Vector3(2f, -7f, 1f),
                        new Vector3(2f, -8f, 1f),
                        new Vector3(2f, -9f, 1f),

                        new Vector3(-4f, -4f, 1f),
                        new Vector3(-7f, -1f, 1f),
                        new Vector3(4f, -4f, 1f),
                        new Vector3(7f, -1f, 1f)}, //15

        new Vector3[] {new Vector3(-10f, -1f, 0f), //1
                        new Vector3(10f, -1f, 0f), //2
                        new Vector3(0f, 4f, 0f), //3
                        new Vector3(0f, -7f, 0f), //4
                        new Vector3(4f, -1f, 0f), //5
                        new Vector3(10f, 4f, 0f), //6
                        new Vector3(10f, -7f, 0f), //7
                        new Vector3(7f, -1f, 0f), //8

                        new Vector3(-8f, 2f, 1f),
                        new Vector3(-7f, 2f, 1f),
                        new Vector3(-6f, 2f, 1f),
                        new Vector3(-5f, 2f, 1f),
                        new Vector3(-4f, 2f, 1f),
                        new Vector3(-3f, 2f, 1f),
                        new Vector3(-2f, 2f, 1f),
                        new Vector3(-1f, 2f, 1f),
                        new Vector3(0f, 2f, 1f),
                        new Vector3(1f, 2f, 1f),
                        new Vector3(2f, 2f, 1f),
                        new Vector3(3f, 2f, 1f),
                        new Vector3(4f, 2f, 1f),
                        new Vector3(5f, 2f, 1f),
                        new Vector3(6f, 2f, 1f),
                        new Vector3(7f, 2f, 1f),
                        new Vector3(8f, 2f, 1f),

                        new Vector3(-8f, -5f, 1f),
                        new Vector3(-7f, -5f, 1f),
                        new Vector3(-6f, -5f, 1f),
                        new Vector3(-5f, -5f, 1f),
                        new Vector3(-4f, -5f, 1f),
                        new Vector3(-3f, -5f, 1f),
                        new Vector3(-2f, -5f, 1f),
                        new Vector3(-1f, -5f, 1f),
                        new Vector3(0f, -5f, 1f),
                        new Vector3(1f, -5f, 1f),
                        new Vector3(2f, -5f, 1f),
                        new Vector3(3f, -5f, 1f),
                        new Vector3(4f, -5f, 1f),
                        new Vector3(5f, -5f, 1f),
                        new Vector3(6f, -5f, 1f),
                        new Vector3(7f, -5f, 1f),
                        new Vector3(8f, -5f, 1f),

                        new Vector3(0f, -3f, 1f),
                        new Vector3(0f, 0f, 1f)}, //16

        new Vector3[] {new Vector3(-7f, -7f, 0f), //1
                        new Vector3(7f, -7f, 0f), //2
                        new Vector3(7f, -5f, 0f), //3
                        new Vector3(7f, -3f, 0f), //4
                        new Vector3(7f, -1f, 0f), //5
                        new Vector3(7f, 1f, 0f), //6
                        new Vector3(7f, 3f, 0f), //7
                        new Vector3(-7f, 3f, 0f), //8

                        new Vector3(0f, 3f, 1f),
                        new Vector3(0f, 1f, 1f),
                        new Vector3(0f, -1f, 1f),
                        new Vector3(0f, -3f, 1f),
                        new Vector3(0f, -5f, 1f),
                        new Vector3(0f, -7f, 1f)}, //17

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(11f, 4f, 0f), //2
                        new Vector3(6f, 4f, 0f), //3
                        new Vector3(0f, 4f, 0f), //4
                        new Vector3(11f, 0f, 0f), //5
                        new Vector3(6f, 0f, 0f), //6
                        new Vector3(0f, 0f, 0f), //7
                        new Vector3(11f, -4f, 0f), //8

                        new Vector3(-9f, 4f, 1f),
                        new Vector3(-9f, 2f, 1f),
                        new Vector3(-9f, 0f, 1f),
                        new Vector3(-9f, -2f, 1f),
                        new Vector3(-9f, -4f, 1f),
                        new Vector3(-9f, -6f, 1f),

                        new Vector3(-3f, 4f, 1f),
                        new Vector3(-3f, 2f, 1f),
                        new Vector3(-3f, 0f, 1f),
                        new Vector3(-3f, -2f, 1f),
                        new Vector3(-3f, -4f, 1f),
                        new Vector3(-3f, -6f, 1f),

                        new Vector3(3f, 4f, 1f),
                        new Vector3(3f, 2f, 1f),
                        new Vector3(3f, 0f, 1f),
                        new Vector3(3f, -2f, 1f),
                        new Vector3(3f, -4f, 1f),
                        new Vector3(3f, -6f, 1f),

                        new Vector3(9f, 4f, 1f),
                        new Vector3(9f, 2f, 1f),
                        new Vector3(9f, 0f, 1f),
                        new Vector3(9f, -2f, 1f),
                        new Vector3(9f, -4f, 1f),
                        new Vector3(9f, -6f, 1f)}, //18

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(11f, -7f, 0f), //2
                        new Vector3(5f, -7f, 0f), //3
                        new Vector3(11f, 4f, 0f), //4
                        new Vector3(5f, 4f, 0f), //5
                        new Vector3(0f, 4f, 0f), //6
                        new Vector3(-5f, 0f, 0f), //7
                        new Vector3(5f, -2f, 0f), //8

                        new Vector3(-9f, 5f, 1f),
                        new Vector3(-8f, 4f, 1f),
                        new Vector3(-8f, 3f, 1f),
                        new Vector3(-8f, 2f, 1f),
                        new Vector3(-8f, 1f, 1f),
                        new Vector3(-7f, 0f, 1f),

                        new Vector3(9f, -8f, 1f),
                        new Vector3(8f, -7f, 1f),
                        new Vector3(8f, -6f, 1f),
                        new Vector3(8f, -5f, 1f),
                        new Vector3(8f, -4f, 1f),
                        new Vector3(7f, -4f, 1f),

                        new Vector3(0f, 0f, 1f)}, //19

        new Vector3[] {new Vector3(-8f, -1f, 0f), //1
                        new Vector3(9f, -1f, 0f), //2
                        new Vector3(9f, 3f, 0f), //3
                        new Vector3(9f, -6f, 0f), //4
                        new Vector3(5f, -1f, 0f), //5
                        new Vector3(5f, 3f, 0f), //6
                        new Vector3(5f, -6f, 0f), //7
                        new Vector3(2f, -1f, 0f), //8

                        new Vector3(0f, 1f, 1f),
                        new Vector3(0f, 0f, 1f),
                        new Vector3(0f, -1f, 1f),
                        new Vector3(0f, -2f, 1f),
                        new Vector3(0f, -3f, 1f),
                        new Vector3(0f, -4f, 1f)}, //20

        new Vector3[] {new Vector3(0f, 0f, 0f), //1
                        new Vector3(-11f, 4f, 0f), //2
                        new Vector3(11f, -7f, 0f), //3
                        new Vector3(11f, 4f, 0f), //4
                        new Vector3(-11f, -7f, 0f), //5
                        new Vector3(-11f, -1f, 0f), //6
                        new Vector3(11f, -1f, 0f), //7
                        new Vector3(0f, 4f, 0f), //8

                        new Vector3(7f, 2f, 1f),
                        new Vector3(8f, 1f, 1f),
                        new Vector3(9f, 0f, 1f),

                        new Vector3(-9f, 0f, 1f),
                        new Vector3(-8f, 1f, 1f),
                        new Vector3(-7f, 2f, 1f),

                        new Vector3(7f, -3f, 1f),
                        new Vector3(8f, -4f, 1f),
                        new Vector3(9f, -5f, 1f),

                        new Vector3(-9f, -3f, 1f),
                        new Vector3(-8f, -4f, 1f),
                        new Vector3(-7f, -5f, 1f),

                        new Vector3(6f, -6f, 1f),
                        new Vector3(5f, -6f, 1f),
                        new Vector3(4f, -6f, 1f),
                        new Vector3(3f, -6f, 1f),
                        new Vector3(2f, -6f, 1f),

                        new Vector3(-6f, -6f, 1f),
                        new Vector3(-5f, -6f, 1f),
                        new Vector3(-4f, -6f, 1f),
                        new Vector3(-3f, -6f, 1f),
                        new Vector3(-2f, -6f, 1f),

                        new Vector3(6f, 3f, 1f),
                        new Vector3(5f, 3f, 1f),
                        new Vector3(4f, 3f, 1f),
                        new Vector3(3f, 3f, 1f),
                        new Vector3(2f, 3f, 1f),

                        new Vector3(-6f, 3f, 1f),
                        new Vector3(-5f, 3f, 1f),
                        new Vector3(-4f, 3f, 1f),
                        new Vector3(-3f, 3f, 1f),
                        new Vector3(-2f, 3f, 1f)}, //21

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(11f, -7f, 0f), //2
                        new Vector3(-11f, -7f, 0f), //3
                        new Vector3(11f, 4f, 0f), //4
                        new Vector3(9f, -1f, 0f), //5
                        new Vector3(5f, -7f, 0f), //6
                        new Vector3(5f, 4f, 0f), //7
                        new Vector3(5f, -1f, 0f), //8

                        new Vector3(-9f, 5f, 1f),
                        new Vector3(-9f, 4f, 1f),
                        new Vector3(-9f, 3f, 1f),
                        new Vector3(-9f, 2f, 1f),
                        new Vector3(-9f, 1f, 1f),

                        new Vector3(9f, -8f, 1f),
                        new Vector3(9f, -7f, 1f),
                        new Vector3(9f, -6f, 1f),
                        new Vector3(9f, -5f, 1f),
                        new Vector3(9f, -4f, 1f),

                        new Vector3(8f, 2f, 1f),
                        new Vector3(9f, 2f, 1f),
                        new Vector3(10f, 2f, 1f),
                        new Vector3(11f, 2f, 1f),
                        new Vector3(12f, 2f, 1f),

                        new Vector3(-8f, -5f, 1f),
                        new Vector3(-9f, -5f, 1f),
                        new Vector3(-10f, -5f, 1f),
                        new Vector3(-11f, -5f, 1f),
                        new Vector3(-12f, -5f, 1f),}, //22

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(11f, -7f, 0f), //2
                        new Vector3(2f, 0f, 0f), //3
                        new Vector3(2f, -4f, 0f), //4
                        new Vector3(-2f, -3f, 0f), //5
                        new Vector3(-2f, -7f, 0f), //6
                        new Vector3(11f, 0f, 0f), //7
                        new Vector3(7f, -6f, 0f), //8

                        new Vector3(0f, 2f, 1f),
                        new Vector3(1f, 2f, 1f),
                        new Vector3(2f, 2f, 1f),
                        new Vector3(3f, 2f, 1f),
                        new Vector3(4f, 2f, 1f),
                        new Vector3(5f, 2f, 1f),

                        new Vector3(0f, -2f, 1f),
                        new Vector3(1f, -2f, 1f),
                        new Vector3(2f, -2f, 1f),
                        new Vector3(3f, -2f, 1f),
                        new Vector3(4f, -2f, 1f),
                        new Vector3(5f, -2f, 1f),

                        new Vector3(0f, -1f, 1f),
                        new Vector3(-1f, -1f, 1f),
                        new Vector3(-2f, -1f, 1f),
                        new Vector3(-3f, -1f, 1f),
                        new Vector3(-4f, -1f, 1f),
                        new Vector3(-5f, -1f, 1f),

                        new Vector3(0f, -5f, 1f),
                        new Vector3(-1f, -5f, 1f),
                        new Vector3(-2f, -5f, 1f),
                        new Vector3(-3f, -5f, 1f),
                        new Vector3(-4f, -5f, 1f),
                        new Vector3(-5f, -5f, 1f),

                        new Vector3(0f, -4f, 1f),
                        new Vector3(0f, -3f, 1f),

                        new Vector3(0f, 0f, 1f),
                        new Vector3(0f, 1f, 1f)}, //23

        new Vector3[] {new Vector3(-11f, -7f, 0f), //1
                        new Vector3(6f, 0f, 0f), //2
                        new Vector3(-5f, 0f, 0f), //3
                        new Vector3(10f, 4f, 0f), //4
                        new Vector3(-11f, 4f, 0f), //5
                        new Vector3(-11f, -4f, 0f), //6
                        new Vector3(-5f, -4f, 0f), //7
                        new Vector3(-5f, 4f, 0f), //8

                        new Vector3(-12f, -6f, 1f),
                        new Vector3(-11f, -6f, 1f),
                        new Vector3(-10f, -6f, 1f),
                        new Vector3(-9f, -6f, 1f),
                        new Vector3(-8f, -6f, 1f),
                        new Vector3(-7f, -6f, 1f),
                        new Vector3(-6f, -6f, 1f),
                        new Vector3(-5f, -6f, 1f),
                        new Vector3(-4f, -6f, 1f),
                        new Vector3(-3f, -6f, 1f),
                        new Vector3(-2f, -6f, 1f),
                        new Vector3(-1f, -6f, 1f),
                        new Vector3(0f, -6f, 1f),

                        new Vector3(9f, -6f, 1f),
                        new Vector3(8f, -6f, 1f),
                        new Vector3(7f, -6f, 1f),
                        new Vector3(6f, -6f, 1f),
                        new Vector3(5f, -6f, 1f),
                        new Vector3(4f, -6f, 1f),
                        new Vector3(3f, -6f, 1f),
                        new Vector3(2f, -6f, 1f),
                        new Vector3(1f, -6f, 1f),

                        new Vector3(-8f, -2f, 1f),
                        new Vector3(-7f, -2f, 1f),
                        new Vector3(-6f, -2f, 1f),
                        new Vector3(-5f, -2f, 1f),
                        new Vector3(-4f, -2f, 1f),
                        new Vector3(-3f, -2f, 1f),
                        new Vector3(-2f, -2f, 1f),

                        new Vector3(-8f, -1f, 1f),
                        new Vector3(-8f, 0f, 1f),
                        new Vector3(-8f, 1f, 1f),
                        new Vector3(-8f, 2f, 1f),

                        new Vector3(-7f, 2f, 1f),
                        new Vector3(-6f, 2f, 1f),
                        new Vector3(-5f, 2f, 1f),
                        new Vector3(-3f, 2f, 1f),
                        new Vector3(-1f, 2f, 1f),
                        new Vector3(1f, 2f, 1f),
                        new Vector3(3f, 2f, 1f),
                        new Vector3(5f, 2f, 1f),
                        new Vector3(7f, 2f, 1f),
                        new Vector3(8f, 2f, 1f),
                        new Vector3(9f, 2f, 1f),
                        new Vector3(10f, 2f, 1f),
                        new Vector3(11f, 2f, 1f),
                        new Vector3(12f, 2f, 1f),

                        new Vector3(9f, -5f, 1f),
                        new Vector3(9f, -4f, 1f),
                        new Vector3(9f, -3f, 1f),
                        new Vector3(9f, -2f, 1f),
                        new Vector3(9f, -1f, 1f),

                        new Vector3(6f, -1f, 1f),
                        new Vector3(7f, -1f, 1f),
                        new Vector3(8f, -1f, 1f),

                        new Vector3(0f, 0f, 1f)}, //24

        new Vector3[] {new Vector3(-9f, -1f, 0f), //1
                        new Vector3(9f, -1f, 0f), //2
                        new Vector3(9f, 3f, 0f), //3
                        new Vector3(9f, -6f, 0f), //4
                        new Vector3(5f, -6f, 0f), //5
                        new Vector3(5f, 3f, 0f), //6
                        new Vector3(1f, 3f, 0f), //7
                        new Vector3(1f, -6f, 0f)}, //25

        new Vector3[] {new Vector3(-11f, 4f, 0f), //1
                        new Vector3(-4f, 0f, 0f), //2
                        new Vector3(11f, -7f, 0f), //3
                        new Vector3(0f, 0f, 0f), //4
                        new Vector3(4f, 0f, 0f), //5
                        new Vector3(-8f, -4f, 0f), //6
                        new Vector3(-8f, 4f, 0f), //7
                        new Vector3(11f, 4f, 0f), //8

                        new Vector3(-10f, 5f, 1f),
                        new Vector3(-10f, 4f, 1f),
                        new Vector3(-10f, 3f, 1f),
                        new Vector3(-10f, 2f, 1f),
                        new Vector3(-10f, 1f, 1f),
                        new Vector3(-10f, 0f, 1f),
                        new Vector3(-10f, -1f, 1f),
                        new Vector3(-10f, -2f, 1f),
                        new Vector3(-10f, -3f, 1f),
                        new Vector3(-10f, -4f, 1f),
                        new Vector3(-10f, -5f, 1f),
                        new Vector3(-10f, -6f, 1f),

                        new Vector3(-9f, -6f, 1f),
                        new Vector3(-8f, -6f, 1f),
                        new Vector3(-7f, -6f, 1f),
                        new Vector3(-6f, -6f, 1f),
                        new Vector3(-5f, -6f, 1f),
                        new Vector3(-4f, -6f, 1f),
                        new Vector3(-3f, -6f, 1f),
                        new Vector3(-2f, -6f, 1f),
                        new Vector3(-1f, -6f, 1f),
                        new Vector3(0f, -6f, 1f),

                        new Vector3(10f, -6f, 1f),
                        new Vector3(9f, -6f, 1f),
                        new Vector3(8f, -6f, 1f),
                        new Vector3(7f, -6f, 1f),
                        new Vector3(6f, -6f, 1f),
                        new Vector3(5f, -6f, 1f),
                        new Vector3(4f, -6f, 1f),
                        new Vector3(3f, -6f, 1f),
                        new Vector3(2f, -6f, 1f),
                        new Vector3(1f, -6f, 1f),

                        new Vector3(10f, -6f, 1f),
                        new Vector3(10f, -5f, 1f),
                        new Vector3(10f, -4f, 1f),
                        new Vector3(10f, -3f, 1f),
                        new Vector3(10f, -2f, 1f),
                        new Vector3(10f, -1f, 1f),
                        new Vector3(10f, 0f, 1f),
                        new Vector3(10f, 1f, 1f),
                        new Vector3(10f, 2f, 1f),
                        new Vector3(10f, 3f, 1f),

                        new Vector3(9f, 3f, 1f),
                        new Vector3(8f, 3f, 1f),
                        new Vector3(7f, 3f, 1f),
                        new Vector3(6f, 3f, 1f),
                        new Vector3(5f, 3f, 1f),
                        new Vector3(4f, 3f, 1f),
                        new Vector3(3f, 3f, 1f),
                        new Vector3(2f, 3f, 1f),
                        new Vector3(1f, 3f, 1f),
                        new Vector3(0f, 3f, 1f),
                        new Vector3(-1f, 3f, 1f),
                        new Vector3(-2f, 3f, 1f),
                        new Vector3(-3f, 3f, 1f),
                        new Vector3(-4f, 3f, 1f),
                        new Vector3(-5f, 3f, 1f),
                        new Vector3(-6f, 3f, 1f),
                        new Vector3(-7f, 3f, 1f),

                        new Vector3(-7f, 2f, 1f),
                        new Vector3(-7f, 1f, 1f),
                        new Vector3(-7f, 0f, 1f),
                        new Vector3(-7f, -1f, 1f),
                        new Vector3(-7f, -2f, 1f),
                        new Vector3(-7f, -3f, 1f),

                        new Vector3(-6f, -3f, 1f),
                        new Vector3(-5f, -3f, 1f),
                        new Vector3(-4f, -3f, 1f),
                        new Vector3(-3f, -3f, 1f),
                        new Vector3(-2f, -3f, 1f),
                        new Vector3(-1f, -3f, 1f),
                        new Vector3(0f, -3f, 1f),
                        new Vector3(1f, -3f, 1f),
                        new Vector3(2f, -3f, 1f),
                        new Vector3(3f, -3f, 1f),
                        new Vector3(4f, -3f, 1f),
                        new Vector3(5f, -3f, 1f),
                        new Vector3(6f, -3f, 1f),
                        new Vector3(7f, -3f, 1f),

                        new Vector3(7f, -2f, 1f),
                        new Vector3(7f, -1f, 1f),
                        new Vector3(7f, 0f, 1f)}, //26
    };

    //Lists what type of tank to spawn in each spawn point (no entry means do not spawn)
    static public List<List<int>> spawnPointCommands = new List<List<int>> {
        new List<int> { 0, 1 }, //1
        new List<int> { 0, 2 }, //2
        new List<int> { 0, 2, 1, 1 }, //3
        new List<int> { 0, 2, 1, 1, 1}, //4
        new List<int> { 0, 3, 2, 2}, //5
        new List<int> { 0, 1, 1, 2, 2}, //6
        new List<int> { 0, 2, 2, 2, 2}, //7
        new List<int> { 0, 3, 2, 2}, //8
        new List<int> { 0, 3, 3, 2, 2 }, //9
        new List<int> { 0, 4, 4 }, //10
        new List<int> { 0, 4, 3, 2, 1 }, //11
        new List<int> { 0, 4, 4, 1, 2}, //12
        new List<int> { 0, 4, 4, 2, 3,}, //13
        new List<int> { 0, 4, 4, 2, 2}, //14
        new List<int> { 0, 5, 1, 1, 1, 1}, //15
        new List<int> { 0, 3, 3, 2, 2, 1}, //16
        new List<int> { 0, 4, 3, 2, 2, 2}, //17
        new List<int> { 0, 5, 5}, //18
        new List<int> { 0, 5, 5, 4, 4}, //19
        new List<int> { 0, 6}, //20
        new List<int> { 0, 6, 6, 2, 2}, //21
        new List<int> { 0, 6, 6, 4, 4}, //22
        new List<int> { 0, 4, 4, 4, 4, 4, 4}, //23
        new List<int> { 0, 5, 5, 4, 4, 3, 3, 2}, //24
        new List<int> { 0, 7, 7, 7}, //25
        new List<int> { 0, 8, 7, 6, 5, 4, 4, 2}, //26
    };

    //Variables dictating what state the game is in
    public bool roundWaiting = false;
    public bool roundPlaying = false;
    public bool roundEnding = false;
    private bool doneUpgrading = false;

    //Event telling other objects that the game has started
    public delegate void RoundUpdated();
    public static event RoundUpdated OnRoundFinished;
    public static event RoundUpdated OnRoundChange;
    public static event RoundUpdated OnRoundStarted;
    public static event RoundUpdated OnRoundInstantiated;

    //Used to wait 2 seconds after enemy dies
    private float afterEnemyTime;
    private float afterEnemyRate = 2f;

    //Used for increasing the multiplier after a tank dies
    private float multiTime;
    private float multiCap = 3f;

    //Win Audio Effect
    public GameObject winAudio;

    //UI Variables
    private GameObject roundCounterPanel;
    private GameObject pausePanel;
    private GameObject doneUpgradingButton;
    private GameObject deathScreen;
    private GameObject controlsImage;
    private Text roundCounter;
    //public AudioListener cameraAudioListener;

    private void Awake()
    {
        //Establishing the start of the game variables numbers
        GameManager.score = 0;
        GameManager.health = 75; 
        GameManager.healthCap = 75; //75

        GameManager.armour = 50;
        GameManager.armourCap = 500;

        GameManager.bulletsLeft = 2;
        GameManager.bulletsCap = 2; //2
        GameManager.bulletType = 0; //0
        GameManager.minesEnabled = true;

        GameManager.reloadCap = 2.5f; //2.5
        GameManager.reloadTime = 0f;

        GameManager.coins = 0; //0
        GameManager.coinsAdded = 0;

        GameManager.multiplier = 1;

        GameManager.roundNumber = 0; //0

        GameManager.speed = 90f;

        GameManager.healthCoins = 100;
        GameManager.armourCoins = 100;
        GameManager.bulletCoins = 100;
        GameManager.reloadCoins = 100;
        GameManager.speedCoins = 100;
        GameManager.mineCoins = 100;
        GameManager.bulletTypeCoins = 500;
        //cameraAudioListener.volume 

        GameManager.mouseSensitivity = 1;

        //Finding the UI variables
        roundCounterPanel = GameObject.Find("RoundCounterPanel");
        pausePanel = GameObject.Find("PausePanel");
        doneUpgradingButton = GameObject.Find("DoneUpgradingButton");
        deathScreen = GameObject.Find("DeathScreen");
        controlsImage = GameObject.Find("ControlsImage");
        roundCounter = GameObject.Find("RoundCountDown").GetComponent<Text>();
    }
    void Start()
    {
        //Making the UI invisible
        pausePanel.transform.localScale = new Vector3(0f, 0f, 0f);
        doneUpgradingButton.transform.localScale = new Vector3(0f, 0f, 0f);
        deathScreen.transform.localScale = new Vector3(0f, 0f, 0f);
        //Call the start of round set up that waits
        roundCounterPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        Time.timeScale = 1;
        roundCounterPanel.GetComponent<RoundChanger>().FadeIntoPanel();
        StartCoroutine(WaitABitBeforeStarting());
        
    }

    // Update is called once per frame
    void Update()
    {
        //Triggers when enough time has passed after the last enemy has died
        if (roundEnding == true && afterEnemyTime < Time.timeSinceLevelLoad)
        {
            roundEnding = false;
            //roundCounterPanel.GetComponent<RoundChanger>().FadeOutOfPanel();
            //StartCoroutine(WaitABitBeforeStarting());
        }

        //Checks time since the last enemy was killed
        if (multiTime < Time.time)
        {
            GameManager.multiplier = 1;
        }

        //Checks whether the game should be paused
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            pausePanel.transform.localScale = new Vector3(1f, 1f, 1f);
            Time.timeScale = 0;
        }
    }

    //Done upgrading
    public void SetDoneUpgrading()
    {
        doneUpgrading = true;
    }

    //Coroutine to set up and wait before starting
    IEnumerator WaitABitBeforeStarting()
    {
        RemoveEverything();
        GameManager.roundNumber += 1;
        //Event to tell other objects the round has changed
        OnRoundChange();
        roundPlaying = false;
        
        //Time.timeScale = 0;
        //Sets up the upgrades panel
        if (GameManager.roundNumber % 5 == 0)
        {
            UpgradeOptions();
            //Waits till the user is done upgrading
            while (doneUpgrading == false)
            {
                yield return new WaitForSeconds(0.1f);
            }
            doneUpgrading = false;
            //removes the upgrades panel
            doneUpgradingButton.transform.localScale = new Vector3(0f, 0f, 0f);
            GameObject[] allUpgrades = GameObject.FindGameObjectsWithTag("UIUpgrades");
            foreach (GameObject upgrade in allUpgrades)
            {
                Destroy(upgrade);
            }
        } else
        {
            //Starts the count down till the game starts if the upgrades panel wasnt used
            roundCounter.text = "6";
            yield return new WaitForSeconds(1);
            roundCounter.text = "5";
            yield return new WaitForSeconds(1);
            roundCounter.text = "4";
            yield return new WaitForSeconds(1);
        }
        //Sets up the game and removes UI
        SpawnAllTanks();
        OnRoundInstantiated();
        roundCounterPanel.GetComponent<RoundChanger>().FadeOutOfPanel();
        //roundCounterPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        controlsImage.transform.localScale = new Vector3(0f, 0f, 0f);
        roundCounter.text = "3";
        yield return new WaitForSeconds(1);
        roundCounter.text = "2";
        yield return new WaitForSeconds(1);
        roundCounter.text = "1";
        yield return new WaitForSeconds(1);
        //Resumes the time scale and thus resumes the game
        //Time.timeScale = 1;
        OnRoundStarted();
        roundPlaying = true;
        roundCounter.text = "FIGHT";
        yield return new WaitForSeconds(1);
        roundCounter.text = "";
    }

    //Used to spawn in the correct upgrades
    void UpgradeOptions()
    {
        roundCounter.text = "";
        doneUpgradingButton.transform.localScale = new Vector3(1f, 1f, 1f);
        //Sets up the upgrade options
        int previousUpgrade = -1;
        for (int i = 0; i < 2; i++) {

            //Current update button reference
            GameObject upgradeButton;
            int randomValue;
            //Runs through till a valid upgrade button is selected
            do
            {
                randomValue = Random.Range(0, 7);
                //makes sure the previous upgrade isn't the one being selected
                if (randomValue != previousUpgrade)
                {
                    //Chooses an upgade and sets it up
                    if (randomValue == 0 && GameManager.armour < GameManager.armourCap)
                    {
                        //Debug.Log(GameManager.armourCoins.ToString() + " COINS \n +100 TOTAL ARMOUR");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.armourCoins.ToString() + " COINS \n +100 TOTAL ARMOUR";
                    }
                    else if (randomValue == 1 && GameManager.bulletsCap < 10)
                    {
                        //Debug.Log(GameManager.bulletCoins.ToString() + " COINS \n +1 BULLET CAPACITY");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.bulletCoins.ToString() + " COINS \n +1 BULLET CAPACITY";
                    }
                    else if (randomValue == 2 && GameManager.reloadCap > 0.1f)
                    {
                        //Debug.Log(GameManager.reloadCoins.ToString() + " COINS \n -0.4s RELOAD TIME");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.reloadCoins.ToString() + " COINS \n -0.4s RELOAD TIME";
                    }
                    else if (randomValue == 3 && GameManager.bulletType != 1)
                    {
                        //Debug.Log(GameManager.bulletTypeCoins.ToString() + " COINS \n SWITCH TO ROCKETS");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.bulletTypeCoins.ToString() + " COINS \n SWITCH TO ROCKETS";
                    }
                    else if (randomValue == 4)
                    {
                        //Debug.Log(GameManager.speedCoins.ToString() + " COINS \n +15% SPEED INCREASE");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.speedCoins.ToString() + " COINS \n +15% SPEED INCREASE";
                    }
                    else if (randomValue == 5)
                    {
                        //Debug.Log(GameManager.speedCoins.ToString() + " COINS \n +15% SPEED INCREASE");
                        upgradeButton = Instantiate(upgradePrefabs[randomValue], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.mineCoins.ToString() + " COINS \n ENABLE MINES";
                    }
                    else
                    {
                        //Debug.Log(GameManager.healthCoins.ToString() + " COINS \n +50 TOTAL HEALTH");
                        upgradeButton = Instantiate(upgradePrefabs[6], roundCounterPanel.transform, false);
                        upgradeButton.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.healthCoins.ToString() + " COINS \n +50 TOTAL HEALTH";

                    }
                    //Spawns the upgrade in the correct spot
                    if (i == 0)
                    {
                        upgradeButton.transform.localPosition = new Vector3(upgradeButton.transform.localPosition.x + 225f, upgradeButton.transform.localPosition.y, upgradeButton.transform.localPosition.z);
                    }
                    else
                    {
                        upgradeButton.transform.localPosition = new Vector3(upgradeButton.transform.localPosition.x - 225f, upgradeButton.transform.localPosition.y, upgradeButton.transform.localPosition.z);
                    }
                }
            } while (randomValue == previousUpgrade);
            previousUpgrade = randomValue;
        }

    }

    //Spawns the tanks
    void SpawnAllTanks()
    {
        //Instantiates a new list to store the spawned tanks
        List<int> currentListOfTankSpawns = new List<int> { };
        Vector3[] currentListOfObjectLocations;

        //If we are above the amount of current available levels, generate a random one
        if (GameManager.roundNumber - 1 >= spawnPointCommands.Count)
        {
            currentListOfObjectLocations = spawnPoints[Random.Range(0, 26)];
            currentListOfTankSpawns.Add(0);
            for (int j = 0; j < 6; j++)
            {
                currentListOfTankSpawns.Add(Random.Range(1, 8));
            }
        }
        //Get the list of spawn commands and spawn points
        else
        {
            currentListOfTankSpawns = spawnPointCommands[GameManager.roundNumber - 1];
            currentListOfObjectLocations = spawnPoints[GameManager.roundNumber - 1];
        }

        //Translate the spawn point commands into instantiations
        for (int i = 0; i < currentListOfObjectLocations.Length; i++)
        {
            //If the z value is 0, spawn tanks
            if (currentListOfObjectLocations[i].z == 0)
            {
                if (currentListOfTankSpawns.Count > i)
                {
                    tanks.Add(Instantiate(tankPrefabs[currentListOfTankSpawns[i]], new Vector3(currentListOfObjectLocations[i].x, 0.5f, currentListOfObjectLocations[i].y), Quaternion.Euler(new Vector3(0, 0, 0))));
                }

            }
            //If the z value is 1, spawn walls
            else if (currentListOfObjectLocations[i].z != 0)
            {
                walls.Add(Instantiate(wallPrefabs[(int)currentListOfObjectLocations[i].z - 1], new Vector3(currentListOfObjectLocations[i].x, 0.5f, currentListOfObjectLocations[i].y), Quaternion.Euler(new Vector3(0, 0, 0))));
            }
            /*
            //If the z value is 2, spawn Moving walls
            else if (currentListOfObjectLocations[i].z == 2)
            {
                walls.Add(Instantiate(wallPrefabs[1], new Vector3(currentListOfObjectLocations[i].x, 0.5f, currentListOfObjectLocations[i].y), Quaternion.Euler(new Vector3(0, 0, 0))));
            }

            //If the z value is 2, spawn Moving walls
            else if (currentListOfObjectLocations[i].z == 3)
            {
                walls.Add(Instantiate(wallPrefabs[2], new Vector3(currentListOfObjectLocations[i].x, 0.5f, currentListOfObjectLocations[i].y), Quaternion.Euler(new Vector3(0, 0, 0))));
            }

            //If the z value is 2, spawn Moving walls
            else if (currentListOfObjectLocations[i].z == 4)
            {
                walls.Add(Instantiate(wallPrefabs[3], new Vector3(currentListOfObjectLocations[i].x, 0.5f, currentListOfObjectLocations[i].y), Quaternion.Euler(new Vector3(0, 0, 0))));
            }
            */
        }
    }

    //Responds to dead enemy event
    void RemoveEnemy(GameObject toRemove)
    {
        //Adds to multiplier if it hasnt been long since last kill but if it has been too long then bring it back to 1
        if (multiTime > Time.time)
        {
            GameManager.multiplier += 1;
        } else
        {
            GameManager.multiplier = 1;
        }
        //If the tank is still in the tanks list remove it
        if (tanks.Contains(toRemove))
        {
            tanks.Remove(toRemove);
        }
        //Trigger the end of the round since this is the last tank
        if (roundPlaying == true && tanks.Count == 1)
        {
            afterEnemyTime = Time.time + afterEnemyRate;
            roundPlaying = false;
            roundEnding = true;
            
            StartCoroutine(WaitAfterLastTankDies());
            GameObject soundObject = Instantiate(winAudio);
            Destroy(soundObject, 2f);
        }
        //Add some time to that multiplier
        multiTime = Time.time + multiCap;

    }

    
    IEnumerator WaitAfterLastTankDies()
    {
        OnRoundFinished();
        yield return new WaitForSeconds(1);
        roundCounterPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        roundCounter.text = "7";
        roundCounterPanel.GetComponent<RoundChanger>().FadeIntoPanel();
        yield return new WaitForSeconds(1);
        StartCoroutine(WaitABitBeforeStarting());
    }

    //Delete everything that is currently on the map
    void RemoveEverything()
    {
        //every tank that still exists, KILL IT
        for (int i = 0; i < tanks.Count; i++)
        {
            Destroy(tanks[i]);
            tanks.Remove(tanks[i]);
            
        }

        //For every wall that exists, KILL IT
        for (int j = 0; j < walls.Count; j++)
        {
            Destroy(walls[j]);
            tanks.Remove(walls[j]);
        }

        //Kill all the smoke
        GameObject[] allSmoke;
        allSmoke = GameObject.FindGameObjectsWithTag("Smoke");
        for (int k = 0; k < allSmoke.Length; k++)
        {
            Destroy(allSmoke[k]);
        }

        //Kill all the bullets
        GameObject[] allBullets;
        allBullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int l = 0; l < allBullets.Length; l++)
        {
            Destroy(allBullets[l]);
        }

        //Kill all the explosives
        GameObject[] allExplosives;
        allExplosives = GameObject.FindGameObjectsWithTag("Explosives");
        for (int l = 0; l < allExplosives.Length; l++)
        {
            Destroy(allExplosives[l]);
        }

    }

    //Responds to the players tank being destroyed and starts the death screen
    void PlayerTankDestroyed(GameObject player)
    {
        deathScreen.transform.localScale = new Vector3(1f, 1f, 1f);
        roundCounterPanel.GetComponent<RoundChanger>().FadeIntoPanel(); 
        roundCounterPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        Time.timeScale = 0;
    }

    void OnEnable()
    {
        EnemyTank.EnemyDestroyed += RemoveEnemy;
        DeathHandler.PlayerDestroyed += PlayerTankDestroyed;
    }


    void OnDisable()
    {
        EnemyTank.EnemyDestroyed -= RemoveEnemy;
        DeathHandler.PlayerDestroyed -= PlayerTankDestroyed;
    }
}
