using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5.0f; //이동속도

    // Update is called once per frame
    void Update()
    {
        //키 입력에 따라 이동
        float move = Input.GetAxis("Horizontal"); //키보드 좌우 방향키
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
