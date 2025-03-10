using UnityEngine;

public class ConditionExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100;

    // Update is called once per frame
    void Update()
    {
        health -= 1; //체력 감소
        Debug.Log("Health : " + health);
        if (health <= 0) 
        {
            Debug.Log("Game Over!");
        }
    }
}
