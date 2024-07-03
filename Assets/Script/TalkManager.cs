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
        talkData.Add(1000, new string[] { "좋은 물건이 많다네" });
        talkData.Add(1100, new string[] { "여러가지 아이템을 팔고 있어요" });
        talkData.Add(1200, new string[] { "우리 마을은 경치가 아름다운 곳이라네",
                                          "한번 마을을 둘러보게나."});
        talkData.Add(1300, new string[] { "안녕?", 
                                          "이 곳에 처음 왔구나?",
                                          "한번 둘러보도록 해" });
        talkData.Add(1400, new string[] { "언제 불의의 습격을 당할지 모르니 조심해"});
        talkData.Add(1500, new string[] { "요즘들어 우리 마을의 세계수님이 시들해지고 있어",
                                          "왜 이러는 걸까..." });
        talkData.Add(1600, new string[] { "후우..",
                                          "그녀랑 잘 되고 싶은데 어떻게 해야 할까..."});
        talkData.Add(1700, new string[] { "저 녀석이 너무 미워..",
                                          "복수 할거야..."});

        talkData.Add(100, new string[] { "평범한 나무상자야" });
        talkData.Add(200, new string[] { "평범한 나무상자야" });
        talkData.Add(300, new string[] { "우리집이야" });
        talkData.Add(400, new string[] { "어렸을 때 아버지가 만들어준 놀이터야" });
        talkData.Add(500, new string[] { "우리 마을을 지켜주는 세계수님이야" });
        talkData.Add(600, new string[] { "이장님의 집이야" });
        talkData.Add(700, new string[] { "상점주인 아주머니 집이야" });
        talkData.Add(800, new string[] { "대장장이 아저씨 집이야" });
        talkData.Add(900, new string[] { "기사님의 집이야" });
        talkData.Add(999, new string[] { "여긴 누구의 집이지..?" });

        talkData.Add(10100, new string[] { "잠겨있다." });
        talkData.Add(10200, new string[] { "부모님의 일기다."});
        talkData.Add(10300, new string[] { "내 얼굴이 보인다." });
        talkData.Add(10400, new string[] { "어렸을 때 읽었던 먼나라 이웃나라 책이 시리즈 별로 꽂혀있다."});
        talkData.Add(10500, new string[] { "보기만 해도 졸린 책들이 가득하다." });
        talkData.Add(10600, new string[] { "어렸을 때 가지고 놀던 장난감들이 들어있다." });
        talkData.Add(10700, new string[] { "여러가지 잡동사니들이 들어있다." });
        talkData.Add(10800, new string[] { "음식물 쓰레기가 들어있다." });
        talkData.Add(10900, new string[] { "재활용 쓰레기들이 들어있다." });
        talkData.Add(11000, new string[] { "잡다한 쓰레기가 들어있다." });
        talkData.Add(11100, new string[] { "낡은 검이 들어있다.",
                                           "검이 왜 여기에 들어있지..?"});
        //Dungeon 1
        talkData.Add(11200, new string[] { "순서가 맞지 않는것 같다." });
        talkData.Add(11300, new string[] { "순서가 맞지 않는것 같다." });
        talkData.Add(11400, new string[] { "순서가 맞지 않는것 같다." });
        talkData.Add(11500, new string[] { "순서가 맞지 않는것 같다." });
        talkData.Add(11600, new string[] { "다음 층으로 내려가고 싶으면 모든 수정을 활성화 해야한다." });
        //Dungeon 2
        talkData.Add(11700, new string[] { "던전 지하 2층" });
        talkData.Add(11800, new string[] { "순서에 맞게 수정을 활성화 하면 문이 열릴 것이다." });
        talkData.Add(11900, new string[] { "아래에 4개의 수정이 모이면 문이 열리리라." });
        talkData.Add(12000, new string[] { "던전 지하 3층" });
        talkData.Add(12100, new string[] { "포기하고 싶은 자 여기로"});
        talkData.Add(13200, new string[] { "빨간색을 조심해라" });
        //Dungeon 3
        talkData.Add(12200, new string[] { "주황색 보석 3개를 모아 마지막을 향해 가라" });
        talkData.Add(12300, new string[] { "준비가 된 자만 앞으로" });
        talkData.Add(12400, new string[] { "텅 비어 있다" });
        talkData.Add(12500, new string[] { "텅 비어 있다" });
        talkData.Add(12600, new string[] { "텅 비어 있다" });
        talkData.Add(12700, new string[] { "문이 굳게 닫혀있다" });
        talkData.Add(12800, new string[] { "준비가 됐으면 보석 3개를 끼워 넣고 가운데 석상에게 말을 걸어라" });
        talkData.Add(12900, new string[] { "주황색 보석이 박혀있다" });
        talkData.Add(13000, new string[] { "주황색 보석이 박혀있다" });
        talkData.Add(13100, new string[] { "주황색 보석이 박혀있다" });
        //Quest Talk

        //10은 QuestManager에 있는 퀘스트 번호 1300은 npc 번호

        //village
        talkData.Add(10 + 1300, new string[] { "어서와",
                                          "요즘 우리 마을 분위기가 좋지 않아",
                                          "조심하는게 좋아",
                                          "일단 이장님께 가봐",
                                          "이장님은 우리 섬의 세계수님 위쪽에 살고 있어"});
        talkData.Add(11 + 1200, new string[] {"아 자네인가 많이 컸구먼",
                                              "집의 문이 잠겼다고?",
                                              "집 열쇠라면 선착장 상자에 있을걸세",
                                              "찾으면 나에게 다시 돌아오게나"});

        talkData.Add(20 + 1200, new string[] {"아직도 찾지 못한겐가?",
                                              "선착장에 가서 상자를 잘 살펴보게"});
        talkData.Add(20 + 5000, new string[] { "뭔가가 들어있는거 같다.",
                                              "상자에서 집 열쇠를 찾았다." });
        talkData.Add(21 + 1200, new string[] { "오, 그래 찾았군",
                                               "자네의 집은 놀이터 오른쪽 집이라네" });

        talkData.Add(30 + 10100, new string[] {"열쇠를 사용해 문을 열었다."});


        //home
        talkData.Add(40 + 10200, new string[] { "5월 1일\n요즘들어 선조가 봉인해둔 던전이 심상치가 않다. 점검을 해봐야 될거 같다.",
            "5월 7일\n아내와 상의끝에 우리 옷장에서 장비를 꺼내 던전 아래로 내려가보기로 했다.   ",
            "5월 11일\n던전 안에는 봉인석이 부숴져있었다. 어떻게 이럴수가...",
            "5월 14일\n준비를 완벽하게 하고 다시 던전을 내려가보기로 했다.",
            "5월 14일\n던전 입구는 다시 숨기기 위해 대장장이에게 부탁을 했다.",
            "5월 17일\n던전을 내려갈 준비를 마쳤고 내일 아내와 함께 봉인석을 고치러 가기로 했다.",});
        talkData.Add(41 + 11000, new string[] {
            "구겨진 쪽지가 있다.","자네가 부탁해서 던전은 숨겨뒀다네",
            "'거울 뒤 버튼'을 누르면 던전 입구를 찾을 수 있을거야.",
            "맞다 자네가 안쓰는 검들은 자네들 방 옷장에 넣어뒀다네"});
        talkData.Add(42 + 10300, new string[] { "어딘가 열리는 소리가 났다." });

        talkData.Add(50 + 11200, new string[] { "파란수정을 활성화 했다." });
        talkData.Add(51 + 11300, new string[] { "붉은수정을 활성화 했다." });
        talkData.Add(52 + 11400, new string[] { "초록수정을 활성화 했다." });
        talkData.Add(53 + 11500, new string[] { "노란수정을 활성화 했다." });
        talkData.Add(54 + 11600, new string[] { "모든 수정이 활성화 되었다." });

        talkData.Add(60 + 11200, new string[] { "파란수정을 활성화 했다." });
        talkData.Add(61 + 11300, new string[] { "붉은수정을 활성화 했다." });
        talkData.Add(62 + 11400, new string[] { "초록수정을 활성화 했다." });
        talkData.Add(63 + 11500, new string[] { "노란수정을 활성화 했다." });
        talkData.Add(64 + 11600, new string[] { "모든 수정이 활성화 되었다." });

        talkData.Add(70 + 12400, new string[] { "석상에서 첫번째 보석을 뺐다." });
        talkData.Add(71 + 12500, new string[] { "석상에서 두번째 보석을 뺐다." });
        talkData.Add(72 + 12600, new string[] { "석상에서 세번째 보석을 뺐다." });
        talkData.Add(73 + 12700, new string[] { "막고 있던 벽이 사라졌다." });
        talkData.Add(74 + 12800, new string[] { "준비가 됐으면 보석 3개를 끼워 넣고 가운데 석상에게 말을 걸어라" });
        talkData.Add(75 + 12900, new string[] { "주황색 보석을 끼워 넣었다." });
        talkData.Add(76 + 13000, new string[] { "주황색 보석을 끼워 넣었다." });
        talkData.Add(77 + 13100, new string[] { "주황색 보석을 끼워 넣었다." });
        talkData.Add(78 + 13200, new string[] { "부모님의 저주를 풀었다 이제 어서 부모님을 데리고 탈출하자." });
    }

    public string GetTalk(int id, int talkIndex) //talkIndex를 사용해 첫번째 문장을 가져올것인지 두번째 문장을 가져올것인지 확인
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
