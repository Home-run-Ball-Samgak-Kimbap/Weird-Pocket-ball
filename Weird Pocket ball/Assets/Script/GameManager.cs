using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static bool turn;
    [SerializeField] private int player1Count = 0;
    [SerializeField] private int player2Count = 0;

    public GameObject[] Balls;
    public GameObject[] table;
    public GameObject cue;
    public GameObject playerBall;
    public GameObject balckBall;
    public GameObject resultUI;
    public GameObject resetPos;

    public Material fireMat;
    public Material iceMat;
    public PhysicMaterial physicIceMat;
    public Transform ballPos;
    public Transform playerPos;
    public GameObject ballSet;
    public TextMeshProUGUI P1;
    public TextMeshProUGUI P2;

    public Vector3 cuePos;


    public TextMeshProUGUI result;
    public TextMeshProUGUI turnUI;

    public int countchecker = 3;
    public float velocity;

    string ballValue;
    string tableValue;
    GameObject thisTable;

    private void Start()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true;
        ballValue = PlayerPrefs.GetString("BallValue");
        tableValue = PlayerPrefs.GetString("TableValue");
        if (tableValue == "Triangle")
        {
            thisTable = table[1];
            table[1].SetActive(true);
            table[0].SetActive(false);
            
        }
        else if (tableValue == "Star")
        {
            thisTable = table[2];
            table[2].SetActive(true);
            table[0].SetActive(false);
            
        }
        else
        {
            thisTable = table[0];
            playerBall.GetComponent<Transform>().position = playerPos.transform.position;
            ballSet.GetComponent<Transform>().position = ballPos.transform.position;

        }

        if (ballValue == "FireBall")
        {
            thisTable.GetComponent<MeshRenderer>().material = fireMat;
            foreach (GameObject ball in Balls)
            {
                ball.GetComponent<ScaleParticleAtPosition>().enabled = true;
            }
        }
        else if(ballValue == "IceBall")
        {
            thisTable.GetComponent<MeshRenderer>().material = iceMat;
            foreach (GameObject ball in Balls)
            {
                ball.GetComponent<SphereCollider>().material = physicIceMat;
                thisTable.GetComponent<MeshCollider>().material = physicIceMat;
            }
        }

        
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

        //���߱⸦ ��ٸ�
        do
        {
            velocity = 0;
            foreach (GameObject ball in Balls)
            {
                Rigidbody ballrig = ball.GetComponent<Rigidbody>();
                velocity += ballrig.velocity.magnitude;
                Debug.Log("name : " + ball.name + "velocity : " + velocity);

            }
            Debug.Log("!velocity : " + velocity);

            yield return new WaitForSeconds(0.5f);
        } while (velocity > 0);
        Debug.Log("���質��?");
        playerBall.SetActive(true);
        ResetPosition();
        ScreenTouchManager.isTouch = false;

        if (turn)
            turnUI.text = "P1";
        else
            turnUI.text = "P2";
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
            P1.text = player1Count.ToString() + "��";
            P2.text = player2Count.ToString() + "��";
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

        if (SceneManager.GetActiveScene().name == "CueScene")
        {
            cue.transform.localPosition = new Vector3(0, 0, -12);
            cue.transform.localRotation = Quaternion.identity;
        }
        else if (SceneManager.GetActiveScene().name == "GunScene")
        {
            cue.transform.localPosition = cuePos;
            cue.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        cue.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����������");
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("�� ������..");
            //playerBall.transform.position = new Vector3(0, -24, 0);
            playerBall.transform.rotation = Quaternion.identity;
            playerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            playerBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            playerBall.GetComponent<Transform>().position = new Vector3(0, -24.6f, -6.29f);
            playerBall.transform.rotation = Quaternion.identity;
            ResetPosition();

        }
        else
            CheckScore(collision.gameObject);
    }
    public void GameEnd()
    {
        SceneManager.LoadScene("NewTitle");
    }
    void ChangeTurn()
    {
        turn = !turn;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
