using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HelicopterController : MonoBehaviour
{
    [Header("�÷�(����)")]
    public float flapForce = 5f;

    [Header("�����緯 RPM")]
    public float idleRPM = 800f;        // �⺻ ȸ����(�õ� �ɸ� ����)
    public float maxRPM = 1800f;        // �ν�Ʈ ����
    public float boostRPM = 500f;       // �� �� �÷��� �� �÷��� ��
    public float rpmDecayPerSec = 300f; // �ʴ� ���ӷ�

    [Header("���� ����")]
    public RotorSpin mainRotor;         // ���η��� (spinAxis = Up)
    public RotorSpin tailRotor;         // ���Ϸ��� (spinAxis = Right �Ǵ� Forward)
    public float tailRotorRPMScale = 0.25f; // ���Ϸ��ʹ� ���� ���κ��� ����

    [Header("�ɼ�: ����")]
    public AudioSource rotorAudio;      // ���� ����(����)
    public float minPitch = 0.8f;
    public float maxPitch = 1.3f;

    Rigidbody rb;
    float currentRPM;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // ���� �� ���̵� RPM����
        currentRPM = idleRPM;

        // ���� ����ȭ(������ �������� �� ����)
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ;
        // �ʿ��ϸ� ��ġ Z�� ����: rb.constraints |= RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        // �����̽� �� �� ������ ���� �÷�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� ������ (�ӵ� �ʱ�ȭ �� ���޽�)
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);

            // RPM �ν�Ʈ
            currentRPM = Mathf.Min(currentRPM + boostRPM, maxRPM);
        }

        // �ð��� �������� ������ ���� �� idleRPM���� ����
        if (currentRPM > idleRPM)
        {
            currentRPM = Mathf.Max(idleRPM, currentRPM - rpmDecayPerSec * Time.deltaTime);
        }
        else
        {
            // (���ϸ� �õ� �������� idle���� õõ�� �ö����)
            currentRPM = Mathf.MoveTowards(currentRPM, idleRPM, rpmDecayPerSec * 0.5f * Time.deltaTime);
        }

        // ���Ϳ� RPM �ݿ�
        if (mainRotor) mainRotor.rpm = currentRPM;
        if (tailRotor) tailRotor.rpm = currentRPM * tailRotorRPMScale;

        // ���� ��ġ ����(����)
        if (rotorAudio)
        {
            float t = Mathf.InverseLerp(idleRPM, maxRPM, currentRPM);
            rotorAudio.pitch = Mathf.Lerp(minPitch, maxPitch, t);
        }
    }
}
