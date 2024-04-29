using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouchManager : MonoBehaviour
{
    [SerializeField] private BallSystem ballSystem;
   // [SerializeField] private CueController cueController;

    public GameObject cue;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    private CueController cueController;
    private void Start()
    {
        cueController = cue.GetComponent<CueController>();    
    }
    private void OnMouseDown()
    {
        //라인렌더러 출력
           Debug.Log("OnMouseDown");
        //   //ShootCue(Input.mousePosition);
      //  ballSystem.OnLineRenderer();
    }
    private void OnMouseUp()
    {
        //라인렌더러 제거 및 발사
        Debug.Log("OnMouseUp");
        //ballSystem.AddForce();
    //    cueController.AddForce();
       
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); // 마우스 위치
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0; // z 좌표는 0으로 설정해 2D 플레인에 맞춤
        cueController.DrowLineRenderer(mousePos);

        Vector2 direction = (worldPos - cue.transform.position).normalized; // 당구대에서 마우스 위치로의 방향 벡터
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // -90도 조정
        cue.transform.rotation = Quaternion.Euler(0, angle, 0); // 회전 적용
    }
}
