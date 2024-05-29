using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isMove = false;
    [SerializeField] private bool turn;
    [SerializeField] private int player1Count = 0;
    [SerializeField] private int player2Count = 0;

    public GameObject player1Balls;
    public GameObject[] player1BallsChildren;
    public GameObject player2Balls;
    public GameObject[] player2BallsChildren;
    public GameObject cue;
    public GameObject playerBall;

    Vector3 cuePos;

    bool callCheck;


    public int countchecker = 3;
    private void Update()
    {
        if (CueController.isStart)
        {
            CueController.isStart = false;
            StartCoroutine(CallBallMovementStatus());
        }
    }
    private void Start()
    {
        GameStart();
        cuePos = cue.transform.position;
        Debug.Log("cue.transform.position : " + cue.transform.localPosition);

    }
    public void GameStart()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true; //player 1 turn
        player1BallsChildren = player1Balls.GetComponentsInChildren<GameObject>();
        player2BallsChildren = player2Balls.GetComponentsInChildren<GameObject>();
    }
    IEnumerator CallBallMovementStatus()
    {
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("ekdrms? 555");

        StartCoroutine(BallMovementStatus());      
    }
    IEnumerator BallMovementStatus()
    {
        bool player1Move = false;
        bool player2Move = false;
        foreach (GameObject ball in player1BallsChildren)
        {            
            if (!ball.GetComponent<BallController>().isStop)
            {
                player1Move = true;
            }
        }
        foreach (GameObject ball in player1BallsChildren)
        {
            if (!ball.GetComponent<BallController>().isStop) // ������ �Ӱ谪���� ũ�� �����̰� �ִٰ� �Ǵ�
            {
                player2Move = true;
            }
        }
        if (!player1Move && !player2Move) isMove = false; //��� ���� ���� ��쿡

        if (isMove)
            yield return new WaitForSeconds(0.5f);
        else
        {
            //����ٸ�
            /*if (callCheck) //
            {
                turn = !true;
                callCheck = false;
            }*/
            ResetChildPosition();
            yield break;
        }
    }
    public void CheckScore(GameObject ball)
    {
        if (ball.name == "Ball")
        {
            turn = !turn;
            playerBall.transform.position = new Vector3(0, -24, 0);
            playerBall.transform.rotation = Quaternion.identity;   
        }
        else
        {

            if (ball.name == "BlackBall")
            {
                if (turn) //player1��
                {
                    if (player1Count == countchecker)
                        Debug.Log("BlackBall | Player1 �¸�");
                    else
                        Debug.Log("BlackBall | player2 �¸�");
                }

                else
                {
                    if (player2Count == countchecker)
                        Debug.Log("BlackBall | Player2 �¸�");
                    else
                        Debug.Log("BlackBall | player1 �¸�");
                }
            }
            else
            {
                if (turn)
                {//player1�� turn���� player1���� �ƴ� ���� ������
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
    }
    void ResetChildPosition()
    {
        Debug.Log("ResetCuePosition");
        //�� ȸ�� �ʱ�ȭ
        playerBall.transform.rotation = Quaternion.identity;
        //ť �� �ʱ�ȭ
        cue.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cue.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //ť ��ġ �ʱ�ȭ
        cue.transform.localPosition = new Vector3(0, 0, -9);//cuePos;
        cue.transform.rotation = Quaternion.identity;
        cue.SetActive(true);
        Debug.Log("ekdrms?");
    }
    private void OnCollisionEnter(Collision collision)
    {
        callCheck = true;
        Debug.Log("����������");
        CheckScore(collision.gameObject);
        collision.gameObject.SetActive(false);
//        collision.gameObject.GetComponent<Collider>().enabled = false;
    }
}
    
