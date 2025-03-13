using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //움직일 거리를 계산해줍니다.
        float distanceY = moveSpeed * Time.deltaTime;
        
        //움직임을 반영합니다.
        transform.Translate(0, distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        //미사일 화면 밖으로 나가면 지우기,gameObject : 자기자신을 의미
        Destroy(gameObject);
    }

}
