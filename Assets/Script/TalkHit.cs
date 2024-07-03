using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TalkHit : MonoBehaviour
{
    public Text ChatText;
    public string writerText = "";
    public GameObject talkPanel; // 대화창 끄고 키게 하기

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TextPractice());
            StartCoroutine(TalkDelay(1.5f));
            
        }
    }

    private IEnumerator TalkDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerContro.instance.isMoving = true;
        talkPanel.SetActive(false);
        gameObject.SetActive(false);
    }
    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        //텍스트 타이밍 효과
        for (a=0; a<narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }   

    }
    IEnumerator TextPractice()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        //Dungeon 1
        if (gameObject.CompareTag("Talk"))
        {
            yield return StartCoroutine(NormalChat("여기가 정말 우리 집 지하야..?"));
        }
        
        if (gameObject.CompareTag("Talk1"))
        {
            yield return StartCoroutine(NormalChat("헉! 저 앞에 몬스터가 있어(z키를 눌러 공격)"));
        }
        if (gameObject.CompareTag("Talk2"))
        {
            yield return StartCoroutine(NormalChat("몬스터가 득실득실해.. 무서운데"));
        }
        if (gameObject.CompareTag("Talk3"))
        {
            yield return StartCoroutine(NormalChat("후끈후끈한 열기가 아래에서 올라오는거 같아"));
        }
        //Dungeon 2
        if (gameObject.CompareTag("Talk4"))
        {
            yield return StartCoroutine(NormalChat("지하 2층인가 여긴 좀 많이 덥네"));
        }
        if (gameObject.CompareTag("Talk5"))
        {
            yield return StartCoroutine(NormalChat("용암에 빠지지 않게 조심하자"));
        }
        if (gameObject.CompareTag("Talk6"))
        {
            yield return StartCoroutine(NormalChat("이 아래로 떨어지면 죽겠지..?"));
        }
        if (gameObject.CompareTag("Talk7"))
        {
            yield return StartCoroutine(NormalChat("길이 두개네..? 어디로 가야하지?"));
        }
        if (gameObject.CompareTag("Talk8"))
        {
            yield return StartCoroutine(NormalChat("앗 상자다! 뭐가 들어 있을까?"));
        }

        //Dungeon 3
        if (gameObject.CompareTag("Talk9"))
        {
            yield return StartCoroutine(NormalChat("후.. 드디어 마지막 층이야 여기에는 부모님이 계시겠지?"));
        }
        if (gameObject.CompareTag("Talk10"))
        {
            yield return StartCoroutine(NormalChat("엄마 아빠가 쓰러져있어!! 빨리 구해야 해"));
        }
    }

}