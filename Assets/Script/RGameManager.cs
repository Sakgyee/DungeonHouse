using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGameManager : MonoBehaviour
{
    public static RGameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;

    public CameraManager cameraManger;

    public GameObject talkPanel; // ��ȭâ ���� Ű�� �ϱ�
    public Text TalkText; //��ȭâ �ؽ�Ʈ�� ���� ����
    public GameObject ScanObject; //��ĵ ������Ʈ �ֱ�
    public bool isAction; //���� ����� ���� ��ȭâ

    public TalkManager talkManager; //TalkManager �� ����
    public int talkIndex; //TalkManager �� ����

    public QuestManager questManager; //QuestManager �� ����

    void Start()
    {    

        SetupScene();
        Debug.Log(questManager.CheckQuest());   
    }

    //��ȭ�� ���� Action 
    public void Action(GameObject scanObj)
    {
        ScanObject = scanObj;
        ObjData objData = ScanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); //����Ʈ �Ŵ����� ������ ���� ��, ����Ʈ��ȣ�� ������
        string talkData = talkManager.GetTalk(id+ questTalkIndex, talkIndex);

        if (talkData == null)
        {
            Debug.Log(questManager.CheckQuest(id));
            isAction = false;
            talkIndex = 0; //���⼭ talkIndex�� �ʱ�ȭ ������� �ٸ� �����鵵 ��ȭ ����
            return; //void���� return�� �������� ��� �ڿ� �ƹ��͵� ���� �ȵ�
        }

        if (isNpc)
        {
            TalkText.text = talkData;
        }
        else
        {
            TalkText.text = talkData;
        }

        isAction = true;
        talkIndex++; //talkIndex�� 1�� �÷� ��ȭ�� �� �ִ��� Ȯ�� ������ null
    }

    private void Awake()
    {
        
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }

    }

    public void SetupScene()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        if(playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();

            cameraManger.VirtualCamera.Follow = player.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
