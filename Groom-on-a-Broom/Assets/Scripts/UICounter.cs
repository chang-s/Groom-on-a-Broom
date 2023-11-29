using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICounter : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;
    public TextMeshProUGUI heartCounter;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter.text = GameManager.totalCoins.ToString();
        heartCounter.text = GameManager.totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCounter == null) {
            Debug.Log("coinCounter obj is null.");
            return;
        } else if (heartCounter == null) {
            Debug.Log("heartCounter obj is null.");
            return;
        }

        if (coinCounter.text != GameManager.totalCoins.ToString())
        {
            coinCounter.text = GameManager.totalCoins.ToString();
        }

        if (heartCounter.text != GameManager.totalLife.ToString())
        {
            heartCounter.text = GameManager.totalLife.ToString();
        }
    }
}
