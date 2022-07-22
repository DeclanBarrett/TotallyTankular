using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public GameObject sceneChanger;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            sceneChanger.GetComponent<LevelChanger>().FadeToLevel(0);
        }
    }
}
