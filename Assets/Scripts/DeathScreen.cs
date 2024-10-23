using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Scene game4;
    public PlayerInfo playerInfo;
    public Transform player;
    [SerializeField] GameObject deathScreen;
    public CoinCount coinCount;

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game4");
    }
    public void Continue()
    {
        if (playerInfo.coins >= 50)
        {
            Debug.Log("GERRO"); 
            Time.timeScale = 1f;
            player.Translate(Vector3.left * 10, player);
            playerInfo.coins = playerInfo.coins - 50;
            coinCount.currentCoins = coinCount.currentCoins - 50;
            deathScreen.SetActive(false);
        }
    }
}

