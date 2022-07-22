using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHighScores : MonoBehaviour
{
    public void HighScoreOn()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HighScoreOff()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }
}
