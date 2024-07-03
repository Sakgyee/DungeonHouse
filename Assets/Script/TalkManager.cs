using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance;
    Dictionary<int, string[]> talkData;
        
    void Awake()
    {

        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }


    void GenerateData()
    {
        //Talk Data
        //NPC : 1000,1100,1200,1300,1400,1500,1600,1700
        //BOX : 100,200
        talkData.Add(1000, new string[] { "���� ������ ���ٳ�" });
        talkData.Add(1100, new string[] { "�������� �������� �Ȱ� �־��" });
        talkData.Add(1200, new string[] { "�츮 ������ ��ġ�� �Ƹ��ٿ� ���̶��",
                                          "�ѹ� ������ �ѷ����Գ�."});
        talkData.Add(1300, new string[] { "�ȳ�?", 
                                          "�� ���� ó�� �Ա���?",
                                          "�ѹ� �ѷ������� ��" });
        talkData.Add(1400, new string[] { "���� ������ ������ ������ �𸣴� ������"});
        talkData.Add(1500, new string[] { "������ �츮 ������ ��������� �õ������� �־�",
                                          "�� �̷��� �ɱ�..." });
        talkData.Add(1600, new string[] { "�Ŀ�..",
                                          "�׳�� �� �ǰ� ������ ��� �ؾ� �ұ�..."});
        talkData.Add(1700, new string[] { "�� �༮�� �ʹ� �̿�..",
                                          "���� �Ұž�..."});

        talkData.Add(100, new string[] { "����� �������ھ�" });
        talkData.Add(200, new string[] { "����� �������ھ�" });
        talkData.Add(300, new string[] { "�츮���̾�" });
        talkData.Add(400, new string[] { "����� �� �ƹ����� ������� �����;�" });
        talkData.Add(500, new string[] { "�츮 ������ �����ִ� ��������̾�" });
        talkData.Add(600, new string[] { "������� ���̾�" });
        talkData.Add(700, new string[] { "�������� ���ָӴ� ���̾�" });
        talkData.Add(800, new string[] { "�������� ������ ���̾�" });
        talkData.Add(900, new string[] { "������ ���̾�" });
        talkData.Add(999, new string[] { "���� ������ ������..?" });

        talkData.Add(10100, new string[] { "����ִ�." });
        talkData.Add(10200, new string[] { "�θ���� �ϱ��."});
        talkData.Add(10300, new string[] { "�� ���� ���δ�." });
        talkData.Add(10400, new string[] { "����� �� �о��� �ճ��� �̿����� å�� �ø��� ���� �����ִ�."});
        talkData.Add(10500, new string[] { "���⸸ �ص� ���� å���� �����ϴ�." });
        talkData.Add(10600, new string[] { "����� �� ������ ��� �峭������ ����ִ�." });
        talkData.Add(10700, new string[] { "�������� �⵿��ϵ��� ����ִ�." });
        talkData.Add(10800, new string[] { "���Ĺ� �����Ⱑ ����ִ�." });
        talkData.Add(10900, new string[] { "��Ȱ�� ��������� ����ִ�." });
        talkData.Add(11000, new string[] { "����� �����Ⱑ ����ִ�." });
        talkData.Add(11100, new string[] { "���� ���� ����ִ�.",
                                           "���� �� ���⿡ �������..?"});
        //Dungeon 1
        talkData.Add(11200, new string[] { "������ ���� �ʴ°� ����." });
        talkData.Add(11300, new string[] { "������ ���� �ʴ°� ����." });
        talkData.Add(11400, new string[] { "������ ���� �ʴ°� ����." });
        talkData.Add(11500, new string[] { "������ ���� �ʴ°� ����." });
        talkData.Add(11600, new string[] { "���� ������ �������� ������ ��� ������ Ȱ��ȭ �ؾ��Ѵ�." });
        //Dungeon 2
        talkData.Add(11700, new string[] { "���� ���� 2��" });
        talkData.Add(11800, new string[] { "������ �°� ������ Ȱ��ȭ �ϸ� ���� ���� ���̴�." });
        talkData.Add(11900, new string[] { "�Ʒ��� 4���� ������ ���̸� ���� ��������." });
        talkData.Add(12000, new string[] { "���� ���� 3��" });
        talkData.Add(12100, new string[] { "�����ϰ� ���� �� �����"});
        talkData.Add(13200, new string[] { "�������� �����ض�" });
        //Dungeon 3
        talkData.Add(12200, new string[] { "��Ȳ�� ���� 3���� ��� �������� ���� ����" });
        talkData.Add(12300, new string[] { "�غ� �� �ڸ� ������" });
        talkData.Add(12400, new string[] { "�� ��� �ִ�" });
        talkData.Add(12500, new string[] { "�� ��� �ִ�" });
        talkData.Add(12600, new string[] { "�� ��� �ִ�" });
        talkData.Add(12700, new string[] { "���� ���� �����ִ�" });
        talkData.Add(12800, new string[] { "�غ� ������ ���� 3���� ���� �ְ� ��� ���󿡰� ���� �ɾ��" });
        talkData.Add(12900, new string[] { "��Ȳ�� ������ �����ִ�" });
        talkData.Add(13000, new string[] { "��Ȳ�� ������ �����ִ�" });
        talkData.Add(13100, new string[] { "��Ȳ�� ������ �����ִ�" });
        //Quest Talk

        //10�� QuestManager�� �ִ� ����Ʈ ��ȣ 1300�� npc ��ȣ

        //village
        talkData.Add(10 + 1300, new string[] { "���",
                                          "���� �츮 ���� �����Ⱑ ���� �ʾ�",
                                          "�����ϴ°� ����",
                                          "�ϴ� ����Բ� ����",
                                          "������� �츮 ���� ������� ���ʿ� ��� �־�"});
        talkData.Add(11 + 1200, new string[] {"�� �ڳ��ΰ� ���� �Ǳ���",
                                              "���� ���� ���ٰ�?",
                                              "�� ������ ������ ���ڿ� �����ɼ�",
                                              "ã���� ������ �ٽ� ���ƿ��Գ�"});

        talkData.Add(20 + 1200, new string[] {"������ ã�� ���Ѱհ�?",
                                              "�����忡 ���� ���ڸ� �� ���캸��"});
        talkData.Add(20 + 5000, new string[] { "������ ����ִ°� ����.",
                                              "���ڿ��� �� ���踦 ã�Ҵ�." });
        talkData.Add(21 + 1200, new string[] { "��, �׷� ã�ұ�",
                                               "�ڳ��� ���� ������ ������ ���̶��" });

        talkData.Add(30 + 10100, new string[] {"���踦 ����� ���� ������."});


        //home
        talkData.Add(40 + 10200, new string[] { "5�� 1��\n������ ������ �����ص� ������ �ɻ�ġ�� �ʴ�. ������ �غ��� �ɰ� ����.",
            "5�� 7��\n�Ƴ��� ���ǳ��� �츮 ���忡�� ��� ���� ���� �Ʒ��� ����������� �ߴ�.   ",
            "5�� 11��\n���� �ȿ��� ���μ��� �ν����־���. ��� �̷�����...",
            "5�� 14��\n�غ� �Ϻ��ϰ� �ϰ� �ٽ� ������ ����������� �ߴ�.",
            "5�� 14��\n���� �Ա��� �ٽ� ����� ���� �������̿��� ��Ź�� �ߴ�.",
            "5�� 17��\n������ ������ �غ� ���ư� ���� �Ƴ��� �Բ� ���μ��� ��ġ�� ����� �ߴ�.",});
        talkData.Add(41 + 11000, new string[] {
            "������ ������ �ִ�.","�ڳװ� ��Ź�ؼ� ������ ���ܵ״ٳ�",
            "'�ſ� �� ��ư'�� ������ ���� �Ա��� ã�� �� �����ž�.",
            "�´� �ڳװ� �Ⱦ��� �˵��� �ڳ׵� �� ���忡 �־�״ٳ�"});
        talkData.Add(42 + 10300, new string[] { "��� ������ �Ҹ��� ����." });

        talkData.Add(50 + 11200, new string[] { "�Ķ������� Ȱ��ȭ �ߴ�." });
        talkData.Add(51 + 11300, new string[] { "���������� Ȱ��ȭ �ߴ�." });
        talkData.Add(52 + 11400, new string[] { "�ʷϼ����� Ȱ��ȭ �ߴ�." });
        talkData.Add(53 + 11500, new string[] { "��������� Ȱ��ȭ �ߴ�." });
        talkData.Add(54 + 11600, new string[] { "��� ������ Ȱ��ȭ �Ǿ���." });

        talkData.Add(60 + 11200, new string[] { "�Ķ������� Ȱ��ȭ �ߴ�." });
        talkData.Add(61 + 11300, new string[] { "���������� Ȱ��ȭ �ߴ�." });
        talkData.Add(62 + 11400, new string[] { "�ʷϼ����� Ȱ��ȭ �ߴ�." });
        talkData.Add(63 + 11500, new string[] { "��������� Ȱ��ȭ �ߴ�." });
        talkData.Add(64 + 11600, new string[] { "��� ������ Ȱ��ȭ �Ǿ���." });

        talkData.Add(70 + 12400, new string[] { "���󿡼� ù��° ������ ����." });
        talkData.Add(71 + 12500, new string[] { "���󿡼� �ι�° ������ ����." });
        talkData.Add(72 + 12600, new string[] { "���󿡼� ����° ������ ����." });
        talkData.Add(73 + 12700, new string[] { "���� �ִ� ���� �������." });
        talkData.Add(74 + 12800, new string[] { "�غ� ������ ���� 3���� ���� �ְ� ��� ���󿡰� ���� �ɾ��" });
        talkData.Add(75 + 12900, new string[] { "��Ȳ�� ������ ���� �־���." });
        talkData.Add(76 + 13000, new string[] { "��Ȳ�� ������ ���� �־���." });
        talkData.Add(77 + 13100, new string[] { "��Ȳ�� ������ ���� �־���." });
        talkData.Add(78 + 13200, new string[] { "�θ���� ���ָ� Ǯ���� ���� � �θ���� ������ Ż������." });
    }

    public string GetTalk(int id, int talkIndex) //talkIndex�� ����� ù��° ������ �����ð����� �ι�° ������ �����ð����� Ȯ��
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); //Get First Talk          
            else
                return GetTalk(id - id % 10, talkIndex); //Get First Quest Talk
        }
                
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];        
       
    }
}
