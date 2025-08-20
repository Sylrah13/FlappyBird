using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // 파이프 왼쪽으로 이동
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 화면 왼쪽에서 벗어나면 제거
        if (transform.position.x < -10f) // 숫자는 카메라 범위에 맞게 조정
        {
        
        }
    }
}
