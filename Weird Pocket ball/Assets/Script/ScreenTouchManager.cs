using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouchManager : MonoBehaviour
{
    [SerializeField] private BallSystem ballSystem;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        //���η����� ���
           Debug.Log("OnMouseDown");
        //   //ShootCue(Input.mousePosition);
        ballSystem.OnLineRenderer();
    }
    private void OnMouseUp()
    {
        //���η����� ���� �� �߻�
        Debug.Log("OnMouseUp");
        ballSystem.AddForce();
       
    }
    private void OnMouseDrag()
    {
        //���η����� �̵�
        Debug.Log("OnMouseDrag" + Input.mousePosition);
        mousePosition = Input.mousePosition;
        ballSystem.DrowLineRenderer(Input.mousePosition);
       // ShootCue(Input.mousePosition);
    }
}
