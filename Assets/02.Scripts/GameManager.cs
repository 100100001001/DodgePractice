using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public GameObject gameOverText;
    // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text timeText;
    // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;

    // ���� ���� �ð�
    private float surviveTime;
    private bool isGameOver;

    void Start()
    {
        // ���� �ð��� ���� ���� ���� �ʱ�ȭ
        surviveTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if (!isGameOver)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            // ���� ������ ���¿��� 'R' Ű�� �����ٸ�,
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // ���� ������ ���� ���� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���� ���� ���·� ��ȯ
        isGameOver = true;
        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameOverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ����� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��ϰ� ���� ���� �ð��� ��
        if (bestTime < surviveTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText ������Ʈ�� ǥ��
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
