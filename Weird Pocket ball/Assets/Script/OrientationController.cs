using UnityEngine;

public class OrientationController : MonoBehaviour
{
    void Start()
    {
        // 가로모드로 고정
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        // 자동 회전 비활성화
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }
}
