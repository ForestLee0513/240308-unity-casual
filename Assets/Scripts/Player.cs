using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // TO DO //
    // 이동 구현
    // 포인트 충돌 시 점수 추가요청 후 포인트 객체 삭제
    // 골 지점에 도달했다면 다음 스테이지 이동 요청
    // 함정이나 월드 바깥 영역에 충돌됐다면 스테이지 초기화 요청

    void Update()
    {
        // axisRaw의 vertical과 horizon으로 x,z축 이동
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * 3f);
    }
}
