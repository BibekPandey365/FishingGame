using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAndFishingToolSpawner : MonoBehaviour
{
    [SerializeField] Transform poolSpawnPonint;
    [SerializeField] Transform FishingToolSpawnPonint;

    [SerializeField] GameObject[] fishingTools;
    [SerializeField] GameObject[] pools;

    void Start()
    {
        GameObject newPool = Instantiate(pools[SelectionHandler.selectedPool],
            poolSpawnPonint.transform.position, transform.rotation, this.transform);

        GameObject newFishingTool = Instantiate(fishingTools[SelectionHandler.selectedHand],
            FishingToolSpawnPonint.transform.position, transform.rotation, this.transform);
    }

    void Update()
    {
        
    }

}
