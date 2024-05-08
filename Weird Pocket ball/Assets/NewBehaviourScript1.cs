using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticleOverTime : MonoBehaviour
{
    public ParticleSystem particleSystem; // 파티클 시스템을 참조하기 위한 변수
    public float scaleFactor = 2f; // 크기를 키울 비율
    public float duration = 10f; // 키우는 시간

    private float startTime;

    void Start()
    {
        // 파티클 시스템의 시작 시간을 기록
        startTime = Time.time;
        // 파티클 시스템 실행
        particleSystem.Play();
    }

    void Update()
    {
        // 현재 시간에서 시작 시간을 빼서 경과한 시간 계산
        float elapsedTime = Time.time - startTime;
        // 경과한 시간에 따라 크기를 조절
        float scale = Mathf.Lerp(1f, scaleFactor, elapsedTime / duration);
        particleSystem.transform.localScale = new Vector3(scale, scale, scale);

        // 만약 지정된 시간이 지나면 파티클 시스템 중지
        if (elapsedTime >= duration)
        {
            particleSystem.Stop();
            // 이 스크립트 자체를 파괴할 수 있도록 설정
            Destroy(this.gameObject);
        }
    }
}
