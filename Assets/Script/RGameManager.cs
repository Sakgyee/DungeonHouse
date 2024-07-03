using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGameManager : MonoBehaviour
{
    public static RGameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;

    public CameraManager cameraManger;

    public GameObject talkPanel; // 대화창 끄고 키게 하기
    public Text TalkText; //대화창 텍스트를 위해 설정
    public GameObject ScanObject; //스캔 오브젝트 넣기
    public bool isAction; //상태 저장용 변수 대화창

    public TalkManager talkManager; //TalkManager 용 변수
    public int talkIndex; //TalkManager 용 변수

    public QuestManager questManager; //QuestManager 용 변수

    void Start()
    {    

        SetupScene();
        Debug.Log(questManager.CheckQuest());   
    }

    //대화를 위한 Action 
    public void Action(GameObject scanObj)
    {
        ScanObject = scanObj;
        ObjData objData = ScanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); //퀘스트 매니저를 변수로 생성 후, 퀘스트번호를 가져옴
        string talkData = talkManager.GetTalk(id+ questTalkIndex, talkIndex);

        if (talkData == null)
        {
            Debug.Log(questManager.CheckQuest(id));
            isAction = false;
            talkIndex = 0; //여기서 talkIndex를 초기화 시켜줘야 다른 옵젝들도 대화 가능
            return; //void에서 return은 강제종료 대신 뒤에 아무것도 쓰면 안됨
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
        talkIndex++; //talkIndex를 1씩 늘려 대화가 더 있는지 확인 없으면 null
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
