using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpen : MonoBehaviour
{
    public Text ChatText;
    public string writerText = "";
    public GameObject talkPanel; // ��ȭâ ���� Ű�� �ϱ�
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

        //�ؽ�Ʈ Ÿ�̹� ȿ��
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
        yield return StartCoroutine(NormalChat("������ �ϳ��� ��� �� ������� ����"));
    }
    IEnumerator TextBad()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("������ �ϳ� �������!"));
    }
    IEnumerator TextGoodFull()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("������ �̹� ���� á��"));
    }
    IEnumerator TextGoodUp()
    {
        talkPanel.SetActive(true);
        PlayerContro.instance.isMoving = false;
        yield return StartCoroutine(NormalChat("������ �ϳ� �þ���!"));
    }
}
