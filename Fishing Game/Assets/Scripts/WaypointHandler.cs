using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    [SerializeField] Transform[] placePoints;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] Transform[] holes;

    void Start()
    {
        PositionHoles();
    }

    void Update()
    {
        ProcessHoleMove();
    }

    void PositionHoles()
    {
        for (int i = 0; i < placePoints.Length; i++)
        {
            holes[i].transform.position = placePoints[i].position;
        }
    }

    void ProcessHoleMove()
    {
        foreach (Transform hole in holes)
        {
            for (int i = 0; i < wayPoints.Length; i++)
            {
                if (hole.position != wayPoints[i].position) continue;

                if (i != wayPoints.Length - 1)
                {
                    hole.GetComponent<HoleMover>().MoveHoleTo(wayPoints[i + 1]);
                }
                else
                {
                    hole.GetComponent<HoleMover>().MoveHoleTo(wayPoints[0]);
                }
            }
        }
    }
}
