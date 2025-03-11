using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5.0f;
    void Start()
    {
        
    }

    void moveControl()
    {
        //지정한 Axis를 통해 키의 방향을 판단하고 속도와 프레임 판정르 곱해 이동량을 정한다.
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //이동량만큼 실제로 이동을 해주는 함수
        transform.Translate(distanceX, 0, 0); //x축만 움직이면 된다.
    }

    // Update is called once per frame
    void Update()
    {
        moveControl(); //함수로 만들어서 호출
    }

}
