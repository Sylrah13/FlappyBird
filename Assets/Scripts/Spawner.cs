using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;   // 생성할 파이프 프리팹
    public float spawnInterval = 2f; // 생성 간격
    public float pipeSpeed = 3f;    // 파이프 이동 속도
    public float minY = -2f;        // 랜덤 Y 최소값
    public float maxY = 2f;         // 랜덤 Y 최대값

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        // 현재 스포너 위치를 기준으로 Y축만 랜덤하게 바꿔서 생성
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, transform.position.z);

        GameObject newPipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        // 파이프 이동 스크립트 부착 (없으면 따로 만들어야 함)
        newPipe.AddComponent<PipeMove>().speed = pipeSpeed;
    }
}
