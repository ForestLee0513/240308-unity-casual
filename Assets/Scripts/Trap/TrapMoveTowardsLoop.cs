using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMoveTowardsLoop : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 maxPos;
    public float speed;
    bool isReachToMaxPos;

    void Update()
    {
        float step = speed * Time.deltaTime;
        if(isReachToMaxPos)
        {
            if(transform.position == startPos)
            {
                isReachToMaxPos = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else
        {
            if (transform.position == maxPos)
            {
                isReachToMaxPos = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, maxPos, step);
        }
    }
}
