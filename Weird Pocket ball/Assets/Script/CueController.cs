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
    public GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("cue.transform.position : " + this.gameObject.transform.position);
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.position * forceSlider.value, ForceMode.Impulse);
            isStart = true;
            this.gameObject.SetActive(false);
            gameManager.BallMovementStatus();
        }
        
    }
}
