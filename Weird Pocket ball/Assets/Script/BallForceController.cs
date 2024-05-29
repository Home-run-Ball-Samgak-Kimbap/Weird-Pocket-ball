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
      Debug.Log("cue.transform.position.x : " + cue.transform.position.x + "forceSlider.value : " + forceSlider.value);
      if(beforeValue > forceSlider.value)
        cue.transform.position += new Vector3(forceSlider.value * 10, 0, forceSlider.value * 10);
      else
        cue.transform.position -= new Vector3( forceSlider.value * 10 , 0, forceSlider.value * 10);
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
