using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSelection : MonoBehaviour, IPointerClickHandler
{
    // 선택한 이미지를 표시할 UI 텍스트
    public Text selectedImageText;

    // 선택한 이미지 정보를 저장할 변수
    private Sprite selectedSprite;

    // 이미지를 클릭했을 때 호출되는 이벤트
    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 UI 요소가 이미지인지 확인
        if (eventData.pointerPress.gameObject.GetComponent<Image>() != null)
        {
            // 클릭한 이미지의 Sprite를 가져옴
            selectedSprite = eventData.pointerPress.gameObject.GetComponent<Image>().sprite;

            // 선택한 이미지 정보를 텍스트로 표시
            if (selectedImageText != null)
            {
                selectedImageText.text = "Selected Image: " + selectedSprite.name;
            }

            // 선택한 이미지에 대한 추가 작업 수행 가능
            // 예: 선택한 이미지를 다른 곳에 적용하거나 처리
        }
    }
}

