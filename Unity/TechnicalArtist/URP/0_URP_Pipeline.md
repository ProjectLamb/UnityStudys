## 랜더링

모델(정점 골격) 데이터로 저장된 물체를 정점 표면을 어떻게 보여줄지, 모니터로 보여주는것

**World Space & Viewport Space & Screen Space**

1. 월드 스페이스
   : A world space point is defined in global coordinates (for example, Transform.position). It is the position of the object in world or global space. 

2. 스크린 스페이스 & 뷰포트 스페이스
   : 스크린 스페이스는 카메라가 월드를 비출때, 비추는 화면을 픽셀로 정의한것 이다.
    * 
        |Screen Space| Viewport Sapce|
        |---|---|
        |![](2023-04-09-19-27-51.png)|![](2023-04-09-19-28-08.png)|

**다음과 같은 과정이 거쳐진다.**

1. 투영(Projection) 
    : 정점 vertex으로 이루어진 3차원 오브젝트를 2차원 스크린에 비추는 과정
2. 클리핑(Clipping) 
    : 스크린 밖의 오브젝트 부분을 처리하는 과정
3. 은면처리(Hidden Surface) 
    : 오브젝트에서 보이는 부분, 보이지 않는 부분을 처리하는 과정
4. 쉐이딩(Shading) 
    : 음영, 조명 빛, 광원 빛, 반사광, 투명한 효과를 버텍스, 프래그먼트를 조작하여 처리하는것
        * Local Illumination : 지역 조명
            엠비언트 오클루젼
        * Global Illumination : 전역 조명
            간접광, 반사광 조차 계산 
				 
5. 매핑(Mpping)/텍스쳐링(Textureing) 
    : 정점 vertex로 이뤄진 오브젝트 표면에 텍스쳐를 씌워 질감과 반사된 풍경을 처리하는 과정.
       * 맵 == 텍스쳐 (동일한것이다.) 

----

## 랜더 파이프라인

#### 파이프라인 아키텍쳐

파이프라인 아키텍쳐 패턴을 따른다 단계(파이프)사이를 필터로 연결한다.

**구성**
* 파이프 : 각 단계명 
* 필터 : 각 파이프를 통해 넘어온 데이터를 처리하고 캡술화하는 서브 시스템

**특징** 
1. DataStream을 처리하는 패턴이다. 
2. 서브시스템이 입력 데이터를 받아 처리하고 결과를 다른 시스템에 보내는 작업이 반복되는 아키텍처 스타일 이다. 

**장점**
1. 데이터변환, 버퍼링, 동기화에 유리함
2. 재사용성, 확장성이 좋아 다양한 파이프라인 생성가능

한 단계의 Output은 다음 단계의 인풋이 된다.

-----------------

## 랜더 파이프라인
**일반적으로..**

![](./img/2023-03-13-21-26-10.png)

---

### 1 Input 구성

**Vertex(정점)**
* 꼭짓점이다. 단순히 위치를 표현한다 말고 그 이외의 데이터를 가지고 있다.
* 정점 구조체는
    * Position : (x, y, z)와 같은 위치 정보도 있고,
    * Color RGB, RGBA같은 컬러 정보
    * Normal : 정점-노멀값 $(n_{x}, n_{y}, n_{z})$
    * UVW : 텍스쳐 좌표
* mesh를 정의하는 기본 단위이다.

---

### 2 IA 정점 조립

>**-> input : Vertex**

**Vertex buffer**
* 정점을 모아놓는 자료구조다.

**Index buffer**
<div align=center>
    <img src="./img/2023-03-26-14-06-58.png" width=350px>
</div>
* 정점 중복을 막는 데이터
* 정점의 불필요한 중복을 제거하는데 사용되는 자료구조다.

**Primitives**
* Vertex buffer 자료 내 정점들을 이용하여 그릴 수 있는 도형
Point, Line, Line Strip, Triangle, Traingle Strip

> **Output -> Vertexs**
> 이제 IA 과정을 거치고 나온 데이터를 버텍스 쉐이더로 넘긴다. 

---

### 3-1.버텍스쉐이딩 (Codeable)

**카메라**

<div align=center>
    <img src="./img/2023-03-30-16-28-56.png" width=350px>
</div>

* Orthographic
* Perspective (원근투영)
  * 막대가 카메라 렌즈에 수직 방향으로 놓인 것 처럼 사진의 중앙에 놓이게 되면 막대의 끝부분만 사진에 원형으로 나타날 것이고, 다른 부분은 전부 보이지 않게 됩니다. 
  * 막대를 위 방향으로 움직이면 막대의 아랫면이 점점 보이기 시작하겠지만, 
  * 막대를 위쪽으로 비스듬히 올리면 다시 가려지게 됩니다. 
<div>
    <img src="./img/2023-04-11-10-29-16.png" width=200px> <img src="./img/2023-04-11-10-33-03.png" width=400px>
