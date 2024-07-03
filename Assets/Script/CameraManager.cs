using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager sharedInstance = null;  //싱클톤 패턴을 사용하기 위함
    [HideInInspector] //유니티에 나타나지 않게 함
    public CinemachineVirtualCamera VirtualCamera;

    private void Awake()
    {
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        VirtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지
    }

   
    void Update()
    {
        
    }
}
