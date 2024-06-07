using UnityEngine;
using UnityEngine.UI;

public class GameResetButtonScript : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;
    public GameObject objectE;
    public GameObject objectF;

    public Button myButton;

    public int a = 1; // 예시 값, 실제 값은 필요에 따라 설정
    public int b = 1;
    public int c = 1;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        objectA.SetActive(false);
        objectB.SetActive(false);
        objectC.SetActive(false);
        objectD.SetActive(false);
        objectE.SetActive(false);
        objectF.SetActive(false);
    }
}
