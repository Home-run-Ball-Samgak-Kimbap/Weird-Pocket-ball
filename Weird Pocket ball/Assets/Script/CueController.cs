using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CueController : MonoBehaviour
{
    public Slider forceSlider;
    public ScreenTouchManager touchManager;
    public GameObject ball;
    public static bool isStart;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test1"+ScreenTouchManager.isTouch);

        if (ScreenTouchManager.isTouch)
        {
            ScreenTouchManager.isTouch = false;

            if (collision.gameObject.tag == "ball")
            {
                this.gameObject.SetActive(false);
                Debug.Log("cue.transform.position : " + this.gameObject.transform.position);
                ball.GetComponent<Rigidbody>().AddForce(ball.transform.position * forceSlider.value, ForceMode.Impulse);
                isStart = true;
            }

        }


    }
}
