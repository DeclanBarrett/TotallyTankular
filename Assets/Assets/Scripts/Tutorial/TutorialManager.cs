using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject playerTank;
    private GameObject currentPlayerTank;

    public GameObject arrowPrefab;
    public GameObject[] currentArrows;
    public GameObject returnButton;

    public Text tutorialInstructions;
    public Text tutorialMinorInstructions;
    public Text tutorialList;

    private string[] instructionArray = new string[] {
    "WASD TO MOVE",
    "USE THE MOUSE TO AIM",
    "SHOOT WITH LEFT CLICK",
    "THIS IS YOUR AMMO AND RELOAD BAR",
    "KILL THE ENEMY",
    "YOU GAINED SOME COINS",
    "THIS IS YOUR HEALTH",
    "HAVE FUN"};

    private string[] instructionMinorArray = new string[] {
    "",
    "",
    "BULLETS BOUNCE. USE THIS TO YOUR ADVANTAGE",
    "WHEN YOU SHOOT YOU USE AMMO. IT TAKES A LITTLE BIT OF TIME TO GAIN IT BACK",
    "",
    "COINS CAN BE USED TO BUY UPGRADES EVERY FEW ROUNDS",
    "YOUR HEARTS REGENERATE BUT YOUR ARMOUR DOES NOT. DON'T DIE",
    ""};

    private int currentStep;

    //Reusable Timer Variables
    float stepTime;
    float stepRate = 10f;

    //Step 5
    public GameObject enemyTank;
    private GameObject currentEnemyTank;

    void Awake()
    {
        GameManager.score = 0;
        GameManager.health = 75;
        GameManager.healthCap = 75; //75

        GameManager.armour = 50;
        GameManager.armourCap = 500;

        GameManager.bulletsLeft = 2;
        GameManager.bulletsCap = 2; //2
        GameManager.bulletType = 0; //0

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
        GameManager.bulletTypeCoins = 500;

        GameManager.mouseSensitivity = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        StepOneSetUp();
    }

    // Update is called once per frame
    void Update()
    {
        StepCheck();
    }

    void StepCheck()
    {
        switch (currentStep)
        {
            case 1:
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    currentStep = 2;
                    GameManager.mouseSensitivity = 1;
                    currentPlayerTank.GetComponentInChildren<PlayerPivot>().SetMouseSensitivity();
                    SetUpTextPrompts();
                }
                ; break;
            case 2:
                if (Input.GetAxis("MouseX") != 0 || Input.GetAxis("MouseY") != 0)
                {
                    currentStep = 3;
                    SetUpTextPrompts();
                }
                ; break;
            case 3:
                if (Input.GetMouseButtonDown(0))
                {
                    currentStep = 4;
                    SetUpTextPrompts();
                    stepTime = Time.time + stepRate;
                    currentArrows[0].transform.localScale = new Vector3(1, 1, 1);
                }
                ; break;
            case 4:
                if (stepTime < Time.time)
                {
                    currentArrows[0].transform.localScale = new Vector3(0, 0, 0);
                    currentStep = 5;
                    SetUpTextPrompts();
                    currentEnemyTank = Instantiate(enemyTank);
                }
                ; break;
            case 5:
                if (!currentEnemyTank)
                {
                    currentStep = 6;
                    SetUpTextPrompts();
                    stepTime = Time.time + stepRate;
                    currentArrows[1].transform.localScale = new Vector3(1, 1, 1);
                }
                ; break;
            case 6:
                if (stepTime < Time.time)
                {
                    currentArrows[1].transform.localScale = new Vector3(0, 0, 0);
                    currentArrows[2].transform.localScale = new Vector3(1, 1, 1);
                    currentStep = 7;
                    SetUpTextPrompts();
                    stepTime = Time.time + stepRate;
                }
                ; break;
            case 7:
                if (stepTime < Time.time)
                {
                    stepTime = Time.time + stepRate;
                    currentArrows[2].transform.localScale = new Vector3(0, 0, 0);
                    returnButton.transform.localScale = new Vector3(1, 1, 1);
                    currentStep = 8;
                    SetUpTextPrompts();
                }
                ; break;
            case 8:
                if (stepTime < Time.time)
                {
                    stepTime = Time.time + stepRate;
                    currentStep = 8;
                }
                ; break;
        }
    }

    //Movement Controls
    void StepOneSetUp()
    {
        foreach (GameObject arrow in currentArrows)
        {
            arrow.transform.localScale = new Vector3(0, 0, 0);
        }
        returnButton.transform.localScale = new Vector3(0, 0, 0);

        currentStep = 1;
        
        SetUpTextPrompts();
        currentPlayerTank = Instantiate(playerTank, new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        GameManager.mouseSensitivity = 0;
        currentPlayerTank.GetComponentInChildren<PlayerPivot>().SetMouseSensitivity();
    }

    void SetUpTextPrompts()
    {
        tutorialInstructions.text = instructionArray[currentStep - 1];
        tutorialMinorInstructions.text = instructionMinorArray[currentStep - 1];
        if (currentStep != 1)
        {
            tutorialList.text += instructionArray[currentStep - 2] + "\n";
        } else
        {
            tutorialList.text = "";
        }
    }

    void RemoveEnemy(GameObject enemy)
    {

    }

    void PlayerTankDestroyed(GameObject player)
    {
        StepOneSetUp();
    }

    void OnEnable()
    {
        DeathHandler.PlayerDestroyed += PlayerTankDestroyed;
        EnemyTank.EnemyDestroyed += RemoveEnemy;
    }


    void OnDisable()
    {
        DeathHandler.PlayerDestroyed -= PlayerTankDestroyed;
        EnemyTank.EnemyDestroyed -= RemoveEnemy;
    }
}
