using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Keep track of total picked coins
    public static int totalCoins = 0;
    public static int totalLife = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCoins()
    {
        return totalCoins;
    }
    public int getLife()
    {
        return totalLife;
    }
}
