using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // �̱���
    private int score = 0;

    void Awake()
    {
        // �̱��� �ʱ�ȭ
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("���� ����: " + score);
    }
}
