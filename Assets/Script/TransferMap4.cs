using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene 매니저 라이브러리 추가

public class TransferMap4 : MonoBehaviour
{

    public string Dungeon3; //이동할 맵이름 


    void Start()
    {

    }

    // 박스 콜라이더에 닿는 순간 이벤트 발생
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
            SceneManager.LoadScene("Dungeon3");
        }
    }
}
