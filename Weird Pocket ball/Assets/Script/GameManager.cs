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
    
