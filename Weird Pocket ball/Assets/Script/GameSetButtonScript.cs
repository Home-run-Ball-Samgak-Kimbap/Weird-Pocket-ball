using UnityEngine;
using UnityEngine.UI;

public class GameSetButtonScript : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;
    public GameObject objectE;
    public GameObject objectF;

    public Button myButton;

    public ModeSelectController modeSelectController; // ModeSelectController 인스턴스 참조

    public int a = 1; // 예시 값, 실제 값은 필요에 따라 설정
    public int b = 1;
    public int c = 1;

    void Start()
    {
        // 오브젝트들을 비활성화
        objectA.SetActive(false);
        objectB.SetActive(false);
        objectC.SetActive(false);
        objectD.SetActive(false);
        objectE.SetActive(false);
        objectF.SetActive(false);

        myButton.onClick.AddListener(OnButtonClick);

        myButton.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        Debug.Log("다음 버튼 눌림");
        modeSelectController.NextButton(); // ModeSelectController 인스턴스의 NextButton 호출
        if (a == 1)
        {
            objectA.SetActive(true);
            objectB.SetActive(true);
            objectC.SetActive(true);
        }
        if (b == 1)
        {
            objectD.SetActive(true);
            objectE.SetActive(true);
            objectF.SetActive(true);
        }
    }

    public void ShowButton()
    {
        myButton.gameObject.SetActive(true);
    }
}

