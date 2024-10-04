# 1. 프로젝트 소개
2D도트 Top-Down RPG입니다.

# 2. 프로젝트 개요
● 개발 기간 : 2023-09-09 ~ 2024-12-10

● 개발 인원 : 강민기(1인개발)

● 개발언어 : C#

● 개발도구 : Unity

● 플랫폼 : PC

# 3. 플레이 영상


# 4. 기능
● 플레이어의 총알을 인스턴스화 해서 관리합니다.

● 플레이어의 위치를 Json으로 저장하여 불러옵니다. 

● 플레이어의 사망시 Particle 효과를 이용해 사망모션을 보여주고 재시작 버튼을 활성화 합니다.

● 플레이어가 절벽으로 떨어질경우 CameraShake를 통해 화면이 흔들리게 됩니다.

■ Stage1

● Trigger를 이용해 함정을 관리하고 Trigger가 발동하면 함정 오브젝트들이 AddForce를 받아 일정한 방향으로 움직인다.

■ Stage2

● 스테이지에 OverlapAreaAll을 한다음 바람을 구현해 플레이어가 왼쪽 또는 오른쪽으로 WindForce만큼 밀리게 됩니다.

● Random.Range함수로 1부터 4까지 숫자를 랜덤하게 뽑고 Switch함수로 각 숫자에 맞게 무궁화 꽃이 피었습니다 패턴의 시작 초를 정하고 
  Random.Range함수로 1부터 5까지 숫자를 랜덤하게 뽑고 플레이어를 얼마나 바라보고 있을건지 WaitForSeconds메소드를 이용해 정합니다.
  Vector3.Distance로 현재 플레이어의 포지션과 적이 뒤돌아서 플레이어를 바라봤을 때의 위치랑 다르면 플레이어는 사망합니다.
  
■ Stage3

● PlayerClone을 만들어 PlayerMove값을 반대로 둬 플레이어가 움직이는 것의 반대로 움직입니다.

■ Boss Stage

● TimeLine을 이용하여 보스 등장 연출을 보여줍니다.

● 보스 패턴을 Random.Range로 1~3까지 랜덤하게 정해서 뽑습니다.

□ 1Page

● Coin 오브젝트를 인스턴스화 해서 X좌표에서 랜덤하게 아래로 떨어지는 RainShot을 쏩니다.

● 대포 오브젝트를 4개의 위치중에 랜덤으로 소환해 AddForce로 Bolt 오브젝트를 발사합니다.

● LineLenderer로 위험지역을 알려준뒤 약 2초후 보스가 일정 방향으로 돌진한다.

● 패턴 하나를 진행한 후 10초의 그로기 패턴이 진행한다.

□ 2Page

● 보스의 피가 50%이하로 내려가면 그 즉시 모든 패턴을 멈추고 2Page 애니메이션이 나옵니다.

● Circle 오브젝트 여러개가 중심점을 기준으로 일정 속도만큼 회전하는 패턴이 나온다. 각 원의 거리 조절을 위해 삼각함수인 Mathf.Cos, Mathf.Sin과 radius를 이용해 여러개의 원이 회전운동을 합니다.

● 5개의 방향에서 2개의 대포 오브젝트가 나와 Bolt 오브젝트를 발사합니다.

● 보스의 피가 0이하가 될 경우 Particle 효과가 나오면서 보스가 사망하고 엔딩 포탈이 나오게 됩니다.
