using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public TMP_Text coinText;
    public int currentCoins;
    public static CoinCount instance;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        coinText.text = "Coins:" + currentCoins.ToString();
    }


    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
