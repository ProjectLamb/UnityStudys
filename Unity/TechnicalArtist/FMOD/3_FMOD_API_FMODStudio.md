---

## FMOD API
---

### 0. 사전 지식, Core API
1. Playback 
   * 다음 상태가 있다.
        ```
        PLAYING
        SUSTAINING : The timeline cursor is paused on a sustain point.
        STOPPED
        STARTING : Preparing to start.
        STOPPING : Preparing to stop.
        ```
    * FMOD와 관련하여 재생은 일반적으로 시스템에 로드된 오디오 파일 또는 오디오 스트림을 재생하는 프로세스를 나타냅니다. 
2. FMOD_3D_ATTRIBUTES
   * 위치와, 벨로시티, 앞, 위의 값을 내보낸다.
        ```
        VECTOR position;
        VECTOR velocity;
        VECTOR forward;
        VECTOR up;
        ```

---

### 1. API : `FMOD.Studio` 
#### 1). `FMOD.Studio.EventInstance`


> FMOD Studio Event의 인스턴스다.

**① Playback Control**

* 
    ```cs
    mEventInstance.start(); //playback을 시작한다. 즉 재생한다는듯

    mEventInstance.stop(); //playback을 멈춘다

    mEventInstance.getPlaybackState(); //Playback 상태를 리턴한다/

    mEventInstance.release(); //해제할 이벤트 인스턴스를 표시한다.
        * 즉, 메모리를 삭제하는다는의미 
        * 중지상태일때 삭제됨
        * 최적화랑 관련됨

    ```

**② Playback Properties**

* 
    ```cs
    mEventInstance.setPitch(float pitch);
    float mEventInstance.getPitch();

    mEventInstance.setProperty(EVENT_PROPERTY index, float value);
    float mEventInstance.getProperty();

    mEventInstance.setVolume(float volume);
    float mEventInstance.getVolume();
    ```

**③ 3D Attributes:**

* 
    ```cs
    mEventInstance.set3DAttributes(FMOD_3D_ATTRIBUTES attributes);
    FMOD_3D_ATTRIBUTES mEventInstance.get3DAttributes();
    ```

**④ 패러미터 설정**

*
    ```cs
    mEventInstance.setParameterByName(string name, float value, bool ignoreseekspeed); //string으로 패러미터 값 변경
        * 여기서 ignoreseekspeed는 
        * parameter's seek를 무시하고 
        * 즉각적으로 변화 할것인지 설정하는것이다.

    float mEventInstance.getParameterByName("_PrameterName_", out _memberParams); //패러미터 값 반환

    mEventInstance.setParametersByIDs(
        PARAMETER_ID[] ids,
        float[] values,
        int count,
        bool ignoreseekspeed = false
    ); //Sets multiple parameter values by unique identifier.
        Range: [1, 32]
        * count : Number of items in the given arrays.
    ```

**⑤ Core**

*
    ```cs
    mEventInstance.getChannelGroup(out FMOD.ChannelGroup group); //마스터 트랙에 해당하는 코어 채널 그룹입니다. ( 채널 그룹 )

    mEventInstance.setReverbLevel(); //Sets the core reverb send level.

    mEventInstance.getReverbLevel(); //Retrieves the core reverb send level.
    ```

---

#### 2). `FMOD.Studio.Bus`

> Represents a global mixer bus.

https://www.fmod.com/docs/2.02/api/studio-api-bus.html

---

#### 3). `FMOD.Studio.VCA`

> Represents a global mixer VCA.

https://www.fmod.com/docs/2.02/api/studio-api-vca.html

---

https://fmod.com/docs/2.00/api/studio-api-eventinstance.html