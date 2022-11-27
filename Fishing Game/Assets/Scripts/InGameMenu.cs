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

    public static bool didWin;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        didWin = false;

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
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(true);

        fishingTool.SetActive(false);

        Time.timeScale = 0f;

        FindObjectOfType<AdManager>().ShowInterstitial();

        FindObjectOfType<AudioManager>().Play("Lose");
    }

    public void OnWin()
    {
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        didWin = true;

        fishingTool.SetActive(false);

        Time.timeScale = 0f;

        FindObjectOfType<AdManager>().ShowInterstitial();

        FindObjectOfType<AudioManager>().Play("Win");
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

        FindObjectOfType<AudioManager>().Play("Click");
    }
}
