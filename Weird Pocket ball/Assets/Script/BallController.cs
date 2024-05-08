using UnityEngine;

public class BallController : MonoBehaviour
{
    public float stopThreshold = 1.5f; // 공을 멈추게 할 속도 임계값
    private Rigidbody rb; // 이 컴포넌트에 연결된 Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 시작할 때 Rigidbody 컴포넌트를 가져옵니다
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        // 공의 현재 속도를 검사합니다
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero; // 속도를 0으로 설정하여 공을 멈춥니다
            rb.angularVelocity = Vector3.zero; // 각속도도 0으로 설정하여 회전을 멈춥니다
        }
    }
}
