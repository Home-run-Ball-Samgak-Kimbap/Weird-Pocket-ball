using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticleAtPosition : MonoBehaviour
{
    public ParticleSystem particlePrefab; // 파티클 프리팹
    public Transform targetObject; // 파티클을 재생할 대상 오브젝트
    public float scaleFactor = 2f; // 크기를 키울 비율
    public float duration = 10f; // 키우는 시간

    private ParticleSystem particleInstance;
    private float startTime;

    void Start()
    {
        // 시작 시간 기록
        startTime = Time.time;

        // 파티클 프리팹으로부터 파티클 시스템 생성
        particleInstance = Instantiate(particlePrefab, targetObject.position, Quaternion.identity);

        // 파티클을 targetObject의 하위 오브젝트로 설정
        particleInstance.transform.parent = targetObject;

        // 파티클 재생
        particleInstance.Play();
    }

    void Update()
    {
        // 경과한 시간 계산
        float elapsedTime = Time.time - startTime;

        // 경과한 시간에 따라 크기 조절
        float scale = Mathf.Lerp(1f, scaleFactor, elapsedTime / duration);
        particleInstance.transform.localScale = new Vector3(scale, scale, scale);

        // 만약 지정된 시간이 지나면 파티클 시스템 중지
        if (elapsedTime >= duration)
        {
            particleInstance.Stop();
            // 이 스크립트 자체를 파괴
            Destroy(this.gameObject);
        }
    }
}
