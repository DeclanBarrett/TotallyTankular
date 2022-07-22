using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplayScores : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject nameText;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.GetInt("ListOfScores") != null && GameManager.listOfScores.Count < PlayerPrefs.GetInt("ListOfScores"))
        {
            Debug.Log("Set Up List of Scores");
            GameManager.listOfScores.Clear();
            for (int i = 0; i < PlayerPrefs.GetInt("ListOfScores"); i++)
            {
                object[] newObject = new object[2];
                newObject[0] = PlayerPrefs.GetString("Name" + i);
                newObject[1] = PlayerPrefs.GetInt("Score" + i);
                
                GameManager.listOfScores.Add(newObject);
            }
        }
    }
    void Start()
    {
        if (GameManager.listOfScores.Count > 0)
        {
            Debug.Log("Gave to List");
            PlayerPrefs.SetInt("ListOfScores", GameManager.listOfScores.Count);


            QuickSort(GameManager.listOfScores, 0, GameManager.listOfScores.Count - 1);
            for (int i = 0; i < GameManager.listOfScores.Count; i++)
            {
                object[] currentNameNum = GameManager.listOfScores[GameManager.listOfScores.Count - 1 - i];
                nameText.GetComponent<UnityEngine.UI.Text>().text += "\n" + currentNameNum[0];
                scoreText.GetComponent<UnityEngine.UI.Text>().text += "\n" + currentNameNum[1].ToString();

                PlayerPrefs.SetString("Name" + i, (string)GameManager.listOfScores[i][0]);
                PlayerPrefs.SetInt("Score" + i, (int) GameManager.listOfScores[i][1]);
                
            }
            PlayerPrefs.Save();
        }
    }

    void QuickSort(List<object[]> allScores, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(allScores, low, high);

            QuickSort(allScores, low, partitionIndex - 1);
            QuickSort(allScores, partitionIndex + 1, high);
        }
    }

    int Partition(List<object[]> partHits, int low, int high)
    {
        int pivot = (int) partHits[high][1];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if ((int) partHits[j][1] <= pivot)
            {
                i++;
                object[] swapHit = partHits[i];
                partHits[i] = partHits[j];
                partHits[j] = swapHit;
            }
        }
        object[] swapAgain = partHits[i + 1];
        partHits[i + 1] = partHits[high];
        partHits[high] = swapAgain;

        return (i + 1);
    }

}
