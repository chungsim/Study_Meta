# Study_Meta
스파르타 코딩 메타버스 개인과제

## 목차
1. 프로젝트 설명
2. 기능
3. 느낀점

## 1. 프로젝트 설명
본 프로젝트는 스파르타 코딩 Unity 캠프의 메타버스 개인과제를 위한 프로젝트입니다.

Unity 2022.3.62f2 버전을 사용하였습니다.

2D 형식으로 제작하였으며 다양한 상호작용을 직접 구현해보는 것을 목표로 하였습니다.

필수항목과 도전항목의 구현을 우선하였으며 에셋은 Kenny와 OpenGameArt, 일부 제작을 통해 사용하였습니다.

## 2. 기능 설명
1. 이벤트 오브젝트 상호작용
<img width="676" height="352" alt="메인" src="https://github.com/user-attachments/assets/fc62eef8-a73a-4898-a29e-3a40ad5ec12c" />

<center>(이벤트 오브젝트)</center>

상호가용 가능한 이벤트 오브젝트의 모음입니다.

좌측부터 NPC, 커스터마이징, 점수판, 미니게임_비행기, 미니게임_결투 입니다.

<center>
<img width="297" height="218" alt="오브젝트 상호작용1" src="https://github.com/user-attachments/assets/2fe0fb17-a349-40f4-8946-ceb48f0e2f85" />
</center>
<center>(이벤트 오브젝트 접근 시 하이라이트)</center>
모든 이벤트 오브젝트는 플레이어가 접근할 시 하이라이트 스프라이트가 뜨도록 하였습니다.
이를 통해 한번에 2가지 이상의 오브젝트에 상호작용 가능한 상태가 되더라고 현재 상호작용 중인 오브젝트를 구별할 수 있습니다.
하이라이트와 상호작용 버틍니 뜬 상태로 'e'를 입력하면 해당 오브젝트의 기능이 작동합니다.

3. 오브젝트별 기능
먼저 우측 두번째 오브젝트에 상호작용하면 비행기 미니게임 씬으로 넘어가게 됩니다.

<img width="799" height="447" alt="비행기 게임 시작" src="https://github.com/user-attachments/assets/849ccc26-2d0e-4427-a54a-63662422a7a3" />

<img width="450" height="283" alt="비행기 게임 카운트다운" src="https://github.com/user-attachments/assets/43613e40-66de-41ff-8b75-de1724de252a" />

게임 시작 UI와 씬이 시작되고 시박 버튼을 누르면 3초의 카운트 다운 이후 게임이 시작됩니다.

