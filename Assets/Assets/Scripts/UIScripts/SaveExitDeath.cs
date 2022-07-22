using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveExitDeath : MonoBehaviour
{
    string NameOfPlayer;
    public InputField name;

    public void SetPlayerScoreLeave(int i)
    {
        object[] playerScoreCombination = new object[2];
        playerScoreCombination[0] = name.text;
        playerScoreCombination[1] = GameManager.score;
        GameManager.listOfScores.Add(playerScoreCombination);

        SceneManager.LoadScene(i);
    }

}
