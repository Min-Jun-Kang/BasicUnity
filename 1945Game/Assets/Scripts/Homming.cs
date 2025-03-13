using UnityEngine;

public class Homming : MonoBehaviour
{
    public GameObject target; //플레이어
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;


    void Start()
    {
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        //A-B 벡터 ( A 쪽으로 가는 벡터) -> 플레이어 - 미사일 하면 플레이어 쪽으로 가는 벡터
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기, 정규화
        dirNo = dir.normalized;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime); //translate -> 벡터 * 속도 * 시간
         
        //transform.position = Vector3.MoveTowards(transform.position
        //    , target.transform.position, Speed * Time.deltaTime); //유도 미사일
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //미사일 지우기
            Destroy(gameObject);
        }
    }

}
