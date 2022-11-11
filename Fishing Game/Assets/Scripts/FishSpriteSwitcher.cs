using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpriteSwitcher : MonoBehaviour
{
    [SerializeField] Sprite normalImg;
    [SerializeField] Sprite hungryImg;

    FishStateHandler.FishState lastState;

    void Start()
    {
        lastState = FishStateHandler.FishState.Normal;
    }

    void Update()
    {

    }

    public void SpriteSwitcher(FishStateHandler.FishState state)
    {
        if (state == lastState) return;

        switch (state)
        {
            case FishStateHandler.FishState.Normal:
                this.GetComponent<SpriteRenderer>().sprite = normalImg;
                lastState = FishStateHandler.FishState.Normal;
                break;
            case FishStateHandler.FishState.Hungry:
                this.GetComponent<SpriteRenderer>().sprite = hungryImg;
                lastState = FishStateHandler.FishState.Hungry;
                break;
            case FishStateHandler.FishState.Caught:
                this.GetComponent<SpriteRenderer>().sprite = normalImg;
                lastState = FishStateHandler.FishState.Caught;
                break;
        }
    }
}
