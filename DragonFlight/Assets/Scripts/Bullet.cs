using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //움직일 속도를 지정해줍니다.
    public float moveSpeed = 0.45f;
    public GameObject explosion;
    public int[] Hp = { 1,3,5 };

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //움직일 거리를 계산해줍니다.
        float distanceY = moveSpeed * Time.deltaTime;

        //움직임을 반영합니다.
        transform.Translate(0, distanceY, 0);
    }

    //화면 밖으로 나가 카메라에서 보이지 않으면 호출된다.
    private void OnBecameInvisible()
    {
        //미사일 화면 밖으로 나가면 지우기,gameObject : 자기자신을 의미
        Destroy(gameObject);
    }

    //2D충돌 트리거 이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딪혔다
        //if (collision.gameObject.tag == "Enemy") ;
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            EnemyDie(10, collision);
            Destroy(gameObject);
            
        }
    }

    void EnemyDie(int score, Collider2D collision) 
    {
        //폭발 이펙트 생성
        Instantiate(explosion, transform.position, Quaternion.identity);
        //몬스터 죽음 소리
        SoundManager.instance.SoundDie();
        //점수 더하기
        GamaManager.instance.AddScore(score);
        //몬스터 소멸
        Destroy(collision.gameObject);
    }
    


}