<div>


**투영(Projection)**
* 3차원 vertex 데이터를 가진 오브젝트 공간 버텍스 좌표를 
2차원 레스터화 될 [클립공간("Clipping"이 일어나는 공간)](https://carmencincotti.com/2022-05-02/homogeneous-coordinates-clip-space-ndc/)으로 변환한다.
* 클립공간은 절두체(상단이 잘린 뿔)
<div align=center>
    <img src="./img/2023-03-30-16-31-37.png" height=175px>
    <img src="./img/2023-04-11-10-38-31.png" height=175px>
</div>

**정점 쉐이딩(조작)**
* Position, Normal, Tangent 등등.. 조작할 수 있다.

**정점, Primitives 를 변환 시키고 리턴한다**
* vart라는 함수는 정점 데이터를 받아 v2f 구조체를 만든다.
v2f는 vertex쉐이더에서 fragment쉐이더로 넘겨줄 데이터를 담아주는 구조체입니다. 
* UV,정점, 컬러 등등등 을 담는다

-----------------

### 3-2.테셀레이션 (Codeable)
폴리곤을 추가 생성
특정 규칙에 따라 저 작은 삼각형으로 나누는 작업이다.

-----------------
### 3-3.GeometrySader (Codeable)

-----------------

### 4.레스터화
"정점 보간 vertext interpolation" 하며. grid-aligned 프레그먼트 집합을 생성한다.

* 클립 공간으로 변형된 데이터 Primitive를 
Fragment(픽셀 후보군)단위로 잘라, 계산하는 작업을 한다. 
아직 어떤게 잘릴지 모른다. 
* 그리고 Clipping(절단)이 일어나는 단계이기도 하다.
* 모니터에 표시되지 않는 부분을 제거하는 Culling 작업
  * culling : 가려졌다는 의미 카메라와 오브젝트에 의해서 가려지는 현상이 생긴다.
   1. 카메라의 절두체에 의한 컬링(Frustum culling) : 절두체 내부에 있다면 표시된다.
   2. 다른 오브젝트에 의한 컬링([Occlusion culling](https://docs.unity3d.com/Manual/OcclusionCulling.html)) : 물체가 앞에 서서 가려지는지 아닌지 
  * 
    |절두체 컬링만 활성화 했을때|오클루전 컬링 또한 같이 활성화|
    |---|---|
    |![](2023-04-11-10-45-13.png)|![](2023-04-11-10-45-18.png)|

Z-test, Stencil test가 일어난다.

Fragment는 다음 정보를 포함하고 있다
* Position
* Normal
* Tangent
* UV

-----------------

### 5. 프레그먼트 쉐이더(Codeable) // 프래그먼트 프로세싱
frag 라는 함수는 v2f 정보를 받아온다.

프래그먼트를 가지고 다음 동작을 수행한다
1. 텍스쳐링 (Mpping) : 폴리건 메쉬의 표면 2D에 이미지와 같은 텍스쳐를 입히는 과정을 한다.
2. 라이팅 : 빛에 의한 물체의 색상 변화, 음영, 깊이감을 표현


-----------------


### 6. Output Manage
알파 테스트
알파 블랜딩
컬러 블렌딩

포스트 프로세싱 다음 효과를 줘 디스플레이에 보낼 최종 출력 프레임을 생성할 수 있다.
* 컬러 그레이딩
* 블룸, 
* 뎁스 오브필드 등 

-----------------

### 7.프레임버퍼
그래픽 엔진에서 모니터에 표시할 이미지를 준비할 목적으로 업데이트 되는 "메모리"
* 프레임 버퍼는 x, y로 인덱싱이 가능하다
* 그말은 즉슨 해상도 크기만큼 픽셀에 대응하는 메모리를 가진다는 의미

프레임 버퍼에서  픽셀에 대응하는곳에 인덱싱하여 색상을 업데이트하는 것

*
    ```glsl
    uint32_t pixelAddress = x + y * WIDTH;
    framebuffer[ pixelAddress ] = newColor;
    ```


Drawcall은
Vertex Shader, 
Geometry Shader (옵션), 
Fragment Shader 순서에 따라서 연산을 수행하여 

Frame을 생성한다.

### 참고

1. https://www.youtube.com/watch?v=NEzJH-JrAdw&t=1s

2. https://www.khanacademy.org/computing/pixar/rendering/rendering1/a/start-here-rendering

3. https://youtu.be/9vlG7rRqzho

4. https://hyeonu1258.github.io/2018/06/26/OpenGL%20Shader/

5. http://alleysark.tistory.com/264?category=543622

7. https://mkblog.co.kr/gpu-graphics-pipeline/

8. [URP Unity](https://www.youtube.com/watch?v=QRlz4-pAtpY)

9. https://docs.unrealengine.com/4.27/ko/BuildingWorlds/LightingAndShadows/ScreenSpaceGlobalIllumination/