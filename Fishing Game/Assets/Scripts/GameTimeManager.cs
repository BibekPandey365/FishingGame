using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimeManager : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    public static float secondLeft;

    void Start()
    {
        GetInitialTime();
    }

    void Update()
    {
        UpdateTimer();

        if(secondLeft <= 0f && !InGameMenu.isGameOver)
        {
            FindObjectOfType<InGameMenu>().OnLose();
        }
    }

    void GetInitialTime()
    {
        switch(SelectionHandler.selectedTimeIndex)
        {
            case 0:
                secondLeft = 120f;
                break;
            case 1:
                secondLeft = 180f;
                break;
            case 2:
                secondLeft = 300f;
                break;
            case 3:
                secondLeft = Mathf.Infinity;
                break;
        }
    }

    void UpdateTimer()
    {
        if(secondLeft > 500)
        {
            timer.text = "";
            return;
        }

        if (secondLeft > 0f)
        {
            secondLeft -= Time.deltaTime;
            string min = ((int)secondLeft / 60).ToString();
            string sec = (secondLeft % 60).ToString("F0");

            timer.text = min + " : " + sec;
        }
        else
        {
            timer.text = "0 : 0";
        }
    }
}
