using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
    static int earnedPoints;

    // UI와 관련된 필드
    static TextMeshProUGUI pointText;
    static TextMeshProUGUI scoreText;
    static TextMeshProUGUI isFinishText;
    static TextMeshProUGUI deathCountText;

    // 초기화 관련 매서드 //
    void Awake()
    {
        // 게임매니저 객체가 없을 경우 초기화
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Init()
    {
        // 포인트 텍스트 있는지 확인
        if (GameObject.Find("UICanvas/Points"))
        {
            pointText = GameObject.Find("UICanvas/Points").GetComponent<TextMeshProUGUI>();
        }
        // 점수 텍스트 있는지 확인
        if (GameObject.Find("UICanvas/Score"))
        {
            scoreText = GameObject.Find("UICanvas/Score").GetComponent<TextMeshProUGUI>();
        }
        // 골 여부 텍스트 있는지 확인
        if (GameObject.Find("UICanvas/isFinish"))
        {
            isFinishText = GameObject.Find("UICanvas/isFinish").GetComponent<TextMeshProUGUI>();
        }
        // 데스카운트 텍스트있는지 확인
        if (GameObject.Find("UICanvas/deathCount"))
        {
            deathCountText = GameObject.Find("UICanvas/deathCount").GetComponent<TextMeshProUGUI>();
        }

        points = GameObject.FindGameObjectsWithTag("Point");
        isFinishText.enabled = false;
        UpdatePointCount();
        UpdateText(scoreText, $"Score: {score}");
        CheckIsFinish();
    }

    private void Start()
    {
        Init();
    }

    // 게임 포인트 관련 매서드 //
    // 게임 포인트 개수 세기
    static public void UpdatePointCount()
    {
        totalPointCount = points.Length;
        // Count 매서드는 https://stackoverflow.com/questions/1444615/using-c-sharp-count-with-a-function 를 참고했음.
        earnedPoints = points.Count(point => point.activeSelf == false);

        UpdateText(pointText, $"Point: {earnedPoints} / {totalPointCount}");
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
        if(totalPointCount == earnedPoints)
        {
            score += 10000;
            isFinishText.enabled = true;
            return true;
        }

        isFinishText.enabled = false;
        return false;
    }

    // 게임 규칙 관련 매서드 //
    // 게임 사망 처리
    static public void Dead()
    {
        deathCount += 1;
        score -= 10;
        ResetPointActive();
        //UpdateText($"");
        UpdateText(deathCountText,$"{deathCount}회 사망");
        UpdateText(scoreText, $"Score: {score}");
    }

    // UI 관련 매서드 //
    // 텍스트 갱신
    static void UpdateText(TextMeshProUGUI textObject, string text)
    {
        if(textObject != null)
        {
            textObject.text = text;
        }
    }
}
