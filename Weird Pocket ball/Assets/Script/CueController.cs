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
        cueLineRenderer.startWidth = 0.05f; // ���� ���� �ʺ�
        cueLineRenderer.endWidth = 0.05f; // ���� �� �ʺ�
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
        // ������ ���� ��ġ�� ���� ����
        Vector3 rayStart = transform.position; // ���� GameObject�� ��ġ
        Vector3 rayDirection = transform.forward; // GameObject�� ���� ����

        // ����ĳ��Ʈ ������ ������ RaycastHit ����
        RaycastHit hit;

        // ����ĳ��Ʈ ����
        if (Physics.Raycast(rayStart, rayDirection, out hit))
        {
            // ���̿� �浹�� ������Ʈ������ �Ÿ� ���
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
