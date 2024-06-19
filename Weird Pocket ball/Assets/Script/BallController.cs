using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isStop = true;
    private float stopThreshold = 0.1f;
    public AudioClip clip;
    public AudioSource audioSource;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
     //   Debug.Log("isStop : " + isStop);
        
        // Debug.Log(rb.velocity.magnitude);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = clip;
        audioSource.Play();
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name != "CornerCollisionDetector")
        {
            if (rb.velocity.magnitude < stopThreshold)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                isStop = true; //����
            }
           // else if (rb.velocity == Vector3.zero)
             //   isStop = true;
            else
                isStop = false;
        }
        
    }
}
