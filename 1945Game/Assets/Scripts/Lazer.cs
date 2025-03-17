using Unity.VisualScripting;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect; //이펙트 처리
    Transform pos; //플레이어 이동 값
    int Attack = 10;

    
    void Start()
    {
        //pos = GameObject.Find("Player").GetComponent<Player>().pos;
        pos = GameObject.FindWithTag("Player").GetComponent<Player>().pos;

    }


    void Update()
    {
        transform.position = pos.position;
    }

    void CreateEffect(Vector3 position) //함수화
    {
        GameObject go = Instantiate(effect, position, Quaternion.identity);
        Destroy(go, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }


}
