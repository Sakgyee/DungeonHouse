# 1. 프로젝트 소개
퀘스트로 스토리를 진행하는 2D도트 Top-Down RPG입니다.

# 2. 프로젝트 개요
● 개발 기간 : 2023-09-09 ~ 2024-12-10

● 개발 인원 : 강민기(1인개발)

● 개발언어 : C#

● 개발도구 : Unity

● 플랫폼 : PC

# 3. 플레이 영상

https://youtu.be/tLEnkb6LgNQ

# 4. 기능
● Tilemap으로 맵을 만들고 Borderline으로 영역을 지정해 캐릭터가 갈 수 있는 곳과 없는 곳을 만들었다.

● Cinemachine으로 카메라가 플레이어를 따라가게 만들었다.

● 퀘스트에 ID를 부여해 순서를 정하고 퀘스트 데이터를 저장할 Dictionary 변수를 만든다. 퀘스트 ID와 NPC ID를 통해 퀘스트 대화가 진행이 된다. Dictionary안에 Key가 있는지 확인하는 ContainKey()를 통해 예외처리를 한다.

● WorldToScreenPoint을 이용해 체력바 오브젝트가 플레이어를 따라가게 만들었다.

● 플레이어가 X키를 눌러 공격할 때 캐릭터가 바라보는 방향으로 공격 히트박스 Collider가 켜지고 공격 애니메이션이 끝나면 사라지게 만들었다.

● 적의 공격범위 Circle Collider한개와 적의 탐지범위 Circle Collider한개를 만들어 플레이어를 추적, 공격하게 만들었고 탐지범위를 벗어나면 플레이어 추격을 멈추고 다시 주변을 배회한다.
