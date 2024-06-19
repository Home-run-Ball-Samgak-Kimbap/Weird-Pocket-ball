
using UnityEngine;



public class ModeSelectController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject modeSelectButtons;
    public GameObject ballModeSubmenu;
    public GameObject tableModeSubmenu;
    public GameObject cueModeSubmenu;
    public GameObject gameplayUI;
    public GameObject BackGround;

    public string selectedBallMode;
    public string selectedTableMode;
    public string selectedCueMode;
    public bool isSelectedBallMode = false;
    public bool isSelectedTableMode = false;
    public bool isSelectedCueMode = false;

    private GameSetButtonScript GameSetButtonScript;

    void Start()
    {
        mainMenu.SetActive(true);
        modeSelectButtons.SetActive(false);
        ballModeSubmenu.SetActive(false);
        tableModeSubmenu.SetActive(false);
        cueModeSubmenu.SetActive(false);
        gameplayUI.SetActive(false);
        BackGround.SetActive(true);
    }

    public void OnStartButtonClicked()
    {
        // 스타트 버튼 클릭 시, 메인 메뉴를 비활성화하고 모드 선택 버튼들을 활성화
        mainMenu.SetActive(false);
        modeSelectButtons.SetActive(true);
    }

// 모드 선택 함수
    public void OnBallModeButtonClicked()
    {
        // 볼 모드 버튼 클릭 시, 볼 모드 서브메뉴를 활성화
        HideAllSubmenus();
        ballModeSubmenu.SetActive(true);
    }
    public void OnTableModeButtonClicked()
    {
        // 테이블 모드 버튼 클릭 시, 테이블 모드 서브메뉴를 활성화
        HideAllSubmenus();
        tableModeSubmenu.SetActive(true);
    }
    public void OnCueModeButtonClicked()
    {
        // 큐 모드 버튼 클릭 시, 큐 모드 서브메뉴를 활성화
        HideAllSubmenus();
        cueModeSubmenu.SetActive(true);
    }
    private void HideAllSubmenus()
    {
        ballModeSubmenu.SetActive(false);
        tableModeSubmenu.SetActive(false);
        cueModeSubmenu.SetActive(false);
    }

    // 하위모드 선택 함수
    public void OnBallSubButtonClicked(string mode) {
        selectedBallMode = mode;
        isSelectedBallMode = true;
        Debug.Log("Selected Ball Mode: " + mode);
    }
    public void OnTableSubButtonClicked(string mode) {
        selectedTableMode = mode;
        isSelectedTableMode = true;
        Debug.Log("Selected Table Mode: " + mode);
    }
    public void OnCueSubButtonClicked(string mode) {
        selectedCueMode = mode;
        isSelectedCueMode = true;
        Debug.Log("Selected Cue Mode: " + mode);
    }
}
