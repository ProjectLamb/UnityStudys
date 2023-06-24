
---

## URP : Universal Render Pipeline

### 유니티에서 URP를 다룬다는 것은..

<div align=center>
   <img src="./img/2023-03-15-10-12-20.png" width=500px>
</div>

1. URP 나 HDRP 둘중 하나 갈아끼우고
2. Render는 포워드나 2D를 갈아 끼우고
3. PASS는 뎁스프리 오파큐 갈아끼우고
   Pass 하나하나는 갈아끼우고 독립적이다.

<div align=center>
   <img src="./img/2023-03-13-21-15-56.png" width=500px>
</div>

유니티에선 특히 수많은 랜더 파이프 라인이 있어도.
포워드 랜더 파이프 라인을 사용하게 된다.

#### 1). RenderPass || Draw Call

드로우 콜
   * 정점을 랜더링 하는 동작
   한번의 그리기 호출
   비록 5000개의 인스턴스를 그린다 하더라도 동일한 OO이라면 단 한번에 그려진다.

랜더링 패스
   * 멀티패스 렌더링 테크닉과 관련이 되어 있다.
   같은 오브젝트를 여러번 랜더링한다.
   *  렌더링이 진행될떄 지나가는 각 단계 하나하나를 렌더 패스라고 한다.

#### 2). Color & Depth & Normal & Speculer

