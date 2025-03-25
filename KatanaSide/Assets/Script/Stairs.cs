using UnityEngine;

public class Stairs : MonoBehaviour
{
    //충돌처리
    //trigger 충돌이 일어났을 때 통과
    //collision 충돌이 일어났을 때 통과 x

    public GameObject player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


}
