using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetRoundCounter();
    }

    public void SetRoundCounter()
    {
        int roundCounter = GameManager.roundNumber;
        this.GetComponent<UnityEngine.UI.Text>().text = "ROUND " + roundCounter.ToString();
    }

    void OnEnable()
    {
        RoundInstantiate.OnRoundChange += SetRoundCounter;
    }


    void OnDisable()
    {
        RoundInstantiate.OnRoundChange -= SetRoundCounter;
    }
}
