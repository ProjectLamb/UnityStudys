# 쉐이더 그래프
### 개요
**특징**
1. 노드베이스
2. 노코드

**실습 목차**

1). 에너지 실드
1. 접속의 검출
2. 엣지 
3. 매경 일그러짐

2). 회오리
1. UV
2. 노이즈

---

### 1). 에너지 실드

접촉면을 인식하는 쉐이더는 어떻게 만드는가?

일반적으로 랜더링에선 불투명을 그리고 투명을 그린다. 그 불투명을 그리는 결과를 Z버퍼에 기록한다.
앞에 있는가(그리기) 뒤에 있는가(안그리기) Z버퍼를 이용한다.

```
랜더링 파이프라인에 따르면
투명을 그리는 단계가 진행되었을때, NDC공간 (클립 공간)으로 변형된다.
```

<img src="./img/2023-03-23-17-46-47.png">


#### z 버퍼
```
카메라 변환, 투영 변환, 정점

---

https://blog.hexabrain.net/184

https://2-54.tistory.com/11

https://jebae.github.io/z-buffer

1. 월드 변환
일반적으로 모든 정점은 각자 자기만의 지역 좌표계 상에서 정의된다.
이 지역 좌표게(모델 좌표계)를 월드에 변환 하는 과정을 말한다.

1. 카메라 변환
이제 물체들이 월드에 배치되었으면
카메라 공간으로 정점들을 변환 하는 과정이다.

1. 투영 변환
Geometry(기하 도형)을 2D 뷰포트 공간으로 옯기는것을 말한다. (버텍스 쉐이더? 3차원 좌표계를 2차원 좌표계로 바꿔주는 변환 필요) 

일반적으로 원근 투영기법을 사용하는데. 
* 카메라와 거리에 따라 투영되는 비율이 달라지며
* Z축 값(깊이 버퍼)가 멀리있는것은 작게, 가까이 있는것은 크게라는 데이터를 저장

---

1. Depth 버퍼링
    한 물체의 픽셀이 다른 물체보다 앞에 있는지 판정하기위해 사용하는 "기법"
    Z 버퍼 값을 사용한다.

2. Z 버퍼
    Z값 앞뒤를 덮는것
    물체가 가지는 Z값을 비교하여 앞에 있는지 결정하는데 사용하는 값이다.
    
    3D 차원 메모리를 렌더링 할떄 보이는 점에서 
    다각형과 같은 물체까지 거리 Z값을 안전하게 보관해두는 기억 장치

3. 버퍼링 과정
    그냥 버퍼
        (x, y)의 2차원 좌표를 기준으로 스크린 픽셀 요소들로 정룔되어 있다.
        만약 다른물체가 같은 픽셀에 그려져야할때 
        그 물체들을 싸그리 비교해 가장 거리가 짧은 값이 Z버퍼에 보관된다.

4. OpenGL
    GLFW는 위에 설명 버퍼들을 자동 생성한다
    Depth는 Fragment를 저장한다.
    Fragment를 OpenGL에 출력할떄, Z-버퍼를 비교한다.
    현재 Fragmanet가 다른 프레그먼트 뒤에 있다면 폐기하고 앞에 덮어 씌운다
    이 과정을 Depth 테스팅이라고 부른다. 이 과정을 OpenGL에 의해 자동적으로 수행된다.

DOF (Depth of Field), 모션 블러를 구현하기위해 사용함
```

<img src="./img/2023-03-24-13-02-34.png">

뎁스 텍스쳐
* URPA에 General 옵션에 Depth 텍스쳐 On을 하면 된다,
* 이 Z 버퍼에 기록한것을 접근하려면 뎁스 텍스쳐를 사용한다.

[Color](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Color-Node.html?q=Color)
* Defines a constant Vector 4 value in the shader using a Color field.
* Default vs HDR
  * 이미션 추가

[씬 뎁스](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Scene-Depth-Node.html)
* Provides access to the current Camera's depth buffer using input UV, which is expected to be normalized screen coordinates.

[스크린 포지션](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Screen-Position-Node.html)
* Provides access to the mesh vertex or fragment's Screen Position. 

[스플릿](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Split-Node.html)
* Splits the input vector In into four Vector 1 outputs R, G, B and A. 


<img src="./img/2023-03-24-13-06-10.png">

---

```
https://buddha-teacher.tistory.com/21

UV
사실 UV에는 특별한 뜻은 없다..
텍스쳐 상의 좌표를 표현하는 제 2의 좌표계라고 생각하는게 편하다.

UV를 래핑(펴는 작업)에 따라서 
텍스쳐의 크기나 베이킹 결과가 상이하게 달라지므로 중요한 요소다

좌표를 표연하는 알파벳은 두가지로 나뉜다.

절대좌표 :  XYZ
사용자좌표 : UVW
```

[Normal Vector](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Normal-Vector-Node.html)
* Provides access to the mesh vertex or fragment's Normal Vector.

<img src="./img/2023-03-24-15-12-11.png">

[View Direction](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/View-Direction-Node.html?q=Direction)
* Provides access to the mesh vertex or fragment's View Direction vector. 

[Normalize]()

[Add](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Add-Node.html)
* Returns the sum of the two input values A and B.
* A + B

