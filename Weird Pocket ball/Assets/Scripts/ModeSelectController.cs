using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ModeSelectController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject modeSelectButtons;
    public GameObject ballModeSubmenu;
    public GameObject tableModeSubmenu;
    public GameObject cueModeSubmenu;
    public GameObject gameplayUI;
    public GameObject BackGround;
    // public GameObject gameSet;

    public string selectedBallMode = null;
    public string selectedTableMode = null;
    public string selectedCueMode = null;

    private GameSetButtonScript GameSetButtonScript;

    void Start()
    {
        GameSet();
        /*
        // 초기 UI 상태 설정
        mainMenu.SetActive(true);
        modeSelectButtons.SetActive(false);
        ballModeSubmenu.SetActive(false);
        tableModeSubmenu.SetActive(false);
        cueModeSubmenu.SetActive(false);
        gameplayUI.SetActive(false);
        BackGround.SetActive(true);
        */
    }
    public void GameSet()
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
        Debug.Log("Selected Ball Mode: " + mode);
        // CheckIfAllModesSelected();
    }
    public void OnTableSubButtonClicked(string mode) {
        selectedTableMode = mode;
        Debug.Log("Selected Table Mode: " + mode);
        // CheckIfAllModesSelected();
    }
    public void OnCueSubButtonClicked(string mode) {
        selectedCueMode = mode;
        Debug.Log("Selected Cue Mode: " + mode);
        // CheckIfAllModesSelected();
    }

// 모든 모드 클릭됐을 때 함수
    // private void CheckIfAllModesSelected() {
    //     if (selectedBallMode != null && selectedTableMode != null && selectedCueMode != null) {
    //         // Scene 바꾸면서 게임판 세팅
    //         ChangeScene("test", selectedBallMode, selectedTableMode, selectedCueMode);
    //         // 아래는 실행 안 되나?

    //         // 모든 모드가 선택되었으면 게임 플레이 UI로 전환
    //         // BackGround.SetActive(false);
    //         // modeSelectButtons.SetActive(false);
    //         // gameplayUI.SetActive(true);
    //         // selectedBallMode = null;
    //         // selectedTableMode = null;
    //         // selectedCueMode = null;
    //         // Debug.Log("All modes selected. Starting game...");
    //     }
    // }
    // public void ChangeScene(string sceneName, string selectedBallMode, string selectedTableMode, string selectedCueMode)
    // {
    //     // 필요한 데이터 저장
    //     Debug.Log(selectedBallMode);
    //     Debug.Log(selectedCueMode);
    //     Debug.Log(selectedTableMode);
    //     Data_JaeWoo.instance.ball = selectedBallMode;
    //     Data_JaeWoo.instance.table = selectedTableMode;
    //     Data_JaeWoo.instance.cue = selectedCueMode;

    //     // 씬 이동
    //     SceneManager.LoadScene(sceneName);

    //     // 다른 씬에서 데이터 가져오기
    //     Debug.Log("Selected Ball: " + Data_JaeWoo.instance.ball);
    //     Debug.Log("Selected Table: " + Data_JaeWoo.instance.table);
    //     Debug.Log("Selected Cue: " + Data_JaeWoo.instance.cue);
    // }

        // NextButton 메서드 추가
    // public void NextButton()
    // {
    //     Debug.Log("NextButton 호출됨");
    //     // 게임 플레이 UI로 전환
    //     modeSelectButtons.SetActive(false);
    //     gameplayUI.SetActive(true);
    // }
}


