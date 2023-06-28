using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [Header("Panel List")]
    //public GameObject MainMenuPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject GamePlayPanel;


    // Start is called before the first frame update
    void Start()
    {
        //MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        Time.timeScale += 1;
        //MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);

    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        //MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        //MainMenuPanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        GamePlayPanel.SetActive(true);
    }

    public void BackToMainMenuButton()
    {

        SceneManager.LoadScene("Level 1");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
