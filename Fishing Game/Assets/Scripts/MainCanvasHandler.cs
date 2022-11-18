using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] Dropdown timeDropdown;


    void Start()
    {
        mainPanel.SetActive(true);
        selectPanel.SetActive(false);

        poolSelectBox.SetActive(true);
        timeSelectBox.SetActive(false);
        handSelectBox.SetActive(false);

    }

    void Update()
    {
        //Pool Select Menu
        PoolToDisplay();

        //Time Select Menu
        timeDropdown.Show();
    }

    #region MainPanel

    public void PlayButton()
    {
        mainPanel.SetActive(false);
        selectPanel.SetActive(true);
    }

    #endregion

    #region SelectPanel

    #region PoolSelection

    public void StartButton()
    {
        poolSelectBox.SetActive(false);
        timeSelectBox.SetActive(true);

        //Time Select Menu
        StartCoroutine("HideExtraIteam");
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
    }

    public void CancelButton()
    {
        poolSelectBox.SetActive(true);
        timeSelectBox.SetActive(false);
        handSelectBox.SetActive(false);
    }

    #region HandSelection

    public void RightHandButton()
    {
        SceneManager.LoadScene(0);
    }

    public void LeftHandButton()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator HideExtraIteam()
    {
        yield return new WaitForSeconds(0.05f);

        int listIteamIndex = timeDropdown.transform.childCount - 1;
        GameObject listIteam = timeDropdown.transform.GetChild(listIteamIndex).gameObject;
        GameObject viewportObject = listIteam.transform.GetChild(0).gameObject;
        GameObject contentObject = viewportObject.transform.GetChild(0).gameObject;
        GameObject firstIteam = contentObject.transform.GetChild(0).gameObject;
        firstIteam.SetActive(false);
        print(firstIteam.name);
    }

    #endregion

    #endregion

    #endregion
}
