using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public Text ChatText;
    public string writerText = "";
    public GameObject talkPanel; // 대화창 끄고 키게 하기
    public GameObject chestopen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Good"))
            {
                if (PotionManager.Potioncount >= 3)
                {
                    StartCoroutine(TextGoodFull());
                    StartCoroutine(TalkDelayFull(1.0f));
                }
                else if (PotionManager.Potioncount <= 2)
                {
                    
                    StartCoroutine(TextGoodUp());
                    StartCoroutine(TalkDelay(1.0f));
                    PotionManager.Potioncount += 1;
                    chestopen.gameObject.SetActive(true);
                }
            }
            if (gameObject.CompareTag("Bad"))
            {
                if(PotionManager.Potioncount <= 0)
                {
                    StartCoroutine(TextBadFull());
                    StartCoroutine(TalkDelay(1.0f));
                    chestopen.gameObject.SetActive(true);
                }
                else
                {
                    StartCoroutine(TextBad());
                    StartCoroutine(TalkDelay(1.0f));
                    PotionManager.Potioncount -= 1;
                    chestopen.gameObject.SetActive(true);
                }
                
            }
        }               
       
    }
    
    private IEnumerator TalkDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerContro.instance.isMoving = true;
        talkPanel.SetActive(false);
        gameObject.SetActive(false);
    }
    private IEnumerator TalkDelayFull(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerContro.instance.isMoving = true;
        talkPanel.SetActive(false);
    }
    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        //텍스트 타이밍 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

    }
  
    IEnumerator TextBadFull()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("포션이 하나도 없어서 안 사라졌어 히히"));
    }
    IEnumerator TextBad()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("포션이 하나 사라졌어!"));
    }
    IEnumerator TextGoodFull()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("포션이 이미 가득 찼어"));
    }
    IEnumerator TextGoodUp()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("포션이 하나 늘었어!"));
    }
}
