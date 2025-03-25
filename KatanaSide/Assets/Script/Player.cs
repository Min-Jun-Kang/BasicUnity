using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 속성")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 5;
    public Vector3 direction;
    public GameObject slash;

    //그림자
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    //히트 이펙트
    public GameObject hit_lazer;

    //bool bJump = false;
    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sr;

    //2D에서는 SpriteRender에서 Flip을 이용하면 좌우 반전을 쉽게 할 수 있다.

    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        direction = Vector2.zero;
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); //왼쪽은 -1 가만히 0 오른쪽 1 세 개의 값만 출력

        if (direction.x < 0)
        {
            //left
            sr.flipX = true; //기능 켜기
            pAnimator.SetBool("Run", true);

            //Shadowflip
            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sr.flipX;
            }
        }
        else if (direction.x > 0)
        {
            //right
            sr.flipX = false; //기능 끄기
            pAnimator.SetBool("Run", true);

            //Shadowflip
            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sr.flipX;
            }

        }
        else if (direction.x == 0)
        {
            pAnimator.SetBool("Run", false);

            for (int i = 0; i < sh.Count; i++)
            {
                Destroy(sh[i]); //게임오브젝트지우기
                sh.RemoveAt(i); //게임오브젝트 관리하는 리스트지우기
            }

        }
        if (Input.GetMouseButtonDown(0)) //0번이면 좌클릭
        {
            pAnimator.SetTrigger("Attack");
            Instantiate(hit_lazer, transform.position, Quaternion.identity);
        }

    }
    
    void Update()
    {
        KeyInput();
        Move();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (pAnimator.GetBool("Jump") == false) 
            {
                Jump();
                pAnimator.SetBool("Jump", true);
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));
        //레이캐스트로 땅 체크
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (pRig2D.linearVelocityY < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.7f)
                {
                    pAnimator.SetBool("Jump", false);
                }
            }
        }

    }

    void Jump()
    {
        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime; //위치
    }
    public void AttSlash()
    {
        //공격 모션
        //플레이어 오른쪽
        if (sr.flipX == false)
        {
            //플레이어 오른쪽
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse); //플레이어가 공격 시 앞으로 살짝 이동
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        }
        else
        {   //왼쪽
            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        }

    }

    //그림자
    public void RunShadow()
    {
        if (sh.Count < 6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity); //그림자 생성
            go.GetComponent<Run_Shadow>().TwSpeed = 10 - sh.Count; //그림자 별 속도 차이를 둬서 잔상효과 생기게 하기
            sh.Add(go); //생긴 그림자 추가
        }
    }

}
