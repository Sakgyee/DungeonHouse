using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene �Ŵ��� ���̺귯�� �߰�

public class TransferMap2 : MonoBehaviour
{

    public string Dungeon1; //�̵��� ���̸� 


    void Start()
    {

    }

    // �ڽ� �ݶ��̴��� ��� ���� �̺�Ʈ �߻�
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene("Dungeon1");
        }
    }
}
