using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public RectTransform handle;
    public RectTransform leftBoundary; // stretch된 오브젝트
    public RectTransform rightBoundary; // stretch된 오브젝트
    public AudioSource audioSource;

    private float minX;
    private float maxX;

    void Start()
    {
        // 좌우 경계의 X 위치를 계산합니다.
        minX = CalculateBoundaryPosition(leftBoundary, 0);
        maxX = CalculateBoundaryPosition(rightBoundary, 1);
    }

    void Update()
    {
        // Handle의 X 위치를 가져옵니다.
        float handleX = handle.position.x;

        // Handle의 위치를 최소 및 최대 경계 값 사이로 제한합니다.
        handleX = Mathf.Clamp(handleX, minX, maxX);

        // Handle의 위치를 0 ~ 1 범위로 정규화합니다.
        float normalizedPosition = (handleX - minX) / (maxX - minX);

        // 오디오 소스의 볼륨을 조절합니다.
        audioSource.volume = normalizedPosition;
    }

    private float CalculateBoundaryPosition(RectTransform boundary, float anchor)
    {
        // 부모 RectTransform을 기준으로 경계 위치를 계산합니다.
        RectTransform parentRect = boundary.parent.GetComponent<RectTransform>();

        float boundaryPosition = parentRect.rect.width * (boundary.anchorMin.x * (1 - anchor) + boundary.anchorMax.x * anchor) + parentRect.position.x - parentRect.rect.width * parentRect.pivot.x;

        return boundaryPosition;
    }
}
