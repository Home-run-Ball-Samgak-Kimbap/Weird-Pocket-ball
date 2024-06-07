using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTouchManager : MonoBehaviour
{
    public GameObject ball;
    //public GameObject cue;
    public Vector3 rayPos;
    public static bool isTouch;


    LineRenderer cueLineRenderer;
    Vector3 prevPos;
    private void Start()
    {
        cueLineRenderer = ball.GetComponent<LineRenderer>();
        cueLineRenderer.startWidth = 0.05f; // 선의 시작 너비
        cueLineRenderer.endWidth = 0.05f; // 선의 끝 너비
    }

    private void OnMouseDown()
    {
        
        prevPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        cueLineRenderer.GetComponent<LineRenderer>().enabled = true;
        isTouch = true;
        //cue.SetActive(true);
       
    }
    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
       
    }
    private void OnMouseDrag()
    {
        ball.GetComponent<LineRenderer>().enabled = true;

        //cueController.DrowLineRenderer(mousePos);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); // 마우스 위치
        Vector2 direction = (prevPos - mousePos).normalized;
        //Debug.Log(direction);
        rayPos = new Vector3(direction.x, 0, direction.y);

        RaycastHit hit;
       // Debug.DrawRay(ball.transform.position, rayPos * 15, Color.red);
        Physics.Raycast(ball.transform.position, rayPos, out hit);
       // Debug.Log(hit.distance);
        Vector3 lineRednderPos = new Vector3(direction.x * hit.distance, 0, direction.y * hit.distance);

        cueLineRenderer.SetPosition(0, ball.transform.position);
        cueLineRenderer.SetPosition(1, ball.transform.position + lineRednderPos);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // -90도 조정
        ball.transform.rotation = Quaternion.Euler(0, -angle, 0); // 회전 적용
    }
}
