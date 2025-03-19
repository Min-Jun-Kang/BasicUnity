using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    //Impulse Source 컴포넌트 참조
    private CinemachineImpulseSource impulseSource;

    void Awake()
    {
        instance = this;
        //게임 오브젝트에 부착된 Impulse Source 컴포넌트 가져오기
        impulseSource = GetComponent<CinemachineImpulseSource>();

    }

    public void CameraShakeShow()
    {
        if (impulseSource != null)
        {
            //기본 설정으로 Impulse 생성
            impulseSource.GenerateImpulse();
        }
    }
}
