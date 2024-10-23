using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Scene game4;
    

    public void restartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game4");
    }
}
