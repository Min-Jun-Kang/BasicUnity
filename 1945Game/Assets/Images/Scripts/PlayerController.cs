using UnityEngine;

//벽 설치안하고 카메라 밖으로 Player 못 나가게 하기
//GPT 버전
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        // 화면의 경계를 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    void Update()
    {
        // 플레이어 이동
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // 경계를 벗어나지 않도록 위치 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }
}
