using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // ������ �������� �̵�
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // ȭ�� ���ʿ��� ����� ����
        if (transform.position.x < -10f) // ���ڴ� ī�޶� ������ �°� ����
        {
        
        }
    }
}
