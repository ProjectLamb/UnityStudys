```
조명

조명 종류
    Directional
    Spot
        Inner Spot angle
            The spot light simulates a cone-shaped beam of light
    Point
    Area : 베이크 조명만 해당

Shading technique (?)
Culling Per (?)
    Object
    Layer	

Multiple directional lights (?)

Number of real-time lights per Camera (?)

Light attenuation type (?)

Vertex Lights 

Light Cookies 

광원, 발광 표면, 반사 프로브, 라이트 프로브
```

#### [1. 스폿 라이트의 설명](https://radeon-pro.github.io/RadeonProRenderDocs/en/plugins/maya/spot_light.html)

* Inner Spot Angle
<img src="./img/2023-04-10-16-23-50.png">

* Outer Cone Falloff
바깥 반경의 투영된 Spot에 흐릿함 정도를 나타낸다.
<img src="./img/2023-04-10-16-24-35.png">

#### 2. 버텍스 라이팅
* <img src="./img/2023-04-10-17-38-39.png">

#### [3. 컬링과 관련된 블로그](https://unitybeginner.tistory.com/56)
#### [4. 라이트 쿠키](https://docs.unity3d.com/Manual/Cookies.html)

```
Deferred Shading rendering path
https://docs.unity3d.com/kr/current/Manual/RenderTech-DeferredShading.html

많은 동적 광원이 포함된 씬에서 효율적이다.
클러스터 랜더링 
```

```
전역 조명 시스템
------------------------
GI

Baked Global Illumination: Progressive GPU Lightmapper
Baked Global Illumination: Mixed Lighting modes
    서브트랙티브, 
    베이크된 간점, 
    섀도우 마스크
Baked Global Illumination: Double Sided GI
Non directional lightmap
Directional lightmap

-------------------------

라이트 프로브
Light Probes: Blending
Light Probes: Custom provided
Light Probes: Occlusion Probes
Light Probes: Proxy volumes (LLPV)

반사 프로브
Reflection Probes: Baked
Reflection Probes: Real-time
Reflection Probes: Real-time time sliced all faces at once
Reflection Probes: Real-time time sliced individual faces
Reflection Probes: On-demand API
Reflection Probes: Simple sampling
    URP 에셋에서 URP가 반사 프로브에서 항상 간단한 샘플링을 수행할지 또는 블렌딩할지 선택
Reflection Probes: Blend probes sampling
Reflection Probes: Blend probes and skybox sampling
Reflection Probes: Box Projection
```

RealTime Global Illumination

인라이튼

* ContributeGI
* It enables you to adjust your lighting in real-time if you do a precompute and do not modify GameObjects in your scene with the ContributeGI setting enabled. 이 시스템을 사용하면 Unity는 조명 데이터를 라이트맵이라고 하는 텍스처와 라이트 프로브 및 반사 프로브로 베이크합니다.

[정적 & 동적](https://docs.unity3d.com/kr/2021.3/Manual/BestPracticeLightingPipelines.html)
* 어느 조명 시스템을 사용하든 Unity는 ‘Contribute GI’라고 표시된 오브젝트만 처리합니다. 
동적 오브젝트가 간접조명을 받기 위해서는 라이트 프로브를 사용해야한다.

GI 조명은 비교적 느린 연산이기 때문에 
뚜렷하게 조명 바리에이션을 가진 복잡한 에셋에만 "Contribute GI’ 태그를 지정해야 합니다. 
균일한 조명을 가지는 메시는 라이트 프로브에서 간접 조명을 받아야한다.

#### Static GameObject
런타임 시점에 음직이지 않는 게임 오브젝트다.
반면 런타임 시점에 음직이는 게임 오브젝트를 동적 게임 오브젝트라고 부른다.

정적 오브젝트는 precompute information을 제공하므로 
런타임 계산을 줄임으로 성능 향상에 기대를 준다.

#### Static Editor Flag 
![](2023-04-11-12-42-39.png)
사전 계산할것을 따로 체크 가능하다.


```
Contribute GI : GI(Bake 또는 실시간) 계산의 타겟이 된다.
    그말은 즉슨 이게 체크 안되면 베이크도 안된다 라는뜻이 된다.

Occluder&Occludee Static : 정적 오클루디&오클루전 표시를 한다 컬링 시스템

Batching Static : 게임 오브젝트의 메시를 다른 적합한 메시와 결합하여 잠재적인 런타임 렌더링 부하를 줄입니다. 
https://docs.unity3d.com/kr/current/Manual/DrawCallBatching.html

Navigation Static : 내비게이션 데이터를 미리 계산할 때 게임 오브젝트를 포함합니다. 자세한 내용은 내비게이션 시스템 문서를 참조하십시오.
```

### 광원 모드
![](2023-04-11-12-58-20.png)

Baked :
Realtime : 
Mixed 

----
Bakelight가 가능하다면.
* autoGenerate란? 언제 시작되는것인가?
* SceneManager 
* 라이트 프로브 무조건 해야함

Realtime 했을때
* 라이트 프로브 가능성
* 반사 프로브 가능성


https://docs.unity3d.com/kr/current/Manual/class-LightingSettings.html#RealtimeLighting 

### 랜더링
