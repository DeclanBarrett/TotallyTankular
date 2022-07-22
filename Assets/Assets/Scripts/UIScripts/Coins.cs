using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    Text coinText;
    Text multiplierText;
    public GameObject additionText;

    public Canvas UICanvas;

    int displayCoins;

    float additionTime;
    float additionCap = 2.95f;
    bool additionBool;

    int caseColour = 0;
    bool IsFlashing = false;

    private void Awake()
    {
        coinText = this.transform.GetChild(1).GetComponent<Text>();
        multiplierText = this.transform.GetChild(2).GetComponent<Text>();
        //additionText = this.transform.GetChild(3).GetComponent<Text>();
    }

    private void Start()
    {
        SetMainCoins();
        SetMultiplier();
    }

    private void Update()
    {
        SetMainCoins();
        SetMultiplier();
    }

    void SetMainCoins()
    {
        if (displayCoins < GameManager.coins)
        {
            displayCoins += 1;
            coinText.text = displayCoins.ToString();

        } else if (GameManager.coins < displayCoins) {
            displayCoins = GameManager.coins;
            coinText.text = displayCoins.ToString();
        }
    }

    void SetMultiplier()
    {
        multiplierText.text = "x" + GameManager.multiplier.ToString();

        if (GameManager.multiplier > 1)
        {
            if (!IsFlashing)
            {
                StartBlinking();
                IsFlashing = true;
            }
            
        } else
        {
            StopBlinking();
            IsFlashing = false;
        }
    } 

    IEnumerator Blink()
    {
        
        while (true)
        {
            switch(caseColour)
            {
                case 0:
                    multiplierText.color = Color.red;
                    caseColour = 1;
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 1:
                    multiplierText.color = Color.black;
                    caseColour = 0;
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
        multiplierText.color = Color.black;
    }

    void SetAddition(int addCoins)
    {
        GameManager.coinsAdded = addCoins * GameManager.multiplier;
        GameManager.coins += GameManager.coinsAdded;
        GameManager.score += GameManager.coinsAdded;
        Vector3 additionTextOffset = new Vector3(50, 185, 0f);
        GameObject currentAdditionText = Instantiate(additionText, UICanvas.transform); ;
        //currentAdditionText.transform.SetParent(UICanvas.transform);
        currentAdditionText.transform.localPosition = additionTextOffset;
        //currentAdditionText.transform.localScale = new Vector3(1f, 1f, 1f);
        currentAdditionText.transform.GetChild(0).GetComponent<Text>().text = "+" + GameManager.coinsAdded.ToString();
        SetMultiplier();
    }

    private void OnEnable()
    {
        EnemyTank.EnemyPayment += SetAddition;
    }

    private void OnDisable()
    {
        EnemyTank.EnemyPayment -= SetAddition;
    }
}
