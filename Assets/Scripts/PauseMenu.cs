using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;    
   
   public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}

