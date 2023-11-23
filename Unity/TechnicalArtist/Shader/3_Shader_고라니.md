## 1. 꼭 알아야 하는것
<img src="./img/2023-03-30-16-57-08.png">

### 1. 스크립트로 쉐이터 패러미터 접근

```cs
public Renderer RD; //자기 자신 랜더링만
public Material MT; //이거 public 으로 해야된다.
private void Start() { }

[ContextMenu("Renderer Set Metal")]
public void RD_SetMetal(){

    RD.material.SetInt("_Metallic_Property", 1);
}
[ContextMenu("Renderer Set Norm")]
public void RD_SetNorm(){
    RD.material.SetInt("_Metallic_Property", 0);
}
[ContextMenu("Material Set Metal")]
public void MT_SetMetal(){
    MT.SetFloat("_Metallic_Property", 1.0f);
}
[ContextMenu("Material Set Norm")]
public void MT_SetNorm(){
    MT.SetFloat("_Metallic_Property", 0f);
}
```

### 2. In Out

```
In, Out의 표기
    Vector 1 : (1)
    Vector 2 : (2)
    Vector 3 : (3)
    Vector 4: (4)
    Dynamic Vector : 벡터가 어떤놈이 들어와도 받아 들이는것
    Matrix 2 : (2x2)
    Matrix 3 : (3x3)
    Matrix 4 : (4x4)
    Dynamic Matrix : 행열이 어떤놈이 들어와도 받아 들이는것
    Dynamic : 
    Boolean : (B) 
    Texture 20 : (T2) 
    Texture 2D Array : (T2A)
    Texture 3D : (T3) 
    Cubemap : (C) 
    Gradient : (G) 
    SamplerState : (SS) 

용어
    알베도 : 색

특징
    벡터 = 색 
    * 값을 시각적으로 보여준다
```


### 3. 버텍스 & 프래그먼트 쉐이터
```
쉐이더는 두가지로 조작 가능하도록 한다
    1. 버텍스
    2. 프래그먼트

UV는
    0,0 : 검정
    1,0 : 빨강 // UV에서 x축에 해당하는것이 바로 탄젠트가 된다
    0,1 : 초록
    1,1 : 노랑
    0,0,1 : 파랑 // 법선(Normal)은 평면의 법선 벡터다
```

오클루젼
알파
알파 클립 

<img src="./img/2023-04-03-16-36-21.png">
<img src="./img/2023-04-03-16-42-06.png">

|옵션|Front|Back|Both|
|---|---|---|---|
|<img src="./img/2023-04-03-16-42-57.png">|<img src="./img/2023-04-03-16-43-56.png">|<img src="./img/2023-04-03-16-44-08.png">|<img src="./img/2023-04-03-16-44-19.png">|


### 4. PBR 마스터


그룹화
Sticky Note : 포스트잇

### 5. SubGraph

----

## 2. Artistic

### 1. Adjustment 조절
```
1. Chennel Mixer
2. Contrast : 대비
3. Hue
4. Invert Colors  : 색 반전
5. Replace Color : 색 교체
6. 화이트 밸런스 : 따뜻한, 차가운
```
### 2. 블랜드, 필터, 마스크
```
1. 블랜드 : 포토샵 레이어
2. 필터 : Dither 모드 등등 8비트
3. 채널 마스크 : 
    1 -> 0
    -1 -> 0
4. 컬러 마스크 : 특정 색만 추출하게끔
```

### 3. Normal
```
1. 노멀 블랜드
2. Normal from height
    * 노멀을 높이 값 (0 ~ 1) 을 통해서 적용
4. Normal from Texture
5. Normal Strength
```

### 4. Utility

```
1. Split : 벡터를 각각 개별값으로 나눈다.
    * RGB (R : x, G : y, B : z)
    * HSV

2. Color : 색공간에 따라 색처리
3. Flip : 
    * -1 -> 1
    * 1 -> -1
4. Swizzle : 섞기
5. branch : 
```


<img src="./img/2023-04-04-10-33-19.png">

### 5. Input
```
Bool 
Color
    * 일반 모드
    * 눈부심 HDR 

Constant 
    * Pi값
    * 타우 Tau 
    * Phi 1 + 5^(1/2) / 2
    * 자연상수 E
    * sqrt 2 : 루트 2

Slider

Time : 애니메이션 만들떄 꼭 필요하다.
    * Sin, Cos
    * Delta Time : 프레임간 시간 차이. 
    * Smooth Delta : 가끔 프레임이 뛸데 보간한다.

Vector 1,2,3,4
```

### 6. Geometry
```
1. bitangent vector
    * Object 

2. 노멀 벡터(??? 다시 자세히좀 보자) : 각 점에서 바깥 기준으로 수직인 벡터 
    * 오브젝트 좌표계 : 각 오브젝트의 Local로 본 좌표계
    * 월드 
        방향을 좌표계를 그대로 대입해 색을 표현해버린다
        월드의 0,0,0에서 Global로 본 좌표계 (각 오브젝트의 Global좌표계가 아님, URP에서는 Absolute World와 완전히 같다)
    * 뷰 카메라 
        카메라의 Local에서 x, y는 그대로이나 Z가 반대인 좌표계 
        눈을 향한다.
    * 탄젠트 좌표계
        각 정점마다 
            u : tangent vector(노말과 수직인 벡터 중 UV의 U와 일치하는 벡터)
            v : bitangent (노말과 수직인 벡터중 UV 에서 V와 일차하는 벡터)
            z : normal (각 점들의 바깥으로 수직인 벡터를 말한다)

1. Position (??? 다시 자세히좀 보자)
    * 물건의 정점위치를 바꾼다.

2. Screen Position : 씬뷰에서 봤을떄 ,화면 UV
    * Default
    * Raw
        * Alpha : 카메라로 부터의 정점 거리
            가까운 물건은 검은색
            멀리 있는 물건은 하양색
    * 타일
    여담) Scene Color 화면 캡쳐 굴절 쉐이더

4. UV : 텍스쳐의 포지션
    UV 컨트롤 R, G 채널을 각각 엇갈려 참조할 수도 있다.
    UV 1, 2 : 라이트맵에 사용

5. 타일링 & 오프셋
    * 또는 타일링
    * 리핏 텍스쳐는 오프셋 이동
    * 로테이트도 가능하다

6. Vertex Color 
    * 버택스 페인트 인식

7. View Direction (방향 벡터)
    * 카메라의 방향을 나타냄
    * 프레넬과 관련이 있다.
```

