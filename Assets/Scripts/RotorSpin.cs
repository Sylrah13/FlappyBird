using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    [Tooltip("ȸ���� (���� MainRotor=Up, TailRotor=Right/Forward)")]
    public Vector3 spinAxis = Vector3.up;

    [HideInInspector] public float rpm;  // �ܺ�(��Ʈ�ѷ�)���� �����ϴ� ���� RPM

    void Update()
    {
        // RPM(�д�ȸ����) �� �ʴ� ���� = rpm * 360 / 60
        float degreesPerSecond = rpm * 6f; // 360/60 = 6
        transform.Rotate(spinAxis.normalized, degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
