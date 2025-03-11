using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //싱글톤
    public static SoundManager instance; //자기자신을 변수로 담기

    AudioSource myAudio; //AudioSource 컴포넌트를 변수로 담는다.
    //재생할 소리들
    public AudioClip soundBullet;
    public AudioClip soundDie;


    private void Awake()
    {
        //사파 방법
        if (instance == null) //인스턴스있는지 검사
        {
            instance = this; //자기자신을 담는다.
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //AudioSource 컴포넌트 가져오기 
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie); //한 번 재생
    }
    public void SoundBullet()
    {
        myAudio.PlayOneShot(soundBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
