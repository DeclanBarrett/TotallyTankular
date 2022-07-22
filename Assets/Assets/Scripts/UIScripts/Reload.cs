using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reload : MonoBehaviour
{
    public Slider ReloadBarObject;

    void SetSize()
    {
        if (GameManager.bulletsLeft != GameManager.bulletsCap)
        {
            if (Time.timeScale != 0)
            {
                float reloadBarSize = 1 - (GameManager.reloadTime - Time.time) / (GameManager.reloadCap);
                ReloadBarObject.value = reloadBarSize;
            }
            /*
            if (1 - ((GameManager.fireTime - Time.time) / (GameManager.reloadCap)) < 1)
            {
                if (Time.timeScale == 0)
                {
                    this.transform.localScale = new Vector3(1f, 1f, 1f);
                } else
                {
                    this.transform.localScale = new Vector3(1 - ((GameManager.fireTime - Time.time) / (GameManager.reloadCap)), 1f);
                }
                
            }
            */
        }
        
        
    }

    void ResetReload()
    {
        GameManager.reloadTime = 0;
        SetSize();
    }


    // Update is called once per frame
    void Update()
    {
        SetSize();
    }

    private void OnEnable()
    {
        RoundInstantiate.OnRoundChange += ResetReload;
    }

    private void OnDisable()
    {
        RoundInstantiate.OnRoundChange -= ResetReload;
    }
}
