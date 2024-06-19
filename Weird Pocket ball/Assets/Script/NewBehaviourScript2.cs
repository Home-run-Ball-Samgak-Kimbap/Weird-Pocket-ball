using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticleAtPosition : MonoBehaviour
{
    public ParticleSystem particlePrefab; // 파티클 프리팹
     Transform targetObject; // 파티클을 재생할 대상 오브젝트
    public float scaleFactor = 2f; // 크기를 키울 비율
    public float duration = 10f; // 키우는 시간
    public float shrinkRate = 0.1f; // 크기를 줄이는 비율
    Color darkenColor = Color.black; // 어둡게 만들 색상
    public float darkenSpeed = 0.1f; // 어두워지는 속도

    private Material material; // 머티리얼

    private ParticleSystem particleInstance;


    public float thrust = 10.0f;
    
    // 시작 시 공을 밀기 위해 추가하였음
    private Rigidbody rb;

    private float startTime;

    void Start()
    {
        targetObject = this.transform;
        // 시작 시간 기록
        startTime = Time.time;

        // 파티클 프리팹으로부터 파티클 시스템 생성
        particleInstance = Instantiate(particlePrefab, targetObject.position, Quaternion.identity);

        // 파티클을 targetObject의 하위 오브젝트로 설정
        particleInstance.transform.parent = targetObject;

        // 파티클 재생
        particleInstance.Play();

        material = GetComponent<Renderer>().material; // 오브젝트의 머티리얼 가져오기
        
        // 시작 시 공을 밀기 위한 함수
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust, ForceMode.Force);
    }

    void Update()
    {
        // 경과한 시간 계산
        float elapsedTime = Time.time - startTime;

        // 경과한 시간에 따라 크기 조절
        float scale = Mathf.Lerp(1f, scaleFactor, elapsedTime / duration);
        particleInstance.transform.localScale = new Vector3(scale, scale, scale);

        // 물체를 점점 작게 하는 함수 호출
        ShrinkOverTime();
        // 물체를 점점 어둡게 하는 함수 호출
        //DarkenOverTime();

        // 만약 지정된 시간이 지나면 파티클 시스템 중지
        if (elapsedTime >= duration)
        {
            particleInstance.Stop();
            // 이 스크립트 자체를 파괴
            Destroy(this.gameObject);
        }
    }

    private void ShrinkOverTime()
    {
        transform.localScale -= new Vector3(shrinkRate, shrinkRate, shrinkRate) * Time.deltaTime;
    }

    private void DarkenOverTime()
    {
        material.color = Color.Lerp(material.color, darkenColor, Time.deltaTime * darkenSpeed);
    }
}
