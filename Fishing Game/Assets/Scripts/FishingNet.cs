using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FishingNet : MonoBehaviour
{
    [SerializeField] Transform net;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fish")
        {
            collision.gameObject.transform.SetParent(net);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = SortingLayer.NameToID("Defult");

            animator.SetInteger("NetState", 2);
            StartCoroutine("DestroyFish", collision.gameObject);

            //Add Score
            ScoreManager.score++;

            FindObjectOfType<AudioManager>().Play("Pull");
        }
    }

    public void PlayNetInAnmation()
    {
        animator.SetInteger("NetState", 1);
    }

    IEnumerator DestroyFish(GameObject fish)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(fish);
        FindObjectOfType<FishingRod>().caughtFish = null;
        animator.SetInteger("NetState", 0);
    }
}
