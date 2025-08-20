using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 5f;
    public float gravityScale = 2f;

    [Header("프로펠러 회전")]
    public Transform[] propellers;          // 메인 + 보조 다 넣어주기
    public float baseRotateSpeed = 400f;    // 평상시 속도
    public float boostRotateSpeed = 3200f;   // 점프 시 속도
    private float currentRotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        currentRotateSpeed = baseRotateSpeed;
    }

    void Update()
    {
        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector3(0, jumpForce, 0);
            currentRotateSpeed = boostRotateSpeed; // 순간 가속
        }

        // 인위적 중력
        rb.AddForce(Vector3.down * gravityScale);

        // 모든 프로펠러 회전
        foreach (Transform p in propellers)
        {
            if (p != null)
                p.Rotate(Vector3.up * currentRotateSpeed * Time.deltaTime);
        }

        // 부드럽게 기본 속도로 복귀
        currentRotateSpeed = Mathf.Lerp(currentRotateSpeed, baseRotateSpeed, Time.deltaTime * 2f);
    }
}
