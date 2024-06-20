using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool isStop = true;
    private float stopThreshold = 1.3f;
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
      //  StartCoroutine(DecelerateOverTime());
        
    }/*
    IEnumerator DecelerateOverTime()
    {
        while (rb.velocity.magnitude > stopThreshold)
        {
            if (rb.velocity.magnitude > 1.5f)
            {
                rb.velocity *= 0.8f;
            }
            else
            {
                rb.velocity *= 0.3f;
            }
            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("ekdrmdke?");
        // 감속이 끝나면 속도를 완전히 멈추고 Coroutine을 종료합니다.
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isStop = true; // 움직임이 멈춤을 표시하는 변수
    }
    */
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
