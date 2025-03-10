using System;
using UnityEngine;

public class VectorStudy : MonoBehaviour
{
    //public Vector2 v2 = new Vector2(10, 10); //벡터 2, 2차원(x좌표, y좌표)
    //public Vector3 v3 = new Vector3(1, 1, 1); //벡터 3, 3차원(x좌표, y좌표, z좌표)
    //public Vector4 v4 = new Vector4(1.0f, 0.5f, 0.0f, 1.0f); //벡터 4, 4차원, 색상 표현하는데 주로 사용한다.

    //내적(Dot Product)
    //두 벡터가 얼마나 같은 방향인지 확인할 때 사용(값이 1에 가까울수록 같은 방향)
    //csharp
    //복사
    //float dotProduct = Vector3.Dot(a, b);
    //✅ 외적(Cross Product)
    //두 벡터가 이루는 수직 벡터(법선 벡터)를 구할 때 사용(주로 회전 계산)
    //csharp
    //복사
    //Vector3 crossProduct = Vector3.Cross(a, b);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 a = new Vector3(1, 0, 0);
        //Vector3 b = new Vector3(2, 0, 0);

        //Vector3 c = a + b;

        //Debug.Log("Vector : " + c);

        //Vector3 a = new Vector3(1, 1, 0);
        //Vector3 b = new Vector3(2, 0, 0);

        //Vector3 c = a + b;

        //Debug.Log("Vector : " + c);//벡터의 덧셈

        //Debug.Log("벡터의 길이 : " + c.magnitude); //벡터의 길이

        //정규화 normalize
        //벡터의 크기를 1로 만들고 방향만 유지

        //Vector3 a = new Vector3(3, 0, 0);

        //Vector3 normalizedVector = a.normalized;

        //Debug.Log("1의길이 방향만 설정하는 정규화 : " + normalizedVector);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
