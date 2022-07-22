using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    void SetScore()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + GameManager.score.ToString();
    }
    private void OnEnable()
    {
        RoundInstantiate.OnRoundChange += SetScore;
    }

    private void OnDisable()
    {
        RoundInstantiate.OnRoundChange -= SetScore;
    }
}