Shading technique
[Pass 종류](https://www.youtube.com/watch?v=N8dbw54pof8)
<img src="2023-04-10-16-32-31.png" width=200px>
<img src="2023-04-10-16-32-45.png" width=200px>
<img src="2023-04-10-16-33-50.png" width=200px>
<img src="2023-04-10-16-34-17.png" width=200px>
<img src="2023-04-10-16-34-45.png" width=200px>

---

### 1. URP Asset

1. URP로 그래픽, 퀄리티 설정을 할 수 있다.
2. RenderPipelineAsset을 상속하는 스크립터블 오브젝트다.
3. 이 에셋을 번갈아 갈아끼울 수 있다, URP와 상응하기만 한다면
4. 단, HDRP/SRP는 서로 호환이 안된다

---

### 2. 사전 지식

1. **렌더 텍스쳐**
실시간으로 생성되고 갱신되는 특수한 텍스쳐다.
스크린을 만드는데 이 텍스쳐를 사용할 수 있다.


2. **[깊이 텍스쳐](https://mgun.tistory.com/1860)**
랜더 텍스쳐가 저장하고있는 "카메라로부터 얼마나 멀리 떨어져있는지"에 대한 값을 바로 깊이 텍스쳐라고 한다.
깊이 텍스쳐를 만들기위해서는 카메라에 대해 이야기 해야한다.
Camera.depthTextureMode를 통해 얻어진다.

* 
   |일반|깊이 카메라|
   |---|---|
   |<img src="./img/2023-03-23-21-42-19.png" >|<img src="./img/2023-03-23-21-42-02.png" >|
   
3. **[노멀 텍스쳐](https://m.blog.naver.com/cccani/221232979712)**
일일이 높이와 질감이 있는 물체는 용량이 너무 크므로
z, y, z 좌표를 R, G, B 좌표로 만든것이다.

* 멀리서보면 입체감이 살지만, 가까이서 보면 결국 평면인것
* 물체의 표면에 굴곡이 있을 때 그 굴곡 때문에 표면의 방향이 바뀌고 그 방향에 따라 빛이 다르게 반사되기 때문에 보는 사람이 그 굴곡을 느낄 수 있다. 
* 결국 표면 질감에서 중요한 건 진짜 굴곡이 아닌 반사각이기 때문에 3D그래픽으로 물체를 표현할 때 표면을 실제로 굴곡이 있는 형태로 만들지 않고, 평면으로 만들고 그 위에 어떤 각도로 보일지 그려놓으면 하나의 폴리곤으로 굴곡이 있는 표면을 표현할 수 있다.
<img src="./img/2023-03-23-21-46-06.png" >

4. **Map**
<img src="./img/2023-03-23-21-48-09.png" >
<img src="./img/2023-04-11-16-04-21.png">
<img src="./img/2023-04-11-16-03-36.png">

*
   ```
   엠비언트 맵 : 엠비언트 오클루전이라고 부르는데 "주변광 차단"
      * 면과 면과 붙은곳은 빛이 덜들어 온다는것을 저장
      * 이걸 텍스쳐로 만들어주면 엠비언트 텍스쳐가 돤다

   디퓨즈 맵(Diffuse) : 난반사, 물체에 깊이감과 입체감을 주고 표면에 색을 부여하는 요소
      * 울퉁 불퉁한 면에 반사되면서 광자의 방향이 들쭉 날쭉한것.
      * (색 + 질감 + 오클루젼 의 조합) 

   스펙큘러(Speculer) 맵  : 정반사,
      * 빛을 받을떄 광택이 있는 물체는 하이라이트(하얗게 되는 부분) = 그 부분은 빛을 그대로 받으면 다 반사 시키기 떄문에 생기는것.
      * 반사되는 색을 조정해주는 Map(텍스쳐)
   ```

1. **투명(Transparent)과 불투명(Opaque)**
Opaque 옵션은 투명하게할지, 불투명하게 할지 를 나타내는 옵션

<div align=center>
   <img src="./img/TTO.png" width=300px>
</div>

---

### 3. UI 목차
목차는 다음과 같다

```
General
Quality
Lighting
Shadows
Post-processing
Advanced
```


#### 1). General

<div align=center>
   <img src="./img/2023-03-23-20-07-26.png" width=500px>
</div>

1. Depth Texture : (On - Off)
   * _CameraDepthTecture을 만드려면 활성화
   * 모든 카메라를 하여금 깊이 텍스쳐를 사용하게 한다.
   * 또는 개별적인 카메라에게 깊이텍스쳐를 사용하게끔 할 수 있다.

2. Opaque Texture : (On - Off)
   * 모든 카메라의 _CameraOpaqueTexture을 만드려면 활성화 
   * GrapPass와 같은 역할을 한다.
     * [GrapPass는 반투명 굴절을 구현하는것이다.](https://darkcatgame.tistory.com/110)
   * Opaque Texture는 일종의 스냅샷을 만드는걸 제공한다. URP가 모든 투명한 매쉬들을 랜더링 하기 전에
   * frosted glass, water refraction, or heat waves 같은 이펙트를 만들꺼면 사용해라..

3. Opaque Downsampling
   * 불투명도 텍스쳐는 필터 적용도를 나타낸다.
4. Terrain Hole (터레인 홀)
   * 이걸 비활성화 시키면 모든 터레인 홀 변형이 제거된다.
   * 빌드 시간이 짧아 진다.

뎁스+노멀 또는 모션 벡터 텍스처

---

### 2). Quality

![](2023-04-12-11-00-36.png)
그래픽 수

1. HDR
   * High Dynamic Range 즉 거리에 따른 렌터링 퀄리티를 조절할 수 있음
   * Bloom 

---

### 3). Lighting


---

### 4). Shadows

---

### 5). Postprocessing

---

### 6). Advanced

---

### 예제
1. 카메라 스태킹
   * baseCamera
   * 카메라 중첩 
   * 랜더링 파츠 : 카메라 별로 랜더링을 따로 바를 수 있음.
2. 3D SkyBox
3. 스탠실 버퍼
4. 포스트 프로세싱
   1. 아웃풋 텍스쳐
   2. 스크린 쉐이더 블러처리
   3. 텍스쳐 LOD : 거리에 따른 텍스쳐 퀄리티
5. 각 오브젝트마다 (총이든, 카메라든) 광각을 다르게
   1. 오브젝트 별로 Pov값을 조절할 수 있다.
6. 시네머신 레일, 4개 카메라 분할
7. 외곽선
   * Cull Front
     * 사실 앞면만 그리지만 뒷면을 확장되서 그리게 된다면 아웃라인처럼 보일 수 있다.
   * 소벨 마스크
   * 포스터라이제이션 
     * 카툰 그래픽 : 선형 색칠을 계단형식으로
   * 파이프라인 갈아 끼우기
   * 포스트 프로세싱 처리
   * 런타임 중에도 갈아 끼울 수 있음
8. 캐릭터가 가려지면 실루엣이 보여지게끔 할 수 있음
   * 쉐이더 그래프 이용
9. 랜더링 레이어
   * 특정 레이어만 보여질 수 있게 설정 가능x

---

### 참고
* https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/universalrp-asset.html

* https://mgun.tistory.com/1860

* https://youtu.be/oGCydIALgJg?t=1670

* https://m.blog.naver.com/cccani/221233015525