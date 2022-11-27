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

                FindObjectOfType<AudioManager>().Play("CatchFish");
            }
        }
    }

    void CatchFish(GameObject fish)
    {
        if (fish == null) return;

        if (fish.GetComponent<FishStateHandler>().currentState == FishStateHandler.FishState.Hungry)
        {
            caughtFish = fish;
            caughtFish.GetComponent<FishStateHandler>().currentState = FishStateHandler.FishState.Caught;
            caughtFish.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            caughtFish.GetComponent<SpriteRenderer>().sortingOrder = SortingLayer.NameToID("Caught");
            caughtFish.transform.SetParent(hook);
            caughtFish.transform.position = new Vector3(hook.position.x - 2f, hook.position.y, transform.position.z);

            FishingNet.GetComponent<FishingNet>().PlayNetInAnmation();
        }
    }


    IEnumerator DestroyFish()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(caughtFish);
        caughtFish = null;
    }
}
