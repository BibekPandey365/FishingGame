using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fishPrefabs;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;

    void Awake()
    {
        SpawnFish();
    }

    void Update()
    {

    }

    void SpawnFish()
    {
        int fishIndex = Random.Range(0, fishPrefabs.Length - 1);
        GameObject myFish = Instantiate<GameObject>(fishPrefabs[fishIndex], this.transform);
        myFish.transform.position = new Vector3(this.transform.position.x + offsetX, this.transform.position.y + offsetY, transform.position.z);
    }
}
