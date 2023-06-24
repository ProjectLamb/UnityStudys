```
------------------------
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
![](2023-04-10-16-23-50.png)

* Outer Cone Falloff
바깥 반경의 투영된 Spot에 흐릿함 정도를 나타낸다.
![](2023-04-10-16-24-35.png)

#### 2. 버텍스 라이팅
* ![](2023-04-10-17-38-39.png)

#### [3. 컬링과 관련된 블로그](https://unitybeginner.tistory.com/56)
#### [4. 라이트 쿠키](https://docs.unity3d.com/Manual/Cookies.html)


```
------------------------

그림자
조명 종류에 대한 그림자
    Directional Light Shadows
    Directional Light Cascade Shadows
    Spot Light Shadows
    Point Light Shadows

Shadow Projection (?)
Shadow Lighting Pass (?)
Shadow Screen Space Pass (?)
Shadow bias
    지원되는 타입: 광원 방향의 오프셋 섀도우 맵 텍셀, 노멀 바이어스
PCF filtering (Percentage Closer Filtering) 
Resolution settings
Shadow Distance Fade
Shadow Mask
    씬별로 설정
Distance Shadow Mask
    포워드 렌더링 경로만 해당
```

#### 1. Shadow Projection
* 
    Stable Fit 
    Close Fit 
    ![](2023-04-10-17-45-19.png)

#### [2. 새도우 바이어스](https://docs.unrealengine.com/4.27/ko/Resources/ContentExamples/Lighting/6_1/)

#### [3. 쉐도우 필터](https://digitalrune.github.io/DigitalRune-Documentation/html/bed07eb7-0d10-40f3-93e8-c823a787b6a7.htm)
* ![](2023-04-11-10-08-03.png)

#### [4. 쉐도우 마스크](https://catlikecoding.com/unity/tutorials/custom-srp/shadow-masks/)
* Mix realtime and baked shadows.


```
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

--------------------------

레이 트레이싱 : 지원안함

--------------------------

패스트레이싱 : 지원안함

--------------------------

환경 조명 : 지원..

--------------------------

걸러 & 색 공간 : 지원

--------------------------

카메라 
Multi display
Hardware Dynamic resolution
Compositing multiple cameras
    카메라 스태킹
Multi-sample anti-aliasing (MSAA)
Fast approximate anti-aliasing (FXAA)
Subpixel morphological anti-aliasing (SMAA)
Depth Texture
Depth + Normal Texture
    SSAO 사용 시에만 활성화
Color Texture
Motion Vectors

--------------------------

볼류 메트릭 
    Linear Fog
    Exponential Fog
    Exponential Squared

--------------------------

기타 시각 효과
Line Renderer component
Trail Renderer component
Lens flares
World Space UI

--------------------------
스크립팅

Camera.RenderWithShader 대신 ScriptableRenderPass
Camera.Render

--------------------------
최적화
Batching By 
    * Shader
    * Material
    * Material Property Blocks
    * Dynamic batching
    * Real-time batching with SRP Batcher
```