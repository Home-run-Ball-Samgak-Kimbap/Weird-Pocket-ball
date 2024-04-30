using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenTouchManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject cue;
    public Vector3 prevPos;
    LineRenderer cueLineRenderer;
    private void Start()
    {
        cueLineRenderer = ball.GetComponent<LineRenderer>();
        cueLineRenderer.startWidth = 0.05f; // ���� ���� �ʺ�
        cueLineRenderer.endWidth = 0.05f; // ���� �� �ʺ�
    }

    private void OnMouseDown()
    {
        prevPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        cueLineRenderer.GetComponent<LineRenderer>().enabled = true;
        cue.SetActive(true);
       
    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        cueLineRenderer.GetComponent<LineRenderer>().enabled = false;
        cue.SetActive(false);
       
    }
    private void OnMouseDrag()
    {
        


            //cueController.DrowLineRenderer(mousePos);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); // ���콺 ��ġ
        Vector2 direction = (prevPos - mousePos).normalized;
        Vector3 rayPos = new Vector3(direction.x, 0, direction.y);
        Vector3 lineRednderPos = new Vector3(direction.x, ball.transform.position.y / 5, direction.y);

        RaycastHit hit;
        Debug.DrawRay(ball.transform.position, rayPos * 15, Color.red);
        Physics.Raycast(ball.transform.position, rayPos, out hit);
        Debug.Log(hit.distance);
        cueLineRenderer.SetPosition(0, ball.transform.position);
        cueLineRenderer.SetPosition(1, lineRednderPos * hit.distance);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // -90�� ����
        ball.transform.rotation = Quaternion.Euler(0, -angle, 0); // ȸ�� ����
    }
}
