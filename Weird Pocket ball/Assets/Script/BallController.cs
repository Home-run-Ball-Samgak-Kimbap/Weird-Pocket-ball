using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isStop;
    public float stopThreshold = 1.5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
       // Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
            isStop = true;
        }
        else
            isStop = false;
    }
}
