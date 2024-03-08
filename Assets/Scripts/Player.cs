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
        // axisRaw의 vertical과 horizon으로 x,z축 이동
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * 3f);
    }

    private void OnCollisionExit(Collision collision)
    {
        // y가 초기값에 비해 낮아졌으면 떨어진 것으로 판정.
        if(transform.position.y < initialPosition.y)
        {
            transform.position = initialPosition;
            GameManager.Dead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 함정 충돌
        if (collision.gameObject.tag == "Trap")
        {
            GameManager.Dead();
        }
    }
}
