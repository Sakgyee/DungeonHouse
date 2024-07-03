using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    public int questActionIndex; //����Ʈ ��ȭ���� ���� ����

    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        //����Ʈ ����Ʈ ����� 1300 id npc�� ��ȭ�ϴ� ����Ʈ
        questList.Add(10, new QuestData("����� ��ȭ�ϱ�" 
                                          , new int[] {1300,1200}));
        questList.Add(20, new QuestData("�� ���� ã��"
                                          , new int[] {5000,1200}));
        questList.Add(30, new QuestData("�� ����"
                                          , new int[] {10000}));
        questList.Add(40, new QuestData("���� �Ա� ã��"
                                          , new int[] {10200,11000,10300}));
        questList.Add(50, new QuestData("���� Ȱ��ȭ"
                                          , new int[] { 11200,11300,11400,11500,11600}));
        questList.Add(60, new QuestData("���� Ȱ��ȭ1"
                                          , new int[] { 11200,11300,11400,11500,11600 }));
        questList.Add(70, new QuestData("���� Ȱ��ȭ1"
                                          , new int[] { 12400,12500,12600,12700,12800,12900,13000,13100,13200 }));
        questList.Add(80, new QuestData("end"
                                          , new int[] {  }));
    }

    public int GetQuestTalkIndex(int id) //npc id�� �ް� ����Ʈ ��ȣ ��ȯ �Լ�
    {
        return questId + questActionIndex;
    }
    public string CheckQuest(int id)
    {
        
        //������ �°� ��ȭ ���� ���� ����Ʈ ��ȭ������ �ø����� �Ѵ�.
        if (id == questList[questId].npcId[questActionIndex])
        questActionIndex++;

        //Control Quest Object ���� �Լ� ȣ��
        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //����Ʈ �̸�
        return questList[questId].questName;
    }
    //���� ����Ʈ�� ���� �Լ� ����
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            case 30:
                if(questActionIndex == 0)
                   questObject[1].SetActive(false);
                   questObject[2].SetActive(true);
                break;
            case 40:
                if (questActionIndex == 3)
                {
                    questObject[0].SetActive(true);
                    questObject[1].SetActive(true);
                }
                break;
            case 50:
                if (questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                    questObject[10].SetActive(false);
                    questObject[4].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    questObject[1].SetActive(false);
                    questObject[11].SetActive(false);
                    questObject[5].SetActive(true);
                }
                if (questActionIndex == 3)
                {
                    questObject[2].SetActive(false);
                    questObject[12].SetActive(false);
                    questObject[6].SetActive(true);
                }
                if (questActionIndex == 4)
                {
                    questObject[3].SetActive(false);
                    questObject[13].SetActive(false);
                    questObject[7].SetActive(true);
                }
                if (questActionIndex == 5)
                {
                    questObject[8].SetActive(false);
                    questObject[9].SetActive(false);

                }
                break;
            case 60:
                if (questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                    questObject[10].SetActive(false);
                    questObject[4].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    questObject[1].SetActive(false);
                    questObject[11].SetActive(false);
                    questObject[5].SetActive(true);
                }
                if (questActionIndex == 3)
                {
                    questObject[2].SetActive(false);
                    questObject[12].SetActive(false);
                    questObject[6].SetActive(true);
                }
                if (questActionIndex == 4)
                {
                    questObject[3].SetActive(false);
                    questObject[13].SetActive(false);
                    questObject[7].SetActive(true);
                    questObject[8].SetActive(true);
                    questObject[9].SetActive(true);
                    questObject[14].SetActive(true);
                    questObject[15].SetActive(true);
                    questObject[16].SetActive(true);
                    questObject[17].SetActive(true);
                }

                break;
            case 70:
                if (questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                }
                if (questActionIndex == 2)
                {
                    questObject[2].SetActive(false);
                    questObject[3].SetActive(true);
                }
                if (questActionIndex == 3)
                {
                    questObject[4].SetActive(false);
                    questObject[5].SetActive(true);
                }
                if (questActionIndex == 4)
                {
                    questObject[6].SetActive(false);
                    questObject[7].SetActive(false);
                }
                if (questActionIndex == 5)
                {
                    questObject[30].SetActive(true);
                    questObject[31].SetActive(true);
                }
                if (questActionIndex == 6)
                {
                    questObject[39].SetActive(false);
                    questObject[25].SetActive(false);
                    questObject[6].SetActive(true);
                    questObject[7].SetActive(true);
                    questObject[8].SetActive(true);
                    questObject[9].SetActive(true);                  
                    questObject[10].SetActive(true);
                    //mob
                    questObject[11].SetActive(true);
                    questObject[12].SetActive(true);
                    questObject[13].SetActive(true);
                    questObject[14].SetActive(true);
                    questObject[15].SetActive(true);
                    questObject[16].SetActive(true);
                    
                }
                if (questActionIndex == 7)
                {
                    questObject[40].SetActive(false);
                    questObject[26].SetActive(false);
                    questObject[17].SetActive(true);
                    questObject[18].SetActive(true);
                    questObject[37].SetActive(true);
                    //mob
                    questObject[19].SetActive(true);
                    questObject[20].SetActive(true);
                    questObject[21].SetActive(true);
                    questObject[22].SetActive(true);
                    questObject[23].SetActive(true);
                    questObject[24].SetActive(true);
                }
                if (questActionIndex == 8)
                {
                    questObject[38].SetActive(true);
                    questObject[27].SetActive(false);
                    questObject[28].SetActive(false);                    
                    questObject[32].SetActive(true);
                    //mob
                    questObject[29].SetActive(true);
                    questObject[35].SetActive(true);
                    questObject[36].SetActive(true);
                }
                if(questActionIndex == 9)
                {                  
                    questObject[33].SetActive(true);
                    questObject[34].SetActive(true);
                }
                break;
        }
    }
    //���� CheckQuest�� �Ű������� �ֱ� ������ �� �Ʒ� checkQuest�ʹ� �ٸ���.
    //�� ����� �����ε�(�Ű������� ���� �Լ� ȣ��)�̶�� �θ���.
    public string CheckQuest()
    {

        //����Ʈ �̸�
        return questList[questId].questName;
    }

}
