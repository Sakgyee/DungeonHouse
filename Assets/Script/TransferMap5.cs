using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene �Ŵ��� ���̺귯�� �߰�

public class TransferMap5 : MonoBehaviour
{

    public string GameOver2; //�̵��� ���̸� 


    void Start()
    {

    }

    // �ڽ� �ݶ��̴��� ��� ���� �̺�Ʈ �߻�
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (PotionManager.Potioncount == 0)
            {
                PotionManager.Potioncount += 3;
            }
            if (PotionManager.Potioncount == 1)
            {
                PotionManager.Potioncount += 2;
            }
            if (PotionManager.Potioncount == 2)
            {
                PotionManager.Potioncount += 1;
            }
            SceneManager.LoadScene("GameOver 2");
        }
    }
}
