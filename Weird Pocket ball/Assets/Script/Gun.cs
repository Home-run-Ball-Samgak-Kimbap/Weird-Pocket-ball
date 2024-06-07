using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public Transform firePoint;      // 총알이 발사될 위치
    public float bulletSpeed = 20f;  // 총알 속도

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        // 총알에 힘을 가해 발사
        rb.velocity = firePoint.forward * bulletSpeed;

        // 일정 시간 후 총알을 파괴 (옵션)
        Destroy(bullet, 2.0f);  // 2초 후 총알 파괴
    }
}
