using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Collider2D _collider;
    public PlayerInfo playerInfo;
    public CoinCount coinCount;
    public int Value;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerInfo.coins++;
        CoinCount.instance.IncreaseCoins(Value);
        Destroy(gameObject);
    }
}
