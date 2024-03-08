using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 이동 구현

    void Update()
    {
        // axisRaw의 vertical과 horizon으로 x,z축 이동
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime);
    }
}
