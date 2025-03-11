using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : MonoBehaviour
{
    //싱글톤
    //어디에서나 접근할 수 있도록 static(정적)으로 자기자신을 저장해서 싱글톤이라는 디자인패턴을
    //사용해본다.
    public static GamaManager instance;
    public Text scoreText; //점수를 표시하는 Text객체를 에디터에서 받아옵니다.
    public Text StartText; //게임 시작표시하는 Text

    int score = 0; //점수를 관리합니다.

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        int i = 3;
        while (i > 0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSeconds(1);

            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false); //UI 감추기
            }
        }
    }

    public void AddScore(int num)
    {
        score += num; //점수를 더한다.
        scoreText.text = "Score : " + score; //텍스트에 반영합니다.(문자열 저장)
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
