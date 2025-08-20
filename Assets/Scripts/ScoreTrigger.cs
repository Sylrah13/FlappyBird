using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾� �±� ���� ������Ʈ�� ����
        {
            ScoreManager.Instance.AddScore(1);
        }
    }
}
