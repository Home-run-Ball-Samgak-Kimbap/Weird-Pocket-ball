using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;     // 총알 프리팹
    public Transform shootingPointStart;  // 총알이 발사될 시작 지점
    public Transform shootingPointEnd;    // 총알이 발사될 끝 지점 (발사 방향 계산용)
    public float bulletSpeed = 20f;     // 총알 속도
    public float fireRate = 0.1f;       // 총알 발사 간격

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭
        {
            StartCoroutine(ShootThreeTimes());
        }
    }

    IEnumerator ShootThreeTimes()
    {
        for (int i = 0; i < 3; i++)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot()
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, shootingPointStart.position, shootingPointStart.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 발사 방향 계산: shootingPointStart에서 shootingPointEnd까지의 벡터의 반대 방향
        Vector3 direction = (shootingPointStart.position - shootingPointEnd.position).normalized;

        // 총알에 힘을 가해 발사
        rb.velocity = direction * bulletSpeed;

        // 일정 시간 후 총알을 파괴 (옵션)
        // Destroy(bullet, 2.0f);  // 2초 후 총알 파괴
    }
}
