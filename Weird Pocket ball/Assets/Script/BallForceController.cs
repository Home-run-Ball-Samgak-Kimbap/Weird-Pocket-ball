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
        // 슬라이더 값의 변화량을 계산
        float deltaValue = beforeValue - forceSlider.value;

        // 변화량을 큐대의 위치에 반영
        cue.transform.localPosition += new Vector3(0, 0, deltaValue * 10);

        // 현재 슬라이더 값을 이전 값으로 업데이트
        beforeValue = forceSlider.value;
        /*
      Debug.Log("cue.transform.position.x : " + cue.transform.position.x + "forceSlider.value : " + forceSlider.value);
      if(beforeValue > forceSlider.value)
        cue.transform.position += new Vector3(forceSlider.value , 0, forceSlider.value);
      else
        cue.transform.position -= new Vector3(forceSlider.value, 0, forceSlider.value);
      beforeValue = forceSlider.value;
        */
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        float force = forceSlider.value * 50;
        forceSlider.value = 0;


        cueRb.AddForce(touchManager.rayPos * force, ForceMode.Impulse);
        ball.GetComponent<LineRenderer>().enabled = false;
    }
}
