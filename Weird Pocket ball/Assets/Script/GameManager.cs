using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isMove = false;
    [SerializeField] private bool turn;

    int player1Count = 0;
    int player2Count = 0;

    public GameObject player1Balls;
    public Rigidbody[] player1BallsChildren;
    public GameObject player2Balls;
    public Rigidbody[] player2BallsChildren;
    public void GameStart()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true; //player 1 turn

        player1BallsChildren = player1Balls.GetComponentsInChildren<Rigidbody>();
        player2BallsChildren = player2Balls.GetComponentsInChildren<Rigidbody>();
    }

    IEnumerator BallMovementStatus()
    {
        bool player1Move = false;
        bool player2Move = false;
        foreach (Rigidbody rb in player1BallsChildren)
        {
            if (rb.velocity.magnitude > 0f) // ������ �Ӱ谪���� ũ�� �����̰� �ִٰ� �Ǵ�
            {
                player1Move = true;
            }
        }
        foreach (Rigidbody rb in player1BallsChildren)
        {
            if (rb.velocity.magnitude > 0f) // ������ �Ӱ谪���� ũ�� �����̰� �ִٰ� �Ǵ�
            {
                player2Move = true;
            }
        }
        if (!player1Move && !player2Move) isMove = false;
        if (isMove)
            yield return new WaitForSeconds(0.5f);
        else
            yield break;
    }
    void CheckTurn(GameObject ball)
    {
        StartCoroutine(BallMovementStatus());
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

        if(ball.name == "BlackBall")
        {
            if (turn)
                Debug.Log("BlackBall | player2 �¸�");
            else
                Debug.Log("BlackBall | Player1 �¸�");
        }
        else
        {
            if (player1Count == 2)
                Debug.Log("Player1 �¸�");
            else if (player2Count == 2)
                Debug.Log("Player2 �¸�");
        }
        


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����������");
        collision.gameObject.GetComponent<Collider>().enabled = false;
        CheckTurn(collision.gameObject);
        
    }
}
