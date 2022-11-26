using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    public static SelectionHandler instance;

    public static int selectedPool;
    public static int selectedTimeIndex;
    public static int selectedHand;

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
