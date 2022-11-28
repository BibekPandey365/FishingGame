using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField] Transform hook;
    //[SerializeField] Transform net;
    [SerializeField] GameObject FishingNet;

    [SerializeField] float speedModifier = 0.012f;

    public GameObject caughtFish;

    void Start()
    {
        caughtFish = null;
    }

    void Update()
    {
        if (InGameMenu.isGameOver) return;
        MoveRod();
    }

    private void MoveRod()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (caughtFish == null)
        {
            if (collision.tag == "Fish")
            {
                CatchFish(collision.gameObject);
            }
        }
    }

    void CatchFish(GameObject fish)
    {
        if (fish == null) return;

        if (fish.GetComponent<FishStateHandler>().currentState == FishStateHandler.FishState.Hungry)
        {
            fish.gameObject.SetActive(false);  //Changing parent of fish is creating a wired visual glitch of setting fish inactive before changing position
            caughtFish = fish;
            caughtFish.transform.SetParent(hook);
            caughtFish.gameObject.SetActive(true);

            caughtFish.transform.position = new Vector3(hook.position.x, hook.position.y, transform.position.z);
            caughtFish.transform.localPosition = new Vector3(0f, 0f, transform.localPosition.z);
            caughtFish.GetComponent<FishStateHandler>().currentState = FishStateHandler.FishState.Caught;
            caughtFish.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            caughtFish.GetComponent<SpriteRenderer>().sortingOrder = SortingLayer.NameToID("Caught");

            FishingNet.GetComponent<FishingNet>().PlayNetInAnmation();

            FindObjectOfType<AudioManager>().Play("CatchFish");
        }
    }
}
