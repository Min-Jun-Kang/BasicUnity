using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Run_Shadow : MonoBehaviour
{
    private GameObject player;
    public float TwSpeed = 10;
    void Start()
    {
        
    }
    //Vector3.Lerp는 유니티에서 두 개의 Vector3 사이를 보간(Interpolation)하는 함수야.선형 보간(Linear Interpolation, Lerp) 방식으로 동작하며, 두 벡터 사이에서 지정된 비율만큼의 값을 반환해.

    //Vector3.Lerp(Vector3 a, Vector3 b, float t)
    //a: 시작점 벡터
    //b: 끝점 벡터
    //t: 보간 계수 (0 ~ 1 사이의 값)
    //t 값이 0이면 a를 반환하고, 1이면 b를 반환해. 0과 1 사이의 값이면 a와 b 사이의 중간 값을 반환하지.

    //부드러운 이동 (Smooth Movement)
    //void Update()
    //{
    //    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    //}
    //→Time.deltaTime* speed를 사용하면 t 값이 점점 증가하면서 점진적으로 이동해.

    //카메라 천천히 따라가기

    //public Transform player;
    //public float followSpeed = 5f;

    //void LateUpdate()
    //{
    //    transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * followSpeed);
    //}
    //→ t 값을 Time.deltaTime* speed로 조정하면, 너무 빠르게 이동하지 않고 부드럽게 따라가.



    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform.position = Vector3.Lerp(transform.position, player.transform.position, TwSpeed * Time.deltaTime); //러프 함수(그림자, 플레이어, 시간)

    }
}
