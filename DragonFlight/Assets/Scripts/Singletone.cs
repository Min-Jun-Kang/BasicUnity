using UnityEngine;

public class Singletone : MonoBehaviour
{

    //유니티에서 싱글톤을 사용하면 하나의 인스턴스만 유지하면서 어디서든 접근 가능하게 만들 수 있다.

    public static Singletone Instance { get; private set; }

    private void Awake()
    {
        //start보다 시점이 더 빠른 지점, 한 번 실행
        //정파 방법
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 유지되게 하는 함수
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void PrintMessage()
    {
        Debug.Log("싱글 톤 메시지 출력!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
