using UnityEngine;

public class TailSpin : MonoBehaviour
{
    public float spinSpeed = 1000f; // 회전 속도

    void Update()
    {
        transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);
    }
}
