using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속도 설정
    public float ItemVelocity = 40f;
    Rigidbody2D rig = null;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
