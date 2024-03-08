using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    static int disabledPointCount;

    // UI�� ���õ� �ʵ�
    GameObject UICavnas;

    // �ʱ�ȭ ���� �ż��� //
    void Awake()
    {
        // ���ӸŴ��� ��ü�� ���� ��� �ʱ�ȭ
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // ���� ���� ��� ����Ʈ ����� ������ ����
        points = GameObject.FindGameObjectsWithTag("Point");
        UpdatePointCount();
        Debug.Log(score);
    }

    // ���� ����Ʈ ���� �ż��� //
    // ���� ����Ʈ ���� ����
    static public void UpdatePointCount()
    {
        totalPointCount = points.Length;
        disabledPointCount = points.Count(point => point.activeSelf == false);

        Debug.Log(totalPointCount);
        Debug.Log(disabledPointCount);
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
        if(totalPointCount == disabledPointCount)
        {
            score += 10000;

            return true;
        }

        return false;
    }

    // ���� ��Ģ ���� �ż��� //
    // ���� ��� ó��
    static public void Dead()
    {
        deathCount += 1;
        score -= 10;
        ResetPointActive();
    }
}
