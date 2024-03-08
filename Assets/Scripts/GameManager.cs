using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    // TODO //
    // ����Ʈ ���� ����
    // �������� �ʱ�ȭ, �̵� ����
    // ���� ����

    // �ʵ� //
    // �̱��� �ν��Ͻ�
    static GameManager instance;
    // ���� ������ ���õ� �ʵ�
    static int deathCount;
    static int score;
    static GameObject[] points;
    static int totalPointCount;
    static int earnedPoints;

    // UI�� ���õ� �ʵ�
    static TextMeshProUGUI pointText;
    static TextMeshProUGUI scoreText;
    static TextMeshProUGUI isFinishText;
    static TextMeshProUGUI deathCountText;

    // �ʱ�ȭ ���� �ż��� //
    void Awake()
    {
        // ���ӸŴ��� ��ü�� ���� ��� �ʱ�ȭ
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Init()
    {
        // ����Ʈ �ؽ�Ʈ �ִ��� Ȯ��
        if (GameObject.Find("UICanvas/Points"))
        {
            pointText = GameObject.Find("UICanvas/Points").GetComponent<TextMeshProUGUI>();
        }
        // ���� �ؽ�Ʈ �ִ��� Ȯ��
        if (GameObject.Find("UICanvas/Score"))
        {
            scoreText = GameObject.Find("UICanvas/Score").GetComponent<TextMeshProUGUI>();
        }
        // �� ���� �ؽ�Ʈ �ִ��� Ȯ��
        if (GameObject.Find("UICanvas/isFinish"))
        {
            isFinishText = GameObject.Find("UICanvas/isFinish").GetComponent<TextMeshProUGUI>();
        }
        // ����ī��Ʈ �ؽ�Ʈ�ִ��� Ȯ��
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

    // ���� ����Ʈ ���� �ż��� //
    // ���� ����Ʈ ���� ����
    static public void UpdatePointCount()
    {
        totalPointCount = points.Length;
        // Count �ż���� https://stackoverflow.com/questions/1444615/using-c-sharp-count-with-a-function �� ��������.
        earnedPoints = points.Count(point => point.activeSelf == false);

        UpdateText(pointText, $"Point: {earnedPoints} / {totalPointCount}");
    }
    // ���� ����Ʈ �ʱ�ȭ
    static public void ResetPointActive()
    {
        foreach(GameObject point in points)
        {
            point.SetActive(true);
        }
        UpdatePointCount();
    }

    // �� ���� �ż��� //
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

    // ���� ��Ģ ���� �ż��� //
    // ���� ��� ó��
    static public void Dead()
    {
        deathCount += 1;
        score -= 10;
        ResetPointActive();
        //UpdateText($"");
        UpdateText(deathCountText,$"{deathCount}ȸ ���");
        UpdateText(scoreText, $"Score: {score}");
    }

    // UI ���� �ż��� //
    // �ؽ�Ʈ ����
    static void UpdateText(TextMeshProUGUI textObject, string text)
    {
        if(textObject != null)
        {
            textObject.text = text;
        }
    }
}
