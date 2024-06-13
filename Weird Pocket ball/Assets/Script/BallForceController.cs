using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallForceController : MonoBehaviour, IEndDragHandler
{
    public ScreenTouchManager touchManager;
    public Slider forceSlider;
    public GameObject ball;
    public GameObject cue;
    Rigidbody cueRb;
    float beforeValue;
    private void Start()
    {
        cueRb = cue.GetComponent<Rigidbody>();

    }
    public void MoveCue()
    {

        // �����̴� ���� ��ȭ���� ���
        float deltaValue = beforeValue - forceSlider.value;

        // ��ȭ���� ť���� ��ġ�� �ݿ�
        cue.transform.localPosition += new Vector3(0, 0, deltaValue * 10);

        // ���� �����̴� ���� ���� ������ ������Ʈ
        beforeValue = forceSlider.value;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        Debug.Log("isTouch"+ScreenTouchManager.isTouch);
        if (ScreenTouchManager.isTouch)
        {
            float force = forceSlider.value * 50;
            cueRb.AddForce(touchManager.rayPos * force, ForceMode.Impulse);
            ball.GetComponent<LineRenderer>().enabled = false;
            ScreenTouchManager.isTouch = false;
            GameManager.turn = !GameManager.turn;
        }
        forceSlider.value = 0;

    }
}
