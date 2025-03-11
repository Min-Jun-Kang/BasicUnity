using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터 가지고오기
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    //public GameObject enemyBoss;

    IEnumerator Coroutine()
    {
        int i = 0;
        while (true)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1);
            i++;
            if (i % 3 == 0) 
            {
                SpawnEnemy(enemy2);
            }
            if (i % 7 == 0)
            {
                SpawnEnemy(enemy3);
            }
        }
    }



    //적을 생성하는 함수
    void SpawnEnemy(GameObject Enemy)
    {
        float randomX = Random.Range(-2f, 2f); //적이 나타날 X좌표를 랜덤으로 생성하기

        //적을 생성한다. randomX랜덤한 x값
        Instantiate(Enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
