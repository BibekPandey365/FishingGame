using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FishSpriteSwitcher : MonoBehaviour
{
    [SerializeField] Sprite normalImg;
    [SerializeField] Sprite hungryImg;

    FishStateHandler.FishState lastState;

    Animator animator;

    void Start()
    {
        lastState = FishStateHandler.FishState.Normal;

        animator = GetComponent<Animator>();
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

                animator.SetBool("IsHungry", false);
                break;

            case FishStateHandler.FishState.Hungry:
                this.GetComponent<SpriteRenderer>().sprite = hungryImg;
                lastState = FishStateHandler.FishState.Hungry;

                animator.SetBool("IsHungry", true);
                break;

            case FishStateHandler.FishState.Caught:
                this.GetComponent<SpriteRenderer>().sprite = normalImg;
                lastState = FishStateHandler.FishState.Caught;

                animator.SetBool("IsHungry", false);
                break;
        }
    }
}
