using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    [SerializeField] TMP_Text scoreTextLose;
    [SerializeField] TMP_Text scoreTextWin;
    [SerializeField] TMP_Text totalFishText;

    public static int score;

    int totalFish = 17;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreTextWin.text = scoreTextLose.text = scoreText.text = score.ToString();

        CheckIfWin();
    }

    void CheckIfWin()
    {
        if(score >= totalFish)
        {
            FindObjectOfType<InGameMenu>().OnWin();
        }
    }
}
