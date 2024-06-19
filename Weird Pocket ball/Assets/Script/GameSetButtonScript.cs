using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameSetButtonScript : MonoBehaviour
{
    public GameObject objectAA;
    public GameObject objectAB;
    public GameObject objectAC;
    public GameObject objectBA;
    public GameObject objectBB;
    public GameObject objectBC;
    public GameObject objectCA;
    public GameObject objectCB;

    // public Button myButton;

    // public ModeSelectController modeSelectController; // ModeSelectController 인스턴스 참조

    // public int aa = 0, ab = 0, ac = 0;
    // public int ba = 0, bb = 0, bc = 0;
    // public int ca = 0, cb = 0;

    void Start()
    {
        // 오브젝트들을 비활성화
        objectAA.SetActive(false);
        objectAB.SetActive(false);
        objectAC.SetActive(false);

        objectBA.SetActive(false);
        objectBB.SetActive(false);
        objectBC.SetActive(false);

        objectCA.SetActive(false);
        objectCB.SetActive(false);

        // myButton.gameObject.SetActive(false);
    }

    public void OnButtonClick(string ball, string table, string cue)
    {
        Debug.Log("게임판 세팅");
        switch (ball){
            case "불타는 공":
                objectAA.SetActive(true);
                break;
            case "당구공":
                objectAB.SetActive(true);
                break;
            case "얼음공":
                objectAC.SetActive(true);
                break;
        }
        switch (ball){
            case "기본당구대":
                objectBA.SetActive(true);
                break;

            case "삼각형당구대":
                objectBB.SetActive(true);
                break;
            case "별모양당구대":
                objectBC.SetActive(true);
                break;
        }
        switch (ball){
            case "기본큐대":
                objectCA.SetActive(true);
                break;

            case "비비탄":
                objectCB.SetActive(true);
                break;
        }
    }
}

