using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionHandler : MonoBehaviour
{
    public static SelectionHandler instance;

    public static int selectedPool;
    public static int selectedTimeIndex;
    public static int selectedHand;

    public static bool isMenuPressed = false;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        
    }
}
