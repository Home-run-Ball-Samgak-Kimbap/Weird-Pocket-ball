using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public bool isMove;
    List<Rigidbody> balls;

    private bool player1 = false;
    private bool player2 = false;
    private bool isMove = false;
    // Start is called before the first frame update
    
    public void ShootBall()
    {
        StartCoroutine(BallMovementStatus());
    }
    IEnumerator BallMovementStatus()
    {
        isMove = false;
        foreach (Rigidbody rb in balls)
        {
            if (rb.velocity.magnitude > 0f) // 설정된 임계값보다 크면 움직이고 있다고 판단
            {
                isMove = true;
            }
        }
        if(isMove)
            yield return new WaitForSeconds(0.5f);
        else
            yield break;
    }
    void CheckTurn(GameObject ball)
    {

        if (ball.tag == "player1")
        {
            if (player1)
            {

            }
        }
        else
        {
            if (player2)
            {

            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        CheckTurn(collision.gameObject);
        
    }
}
