using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateHandler : MonoBehaviour
{
    [SerializeField] float hungryYPosition;
    float switchTime;
    FishSpriteSwitcher fishSpriteSwitcher;

    public enum FishState
    {
        Normal, Hungry, Caught,
    }

    FishState currentState;

    void Start()
    {
        fishSpriteSwitcher = GetComponent<FishSpriteSwitcher>();
        currentState = FishState.Normal;

        switchTime = Random.Range(0f, 5f);
    }

    void Update()
    {
        StateUpdater();
        NormalHungrySwitcherProcess();
    }

    void StateUpdater()
    {
        switch (currentState)
        {
            case FishState.Normal:
                NormalState();
                break;
            case FishState.Hungry:
                HungryState();
                break;
            case FishState.Caught:
                CaughtState();
                break;
        }
    }

    private void NormalHungrySwitcherProcess()
    {
        if (currentState == FishState.Normal || currentState == FishState.Hungry)
        {
            switchTime -= Time.deltaTime;
            if (switchTime < 0f)
            {
                NormalHungryStateSwitcher();
            }
        }
    }

    void NormalHungryStateSwitcher()
    {
        if(currentState == FishState.Normal)
        {
            switchTime = 3f;

            currentState = FishState.Hungry;

            UpdateFishPosition(hungryYPosition);
        }
        else if(currentState == FishState.Hungry)
        {
            switchTime = Random.Range(3f, 8f);

            currentState = FishState.Normal;

            UpdateFishPosition(- hungryYPosition);
        }

        fishSpriteSwitcher.SpriteSwitcher(currentState);
    }

    void NormalState()
    {

    }

    void HungryState()
    {
     
    }

    void CaughtState()
    {

    }

    void UpdateFishPosition(float offSet)
    {
        Vector3 newPos = new Vector3(transform.localPosition.x, transform.localPosition.y + offSet, transform.localPosition.z);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + offSet, transform.localPosition.z);

        StartCoroutine(UpdatingPosition(newPos));
    }

    IEnumerator UpdatingPosition(Vector3 newPos)
    {
        float travelPersent = 0f;

        while (travelPersent < 100)
        {
            travelPersent += Time.deltaTime * 4f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, travelPersent);

            yield return new WaitForEndOfFrame();
        }
    }
}
