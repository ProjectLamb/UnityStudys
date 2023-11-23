### 다이나믹 라이팅을 처리하기위해서 랜더링 파이프라인의 변화

Baked 라면 딱히 의미가 없는 부분이라..
실시간 라이팅을 하는 게임에서 사용하는 개념을 보자..

### Forward

**Forward Rendering** (Traditional, Multipass)
전통적인 랜더링 시스템(Forward Rendering System)에서는 
오브젝트 하나를 그릴 때 마다 영향 받는 빛을 모두 탐지하고 한 셰이더 안에 몰아넣거나, 멀티 패스로 그려서 모든 빛을 표현하여야만 했다.


**진행과정**
Culling이전에 진행
즉, Vertex Shade를 지나 Fragment 과정에서 실행된다.

1. Frame buffer 
2. Depth buffer
   깊이 값을 저장해서 오클루젼 컬링을 구현
   단, 불투명 오브젝트에만 저장
   단, Order랑은 상관이 없다.
3. Double buffer
   오브젝트 하나 렌더링 될떄 그냥 프레입 버퍼가 적용 되는데
   오브젝트가 여러개 있을때는? 차곡 차곡 그리는것을 반복하게 되는데.
![](2023-04-11-17-31-37.png)

**빛**
포워드 랜더링이 빛을 표현하는 방법을 말해보자.
1. SinglePass
   * 메시나 적용되는 빛들을 한 셰이더 안에 몰아 넣는다.
   * 적은 라이트같은경우 좋긴한데.. 빛이 너무 많으면 좆된다.
2. MultiPass
   * 걍 좆 최악임 : num_objects * num_lights
   * 진짜 빛의 개수에 따라 드로우콜이 최악으로 치닫는 일이 벌어짐
   * <img src="2023-04-11-17-35-19.png" width=300px>
   * 한 오브젝트에 영향을 끼칠 수 있는 빛의 개수 최대 8개다..

* 실시간 광원에 대해선 취약하다. 실시간 광원을 사용하지 않거나 조명 정확도가 필요하지 않은 경우 이걸 사용하면 좋다 범용적인 목적을 두어 부하나 성능이 좋다.


왜냐하면 

---

### Defferd
**Defferd** 

* 동적 라이트를 다루는 기법
Diffuse, Depth, Normal 등등을 G Buffer에 담고
Culling이 끝난 이후 라이팅을 진행
* 이렇게 되면 라이트의 갯수 제한 없이, 오브젝트 개수 제한 없이 각종 라이트를 누적 시킬 수가 있다. 라이팅, 셰이딩 연산을 매우 줄여준단다.

Render Target 

**G buffer(Geometry buffer)** 
* Pass를 기록하는 버퍼란다..
* Posiiton, Normal, Color, Depth, UV, Speculer, Diffuse, Rim, Motion Blur, 이런것

<div align=center>
    <img src="2023-04-11-16-13-03.png" height=218px>
    <img src="2023-04-11-17-09-42.png" height=218px>
</div>

**진행과정**

1. Pass 1 
   * G Buffer에 Screen(화면)에 보이는 
   Geometry 정보를 텍스쳐(맵)에 기록한다.

2. Pass 2
   1. ScreenSpace(화면 공간) 에서 G buffer에 기록된 값을 바탕으로 Indirect Shading을 처리한다.

**설명**
디퍼드 쉐이딩은 GPU의 지원이 필요로 한다.
실시간 광원이 많고 높은 수준의 조명 정확도를 필요한다면 이걸 사용하는것이 좋다.
* 반투명 오브젝트는 포워드 랜더링을 사용한다
* 직교 투사 또한 포워드 랜더링을 사용한다.
* 하드웨어 안티엘리어싱은 아예 지원을 안하므로 포스트 프로세싱 효과를 사용해 유사한 형태로 구현 가능하다 

디퍼드 쉐이딩은 게임 오브젝트에 영향을 미칠 수 있는 광원의 수에 제한이 없다
* 광원이 픽셀별로 계산되므로 노멀 맵 등과 올바르게 상호작용한다.
* 단, 반투명 게임 오브젝트를 처리할 수 없다는 단점이 있다. 따라서 포워드 랜더링을 해야한다.

Deferred Rendering은 그림자 캐스팅이 없는 동적 라이팅을 맘껏 쓰고자 하는데 기본 취지가 있다. 

### Forward+ 
![](2023-04-11-19-05-08.png)

---

### ect

1. Light Indexed Defferd Rendering
   * 각 Light의 인덱스를 할당하고 픽셀마다 인덱스 저장
2. Inferred Rendering
   * 반투명 처리 가능



https://velog.io/@15ywt/%EA%B7%B8%EB%9E%98%ED%94%BD%EC%8A%A4-Ray-tracing%EC%97%90%EC%84%9C%EC%9D%98-GBuffer%EC%82%AC%EC%9A%A9%EC%9D%98-%EC%9D%98%EB%AF%B8


http://egloos.zum.com/ozlael/v/2423070

https://www.slideshare.net/cagetu/kgc2012-deferred-forward

https://www.youtube.com/watch?v=anz5bHVbeEY