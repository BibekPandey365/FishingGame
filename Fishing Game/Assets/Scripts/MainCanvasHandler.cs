using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainCanvasHandler : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject selectPanel;

    [Header("Selection Box")]
    [SerializeField] GameObject poolSelectBox;
    [SerializeField] GameObject timeSelectBox;
    [SerializeField] GameObject handSelectBox;

    [Header("Pool's Menu")]
    [SerializeField] GameObject[] pools;
    int selectedPool = 0;

    [Header("Time Dropdown Menu")]
    [SerializeField] Toggle[] timeToggles;
    int selectedTimeToggle = 0;


    void Start()
    {
        mainPanel.SetActive(true);
        selectPanel.SetActive(false);

        poolSelectBox.SetActive(true);
        timeSelectBox.SetActive(false);
        handSelectBox.SetActive(false);


        FindObjectOfType<AdManager>().RequestInterstitial();
    }

    void Update()
    {
        //Pool Select Menu
        PoolToDisplay();

        //Time Select Menu
        UpdateTimeToggle();
    }

    #region MainPanel

    public void PlayButton()
    {
        mainPanel.SetActive(false);
        selectPanel.SetActive(true);

        FindObjectOfType<AudioManager>().Play("Done");
    }

    public void MoreButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7011584689522728649");

        FindObjectOfType<AudioManager>().Play("Click");
    }

    #endregion

    #region SelectPanel

    #region PoolSelection

    public void StartButton()
    {
        poolSelectBox.SetActive(false);
        timeSelectBox.SetActive(true);

        SelectionHandler.selectedPool = selectedPool;

        FindObjectOfType<AudioManager>().Play("Done");
    }

    public void LeftButton()
    {
        if(selectedPool != 0)
        {
            selectedPool--;
        }
        else
        {
            selectedPool = pools.Length-1;
        }

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void RightButton()
    {
        if (selectedPool != pools.Length - 1)
        {
            selectedPool++;
        }
        else
        {
            selectedPool = 0;
        }

        FindObjectOfType<AudioManager>().Play("Click");
    }

    void PoolToDisplay()
    {
        for(int i=0; i<pools.Length; i++)
        {
            if(i == selectedPool)
            {
                pools[i].SetActive(true);
            }
            else
            {
                pools[i].SetActive(false);
            }
        }
    }

    #endregion

    #region TimeSelection

    public void DoneButton()
    {
        timeSelectBox.SetActive(false);
        handSelectBox.SetActive(true);

        SelectionHandler.selectedTimeIndex = selectedTimeToggle;


        FindObjectOfType<AdManager>().ShowInterstitial();

        FindObjectOfType<AudioManager>().Play("Done");
    }

    public void CancelButton()
    {
        poolSelectBox.SetActive(true);
        timeSelectBox.SetActive(false);
        handSelectBox.SetActive(false);

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void UpdateTimeToggle()
    {
        for (int i = 0; i < timeToggles.Length; i++)
        {
            if(timeToggles[i].isOn)
            {
                if(i != selectedTimeToggle)
                {
                    timeToggles[selectedTimeToggle].isOn = false;
                    selectedTimeToggle = i;
                    timeToggles[selectedTimeToggle].isOn = true;

                    FindObjectOfType<AudioManager>().Play("Click");
                }
            }
            else
            {
                if (i == selectedTimeToggle)
                {
                    timeToggles[i].isOn = true;
                }
                else
                {
                    timeToggles[i].isOn = false;
                }
            }
        }
    }

    #endregion

    #region HandSelection

    public void LeftHandButton()
    {
        SelectionHandler.selectedHand = 0;
        SceneManager.LoadScene(1);

        //FindObjectOfType<AdManager>().ShowInterstitial();

        FindObjectOfType<AudioManager>().Play("Done");
    }

    public void RightHandButton()
    {
        SelectionHandler.selectedHand = 1;
        SceneManager.LoadScene(1);

        //FindObjectOfType<AdManager>().ShowInterstitial();

        FindObjectOfType<AudioManager>().Play("Done");
    }


    #endregion

    #endregion
}
