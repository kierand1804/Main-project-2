using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int coins;
    public int collectables;
    public int lives;

    public void Update()
    {
        Debug.Log(coins);
    }
}
