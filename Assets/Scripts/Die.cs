using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Collision2D deathBox;
    [SerializeField] GameObject deathScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(deathScreen);
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

}
