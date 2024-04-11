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
        //라인렌더러 출력
           Debug.Log("OnMouseDown");
        //   //ShootCue(Input.mousePosition);
        ballSystem.OnLineRenderer();
    }
    private void OnMouseUp()
    {
        //라인렌더러 제거 및 발사
        Debug.Log("OnMouseUp");
        ballSystem.AddForce();
       
    }
    private void OnMouseDrag()
    {
        //라인렌더러 이동
        Debug.Log("OnMouseDrag" + Input.mousePosition);
        mousePosition = Input.mousePosition;
        ballSystem.DrowLineRenderer(Input.mousePosition);
       // ShootCue(Input.mousePosition);
    }
}
