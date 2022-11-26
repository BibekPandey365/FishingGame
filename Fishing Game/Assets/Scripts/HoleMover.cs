using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveHoleTo(Transform waypoint)
    {
        /*if (transform.position != waypoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);
        }*/

        StartCoroutine(PlayerMoving(waypoint));
    }

    IEnumerator PlayerMoving(Transform waypoint)
    {
        float travelPersent = 0f;

        while (travelPersent < 100)
        {
            travelPersent += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(transform.position, waypoint.position, travelPersent);

            yield return new WaitForEndOfFrame();
        }
    }
}
