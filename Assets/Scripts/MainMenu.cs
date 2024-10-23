using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject gameSelect;
    

  public void playButton()
    {
        title.SetActive(false);
        gameSelect.SetActive(true);
    }
    public void playGame1()
    {
        SceneManager.LoadScene("Game1");
    }
    public void playGame2()
    {
        SceneManager.LoadScene("Game2");
    }
    public void playGame3()
    {
        SceneManager.LoadScene("Game3");
    }
    public void playGame4()
    {
        SceneManager.LoadScene("Game4");
    }
    public void PlayBeatIt()
    {
        SceneManager.LoadScene("TopFloor");
    }
    public void returnToMainMenu()
    {
        title.SetActive(true);  
        gameSelect.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
