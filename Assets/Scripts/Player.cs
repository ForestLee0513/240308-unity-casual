using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // TO DO //
    // �̵� ����
    // ����Ʈ �浹 �� ���� �߰���û �� ����Ʈ ��ü ����
    // �� ������ �����ߴٸ� ���� �������� �̵� ��û
    // �����̳� ���� �ٱ� ������ �浹�ƴٸ� �������� �ʱ�ȭ ��û

    void Update()
    {
        // axisRaw�� vertical�� horizon���� x,z�� �̵�
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * 3f);
    }
}
