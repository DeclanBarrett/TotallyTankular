using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundScreenCoins : MonoBehaviour
{

    void CoinUpdate()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.coins.ToString();
    }

    private void OnEnable()
    {
        RoundInstantiate.OnRoundChange += CoinUpdate;
        UpgradeScript.UpgradeEverything += CoinUpdate;
    }

    private void OnDisable()
    {
        RoundInstantiate.OnRoundChange -= CoinUpdate;
        UpgradeScript.UpgradeEverything -= CoinUpdate;
    }
}
