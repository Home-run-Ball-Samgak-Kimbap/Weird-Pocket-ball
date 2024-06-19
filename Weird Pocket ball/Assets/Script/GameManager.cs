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
    public GameObject gameSet;
    public GameObject resetPos;

    public Material fireMat;
    public Material iceMat;
    public PhysicMaterial physicIceMat;
    public Transform ballPos;
    public Transform PlayerPos;
    public GameObject ballSet;

    public Vector3 cuePos;


    public TextMeshProUGUI result;
    public TextMeshProUGUI turnUI;

    public int countchecker = 3;
    public float velocity;

    string ballValue;
    string tableValue;
    string cueValue;
    GameObject thisTable;

    private void Start()
    {
        player1Count = 0;
        player2Count = 0;
        turn = true;
        ballValue = PlayerPrefs.GetString("BallValue");
        tableValue = PlayerPrefs.GetString("TableValue");
        cueValue = PlayerPrefs.GetString("CueBalue");
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
            playerBall.GetComponent<Transform>().position = PlayerPos.transform.position;
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

        //¸ØÃß±â¸¦ ±â´Ù¸²
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
        Debug.Log("¸ØÃè³ª¿ä?");
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
            if (turn) //player1ÅÏ
            {
                if (player1Count == countchecker)
                {
                    Debug.Log("BlackBall | Player1 ½Â¸®");
                    result.text = "Player1\n½Â¸®";
                }
                else
                {
                    Debug.Log("BlackBall | player2 ½Â¸®");
                    result.text = "Player2\n½Â¸®";
                }
            }
            else
            {
                if (player2Count == countchecker)
                {
                    Debug.Log("BlackBall | Player2 ½Â¸®");
                    result.text = "Player2\n½Â¸®";
                }
                else
                {
                    Debug.Log("BlackBall | player1 ½Â¸®");
                    result.text = "Player1\n½Â¸®";
                }
            }
            resultUI.SetActive(true);
        }
        else
        {
            if (turn)
            {//player1ÀÇ turn¿¡¼­ player1°øÀÌ ¾Æ´Ñ °øÀ» ³ÖÀ¸¸é
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
        //°ø È¸Àü ÃÊ±âÈ­
        playerBall.transform.rotation = Quaternion.identity;
        //Å¥ Èû ÃÊ±âÈ­
        cue.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cue.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //Å¥ À§Ä¡ ÃÊ±âÈ­

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
        Debug.Log("°ø±¼·¯°¡À¯");
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("°ø ºüÁö´Ù..");
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
        SceneManager.LoadScene("NewTitle");

    }
    void ChangeTurn()
    {
        turn = !turn;
    }
}