[멀티플라이](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Add-Node.html)
* Returns the result of input A multiplied by input B. 
  * 벡터 * 벡터
  * 벡터 * 행렬
  * 행렬 * 행렬
* A * B


[서브트랙트](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Subtract-Node.html)
* Returns the result of input A minus input B.
* A - B 리턴

[Dot Product (스칼라곱 | 내적)](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Dot-Product-Node.html)
* A 벡터와 B 벡터의 내적을 리턴

[림라이트 (역광)](https://nichi72.tistory.com/4)
* <img src="./img/2023-03-24-12-09-23.png">
* https://www.youtube.com/watch?v=jcMRaFF9RRI

---
[Time](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/View-Direction-Node.html?q=Direction)
* Provides access to various Time parameters in the shader.
* 어쩄든 런타임동안 바뀌는 값을 전달하는것 같다..
* 
    ```
    Time Value
    Sine TIme
    Cosine Time
    Delta Time (Current Time)
    Smooth Delta
    ```
[Tiling And Offset](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Tiling-And-Offset-Node.html?q=Tiling%20and)
* Tiles and offsets the value of input UV by the inputs Tiling and Offset respectively.
* UV 값을 Tiling, Offset이라는 변수를 통해 UV 값을 변경해준다.
* 주로 맵의 오차를 줄이거나, 세밀한 조절, 또는 텍스쳐 자체를 애니메이션 시간에 따라 스크롤링해주는데 사용


[Remap](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Remap-Node.html?q=Remap)
* 들어오는 "In Min Max"(x, y) 벡터와 출력될 "Out Min Max" (x, y) 벡터를 이용해
* 선형보간을 거쳐서 In 값을 Out 값으로 변환
*  
    ```GLSL
    Out = OutMinMax.x + (In - InMinMax.x);
    Out *= (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
    ```


[블렌드](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Blend-Node.html?q=Blend)
* 포토샵같은 블랜드 모드 제공
*
    ```
    Burn, Darken, Difference, Dodge, Divide, 
    Exclusion, HardLight, HardMix, Lighten, LinearBurn, 
    LinearDodge, LinearLight, LinearLightAddSub, 
    Multiply, Negation, Overlay, PinLight, Screen, SoftLight, 
    Subtract, VividLight, Overwrite	Blend mode to apply
    ```

---

#### 일그러짐 효과

1. URP 오브젝트 스크립트에셋 설정
   1. [OpaqueTexture - On](../URP/5_URP_에셋.md)
   2. 카메라가 보는 모든것을 텍스쳐 가져올 수 있는
   ```_CameraOpaqueTexture``` 를 사용하기 위해
2. ShaderGraph 스크립트 변수
   * <img src="./img/2023-03-26-14-39-57.png">
   * Texture2D를 \+ 버튼을 통해서 인스펙터에서 볼 수 있는 값을 추가
3. Referece값을 _CameraOpaqueTexture 으로 바꾸기
   * <img src="./img/2023-03-26-16-37-06.png">
   * **그리고 중요한것이 Expose 값은 비활성화 해야한다.**


Lit 쉐이더 그래프 만들기

#### 쉐이더 겹치기
2Pass는 못하므로 별개의 쉐이더를 
Meterial 붙인다.
<img src="./img/2023-03-24-21-49-53.png">

[Twirl]()
* 렌즈효과 처럼 소용돌이 외곡을 줌

[Gradient Noise]()


---

#### 2). 회오리
<img src="./img/2023-03-28-10-23-28.png">

UV 스크롤
노이즈 텍스쳐 컷오프
* 노이즈는 UV를 흔들때 사용하기도한다.
* 디졸브를 만드는데 사용하기도 한다.

특히 보로노이 노이즈
* 물을 표현하는데 사용하기도 한다.

모션 합성
* 정점 애니메이션

[Fresnel 방정식](https://docs.unrealengine.com/4.26/ko/RenderingAndGraphics/Materials/HowTo/Fresnel/)

<div align=center>
    <img src="./img/2023-04-04-09-54-39.png" width=300px>
</div>

* 구체 중앙의 0 인 부분은 프레넬 이펙트가 없는 것이 보입니다. 왜냐면 카메라가 바로 표면 노멀쪽을 향하고 있기 때문입니다. 표면 노멀과 카메라가 수직이 되어갈 수록, 즉 1 에 가까울 수록 프레넬 이펙트가 더욱 잘 보이게 되는데, 바로 그러한 작동방식 유형이 필요한 것입니다.

Fresnel_Exp

<img src="./img/2023-04-04-09-58-49.png">

* Fresnel_Exp 의 값이 커질수록 프레넬 이펙트가 가장자리에, 작을 수록 중앙에 가까워진다는 점 기억하세요. Fresnel_Exp 값이 프레넬에 영향을 끼치는 예제는 아래와 같습니다. 수치가 커질수록 프레넬 이펙트가 메시 가장자리에 가까워지는 것을 볼 수 있습니다.

노멀맵 응용
<img src="./img/2023-04-04-10-00-49.png">

---

아직도 잘 이해가 안되는것
포지션
UV
Split
노멀, 뷰디렉션
Dot Product의 원리


버텍스 컬러



http://chulin28ho.egloos.com/
https://gimchicchige-mukgoshipda-1223.tistory.com/23