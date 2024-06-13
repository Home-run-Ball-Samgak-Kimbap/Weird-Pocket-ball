using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ButtonScaleManager : MonoBehaviour
{
    public Button[] buttons; // 관리할 버튼 배열
    public Vector3 normalScale = new Vector3(1f, 1f, 1f); // 기본 크기 벡터
    public Vector3 highlightedScale = new Vector3(1.2f, 1.2f, 1.2f); // 강조된 상태의 크기 벡터
    public float transitionSpeed = 10f; // 크기 변경 속도

    private Button currentlyHighlightedButton; // 현재 강조된 버튼을 추적하기 위한 변수

    void Start()
    {
        foreach (Button button in buttons)
        {
            // 각 버튼에 EventTrigger 컴포넌트를 추가
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            // PointerEnter 이벤트 설정
            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { OnPointerEnter(button); });
            trigger.triggers.Add(entryEnter);

            // PointerExit 이벤트 설정
            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((data) => { OnPointerExit(button); });
            trigger.triggers.Add(entryExit);

            // 버튼 클릭 이벤트 설정
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    public void OnPointerEnter(Button button)
    {
        if (currentlyHighlightedButton != null && currentlyHighlightedButton != button)
        {
            StopAllCoroutines();
            StartCoroutine(ScaleTo(currentlyHighlightedButton.GetComponent<RectTransform>(), normalScale));
        }

        currentlyHighlightedButton = button;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(button.GetComponent<RectTransform>(), highlightedScale));
    }

    public void OnPointerExit(Button button)
    {
        // 마우스가 버튼에서 벗어나면 크기를 원래대로 되돌림
        if (currentlyHighlightedButton == button)
        {
            StopAllCoroutines();
            StartCoroutine(ScaleTo(button.GetComponent<RectTransform>(), normalScale));
            currentlyHighlightedButton = null;
        }
    }

    public void OnButtonClick(Button button)
    {
        // 버튼 클릭 시 현재 강조된 버튼의 크기를 원래대로 되돌림
        if (currentlyHighlightedButton != null && currentlyHighlightedButton != button)
        {
            StopAllCoroutines();
            StartCoroutine(ScaleTo(currentlyHighlightedButton.GetComponent<RectTransform>(), normalScale));
        }

        currentlyHighlightedButton = button;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(button.GetComponent<RectTransform>(), highlightedScale));
    }

    private IEnumerator ScaleTo(RectTransform rectTransform, Vector3 targetScale)
    {
        // 목표 크기에 도달할 때까지 크기 변경
        while (Vector3.Distance(rectTransform.localScale, targetScale) > 0.01f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        rectTransform.localScale = targetScale;
    }
}
