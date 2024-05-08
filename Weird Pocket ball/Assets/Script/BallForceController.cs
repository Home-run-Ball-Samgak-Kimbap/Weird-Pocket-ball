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
    private void Start()
    {
        cueRb = cue.GetComponent<Rigidbody>();

    }
    public void MoveCue()
    {
        cue.transform.position -= touchManager.rayPos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        float force = forceSlider.value * 100;
        forceSlider.value = 0;


        cueRb.AddForce(touchManager.rayPos * force, ForceMode.Impulse);
        ball.GetComponent<LineRenderer>().enabled = false;
    }
}
