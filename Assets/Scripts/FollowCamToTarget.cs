using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamToTarget : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = offset + target.transform.position;
        }
    }
}
