using UnityEngine;

public class MonoBehaviorExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start : 게임이 시작될 때 호출합니다.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update : 프레임마다 호출 됩니다.");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate : 물리 연산에 사용됩니다.");        
    }

    //컨트롤 시프트 M : 기본으로 제공되는 함수 확인


}
