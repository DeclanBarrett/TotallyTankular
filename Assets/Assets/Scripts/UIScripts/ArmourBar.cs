using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourBar : MonoBehaviour
{
    
    private void Awake()
    {
        SetArmour();
    }

    void SetArmour()
    {
        foreach (Transform child in transform)
        {
            child.transform.localScale = new Vector3(0, 0, 0);
        }

        if (GameManager.armour > 0)
        {
            for (int i = 0; i < Mathf.CeilToInt(GameManager.armour/ 50); i++)
            {
                this.transform.GetChild(i).transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnEnable()
    {
        RoundInstantiate.OnRoundChange += SetArmour;
        Health.PlayerHealthUpdated += SetArmour;
    }

    private void OnDisable()
    {
        RoundInstantiate.OnRoundChange -= SetArmour;
        Health.PlayerHealthUpdated -= SetArmour;
    }
    
}
