## Unity FMOD 

---

### 1. FMOD 콘텐츠 엑세스하기

#### 1). 단일 플랫폼 빌드
.bank 파일 세트가 포함된 디렉토리를 지정한다. 
<img src="./image/Doc/2023-04-21-15-58-43.png">

장점 : 
* 버젼 컨트롤하기 좋다 
* 모바일게임에 좋다.

#### 2). 다중 플랫폼 빌드
<img src="./image/Doc/2023-04-21-15-58-37.png">

---

### 2. Unity 프로젝트에 파일 저장하기

#### 1). 유니티 설정

<div align=center>
    <img src="2023-04-21-16-14-43.png" height="200px">
    <img src="2023-04-21-16-15-41.png" height="200px">
</div>

> Unity가 프로젝트로 가져오려고 시도하므로 FMOD Studio 프로젝트를 Assets 디렉토리에 넣지 마십시오.

#### 2). FMOD 설정
**① 경로설정**
![](2023-04-21-16-16-19.png)
**② 빌드 설정**
![](2023-04-21-16-19-07.png)

---

### 3.  스피커 모드 설정

![](2023-04-21-16-21-47.png)

---

### 4. 콘텐츠 추가

#### 1). 리스너 추가
컴포넌트 : `FMOD Studio Listener` 
* 3D 이벤트를 올바르게 작동 가능하게함

#### 2). 이벤트 브라우저에서 콘텐츠 끌기

#### 3). 트리거 조건
**① 종류**
![](2023-04-21-17-32-09.png)

**② FMOD 구성요소**
* FMOD Studio Event Emitter - 이벤트 또는 스냅샷을 재생하고 중지합니다.
* FMOD Studio Parameter Trigger - FMOD Studio Event Emitter의 매개변수 값을 변경한다.
* FMOD Studio Global Parameter Trigger - 전역 매개변수 값을 설정합니다.
* FMOD Studio Bank Loader - .bank 파일을 로드 및 언로드합니다.

#### 4). 리버브 존 생성
플레이어 로케이션에 따라서 이펙트의 활성화 상태를 만든다.
스냅샷을 사용해서 만들던지, 이벤트 Emmiter컴포넌트를 용하던지.

* `FMOD Studio Event Emitter` 에서 Play Event를 Trigger Enter로, Stop Event를 Trigger Exit로, Collision Tag를 Player로 설정합니다.
* 충돌체 구성 요소(예: `Box Collider`)를 Game Object에 추가하고 Is Trigger를 활성화하고 원하는 크기와 위치를 설정합니다.

#### 5). 타임라인을 통해서 스냅샷 만들기
[`FMOD Event Playable`](https://fmod.com/docs/2.01/unity/timeline.html)

---

## Unity Integrate
```cs
UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeEngineAudio : MonoBehaviour
    {
        public float minRPM = 0;
        public float maxRPM = 5000;
        ArcadeKart arcadeKart;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        void Update()
        {
            float kartSpeed     = arcadeKart != null ? arcadeKart.LocalSpeed() : 0;
            // set RPM value for the FMOD event
            float effectiveRPM = Mathf.Lerp(minRPM, maxRPM, kartSpeed);
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("RPM", effectiveRPM);
        }
    }
}
```