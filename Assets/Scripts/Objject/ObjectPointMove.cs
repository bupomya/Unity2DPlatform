using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPointMove : MoveMent
{
    [SerializeField] private Transform[] turnPoint;

    private int curTurnPointIdx;

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (turnPoint.Length == 0) return;

        Transform targetWaypoint = turnPoint[curTurnPointIdx];

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (curTurnPointIdx < turnPoint.Length - 1)
                    curTurnPointIdx++;
            else
            {
                curTurnPointIdx--;
                IsRight = false;
            }
        }
    }
}