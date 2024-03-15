## mini-project/number-baseball
- 기간 : 2021.08~2021.08 (약 1주)
- 참여 인원 : 1인
- 사용 스택 : C# Winform Socket

### [개발 동기]
C# 언어를 기반으로 서버와 클라이언트의 통신 과정을 학습하기 위해 작성했다.

### [실행 과정 설명]
1. MultiChatServer.exe 실행 (Port 9000, 서버 IP 사용)
2. MultiChatClient.exe 실행 (Port 9000, Client IP 변경)
3. 1개의 서버와 N개의 클라이언트로 1 : N 플레이

### [프로젝트 설명]
- 참조 사이트의 소스를 활용하여 콘솔 야구 게임을 개발
- 화면 : 서버 화면, 클라이언트 화면
- 기능 : 1 대 N Socket 통신, 게임 로직 개발, 서버에 접속 클라이언트 정보 리스트 및 랭킹 리스트 저장

### [기능 흐름]
| |서버 구동 화면|
|------|---|
|서버 시작 (이후 ON)|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/91513bea-3f46-46e4-a148-23e497e9e265)|

| |클라이언트 구동 화면 (플레이어 2 시점)|
|------|---|
|메인 접속 (플레이어 1)|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/fffef63e-42f7-4469-b879-d8e8172e3ef3)|
|메인 접속 및 게임 시작 (플레이어 2)|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/8be66187-c723-4b58-899c-0799a617352e)|
|숫자 입력|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/68949ef8-3b21-4065-8148-4b8eeb8187d5)|
|OK 버튼 클릭 시 결과 리스트 저장|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/845a5f3c-6fea-4cb3-8c3f-ffa40c437aec)|
|정답일 경우 서버에 결과 반영|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/2e63e83e-779b-4b27-9275-d351bc0a3093)|
|다시 하기 후 서버에 결과 반영|![image](https://github.com/Jsub22/baseball_proj/assets/77329400/1e2adec1-27a1-4312-85a5-8b208c0b4095)|

참조 사이트 : https://slaner.tistory.com/170?category=546117

### [개발 후기]
이 프로젝트의 개발 경험은 Socket 서버와 클라이언트의 구조와 이를 통해 메시지를 비동기 수신하는 법을 이해하는 데에 도움이 되었다.
이로써 다음 프로젝트에서는 컴퓨터와의 소통에서 나아가 다른 유저와의 소통으로 확장될 수 있었다.
