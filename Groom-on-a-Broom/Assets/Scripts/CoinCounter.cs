using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counterText == null)
        {
            Debug.Log("counterText obj is null.");
            return;
        }

        if(counterText.text != Coin.totalCoins.ToString())
        {
            counterText.text = Coin.totalCoins.ToString();
        }
    }
}
