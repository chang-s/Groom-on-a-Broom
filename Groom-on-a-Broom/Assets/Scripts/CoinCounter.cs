using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counterText == null)
        {
            Debug.Log("counterText obj is null.");
            return;
        }

        if(counterText.text != GameManager.totalCoins.ToString())
        {
            counterText.text = GameManager.totalCoins.ToString();
        }
    }
}
