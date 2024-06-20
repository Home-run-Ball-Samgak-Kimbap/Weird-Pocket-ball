using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    private static TabController _instance = null;

    public static TabController Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<TabController>();
                
                if (_instance == null) {
                    Debug.LogError("There's no active TabController object");
                }
            }
            return _instance;
        }
    }

    private TabButton tabButton; // 현재 선택된 탭 버튼을 추적하기 위한 변수

    private void Start() {
        if (transform.childCount > 0) {
            SelectedButton(transform.GetChild(0).GetComponent<TabButton>());
        }
    }

    public void SelectedButton(TabButton _button) {
        if (tabButton != null) {
            tabButton.Deselect();
        }
        tabButton = _button;
        tabButton.Select();
    }
    public void Quit() {
        Application.Quit();/*
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                
            }
        }*/
    }
}