### 7. 그라디언트 빛 
```
8. 그라디언트
    * 블랜드 : 부드러움
    * 계단식 : 셀셰이딩

9. 환경광 참조

```

<img src="./img/2023-04-04-10-47-30.png">
<img src="./img/2023-04-04-10-53-07.png">
<img src="./img/2023-04-04-10-54-53.png">
<img src="./img/2023-04-04-13-08-23.png">

### 8. 행렬

```
행렬 인풋
    1. Position Shader 에 관련

    Model : 오브젝트에서 월들로 변환하는 행렬, Model to World 
    Inverse Model : Model의 역행렬 

    View : 월드에서 뷰로 변환하는 행렬, World to View 
    inverse View : View의 역행렬

    Projection : 뷰에서 투영으로 변환하는 행렬, View to Projection 
    Inverse Projection : Projection의 역행렬 

    View Projection : 월드에서 투영으로 변환하는 행렬: World to Projection 
    Inverse View Projection : View Projection의 역행렬
```

### 9. 물리기반 랜더링

```
Dielectric Speculer
    비금속 극성물질 
    굴절률과 관련됨
    물같은 굴절률

Metal Reflectance 
    금속 빛 반사율
    메테리얼 옵션 선택도 가능 
        철 금 알루미늄 코발트.. 등등
```

### 10. Scene
```
Camera : 실제 카메라의 세팅 상태를 가져온다
    그 카메라의 값을 참고하기 위해 사용한다.

Fog

Object : 실제 그 오브젝트의 transform 데이터를 가져온다
    transform position, sacle 값을 참조하고 싶을떄 사용한다

Scene Color : 화면 캡쳐
    * 항상 투명 옵션을 켜놓자
    * 단 카메라 OpacueTextuer를 사용하자 그럼으로 사용할 일 없을듯.

Scene Depth (???) : Opaque를 그리고 난 뒤의 Z buffer 값
    * 가까운것은 검은색
    * 먼것은 흰색
    깊이값을 표현하는것

    1. 그래서 Scene Depth를 통해서 오브젝트의 거리와
    2. Screen position(Raw)을 통해 알파값을 가져와
    스크린이 그 좌표에 있는 값을 가져온다 반투명의 닿은 좌표까지의 거리를 가져온다.
    
    그래서 1과 2의 값을 차이로 한다면 
    물 지형 가장자리 부분이 밝게, 에너지 볼을 만들 수 있다.

Screen 
```
<img src="./img/2023-04-04-16-27-31.png">

### 11. 텍스쳐

```
큐브맵 : 주사위 만들기
    한쪽면만 반사하게 창문 구현 가능

샘플러 스테이트 : Sampler input으로 들어가는것
    필터 
        리니어 멀리갈수록 뭉개짐
        트릴리어 경계가 부드럽개
    포인터 
        클램프 : 
        랩 : 길어지게
        미러 
```

<img src="./img/2023-04-04-16-35-55.png">

레벨 오브 디테일

### 12. 마스터 모드?

포워드 랜더러
스프라이트 림 마스터

### 비주얼 이펙트 그래프

### 13. 수학
```
1. 모듈러
2. 포스터라이즈
3. add : 밝아짐
4. 곱하기 : 어두워짐
   1. 하나라도 0이면 0이니
5. 

6. Derivate
7. Matrix
8. OnMinus : 값을 음수로 바로
```

### 14. Vector
```
Distance : 가까워지면 사라지는 셰이더
Dot Product : 프레넬
Projection : 투영

Reflection 반사 : In 과 노말이 들어올떄 아웃이 벡터로
Rejection 거부

Rotate About Axis : 
    버테스 포지션에 넣으면 회전이 된다.

Sphire Mask
   Step 이랑 같이 사용
    Step은 1, 0사이 float 값을 잘라서 정수값 가져온다. 

도형을 만들 수 있음
둥글게 할수도 있음

빛이 들어오는 방향을 인식해 

```


### 15. 유틸리티
```
Branch
if else 를 나누는 노드다.
```

### 16. UV
```
flipbook
    1. 텍스쳐를 가로세로 나눠준다.
    뚝뚝 끊기게 해서 보이고 싶다면?

    invert x, y를 통해 시작점과 끝점을 오차 조절할 수 있다.

Polor Cordinate
    물결 모양
    또느 스킬 쿨타임 돌아가는거

Radial Cerial

Rotate : 회전
    피봇도 잡을 수 있다.

타일링 앤 오프셋

트라이 플래너
    가로 세로를 되게 부드럽게 펼쳐준다.
    끊기는게 없도록

트리플라이너

Teirl : 꼬인 정도 
```

