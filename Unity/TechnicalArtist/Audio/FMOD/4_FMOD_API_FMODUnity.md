---

## FMOD API
---

### 0. 사전 지식, Core API
1. EmitterRef
   * StudioEventEmitter, ParameterInfo에 사용
        ```cs
        class EmitterRef {
            // The StudioEventEmitter that is being used.
            public StudioEventEmitter Target;
            // List of parameter info for the targeted StudioEventEmitter.
            public ParamRef[] Params;
        }
        ```
    * ParamRef
        ```cs
        class ParamRef {
            //패러미터 이름
            public string Name;
            //패러미터 값
            public float Value;
            //패러미터 식별자
            public FMOD.Studio.PARAMETER_ID ID;
        }
        ```

### 1. API : `FMODUnity` 

#### 1). `FMODUnity.RuntimeManager`

*
    ```cs
    EventInstance RuntimeManager.CreateInstance(EventRef || string); // 이벤트 인스턴스를 만든다. 
        * EventInstance 반환 
        * 단, 3D 포지셔닝을 해줘야 하므로
          AttachInstanceToGameObject() 는 필수적 또는
          set3DAttribute() 설정

    RuntimeManager.PlayOneShot(EventRef || string, Vector3);
        * 주어진 위치에서 이벤트를 발사하고 Forget한다.
        * 패러미터값 설정은 할 수 없음

    RuntimeManager.PlayOneShotAttached(EventRef || string, GameObject);
        * 게임오브젝트에 붙여서 위치를 프레임마다 계속 따라간다.
        * 다만 완료까지만 재생하고 끝.

    RuntimeManager.AttachInstanceToGameObject(EventInstance, Transform, Rigidbody); 
        * 3차원 위치를 추적한다.
        * GameObject나 Rigidbody velocity를 프레임마다 맞춘다.

    RuntimeManager.DetachInstanceFromGameObject(EventInstance); 
        * 매개변수로 들어간 인스턴스를 더이상 추적하지 않는다.

    FMOD.Studio.Bus RuntimeManager.GetBus(string);
        * The path must start with "bus:/".
        * 버스 가져오기

    FMOD.Studio.VCA RuntimeManager.GetVCA(string);
        * The path must start with "vca:/".
        * VAC 가져오기

    RuntimeManager.GetEventDescription(EventRef);

    RuntimeManager.PauseAllEvents(); //모두 정지
    ```

#### 2). `FMODUnity.RuntimeUtils`

* 
    ```cs
    // Create an FMOD.Attributes_3D structure 
    // containing the position and velocity of an event 
    // from a Unity object.
    FMOD.ATTRIBUTES_3D RuntimeUtils.To3DAttributes(Vector3);
    FMOD.ATTRIBUTES_3D RuntimeUtils.To3DAttributes(Transform);
    FMOD.ATTRIBUTES_3D RuntimeUtils.To3DAttributes(Transform, Rigidbody);
    FMOD.ATTRIBUTES_3D RuntimeUtils.To3DAttributes(GameObject, Rigidbody);
    ```

---


### 참고
https://fmod.com/docs/2.02/unity/examples-basic.html