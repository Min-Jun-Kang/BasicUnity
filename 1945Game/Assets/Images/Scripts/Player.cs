using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;

    Animator ani; //애니메이터를 가져올 변수(애니메이션에 접근해야함)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>(); //컴포넌트 가져오기 GetComponent<컴포넌트 이름>()
       
    }

    // Update is called once per frame
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

        transform.Translate(moveX, moveY, 0);

    }
}
