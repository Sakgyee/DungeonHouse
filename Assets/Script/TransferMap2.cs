using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene 매니저 라이브러리 추가

public class TransferMap2 : MonoBehaviour
{

    public string Dungeon1; //이동할 맵이름 


    void Start()
    {

    }

    // 박스 콜라이더에 닿는 순간 이벤트 발생
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene("Dungeon1");
        }
    }
}
