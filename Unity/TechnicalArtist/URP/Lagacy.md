
# 유니버셜 RP

MainThread : RCMD
RenderThread : GCMD
WorkerThread : IGCMD
GfxDeviceClient 

### Legacy
<img src="2023-03-15-10-12-29.png" width=400px>

### 유니티에서 우리가 다룰수 있는 부분
1. Graphics API
2. RenderContext
   1. 컬링
   2. 커맨드 버퍼 단위
   3. RCMD   

### SRP

### 랜더 스레드 패턴 (Dual)
랜더링에서는 일반적으로 유니티는 듀얼 스레드란다.
<img src="2023-03-15-09-51-32.png" width=400px>

SRP 구조 후킹 이제 직접 변경 가능

```
후킹
  Camera.RenderWithShader
  Camera.AddCommandBuffer
  Camera.Render
  OnPreCull
  OnPreRender
  OnPostRender
  OnRenderlmage
커맨드 버퍼
  Camera.AddCommandBuffer
  Light.AddCommandBuffer
```

<img src="2023-03-15-09-52-47.png" width=400px>

### 랜더 스레드 패턴 (jobtified 패턴)
<img src="2023-03-15-09-55-34.png" width=400px>

### 랜더 스레드 패턴 (Graphicjob 패턴)
<img src="2023-03-15-09-56-04.png" width=400px>

DX12, 불칸, 메탈 같은것

---

### URP 는 DOD(Data Oriented Design)
모듈화가 불가능한것들 스크립터블 오브젝트

![](2023-03-15-09-58-41.png)
1. URP 나 HDRP 둘중 하나 갈아끼우고
2. Render는 포워드나 2D를 갈아 끼우고
3. PASS는 뎁스프리 오파큐 갈아끼우고
   Pass 하나하나는 갈아끼우고 독립적이다.

---

### 랜더 파이프라인 에셋
1. 인스펙터
2. PassFeatureValue 
   1. (Render Features)
   2. 랜더 컨텍스 명령어 한줄을 설정 그걸 데이터화 시킨것

UR는 그냥 상속받아서 구성하느것

URP 파이프라인은
  어떻게 호출할까가 중요하다
  그냥 로직일뿐

쉐이더 
컨스턴트 버퍼

---

### 쉐이더
![](2023-03-15-10-16-02.png)
![](2023-03-15-10-15-14.png)

https://www.youtube.com/watch?v=QRlz4-pAtpY