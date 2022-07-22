using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int roundNumber;
    static public int score;

    static public float health;
    static public float healthCap;

    static public float armour;
    static public float armourCap;

    static public int bulletsLeft;
    static public int bulletsCap;
    static public bool minesEnabled;

    static public float reloadCap;
    static public float reloadTime;

    static public int coins;
    static public int coinsAdded;

    static public int multiplier;

    static public float speed;

    static public int bulletType;

    static public List<object[]> listOfScores = new List<object[]> {

    };

    static public int healthCoins;
    static public int armourCoins;
    static public int bulletCoins;
    static public int reloadCoins;
    static public int speedCoins;
    static public int bulletTypeCoins;
    static public int mineCoins;

    static public float worldWideVolume;

    static public float mouseSensitivity;

}
