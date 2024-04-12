using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagement
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ModeButton()
    {
        SceneManager.LoadScene("ModeSetting"); // 전환하고자 하는 화면인 B의 이름을 ""에 넣어준다.
    }
}