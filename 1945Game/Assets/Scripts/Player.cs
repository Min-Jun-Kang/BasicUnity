using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;

    Animator ani; //애니메이터를 가져올 변수(애니메이션에 접근해야함)

    public GameObject[] bullet;  //총알 추후 4개 배열로 만들예정

    public Transform pos = null;

    //아이템
    public int power = 0;

    [SerializeField]
    private GameObject PowerUp; //private일 때 인스펙터에서 사용하는 방법

    //레이저
    public GameObject lazer;
    public float gValue = 0;


    void Start()
    {
        ani = GetComponent<Animator>(); //컴포넌트 가져오기 GetComponent<컴포넌트 이름>()
       
    }

    void Update()
    {
        //방향키에 따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); //스피드 보정시간 위치 
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // 움직임 -1 ~ 1 (왼쪽 ~ 오른쪽)
        //왼쪽
        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
            ani.SetBool("left", false);
        //오른쪽
        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
            ani.SetBool("right", false);
        //위쪽
        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
            ani.SetBool("up", false);

        transform.Translate(moveX, moveY, 0); //움직임을 표현

        //스페이스
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //프리팹 위치 방향 넣고 생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;


            if (gValue >= 1)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(go, 2);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if (gValue <= 0)
            {
                gValue = 0;
            }


        }

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.

    }


    //아이템 먹기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            power += 1;

            if (power > 3)
            {
                power = 3;
            }
            else 
            {
                //파워업
                GameObject go = Instantiate(PowerUp, transform.position, Quaternion.identity);
                Destroy(go, 1);
            }
        }

        //아이템 먹은 처리
        Destroy(collision.gameObject);
    }
}
