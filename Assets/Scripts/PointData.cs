using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointData : MonoBehaviour
{
    // ����Ʈ �浹 �� ���� �߰���û �� ����Ʈ ��ü ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
