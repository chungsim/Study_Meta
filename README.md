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

상호가용 가능한 이벤트 오브젝트의 모음입니다.

좌측부터 NPC, 커스터마이징, 점수판, 미니게임_비행기, 미니게임_결투 입니다.

<img width="297" height="218" alt="오브젝트 상호작용1" src="https://github.com/user-attachments/assets/2fe0fb17-a349-40f4-8946-ceb48f0e2f85" />

모든 이벤트 오브젝트는 플레이어가 접근할 시 하이라이트 스프라이트가 뜨도록 하였습니다.

이를 통해 한번에 2가지 이상의 오브젝트에 상호작용 가능한 상태가 되더라고 현재 상호작용 중인 오브젝트를 구별할 수 있습니다.

하이라이트와 상호작용 버틍니 뜬 상태로 'e'를 입력하면 해당 오브젝트의 기능이 작동합니다.

3. 오브젝트별 기능

먼저 우측 두번째 오브젝트에 상호작용하면 비행기 미니게임 씬으로 넘어가게 됩니다.

<img width="799" height="447" alt="비행기 게임 시작" src="https://github.com/user-attachments/assets/849ccc26-2d0e-4427-a54a-63662422a7a3" />

<img width="450" height="283" alt="비행기 게임 카운트다운" src="https://github.com/user-attachments/assets/43613e40-66de-41ff-8b75-de1724de252a" />

게임 시작 UI와 씬이 시작되고 시박 버튼을 누르면 3초의 카운트다운 이후 게임이 시작됩니다.

<img width="796" height="445" alt="비행기 게임 종료" src="https://github.com/user-attachments/assets/cd6ebce2-7173-4a76-abff-7de99019ff1a" />

비행기가 장해물이나 상하 지형과 충돌 시 게임이 종료되고 결과 UI가 표시됩니다.

Retrty 버튼을 통해 씬을 제시작할 수 있고 Exit 버튼을 눌러 메인 씬으로 돌아갈 수 있습니다.

게임결과 최고 점수를 갱신하면 PlayerPrefs를 통해 최고점수를 기록하고 표시합니다.

두번째 미니게임은 결투입니다.

<img width="793" height="442" alt="콜로세움 게임 스샷1" src="https://github.com/user-attachments/assets/891d5abd-a397-43a6-b25e-68f4c1735a9d" />

두 명이 동시에 플레이가 가능한 게임으로 공격을 통해 상대의 체력을 전부 깎는것을 목표로 합니다.

각 플레이어의 이동과 공격은 wasd와 스페이스바 / 방행키와 넘패드0 으로 구분하였습니다.

<img width="792" height="445" alt="콜로세움 종료" src="https://github.com/user-attachments/assets/eb36f835-eed8-4d97-91cf-4319ee68e9ad" />

한 플레이어의 체력이 0이 되면 게임이 종료되고 결과 UI가 표시됩니다.

화면 중앙에는 승리한 플레이어의 모습과 이름이 나타나고 PlayerPrefs에 1P/2P 별 승리 횟수가 기록됩니다.

다음은 점수판입니다.

<img width="760" height="401" alt="점수판" src="https://github.com/user-attachments/assets/9a49cc6b-9fa1-4fdb-af91-fca184c24952" />

점수판 오브젝트와 상호작용하면 위와 같은 UI가 표시됩니다.

좌측은 비행기 게임의 최고점수이고 우측은 결투 게임의 플레이어 별 승리 횟수입니다.

플레이어 커스터마이징 입니다.

커스터마이징 요소로 치장 아이템과 펫을 추가하였습니다.

<img width="772" height="424" alt="커스텀" src="https://github.com/user-attachments/assets/1e2576ac-c06c-44c3-bdc9-5ca47a96c74d" />

커스터마이징 오브젝트와 상호작용하면 위와 같은 UI가 표시됩니다.

좌측 버튼을 통해 적용할 펫을 고르고 우측을 통해 치장 아이템을 선택하여 중앙을 통해 미리보기가 가능합니다.

하단 Apply 버튼을 누르고 UI를 나가면 변경사항이 적용되어 있습니다.

<img width="250" height="169" alt="커스텀결과" src="https://github.com/user-attachments/assets/6393c93d-d417-42ce-9b4d-66fbcb127ec7" />

또한 PlayerPrefs를 이용하여 적용된 커스터마이징 요소를 저장, 메인 씬 복귀 시 적용되도록 하였습니다.

탈것은 현재 별도의 UI 없이 'r'키를 입력하면 적용되도록 하였습니다.

<img width="377" height="236" alt="탈것" src="https://github.com/user-attachments/assets/d9f6fb20-8afd-45fe-a11b-f1e012e13c67" />

탈것을 적용하면 플레이어의 이동속도가 빨라지고 넉백처리가 되지 않도록 하였습니다.

펫과 치장 아이템 탈것은 플레이어의 방향에 따라 상대좌표와 좌우가 반전 처리되어 위치하도록 하였습니다.

마지막으로 NPC입니다.

NPC는 상호작용 시 오브젝트의 인스펙터에 등록되어있는 스크립트(string)중 하나를 랜덤으로 표시합니다.

<img width="280" height="220" alt="대화1" src="https://github.com/user-attachments/assets/9554c8a3-7909-430e-92a1-26b67ea54812" />
<img width="259" height="214" alt="대화2" src="https://github.com/user-attachments/assets/69e1bdc5-7bcf-41a1-bcbd-19a1837e47d0" />
