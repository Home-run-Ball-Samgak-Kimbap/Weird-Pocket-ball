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
        //���η����� ���
           Debug.Log("OnMouseDown");
        //   //ShootCue(Input.mousePosition);
      //  ballSystem.OnLineRenderer();
    }
    private void OnMouseUp()
    {
        //���η����� ���� �� �߻�
        Debug.Log("OnMouseUp");
        //ballSystem.AddForce();
    //    cueController.AddForce();
       
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); // ���콺 ��ġ
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0; // z ��ǥ�� 0���� ������ 2D �÷��ο� ����
        cueController.DrowLineRenderer(mousePos);

        Vector2 direction = (worldPos - cue.transform.position).normalized; // �籸�뿡�� ���콺 ��ġ���� ���� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; // -90�� ����
        cue.transform.rotation = Quaternion.Euler(0, angle, 0); // ȸ�� ����
    }
}
