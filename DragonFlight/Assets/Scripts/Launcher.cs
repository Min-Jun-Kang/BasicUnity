using UnityEngine;

public class Launcher : MonoBehaviour
{

    public GameObject bullet; //미사일 프리팹 가져올 변수



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating(함수 이름, 초기지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //미사일 생성
        //미사일 프리팹, 런쳐포지션, 방향값 안줌
        Instantiate(bullet, transform.position, Quaternion.identity); //transform.position하면 보인 위치
        //미사일 발사 소리
        SoundManager.instance.SoundBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
