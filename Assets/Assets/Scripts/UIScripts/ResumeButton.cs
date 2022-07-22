using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void ResetTime()
    {
        Time.timeScale = 1;
        GameObject.Find("PausePanel").transform.localScale = new Vector3(0, 0, 0);
    }
}
