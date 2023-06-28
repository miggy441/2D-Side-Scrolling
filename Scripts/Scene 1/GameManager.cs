using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Panel List")]
    public GameObject MainMenuPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject GamePlayPanel;

    private void Start()
    {
        MainMenuPanel.SetActive(true);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
        Time.timeScale = 0;

    }

    public void StartButton()
    {
        Time.timeScale += 1;    
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false );
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
    }

    public void BackToMainMenuButton()
    {
        
        SceneManager.LoadScene("Level 1");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextStageButton()
    {
        SceneManager.LoadScene("Level2");
    }

}