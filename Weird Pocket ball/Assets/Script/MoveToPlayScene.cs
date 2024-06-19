using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToPlayScene : MonoBehaviour {
    public Button myButton;
    public ModeSelectController ModeSelectController;
    private string BallMode;
    private string TableMode;
    private string CueMode;
    private bool isBallMode = false;
    private bool isTableMode = false;
    private bool isCueMode = false;

    void Start() {
        if (myButton == null || ModeSelectController == null) {
            Debug.LogError("myButton 또는 modeSelectController가 설정되지 않았습니다." + myButton + ModeSelectController);
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

    void Update(){
        BallMode = ModeSelectController.selectedBallMode;
        TableMode = ModeSelectController.selectedTableMode;
        CueMode = ModeSelectController.selectedCueMode;
        isBallMode = ModeSelectController.isSelectedBallMode;
        isTableMode = ModeSelectController.isSelectedTableMode;
        isCueMode = ModeSelectController.isSelectedCueMode;
    }

    private void OnButtonClick() {
        Debug.Log("Scene Change Button Clicked");
        Debug.Log("Ball: " + BallMode);
        Debug.Log("Table: " + TableMode);
        Debug.Log("Cue: " + CueMode);
        if (isBallMode && isTableMode && isCueMode){
            Debug.Log(BallMode);
            ChangeScene();
        }
    }

    private void ChangeScene() {
        // 정수 값을 전역 변수 또는 PlayerPrefs에 저장
        PlayerPrefs.SetString("BallValue", BallMode);
        PlayerPrefs.SetString("TableValue", TableMode);
        PlayerPrefs.SetString("CueBalue", CueMode);

        // 새로운 씬 로드
        if (CueMode == "BasicCue"){
            SceneManager.LoadScene("CueScene");
        }
        if (CueMode == "Gun"){
            SceneManager.LoadScene("GunScene");
        }
        
    }
}
