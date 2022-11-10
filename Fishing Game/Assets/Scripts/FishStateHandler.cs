using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateHandler : MonoBehaviour
{
    float switchTime;

    public enum FishState
    {
        Normal, Hungry, Caught,
    }

    FishState currentState;

    void Start()
    {
        currentState = FishState.Normal;

        switchTime = Random.Range(1f, 5f);
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
        if (currentState != FishState.Normal || currentState != FishState.Hungry) return;

        switchTime -= Time.deltaTime;
        if (switchTime < 0f)
        {
            NormalHungryStateSwitcher();
        }
    }

    void NormalHungryStateSwitcher()
    {
        if(currentState == FishState.Normal)
        {
            switchTime = 3f;

            currentState = FishState.Hungry;
        }
        else if(currentState == FishState.Hungry)
        {
            switchTime = Random.Range(5f, 10f);

            currentState = FishState.Normal;
        }

        Debug.Log(switchTime);
        print(currentState);
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
}
