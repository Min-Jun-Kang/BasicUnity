using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5.0f; //이동속도

    // Update is called once per frame
    void Update()
    {
        //Vector3 a = Vector3.right; //정규화된 방향벡터 (1,0,0)


        ////키 입력에 따라 이동
        //float move = Input.GetAxis("Horizontal"); //키보드 좌우 방향키 (좌 : -1, 우 :+1)

        //transform.Translate(Vector3.right * move * speed * Time.deltaTime); //Time.deltaTime 프레임 조절

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); //Vertical은 상하 방향키 (하 : -1, 상 :+1), 2D에서 이용하는 방법

        Vector3 move2 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //3D에서 이용하는 방법

        transform.position += move2 * speed * Time.deltaTime; //Translate와 같은 방법




    }
}
