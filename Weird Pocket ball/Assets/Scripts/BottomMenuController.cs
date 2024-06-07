using UnityEngine;
using UnityEngine.UIElements;

public class BottomMenuController : MonoBehaviour
{
    private VisualElement ballModeSubmenu;
    private VisualElement tableModeSubmenu;
    private VisualElement cueModeSubmenu;

    public GameObject modeSelectionUI;
    public GameObject gameplayUI;
    public SoundManager SoundManager;

    private string selectedBallMode;
    private string selectedTableMode;
    private string selectedCueMode;
    int selectedBallModeNum = 0;
    int selectedTableModeNum = 0;
    int selectedCueModeNum = 0;

    public GameObject GameSetButton;

    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        var btnBallMode = root.Q<Button>("btnBallMode");
        ballModeSubmenu = root.Q<VisualElement>("ballModeSubmenu");

        var btnTableMode = root.Q<Button>("btnTableMode");
        tableModeSubmenu = root.Q<VisualElement>("tableModeSubmenu");

        var btnCueMode = root.Q<Button>("btnCueMode");
        cueModeSubmenu = root.Q<VisualElement>("cueModeSubmenu");

        btnBallMode.clicked += () => { ToggleSubmenu(ballModeSubmenu); OnSfx(); };
        btnTableMode.clicked += () => { ToggleSubmenu(tableModeSubmenu); OnSfx(); };
        btnCueMode.clicked += () => { ToggleSubmenu(cueModeSubmenu); OnSfx(); };


        var btn8ball = root.Q<Button>("btn8ball");
        var btnIcefall = root.Q<Button>("btnIcefall");
        var btnFireball = root.Q<Button>("btnFireball");
        var btnSetTable = root.Q<Button>("btnSetTable");
        var btnTriangleTable = root.Q<Button>("btnTriangleTable");
        var btnStarTable = root.Q<Button>("btnStarTable");
        var btnSetCue = root.Q<Button>("btnSetCue");
        var btnGun = root.Q<Button>("btnGun");

        btn8ball.clicked += () => { OnBallModeButtonClicked("8 Ball"); OnSfx(); };
        btnIcefall.clicked += () => { OnBallModeButtonClicked("Icefall"); OnSfx(); };
        btnFireball.clicked += () => { OnBallModeButtonClicked("Fireball"); OnSfx(); };
        btnSetTable.clicked += () => { OnTableModeButtonClicked("Set Table"); OnSfx(); };
        btnTriangleTable.clicked += () => { OnTableModeButtonClicked("Triangle Table"); OnSfx(); };
        btnStarTable.clicked += () => { OnTableModeButtonClicked("Star Table"); OnSfx(); };
        btnSetCue.clicked += () => { OnCueModeButtonClicked("Set Cue"); OnSfx(); };
        btnGun.clicked += () => { OnCueModeButtonClicked("Gun"); OnSfx(); };
    }

    private void ToggleSubmenu(VisualElement submenu)
    {
        HideAllSubmenus();
        submenu.style.display = submenu.style.display == DisplayStyle.None ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void HideAllSubmenus()
    {
        ballModeSubmenu.style.display = DisplayStyle.None;
        tableModeSubmenu.style.display = DisplayStyle.None;
        cueModeSubmenu.style.display = DisplayStyle.None;
    }


    private void OnBallModeButtonClicked(string mode)
    {
        selectedBallMode = mode;
        Debug.Log(mode + " 버튼 클릭됨");
        // 다음 모드인 테이블 모드로 넘어가기
        Debug.Log("selectedBallModeNum = 1");
        selectedBallModeNum = 1;
        // ToggleSubmenu(ballModeSubmenu);
        if (selectedBallModeNum == 1 & selectedTableModeNum == 1 & selectedCueModeNum == 1){
            Debug.Log("ball에서 페이지 넘어감");
            // GameSetButtonScript.ShowButton();
            GameSetButton.SetActive(true);
            // if (GameSetButton != null)
            // {
            //     // 버튼을 활성화합니다.
            //     GameSetButton.SetActive(true);
            // }
            // else
            // {
            //     Debug.LogError("GameSetButton에 대한 참조가 설정되지 않았습니다.");
            // }
            // OnCueModeSelected();
        }
    }

    private void OnTableModeButtonClicked(string mode)
    {
        selectedTableMode = mode;
        Debug.Log(mode + " 버튼 클릭됨");
        // 다음 모드인 큐 모드로 넘어가기
        Debug.Log("selectedTableModeNum = 1");
        selectedTableModeNum = 1;
        // ToggleSubmenu(tableModeSubmenu);
        if (selectedBallModeNum == 1 & selectedTableModeNum == 1 & selectedCueModeNum == 1){
            Debug.Log("Table에서 페이지 넘어감");
            GameSetButton.SetActive(true);
            // GameSetButtonScript.ShowButton();
            // if (GameSetButtonScript != null)
            // {
            //     // 버튼을 활성화합니다.
            //     GameSetButtonScript.SetActive(true);
            // }
            // else
            // {
            //     Debug.LogError("GameSetButtonScript에 대한 참조가 설정되지 않았습니다.");
            // }
            // OnCueModeSelected();
        }
    }

    private void OnCueModeButtonClicked(string mode)
    {
        selectedCueMode = mode;
        Debug.Log(mode + " 버튼 클릭됨");
        Debug.Log("selectedCueModeNum = 1");
        selectedCueModeNum = 1;
        // ToggleSubmenu(cueModeSubmenu);
        if (selectedBallModeNum == 1 & selectedTableModeNum == 1 & selectedCueModeNum == 1){
            Debug.Log("Cue에서 페이지 넘어감");
            // GameSetButtonScript.ShowButton();
            GameSetButton.SetActive(true);
            // OnCueModeSelected();
        }
    }

    private void OnCueModeSelected()
    {
        Debug.Log("큐 모드 선택됨: " + selectedCueMode);
        // 모드 선택 UI를 비활성화하고 게임 플레이 UI를 활성화
        if (modeSelectionUI != null && gameplayUI != null)
        {
            Debug.Log("게임플레이 모드로 전환");
            modeSelectionUI.SetActive(false);
            gameplayUI.SetActive(true);
        }
        else
        {
            Debug.LogError("UI 오브젝트가 연결되지 않았습니다.");
        }
    }
    public void NextButton(){
        OnCueModeSelected();
    }
    public void OnSfx(){

        if (SoundManager != null ){

            SoundManager.OnSfx();
        }
    }
}






