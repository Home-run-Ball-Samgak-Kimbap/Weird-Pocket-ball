using UnityEngine;
using UnityEngine.UI;

public class GameStartButtonScript : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;

    public Button myButton;

    private int a = 1; // 예시 값, 실제 값은 필요에 따라 설정
    private int b = 0;
    private int c = 1;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        objectA.SetActive(a == 1);
        objectB.SetActive(b == 1);
        objectC.SetActive(c == 1);
    }
}
