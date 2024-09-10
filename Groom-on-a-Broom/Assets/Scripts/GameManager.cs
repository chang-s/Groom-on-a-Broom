using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Keep track of total picked coins
    public static int totalCoins = 0;
    public static int totalLife = 5;
    public static int totalDistance = 0;
    public static bool cleared = false;

    public int getCoins()
    {
        return totalCoins;
    }
    public int getLife()
    {
        return totalLife;
    }
    public int getDistance()
    {
        return totalDistance;
    }
}
