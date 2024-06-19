using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToPlayScene : MonoBehaviour {
    public Button myButton;
    public ModeSelectController ModeSelectController;
    private string BallMode;
    private string TableMode;
    private string CueMode;

    void Start() {
        if (myButton == null || ModeSelectController == null) {
            Debug.LogError("myButton 또는 modeSelectController가 설정되지 않았습니다.");
            return;
        }
        myButton.onClick.AddListener(OnButtonClick);
        if (ModeSelectController != null) {
            // BallMode = ModeSelectController.selectedBallMode; // 여기서 초기화
            // Debug.Log("Successfully imported value: " + BallMode);
            // TableMode = ModeSelectController.selectedTableMode;
            // Debug.Log("Successfully imported value: " + TableMode);
            // CueMode = ModeSelectController.selectedCueMode;
            // Debug.Log("Successfully imported value: " + CueMode);
        }else {
            Debug.LogError("ModeSelectController가 설정되지 않았습니다.");
        }
    }

    private void OnButtonClick() {
        if (ModeSelectController.selectedBallMode != null && ModeSelectController.selectedTableMode != null && ModeSelectController.selectedCueMode != null) {
            Debug.Log("Scene Change Button Clicked");
            ChangeScene();
        }
    }

    private void ChangeScene() {
        // 정수 값을 전역 변수 또는 PlayerPrefs에 저장
        PlayerPrefs.SetString("BallValue", BallMode);
        PlayerPrefs.SetString("TableValue", TableMode);
        PlayerPrefs.SetString("CueBalue", CueMode);

        // 새로운 씬 로드
        SceneManager.LoadScene("test");
    }
}
