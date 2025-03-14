using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3;
    public float Delay = 1f;
    public Transform missile1;
    public Transform missile2;
    public GameObject bullet; //적도 공격을한다.
    //아이템 가져오기
    public GameObject Item = null;

    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", Delay);
        
    }
    void CreateBullet()
    {
        Instantiate(bullet, missile1.position, Quaternion.identity);
        Instantiate(bullet, missile2.position, Quaternion.identity);

        //재귀호출
        Invoke("CreateBullet", Delay);
    }


    // Update is called once per frame
    void Update()
    {
        //아래 방향으로 움직여라
        transform.Translate(Vector3.down * Speed * Time.deltaTime); //적은 위에서 아래로 움직임
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //미사일에 따른 데미지 입는 함수
    public void Damage(int attack)
    {
        ItemDrop();
        Destroy(gameObject);
    }


    public void ItemDrop()
    {
        //아이템 생성
        Instantiate(Item, transform.position, Quaternion.identity); 
    }



}
