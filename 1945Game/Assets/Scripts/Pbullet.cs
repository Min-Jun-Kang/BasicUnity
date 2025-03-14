using UnityEngine;

public class Pbullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //공격력
    //이펙트
    public GameObject effect;

    // Update is called once per frame
    void Update()
    {
        //미사일 위쪽방향으로 움직이기
        //위의방향 x 스피드 x 타임

        transform.Translate(Vector2.up * Speed * Time.deltaTime); //vector2.up 위쪽 방향의 단위 벡터

    }

    //화면밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        //화면 밖으로 나간 총알 지우기
        Destroy(gameObject);
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")) 
        {
            //이펙트생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1초 후 지우기
            Destroy(go, 1);

            //몬스터 삭제
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Monster>().Damage(1);
            //collision.gameObject -> Monster prefabs을 의미
            //Monster 스크립트가 component이기 때문에 GetComponent를 이용해서 스크립트에 다가갈 수 있다.
            
            //미사일 삭제
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {

            //이펙트생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //1초뒤에 지우기
            Destroy(go, 1);

            //미사일 삭제
            Destroy(gameObject);

        }
    }

}
