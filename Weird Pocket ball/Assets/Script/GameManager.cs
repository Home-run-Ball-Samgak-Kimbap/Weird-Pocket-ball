using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isStop = false;
    [SerializeField] private bool turn;
    [SerializeField] private int player1Count = 0;
    [SerializeField] private int player2Count = 0;

    public GameObject[] Balls;
    public GameObject cue;
    public GameObject playerBall;
    public GameObject balckBall;
    public GameObject resultUI;

    public bool player1Move = false;
    public bool player2Move = false;
    public bool boolMove;

    public TextMeshProUGUI result;

    public int countchecker = 3;
    float velocity;



    private void Start()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true;
    }

    public void BallMovementStatus()
    {
        cue.SetActive(false);
        Debug.Log("velocity" + velocity);
        StartCoroutine("CheckVelocity");
    }
    IEnumerator CheckVelocity()
    {
        do
        {
            velocity = 0;
            foreach (GameObject ball in Balls)
            {
                Rigidbody ballrig = ball.GetComponent<Rigidbody>();
                velocity += ballrig.velocity.magnitude;
            }
          //  Debug.Log("velocity" + velocity);
            yield return new WaitForSeconds(0.5f);
        } while (velocity > 0);
        ResetPosition();
        ScreenTouchManager.isTouch = false;
        StopCoroutine(CheckVelocity());
    }
    public void CheckScore(GameObject ball)
    {
        ball.SetActive(false);
        if (ball.name == "BlackBall")
        {
            if (turn) //player1턴
            {
                if (player1Count == countchecker)
                {
                    Debug.Log("BlackBall | Player1 승리");
                    result.text = "Player1\n승리";
                }
                else
                {
                    Debug.Log("BlackBall | player2 승리");
                    result.text = "Player2\n승리";
                }
            }
            else
            {
                if (player2Count == countchecker)
                {
                    Debug.Log("BlackBall | Player2 승리");
                    result.text = "Player2\n승리";
                }
                else
                {
                    Debug.Log("BlackBall | player1 승리");
                    result.text = "Player1\n승리";
                }
            }
            resultUI.SetActive(true);
        }
        else
        {
            if (turn)
            {//player1의 turn에서 player1공이 아닌 공을 넣으면
                if (ball.tag != "Player1")
                {
                    turn = false;
                    player2Count++;
                }
                else
                    player1Count++;
            }
            else
            {
                if (ball.tag != "Player2")
                {
                    turn = true;
                    player1Count++;
                }
                else
                    player2Count++;
            }
            //  ResetChildPosition();
        }
    }
        
    void ResetPosition()
    {
        Debug.Log("ResetCuePosition");
        //공 회전 초기화
        playerBall.transform.rotation = Quaternion.identity;
        //큐 힘 초기화
        cue.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cue.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //큐 위치 초기화
        cue.transform.localPosition = new Vector3(0, 0, -9);//cuePos;
        cue.transform.rotation = Quaternion.identity;
        cue.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("공굴러가유");
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (collision.gameObject.tag == "Ball")
        {
            turn = !turn;
            playerBall.transform.position = new Vector3(0, -24, 0);
        }
        else
            CheckScore(collision.gameObject);
    }
    public void GameEnd()
    {
        resultUI.SetActive(false);

    }
}
    
