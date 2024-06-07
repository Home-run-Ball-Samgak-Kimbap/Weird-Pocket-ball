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

    public GameObject[] player1BallsChildren;
    public GameObject[] player2BallsChildren;
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
    
    private void Start()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true;
    }
    private void Update()
    {
        if (CueController.isStart)
        {
            Debug.Log("lets go");
            BallMovementStatus2();
        }
    }

    IEnumerator CallBallMovementStatus()
    {
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("ekdrms? 555");

      //  StartCoroutine(BallMovementStatus());      
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
        if (!player1Move && !player2Move) //isStop = true; //��� ���� ���� ��쿡

        //if (isStop)
        {
            Debug.Log("isStop!"); 
            ResetPosition();
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            //����ٸ�
            /*if (callCheck) //
            {
                turn = !true;
                callCheck = false;
            }*/
        }
    }
    void BallMovementStatus2()
    {
        
        bool playerBallMove = playerBall.GetComponent<BallController>().isStop;
        bool blackBallMove = balckBall.GetComponent<BallController>().isStop;
        boolMove = false;
        while (!boolMove)
        {
            foreach (GameObject ball in Balls)
            {
                if (!ball.GetComponent<BallController>().isStop)
                {
                    boolMove = true;
                }
            }
        }
        /*
        do
        {
            player1Move = false;
            player2Move = false;
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
            Debug.Log("!player1Move" + !player1Move + "!player2Move" + !player2Move + "playerBallMove" + playerBallMove + "blackBallMove" + blackBallMove);
        } while(!player1Move && !player2Move && playerBallMove && blackBallMove);
        */
        Debug.Log("isStop!");
        ResetPosition();
        CueController.isStart = false;
    }
    public void CheckScore(GameObject ball)
    {
        ball.SetActive(false);
        if (ball.name == "BlackBall")
        {
            if (turn) //player1��
            {
                if (player1Count == countchecker)
                {
                    Debug.Log("BlackBall | Player1 �¸�");
                    result.text = "Player1\n�¸�";
                }
                else
                {
                    Debug.Log("BlackBall | player2 �¸�");
                    result.text = "Player2\n�¸�";
                }
            }
            else
            {
                if (player2Count == countchecker)
                {
                    Debug.Log("BlackBall | Player2 �¸�");
                    result.text = "Player2\n�¸�";
                }
                else
                {
                    Debug.Log("BlackBall | player1 �¸�");
                    result.text = "Player1\n�¸�";
                }
            }
            resultUI.SetActive(true);
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
        
    void ResetPosition()
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����������");
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
    
