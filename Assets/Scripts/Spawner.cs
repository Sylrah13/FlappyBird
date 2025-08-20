using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;   // ������ ������ ������
    public float spawnInterval = 2f; // ���� ����
    public float pipeSpeed = 3f;    // ������ �̵� �ӵ�
    public float minY = -2f;        // ���� Y �ּҰ�
    public float maxY = 2f;         // ���� Y �ִ밪

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
        // ���� ������ ��ġ�� �������� Y�ุ �����ϰ� �ٲ㼭 ����
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, transform.position.z);

        GameObject newPipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        // ������ �̵� ��ũ��Ʈ ���� (������ ���� ������ ��)
        newPipe.AddComponent<PipeMove>().speed = pipeSpeed;
    }
}
