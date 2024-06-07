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
        btnSetCue.clicked += OnCueModeSelected;
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
        ToggleSubmenu(tableModeSubmenu);
    }

    private void OnTableModeButtonClicked(string mode)
    {
        selectedTableMode = mode;
        Debug.Log(mode + " 버튼 클릭됨");
        // 다음 모드인 큐 모드로 넘어가기
        ToggleSubmenu(cueModeSubmenu);
    }

    private void OnCueModeButtonClicked(string mode)
    {
        selectedCueMode = mode;
        Debug.Log(mode + " 버튼 클릭됨");
        OnCueModeSelected();
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
        public void OnSfx(){

        if (SoundManager != null ){

            SoundManager.OnSfx();
        }
    }
}






