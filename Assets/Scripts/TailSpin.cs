using UnityEngine;

public class TailSpin : MonoBehaviour
{
    public float spinSpeed = 1000f; // ȸ�� �ӵ�

    void Update()
    {
        transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);
    }
}
