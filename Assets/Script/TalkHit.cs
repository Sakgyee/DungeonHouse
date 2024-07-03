using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TalkHit : MonoBehaviour
{
    public Text ChatText;
    public string writerText = "";
    public GameObject talkPanel; // ��ȭâ ���� Ű�� �ϱ�

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

        //�ؽ�Ʈ Ÿ�̹� ȿ��
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
            yield return StartCoroutine(NormalChat("���Ⱑ ���� �츮 �� ���Ͼ�..?"));
        }
        
        if (gameObject.CompareTag("Talk1"))
        {
            yield return StartCoroutine(NormalChat("��! �� �տ� ���Ͱ� �־�(zŰ�� ���� ����)"));
        }
        if (gameObject.CompareTag("Talk2"))
        {
            yield return StartCoroutine(NormalChat("���Ͱ� ��ǵ����.. �����"));
        }
        if (gameObject.CompareTag("Talk3"))
        {
            yield return StartCoroutine(NormalChat("�Ĳ��Ĳ��� ���Ⱑ �Ʒ����� �ö���°� ����"));
        }
        //Dungeon 2
        if (gameObject.CompareTag("Talk4"))
        {
            yield return StartCoroutine(NormalChat("���� 2���ΰ� ���� �� ���� ����"));
        }
        if (gameObject.CompareTag("Talk5"))
        {
            yield return StartCoroutine(NormalChat("��Ͽ� ������ �ʰ� ��������"));
        }
        if (gameObject.CompareTag("Talk6"))
        {
            yield return StartCoroutine(NormalChat("�� �Ʒ��� �������� �װ���..?"));
        }
        if (gameObject.CompareTag("Talk7"))
        {
            yield return StartCoroutine(NormalChat("���� �ΰ���..? ���� ��������?"));
        }
        if (gameObject.CompareTag("Talk8"))
        {
            yield return StartCoroutine(NormalChat("�� ���ڴ�! ���� ��� ������?"));
        }

        //Dungeon 3
        if (gameObject.CompareTag("Talk9"))
        {
            yield return StartCoroutine(NormalChat("��.. ���� ������ ���̾� ���⿡�� �θ���� ��ð���?"));
        }
        if (gameObject.CompareTag("Talk10"))
        {
            yield return StartCoroutine(NormalChat("���� �ƺ��� �������־�!! ���� ���ؾ� ��"));
        }
    }

}