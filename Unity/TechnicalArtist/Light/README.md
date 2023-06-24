<h1 align="center"> Light </h1>

---

```
* 라이트맵 라이트 프롭스
    * Light의 종류
    * Light Map 이론
    * Light Map 실습
    * Light Probes에 대한 이해
    * Light Probes 활용 실습
* prograssive, 라이트 매퍼, Global Illumination, 레이트레이싱, 인라이튼
* 라이트 매핑 : 직접 조명과 간접 조명을 사전에 계산하고, 나중에 사용할 수 있도록 해당 결과를 라이트맵이라는 텍스처에 저장할 수 있습니다. 
```

![](./img/2023-02-27-17-05-08.png)

## 1. 개요

\# GI

글로벌 일루미네이션
GI란, 수학적 모델이다, 복잡한 빛의 행동을 시뮬레이트하기 시도하기위한 모델
반사되거나, 상호작용하는 

사전에 계산을 처리하는 방식을 사용한다.

GI 가 작동하느 방식과 개요를 살표보자

## 2. 라이팅 방법 선택하기

\# 실시간 라이팅 \# Baked GI

사실 실시간으로 계싼이 가능하다고는 하지만..

하지만 여기서는 간략한 차이점을 소개할것이다.

성능상으로 각각 차이가 있다.

#### 1). 실시간 라이팅

Directional은 실시간 라이팅이다.
Directional는 UPDATE 때마다 계산된다,

하지만, 실시간 라이팅은 반사가 되지 않는다.

좀더 사실적인 라이팅을 위해서는 Baked 라이팅이 필요하다

#### 2). Baked GI 라이팅
베이크는 Static 오브젝트를 베이크한다.
베이크 라이트는 반사된다.
게임 플레이동안은 바꿀수 없다.

## 3. 프리 컴퓨트 프로세스

\# Probes \# Baked

Precompute 프로세스

Auto Generate Lighting On

백그라운드 처리가되서 에디터 처리도하면서 같이할수 있다.

그래서 베이킹 작업은 다음을 포험한다.
```
Probes
    1. Ambient Probes
    2. Baked/Realtime Reflection Probes

Baked GI
    1. Create Geometry
    2. Atlassing
    3. Create Baked Systems
    4. Baked Resources
    5. Baked AO
    6. Export Baked Texture
    7. Bake Visibility
    8. Bake Direct
    9. Ambient and Emissive
    10. Create Bake Systems
    11. Bake Runtime
    12. Upsampling Visibility
    13. Bake Indirect
    14. Final Gather
    15. Bake ProbesSet
    16. Compositing
```

precomputed realtime GI를 사용하면, Scene내의 스태틱 메쉬 주변에 반사되는 빚을 미리 계산하는 과정을 거친 다음, 런타임에 사용하기 위해서 이 데이터를 저장한다.

## 4. Precompute 실습

오직 Static geometry가 베이크 대상이다.

일단 Precompute작업을 하려면, 적어도 하나의 GameObjectrk Static 표시가 되어있어야한다. 인스펙터에서 선택해라.

Inspactor > Static 
모든 게임 오브젝트를 Static을 하게할것이다.

Auto Lighting > Scene > Auto 
하면 자동적으로 Precompute 해준다.

## 5. Auto/Manual Precompute
Auto/Manual 설정 

오토 제너레이트가 Selected  되어있으면 알아서 해주겠지만

만약 Selected 설정 안되어있으면 직접 설정해야하는데
![](./img/2023-03-16-23-24-59.png)

## 6. GI Cache
BakeGI는 데이터로 저장된다.
그리고 재사용 가능한 형태다

## 7.랜더링 Path 선택하기

**Forward 랜더링**

![](./img/2023-03-17-09-58-22.png)

그 각각의 오브젝트에 영향을 미치는 빛을위해
각각 오브젝트는 pass 에서 랜더링 된다.

포워드 랜더링 방식은 빠르다, 
하드웨어 계산량이 낮아짐

어쩄든 이비지 퀄리티를 높이는데 이바지한다.

하지만 단점이 미리 계산하는데 있어 
더많은 오브젝트간 상호 영향을 끼친다면 랜더링속도가 늦어진다.

게임에서 많은 빛은 금기시된다.
빛의 카운트를 잘 조절만 한다면 좋다.

