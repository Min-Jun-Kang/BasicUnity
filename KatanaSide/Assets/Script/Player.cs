using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpUp = 1;
    public Vector3 direction;
    public GameObject slash;

    bool bJump = false;
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
        }
        else if (direction.x > 0)
        {
            //right
            sr.flipX = false; //기능 끄기
            pAnimator.SetBool("Run", true);
        }
        else if (direction.x == 0)
        {
            pAnimator.SetBool("Run", false);
        }
        if (Input.GetMouseButtonDown(0)) //0번이면 좌클릭
        {
            pAnimator.SetTrigger("Attack");
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
        //플레이어 오른쪽
        Instantiate(slash, transform.position, Quaternion.identity);


    }


}
