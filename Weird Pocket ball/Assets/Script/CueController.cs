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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            this.gameObject.SetActive(false);
            ball.GetComponent<Rigidbody>().AddForce(touchManager.rayPos * forceSlider.value * 50, ForceMode.Impulse);

        }

    }
}
