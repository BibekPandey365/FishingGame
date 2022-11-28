using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    [SerializeField] GameObject fishingTool;

    public static bool isGameOver;
    //public static bool isGameOver;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        isGameOver = false;

        gamePanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);



        FindObjectOfType<AdManager>().RequestInterstitial();
    }

    void Update()
    {
        
    }

    public void OnLose()
    {
        FindObjectOfType<AudioManager>().Play("Lose");

        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(true);
        isGameOver = true;

        fishingTool.SetActive(false);

        Time.timeScale = 0f;

        FindObjectOfType<AdManager>().ShowInterstitial();
    }

    public void OnWin()
    {
        FindObjectOfType<AudioManager>().Play("Win");

        gamePanel.SetActive(false);
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        isGameOver = true;

        fishingTool.SetActive(false);

        Time.timeScale = 0f;

        FindObjectOfType<AdManager>().ShowInterstitial();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void MenuButton()
    {
        SelectionHandler.isMenuPressed = true;
        SceneManager.LoadScene(0);

        FindObjectOfType<AudioManager>().Play("Click");
    }
}
