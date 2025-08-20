using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    [Tooltip("회전축 (보통 MainRotor=Up, TailRotor=Right/Forward)")]
    public Vector3 spinAxis = Vector3.up;

    [HideInInspector] public float rpm;  // 외부(컨트롤러)에서 세팅하는 현재 RPM

    void Update()
    {
        // RPM(분당회전수) → 초당 각도 = rpm * 360 / 60
        float degreesPerSecond = rpm * 6f; // 360/60 = 6
        transform.Rotate(spinAxis.normalized, degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
