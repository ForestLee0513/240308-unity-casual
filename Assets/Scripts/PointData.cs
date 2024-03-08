using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointData : MonoBehaviour
{
    // 포인트 충돌 시 점수 추가요청 후 포인트 객체 삭제

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
