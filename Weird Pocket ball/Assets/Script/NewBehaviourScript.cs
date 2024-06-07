using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem fireEffect; // 불타는 이펙트에 사용할 파티클 시스템
    public float growFactor = 0.1f; // 이펙트 확대 비율 (시간당)

    private ParticleSystem.MainModule mainModule; // 파티클 시스템의 메인 모듈 접근을 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        if (fireEffect != null)
        {
            mainModule = fireEffect.main; // 파티클 시스템의 메인 모듈 초기화
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireEffect != null)
        {
            // 시간에 따라 파티클 시스템의 startSize를 증가시킵니다.
            mainModule.startSize = mainModule.startSize.constant + (growFactor * Time.deltaTime);
            // 상황에 따라 다른 파티클 속성(예: startSpeed, lifetime 등)도 조절 가능합니다.
        }
    }
}
