using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그 붙인 오브젝트만 감지
        {
            ScoreManager.Instance.AddScore(1);
        }
    }
}
