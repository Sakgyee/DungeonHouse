using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager sharedInstance = null;  //��Ŭ�� ������ ����ϱ� ����
    [HideInInspector] //����Ƽ�� ��Ÿ���� �ʰ� ��
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
        DontDestroyOnLoad(this.gameObject); // ���� ������Ʈ �ı�����
    }

   
    void Update()
    {
        
    }
}
