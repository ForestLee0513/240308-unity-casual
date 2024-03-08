using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    // TODO //
    // 포인트 개수 관리
    // 스테이지 초기화, 이동 관리
    // 점수 관리

    // 필드 //
    // 싱글톤 인스턴스
    static GameManager instance;
    // 게임 점수와 관련된 필드
    static int deathCount;
    static int score;
    static GameObject[] points;
    static int totalPointCount;
    static int disabledPointCount;

    // UI와 관련된 필드
    GameObject UICavnas;

    // 초기화 관련 매서드 //
    void Awake()
    {
        // 게임매니저 객체가 없을 경우 초기화
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // 현재 씬의 모든 포인트 목록을 변수로 지정
        points = GameObject.FindGameObjectsWithTag("Point");
        UpdatePointCount();
        Debug.Log(score);
    }

    // 게임 포인트 관련 매서드 //
    // 게임 포인트 개수 세기
    static public void UpdatePointCount()
    {
        totalPointCount = points.Length;
        disabledPointCount = points.Count(point => point.activeSelf == false);

        Debug.Log(totalPointCount);
        Debug.Log(disabledPointCount);
    }
    // 게임 포인트 초기화
    static public void ResetPointActive()
    {
        foreach(GameObject point in points)
        {
            point.SetActive(true);
        }
        UpdatePointCount();
    }

    // 골 관련 매서드 //
    static public bool CheckIsFinish()
    {
        if(totalPointCount == disabledPointCount)
        {
            score += 10000;

            return true;
        }

        return false;
    }

    // 게임 규칙 관련 매서드 //
    // 게임 사망 처리
    static public void Dead()
    {
        deathCount += 1;
        score -= 10;
        ResetPointActive();
    }
}
