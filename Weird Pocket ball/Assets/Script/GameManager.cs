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

    public TextMeshProUGUI result;
    public TextMeshProUGUI turnUI;

    public int countchecker = 3;
    float velocity;
    Vector3 resetPos = new Vector3(0, -24f, 0);



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
            EditorApplication.isPaused = false;
            resultUI.SetActive(true);
        }
        else
        {
            if (turn)
            {//player1�� turn���� player1���� �ƴ� ���� ������
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
        //�� ȸ�� �ʱ�ȭ
        playerBall.transform.rotation = Quaternion.identity;
        //ť �� �ʱ�ȭ
        cue.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cue.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //ť ��ġ �ʱ�ȭ
        cue.transform.localPosition = new Vector3(0, 0, -12);//cuePos;
        cue.transform.rotation = Quaternion.identity;
        cue.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����������");
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.SetActive(false);

            //playerBall.transform.position = new Vector3(0, -24, 0);
            playerBall.transform.rotation = Quaternion.identity;
            playerBall.GetComponent<Transform>().position = resetPos;

        }
        else
            CheckScore(collision.gameObject);
    }
    public void GameEnd()
    {
        EditorApplication.isPaused = true;
        gameSet.SetActive(false);
        resultUI.SetActive(false);

    }
    void ChangeTurn()
    {
        turn = !turn;
    }
}
    
