using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pools;

    void Start()
    {
        GameObject newPool = Instantiate(pools[SelectionHandler.selectedPool], this.transform.position, transform.rotation);
    }

    void Update()
    {
        
    }
}
