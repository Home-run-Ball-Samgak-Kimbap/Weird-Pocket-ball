using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static bool turn;
    [SerializeField] private int player1Count = 0;
    [SerializeField] private int player2Count = 0;

    public GameObject[] Balls;
    public GameObject cue;
    public GameObject playerBall;
    public GameObject balckBall;
    public GameObject resultUI;
    public GameObject gameSet;
    public GameObject resetPos;

    public Vector3 cuePos;


    public TextMeshProUGUI result;
    public TextMeshProUGUI turnUI;

    public int countchecker = 3;
    public float velocity;


    private void Start()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true;
    }
    

    public void BallMovementStatus()
    {
        cue.SetActive(false);
       // Debug.Log("velocity" + velocity);
        StartCoroutine("CheckVelocity");
    }
    IEnumerator CheckVelocity()
    {
        yield return new WaitForSeconds(0.5f);

        //멈추기를 기다림
        do
        {
            velocity = 0;
            foreach (GameObject ball in Balls)
            {
                Rigidbody ballrig = ball.GetComponent<Rigidbody>();
                velocity += ballrig.velocity.magnitude;
                Debug.Log("name : "+ball.name+"velocity : " + velocity);

            }
            Debug.Log("!velocity : " + velocity);

            yield return new WaitForSeconds(0.5f);
        } while (velocity > 0);
        Debug.Log("멈췄나요?");
        playerBall.SetActive(true);
        ResetPosition();
        ScreenTouchManager.isTouch = false;

        if (turn)
            turnUI.text = "Player 1";
        else
            turnUI.text = "Player 2";
        StopCoroutine(CheckVelocity());
    }
    public void CheckScore(GameObject ball)
    {
        ball.SetActive(false);

        if (ball.name == "BlackBall")
        {
            ChangeTurn();
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
                    ChangeTurn();
                    player2Count++;
                }
                else
                    player1Count++;
            }
            else
            {
                if (ball.tag != "Player2")
                {
                    ChangeTurn();
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
        cue.transform.localPosition = cuePos;//new Vector3(0, 0, -12);//cuePos;
        cue.transform.localRotation = Quaternion.Euler(0, -90, 0);// Quaternion.identity;
        cue.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("공굴러가유");
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("공 빠지다..");
            //playerBall.transform.position = new Vector3(0, -24, 0);
            playerBall.transform.rotation = Quaternion.identity;
            playerBall.GetComponent<Transform>().localPosition = new Vector3(-15, -4, -4);//resetPos.GetComponent<Transform>().position;
        }
        else
            CheckScore(collision.gameObject);
    }
    public void GameEnd()
    {
        gameSet.SetActive(false);
        resultUI.SetActive(false);

    }
    void ChangeTurn()
    {
        turn = !turn;
    }
}
    
