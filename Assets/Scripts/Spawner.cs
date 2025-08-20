using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;   // ������ ������ ������
    public float spawnDelay = 4f;   // ������ �ð�
    private float timeCheck = 0f;   // �ð� üũ ����

    public float minY = -2f;  // ������ ��ġ �ּ�
    public float maxY = 2f;   // ������ ��ġ �ִ�

    void Update()
    {
        timeCheck += Time.deltaTime;

        if (timeCheck >= spawnDelay)
        {
            SpawnPipe();
            timeCheck = 0f; // ����
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}
