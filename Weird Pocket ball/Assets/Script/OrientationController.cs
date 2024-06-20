using UnityEngine;

public class OrientationController : MonoBehaviour
{
    public enum Orientation
    {
        LandscapeLeft,
        LandscapeRight,
        Portrait
    }

    public Orientation sceneOrientation;

    void Start()
    {
        SetOrientation();
    }

    void SetOrientation()
    {
        switch (sceneOrientation)
        {
            case Orientation.LandscapeLeft:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
            case Orientation.LandscapeRight:
                Screen.orientation = ScreenOrientation.LandscapeRight;
                break;
            case Orientation.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
        }
    }
}
