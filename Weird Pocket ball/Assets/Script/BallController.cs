using UnityEngine;

public class BallController : MonoBehaviour
{
    public float stopThreshold = 1.5f; // ���� ���߰� �� �ӵ� �Ӱ谪
    private Rigidbody rb; // �� ������Ʈ�� ����� Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ������ �� Rigidbody ������Ʈ�� �����ɴϴ�
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        // ���� ���� �ӵ��� �˻��մϴ�
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero; // �ӵ��� 0���� �����Ͽ� ���� ����ϴ�
            rb.angularVelocity = Vector3.zero; // ���ӵ��� 0���� �����Ͽ� ȸ���� ����ϴ�
        }
    }
}
