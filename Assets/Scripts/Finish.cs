using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string changeTargetSceneName;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // ���� ������ �������� Ȯ��
            if (GameManager.CheckIsFinish())
            {
                SceneManager.LoadScene(changeTargetSceneName);
            }
        }
    }
}
