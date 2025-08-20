using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;   // 생성할 파이프 프리팹
    public float spawnDelay = 4f;   // 딜레이 시간
    private float timeCheck = 0f;   // 시간 체크 변수

    public float minY = -2f;  // 파이프 위치 최소
    public float maxY = 2f;   // 파이프 위치 최대

    void Update()
    {
        timeCheck += Time.deltaTime;

        if (timeCheck >= spawnDelay)
        {
            SpawnPipe();
            timeCheck = 0f; // 리셋
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}
