using UnityEngine;
using UnityEngine.UIElements;

public class BottomMenuController : MonoBehaviour
{
    private VisualElement ballModeSubmenu;
    private VisualElement tableModeSubmenu;
    private VisualElement cueModeSubmenu;

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

        btnBallMode.clicked += () => ToggleSubmenu(ballModeSubmenu);
        btnTableMode.clicked += () => ToggleSubmenu(tableModeSubmenu);
        btnCueMode.clicked += () => ToggleSubmenu(cueModeSubmenu);

        var btn8ball = root.Q<Button>("btn8ball");
        var btnIcefall = root.Q<Button>("btnIcefall");
        var btnFireball = root.Q<Button>("btnFireball");
        var btnSetTable = root.Q<Button>("btnSetTable");
        var btnTriangleTable = root.Q<Button>("btnTriangleTable");
        var btnStarTable = root.Q<Button>("btnStarTable");
        var btnSetCue = root.Q<Button>("btnSetCue");
        var btnGun = root.Q<Button>("btnGun");

        btn8ball.clicked += () => OnSubmenuButtonClicked("8 Ball");
        btnIcefall.clicked += () => OnSubmenuButtonClicked("Icefall");
        btnFireball.clicked += () => OnSubmenuButtonClicked("Fireball");
        btnSetTable.clicked += () => OnSubmenuButtonClicked("Set Table");
        btnTriangleTable.clicked += () => OnSubmenuButtonClicked("Triangle Table");
        btnStarTable.clicked += () => OnSubmenuButtonClicked("Star Table");
        btnSetCue.clicked += () => OnSubmenuButtonClicked("Set Cue");
        btnGun.clicked += () => OnSubmenuButtonClicked("Gun");
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

    private void OnSubmenuButtonClicked(string submenu)
    {
        Debug.Log(submenu + " 버튼 클릭됨");
        // 해당 서브메뉴 항목에 대한 로직을 여기에 추가합니다.
    }
}





