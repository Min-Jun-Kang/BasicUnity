using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet; //이렇게 하면 Unity 내에서 Script 부분에 buLLet 자리가 생김
    

    void Start()
    {
        InvokeRepeating("shoot", 0.5f, 0.5f); //반복 함수
    }

    void shoot() 
    {
        //미사일 생성
        Instantiate(bullet, transform.position, Quaternion.identity); // 생성할 오브젝트, 현재 위치, 현 상태
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
