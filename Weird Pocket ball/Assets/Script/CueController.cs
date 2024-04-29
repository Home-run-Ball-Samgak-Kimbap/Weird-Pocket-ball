using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour
{

    public LineRenderer cueLineRenderer;
    private ScreenTouchManager screenTouchManager;
    private Vector3 forceDirection;
    private float forceMagnitude;
    public float length = 5f;
    public GameObject tip;
    public GameObject ball;

    public GameObject endObj;

    private void Start()
    {
        cueLineRenderer.startWidth = 0.05f; // 선의 시작 너비
        cueLineRenderer.endWidth = 0.05f; // 선의 끝 너비
    }
    public void OnLineRenderer()
    {
        cueLineRenderer.enabled = true;
    }
    public void DrowLineRenderer(Vector3 mousePosition)
    {
       // Vector2 direction = (worldPos - cue.transform.position).normalized;
        //Vector3 endPos = (tip.transform.position - endObj.transform.position).normalized;
        //mousePosition);
                                                                  //forceDirection = (ray.GetPoint(5f) - transform.position).normalized;
                                                                  // forceDirection = (endPos - transform.position).normalized;
        /// forceMagnitude = (endPos - transform.position).magnitude * 500f;
        /// 
        // 레이의 시작 위치와 방향 설정
        Vector3 rayStart = transform.position; // 현재 GameObject의 위치
        Vector3 rayDirection = transform.forward; // GameObject의 전방 방향

        // 레이캐스트 정보를 저장할 RaycastHit 변수
        RaycastHit hit;

        // 레이캐스트 실행
        if (Physics.Raycast(rayStart, rayDirection, out hit))
        {
            // 레이와 충돌한 오브젝트까지의 거리 출력
            Debug.Log("Hit " + hit.collider.gameObject.name + " at distance: " + hit.distance);
            cueLineRenderer.SetPosition(0, tip.transform.position);
            cueLineRenderer.SetPosition(1, hit.transform.position);
        }
        else
        {
            cueLineRenderer.SetPosition(0, ball.transform.position);
            cueLineRenderer.SetPosition(1, endObj.transform.position);
        }//endObj.transform.position);
    }

    public void AddForce()
    {
        cueLineRenderer.enabled = false;
        this.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude);
    }
}
