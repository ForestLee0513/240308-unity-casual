using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 initialPosition;
    public float speed;

    void Start()
    {
       initialPosition = transform.position;
    }

    void Update()
    {
        // axisRaw�� vertical�� horizon���� x,z�� �̵�
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * 3f);
    }

    private void OnCollisionExit(Collision collision)
    {
        // y�� �ʱⰪ�� ���� ���������� ������ ������ ����.
        if(transform.position.y < initialPosition.y)
        {
            transform.position = initialPosition;
            GameManager.Dead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹
        if (collision.gameObject.tag == "Trap")
        {
            GameManager.Dead();
        }
    }
}