Drawcall 계산을 할 때마다 Light (빛) 연산을 수행하여 Object의 색상을 결정한다. 


**Defrred 랜더링**

![](./img/2023-03-17-09-58-28.png)

Drawcall 결과값을 여러 개의 Render Target에 저장하게 된다. 

Depth, Normal, color 계산을 하여 각기 다른 랜더 타겟어 결과값을 저장한다.
![](./img/2023-03-17-10-48-09.png)

장점은 빛 연산의 오버 헤드를 줄일 수 있다.

결과적으로 Light의 개수가 많거나 Object의 개수가 급격히 많아지는 경우 Deferred Rendering의 성능이 Forward Rendering보다 좋아진다.

Mobile Device 같은 경우 Forward Rendering을 더 많이 사용한다. Deferred Rendering의 경우 여러 개의 Render Target을 저장하기 위해 많은 Memory 공간이 필요하다. 

https://mkblog.co.kr/gpu-forward-rendering-vs-deferred-rendering/

---

## 8. 컬러 스페이스 선택
**Linear Color**
Edit > Project Setting > Player

단 몇 모바일에서는 사용 불가능

**Gammaa Color**

https://docs.unity3d.com/kr/2019.4/Manual/LinearRendering-LinearOrGammaWorkflow.html

## 9 HDR 
컬러 스페이스도, 다이나믹 레인지
사용가능한 동작 범위


```
Dynamic range 
1. DR이 높으면 밝은 이미지와 어두운 이미지를 동시촬영이 유리하다
2. DR이 높으면 비슷한 밝기의 이미지를 구분하는것이 용이하다.
3. Noise가 좋다
```

밝거나 어두운 색상을 캡쳐하는 방식을 정의한다.
HDR을 사용하면 색정확도, 표현력이 증가하고
음영 영역 사이 밝기 차이가 명확하게 되도록 할수 있다.

## 10 톤 매핑

## 11 Reflextion
**반사 소스**
일반적으로 씬의 오브젝트는 표준 셰이더를 사용하여 랜더링 된다

기본적으로 높은 반사율, 금속재질은 Skybox를 반영한다.

**Probes**
종종 Skybox를 단순히 반사하는건 주변 사물과 제대로 영향을 미치지 못하는것이다. 정확한 반사를 위해서는 반사 프로브를 사용해 물체가 보는것을 샘플링 해야한다.

GameObject > Light > Reflection Probe
를 통해서 반사 프로브를 추가 할 수 있다.


![](./img/2023-03-17-12-08-04.png)
좌측은 기본 반사, 오른쪽은 반사 프로브가 추가된상태

반사 프로브는 Baked, Realtime, custom 으로 설정할 수 있으며
실시간은 매우 해롭다. 따라서 베이킹 반사 프로브가 선호된다.

## 12 주변 조명
Window > Rendering > Lighting Setting > Source

## 13 조명의 유형
1. 디렉셔널 라이트
2. 포인트 라이트
   1. 3D공간의 한 점으로 생각할 수 있다.
   2. 전구, 무기 Glow 오브젝트에서 빛이 방출될떄 유용하다.
   3. 벽과 바닥을통해 빛이 새어나갈 수 있는 문제도  있는데 Baked 처리하면 괜찮다.
3. 스포트라이트
   1. 원뿔로 투사한다
4. 에어리어 라이트
   1. 사각형 조명

## 14 Emissive Material
표면 전체에 빛을 방출하는 메테리얼이다.
셰이더가 다루는 속성이다.
![](./img/2023-03-17-12-28-13.png)

## Light Probe
Baked 또는 Precompute Realtime GI 시스템에서는 정적 개체만 고려한다.

라이트 프로브를 쓰면 라이트맵에 영향을 미치는
동일한 복잡한 반사 조명에 음직이는 물체가 반응할 수 있다.

#### 프로브의 이해가 아직 잘..

https://learn.unity.com/tutorial/introduction-to-lighting-and-rendering-2019-3#5fe99310edbc2a29f881124b

https://www.slideshare.net/gukhwanji/ss-23259457

https://www.youtube.com/watch?v=VnG2gOKV9dw

https://www.youtube.com/watch?v=wwm98VdzD8s
