## 0. 이펙트 세팅
[유니티 스카이 배경 어둡게](https://www.youtube.com/watch?v=5sOzn3KZjzg)

## 1. Particle System

https://cafe.naver.com/fxcg : 카페
https://mebiusbox.github.io/contents/EffectTextureMaker/ : 파티클 생성기
https://gamefx.co.kr/ : 아카데미
https://www.pinterest.co.kr/search/pins/?q=game%20effect&rs=typed : 핀터레스트
https://www.videocopilot.net/tutorials/ : 비디오 코파일러
https://halisavakis.com/my-take-on-shaders-vfx-master-shader-part-iii/ : 해외 장인

### 1). 메인 모듈
1. Duration : Play가 끝나는 
2. Looping > Prewarm
   1. 눈을 먼저 뿌릴때.
3. Start Delay : 시작시 좀있다 실행
4. 파티클이 얼마나 남아있을지 수명
5. 사이즈, 회전 각도, 중력 적용, 속도, chleo vkxlzmf tn
6. 파티클이 따라가냐 완전 독립인가
   1. 구름, 호스, 화염 방사기와 같은 시스템에서는 파티클이 부모 게임 오브젝트와 따로 움직이도록 설정해야 합니다.
   2. 반면에 두 개의 전극 사이에서 생기는 불꽃을 만드는 데 사용되는 파티클이라면 부모 오브젝트와 함께 이동해야 합니다.
7. 스케일링 모드 : 
   1. 시작 포지션 : 점에만
   2. 부모의 크기를 따라가는
8. Emitter velocity (?)
   1. Transform 컴포넌트의 움직임을 추적하여 속도를 계산할 수 있습니다.
9.  Stop Action
   1.  파티클이 정지되었을때 특정 동작을 수행하도록 설정 가능
       1.  Disable : 비활성화
       2.  Destroy : 게임 오브젝트 파괴
       3.  Callback : OnParticleSystemStopped 콜백을 게임 오브젝트에 연결된 스크립트로 전송합니다.
10. 컬링 모드
    1.  파티클이 화면 밖으로 나가면 시뮬을 중단할지 말지.
        1.  Automatic : 루핑은 멈춘다
        2.  Pause : 멈춘다
        3.  Always Simulate (?)
11. Ring Buffer Mode	
    1. 파티클이 Max Particles 수에 도달할 때까지 파티클을 계속 활성화합니다. Max Particles 수에 도달하면 수명이 경과한 파티클을 제거하는 대신 가장 오래된 파티클을 재활용하여 새 파티클을 생성합니다. 아이작 눈물
    2.  Pause Until Replaced	수명을 다한 오래된 파티클을 일시정지했다가 Max Particle 한계에 도달하면 시스템에서 재활용하여 새 파티클로 다시 표시되게 합니다.
    3. Loop Until Replaced	수명을 다한 파티클이 특정한 수명 비율 지점으로 다시 돌아가며, Max Particle 한계에 도달하면 시스템에서 재활용하여 새 파티클로 다시 표시되게 합니다.

#### 2). Emission
1. 레이트 오버 타임
2. 거리당 방출량(Rate over Distance)  : 음직일떄 출현할때.
   1. (예: 흙길을 달릴 때 자동차 바퀴에서 나오는 먼지)
3. 버스트 모드 : 샷건 모드
    1번 2번 3번 리스트 샷건 가능
     특정 시간마다 나타나는 추가 파티클(예: 연기가 나는 증기 기관차 굴뚝)의 버스트

#### 3). ShapeMode
1. 방출 표면
   1. 구체
   2. 반구(Hemisphere)
   3. 원뿔(Corn)
   4. 박스
   5. 메시, 메시랜더러, 스킨드 메시랜더러
   6. 스프라이트 렌더러
   7. 2D 원
   8. 가장자리 edge : 한 면으로만
   9.  도넛
   10. 직사각형

#### 4). Velocity Over Lifetime 
* 모듈을 통해 파티클의 수명 주기에 걸쳐 속도를 조절할 수 있습니다.
월드축으로 두고 쓰자
소용돌이 만들 수 있다.
올라가면서 반경이 넓어 지게도 할 수 있다.

#### 5). Limit vel over lifetime  
라이프 타임에 따라 속도 감속을 주기
![](2023-02-17-16-56-01.png)

#### 6) 인헤릿 벨로시티
부모 오브젝트의 속도에따라 사용

#### 7). force 오버 라이프 타임
처음엔 느리다가 빠르게
![](2023-02-17-16-58-45.png)

#### 8). 파티클 마다 시간 색상 변경

#### 9). 컬러 바이 스피드
속도가 빠르면 색이 바뀜

#### 10). Rotation
1. Rotation over Lifetime : 생명 주기에 따른 회전
   * 시간 경과에 따른 프로퍼티 다양화 
     * 시간이 다닳면 점점 느려지는
     * ![](2023-02-17-17-02-47.png)
     * 마지막 발악을 하는
     * ![](2023-02-17-17-03-48.png)


2. Rotation by Speed
Angular Velocity 이랑 Speed Range 방향을 잘 확인해야한다
될수있으면 Angular 는 증가함수로 지정하자.
   * 굴러가다 느려지는 파티클 빠를수록 더 미치는 파티클
      * ![](2023-02-17-17-00-08.png)

   * 느릴수록 더 미치는
     * ![](2023-02-17-16-44-30.png)

#### 11). 노이즈 모듈
이 모듈을 사용하여 파티클의 움직임에 역동성을 더할 수 있습니다.

예를 들어 타다 남은 불이 움직이거나 연기가 움직이면서 소용돌이치는 모습을 상상해 보십시오. 강한 고주파 노이즈를 사용하여 타다 남은 불을 시뮬레이션할 수 있고, 부드러운 저주파 노이즈를 사용하여 연기 효과를 모델링할 수 있습니다.

#### 12). 콜리젼 바닥을 이해함 (충돌 모듈)


#### 13). 서브 이미터

#### 14). 스프라이트 텍스쳐
* 텍스쳐 시트 애니메이션
1, 2, 3, 4 순서대로
그리드 사용가능

* 1, 2, 3, 4, 
랜덤으로 

#### 라이트 절대 안씀

#### 트레일 
트레일 메테리얼 달을수 있음
모드 담배 모양도 된다. 모드에 따라
버텍스 디스턴스 꺾을때 자연스러움
텍스쳐가 쭉 늘어나가 또는 연달아서 할지

#### Custom Data Module 중요..
쉐이더를 건든다. 쉐이더 코드
쉐이더와 파티클시스템이 연동되는 Parameter를 만들고 다루는 것입니다.
파티클 시스템에 넣은 마테리얼의 색 데이터만 변경가능했지만 해당 기능을 사용하면 여러가지 데이터를 조작하여 더 다양한 파티클을 만들 수 있게 됩니다.

![](2023-02-17-17-06-20.png)
Renderer모듈에 Custom Vertex Streams를 체크하면 Custom Data를 사용하겠다는 것을 뜻하며, 이는 쉐이더와 연동이 된다는 뜻입니다.
![](2023-02-17-17-07-34.png)

![](2023-02-17-17-08-37.png)
특히
Vertex Stream부분을 보시면 추가한 Custom1.x뒤에 TEXCOORD0.z라고 명시된 것을 확인 할 수 있습니다.
이는 쉐이더의 input 값으로 TEXCOORD0.z가 들어온다는 뜻

Shader의 Input 구조체를 통해 다양한 정보를 쉐이더로 입력받을 수 있다.
![](2023-02-17-17-09-00.png)
![](2023-02-17-17-09-08.png)

파티클을 통한 본격적인 쉐이더 변수조작
![](2023-02-17-17-09-49.png)
![](2023-02-17-17-09-56.png)

#### 랜더러 모드 : 잘쓴다

* _ 
   빌보드 : 늘 나만 바라보게
   메테리얼 : 파티클 앞뒤 정렬
   파티클들 간의 앞뒤 순서
   보통 뷰를 많이 쓴다.
   파티클의 오프셋 피봇.
   스프라이트 마스크도 지정 : 마스크 만큼 많이 쓰게.
   파티클 맥스

https://darkcatgame.tistory.com/63
https://chulin28ho.tistory.com/438


파티클 아웃라인 생기는거 거슬리면
https://www.reddit.com/r/Unity3D/comments/7ylur0/why_do_particles_get_an_selection_outline_since/?onetap_auto=true