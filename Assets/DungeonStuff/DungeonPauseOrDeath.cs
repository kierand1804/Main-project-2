using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonPauseOrDeath : MonoBehaviour
{
    public GameObject deathUI;
    // Start is called before the first frame update
    public void Continue()
    {
        deathUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("TopFloor");
        Time.timeScale = 1.0f;
        GameController.instance.ResetPlayerStats();
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        GameController.instance.ResetPlayerStats();
    }
    public void ExitGame()
    {
        Application.Quit();
        GameController.instance.ResetPlayerStats();
    }
}
