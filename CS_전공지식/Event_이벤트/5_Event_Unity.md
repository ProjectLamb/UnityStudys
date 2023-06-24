---
ebook:
  theme: one-dark.css
  title: 이벤트지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #D8D241; border-left: 5px solid #D8D241; border-right: 5px solid #D8D241; background-color: #D8D241; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #C4B000 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## 💡 5 UnityEvent 

#### 유니티에서 이벤트를 사용해보자.

> 1. **다른 코드에 있는 함수를 가져오고 싶다.** 
>     * `GameObject.Find(string ).Sendmessage(string );` 이거 대신 사용하고 싶다. 근데 문자열 하나 틀리면 디버깅해서 찾기도 어려울것이다..
>     * 그냥 GameObject캐싱 하고 `TryGetComponenet()`쓰고 사용하죠 뭐.. 
>       근데 이거 계속 쓰다보니 무수한 `GetCom..` 가독성이 안좋다 생각이 들때.
>     * 아니 하나 바꿨다고 다~~ 바꿔야 하는거야?? **커플링**이 심각할때
> 2. **함수 실행에도 순서, 우열이 있다는것을 보장받고 싶을때.**
>     * 즉 순차적으로 실행되는것이 보장받고 싶을떄.
> 3. **뭐뭐 했을때~~~ 이거저거 실행하고 싶다!**

#### 다음과 같은 생각이 스쳐 지나간다면 이벤트를 사용하는것을 추천한다!

---

### 📄 1. 사전 지식

#### 1). Observer Pattern

<div align=center>
    <img src="https://imgur.com/rosmtme.png" width=80%>
</div>

**① Subject(Publisher)** 🔔 : 
* 자신의 상태에 변경에 대해서 다른 객체들에게 알림을 보내는 역할을 한다.
* Observer(Subscriber) 리스트를 가지고 있다.
  * 이벤트가 발생할 때 이 Observer(Subscriber) 리스트를 샅샅히 뒤져 알림을 보낸다.
* Observer(Subscriber) 가 구독 또는 구독 취소를 할 수 있는 매커니즘을 가진 구독자 객체

**② Observer(Subscriber)** 👂 🏃 :
* Subscriber(Publisher)가 만드는 알림을 받는 객체
* 알림을 받고 행동함

**③ 클라이언트** : 🏟️
* 클라이언트는 Subject 와 Observer 객체를 별도로 생성하고 Observer를 Subject에 등록한다.

---

#### 2). UnityEvent와 Observer Pattern의 관계

1. *Subject(Publisher) 🔔* 는 **UnityEvent**
2. *Observer(Subscriber) 👂 🏃* 는 **함수 or.. 델리게이트**
3. 클라이언트 = **아래 코드가 있는 .cs**
  *
    ```cs
    UnityEvent someEvents;
    
    someEvents += 함수 or.. 델리게이트; //등록하고
    someEvents -= 함수 or.. 델리게이트; //해제하는
    someEvents.Invoke();
    ```

---

### 📄 2. UnityEvent Scripting (매개변수 없음)

#### 1). 이벤트 만들기

```cs
using UnityEngine.Events; // 이거 맨 꼭데기에 선언해줘야 한다
          : //생략
  public UnityEvent inspectorEvents;
         UnityEvent scriptEvents;

```

위에 `inspectorEvents` 와 `scriptEvents`를 나눈것은
이벤트가 연결되는 방식이 2가지 있는데 그에따라서 나눈것이다.

---

#### 2-1). 이벤트와 동작 연결하기 : 인스펙터로 연결
*주의할점은 Public 함수만 연결 가능하다.*

1. 인스펙터에 UnityEvent라는 타입을 노출 시킨다
   *카메라를 SetActive(false) 해보자..*
    ```cs
    using UnityEngine;
    using UnityEngine.Events;

    public class TEST_UnityEvent : MonoBehaviour
    {
        public UnityEvent inspectorEvents;

        [ContextMenu("Invoke inspectorEvent")]
        void InvokeInspectorEvent(){
            inspectorEvents.Invoke();
        }
    }
    ```
2. 인스펙터에서 드래그 앤 드롭 해준다.
    <div align=center>
      <img src="https://media.giphy.com/media/E9I9MRElqDuh7ME92u/giphy.gif" width=80%>
    </div>

---

#### 2-2). 이벤트와 동작 연결하기 : 런타임에서 동적으로 연결하는 방식
scriptEvents 라는 UnityEvent를 스크립트를 통해서 등록하고 싶다면
동작을 연결하고싶은 .cs 코드에서 scriptEvents을 접근해야한다.

1. 전역적으로 접근하게끔 Static으로 해주자..
    ```cs
    using UnityEngine;
    using UnityEngine.Events;
    public class TEST_UnityEvent : MonoBehaviour
    {
        static internal UnityEvent scriptEvents = new UnityEvent();

        [ContextMenu("Invoke scriptEvent")]
        void InvokeScriptEvent(){
            scriptEvents.Invoke();
        }
    }
    ```

2. #### `someEvent.AddListener(_함수명_)`
   UnityEvent의 .AddListener()라는 메소드를 통해서 동작을 연결한다.

<div align=center>
    <img src="https://imgur.com/SgXrYWN.png" width=45%>
    <img src="https://imgur.com/WMsQbOQ.png" width=45%><br>
    <img src="https://imgur.com/Xi6Y9At.png" width=45%>
    <img src="https://imgur.com/E6S4cNl.png" width=45%>
</div>

1. #### `someEvent.RemoveListener(_함수명_)`
   더 이상 이벤트에 따른 동작을 실행하고 싶지 않을떄,
   이벤트와 동작의 연결을 끊어주고 싶을때 사용한다.

2. #### `someEvent.RemoveAllListeners()`
   일일이 제거하는것도 일이니 전부 제거하는것도 제공한다.

---

#### 3). 이벤트 실행을 통해 연결된 동작 실행하기
* #### `someEvent.Invoke()`
    ```cs
    using UnityEngine;
    using UnityEngine.Events;

    public class TEST_UnityEvent : MonoBehaviour
    {
        public UnityEvent inspectorEvents;
        static internal UnityEvent scriptEvents;

        [ContextMenu("Invoke inspectorEvent")]
        void InvokeInspectorEvent(){
            inspectorEvents.Invoke();
        }

        [ContextMenu("Invoke scriptEvent")]
        void InvokeScriptEvent(){
            scriptEvents.Invoke();
        }
    }
    ```

---

#### 4).예제

* **1-1 인스펙터에 연결한 사례 :  "이벤트와 카메라 Active연결"**
    <div align=center>
        <img src="https://media.giphy.com/media/WNXf0XFttjD5eLDQbK/giphy.gif" width=80%>
    </div>

* **1-2 인스펙터에 연결한 사례 : "이벤트와 숫자 순차출력 연결"**
    <div align=center>
        <img src="https://media.giphy.com/media/wygJtjepQ3l2OriVoG/giphy.gif" width=80%>
    </div>

* **2-1 스크립트를 통해 동적 연결한 사례 : "이벤트와 숫자 순차출력 연결"**
    <div align=center>
        <img src="https://media.giphy.com/media/BEIyNItIeko4xlW0mp/giphy.gif" width=80%>
    </div>
### 📄 3. UnityEvent Scripting (매개변수 넘기기)
#### 매개변수를 입력해야 되는 상황이라면?

#### 1). 매개변수를 가지는 이벤트 만들기
* 매개변수는 최대 4개까지 넣을수 있게 오버로드 되어있다.
    ```cs
    public UnityEvent inputEvent;
    public UnityEvent<T1> inputvent1;
    public UnityEvent<T1, T2> inputvent2;
    public UnityEvent<T1, T2, T3> inputvent3;
    public UnityEvent<T1, T2, T3, T4> inputvent4;
    ```

* 예시
    ```cs
    public UnityEvent<int, float, Vector3>          inputInspectorEvents = new UnityEvent<int, float, Vector3>();
    static internal UnityEvent<int, float, Vector3> inputScriptEvents    = new UnityEvent<int, float, Vector3>();
    ```

---
#### 2). 이 매개변수 전달을 통해서 하고 싶은건 뭔가?

**다음 함수를 한번 UnityEvent에 연결해보자!**

> 값, 시간값, 위치값을 넘겨주면
> 그 시간 뒤에 값을 프린트하고, 위치값으로 순간이동해보고 싶을떄!

<details>
   <summary style="cursor:pointer; text:bold"><b>📂대충 위의 동작을 하는 코드📂</b></summary>

```cs
using System.Diagnostics;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TEST_PrinterInputAmount : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();
    
    public void printAmount(int _amount, float _time, Vector3 _position){
        StartCoroutine(CoPrint(_amount, _time, _position));
    }

    IEnumerator CoPrint(int _amount, float _time, Vector3 _position){
        sw.Start();
        Debug.Log("sw : " + sw.ElapsedMilliseconds.ToString()+"ms");

        yield return new WaitForSeconds(_time);

        Debug.Log($"Input Amount : {_amount}\n Input Position {_position}");
        transform.position = _position;
        
        Debug.Log("sw : " + sw.ElapsedMilliseconds.ToString()+"ms");
        sw.Stop();
    }
}
```
   <!-- summary 아래 한칸 공백 두어야함 -->
</details>


----

#### 2-1) : 이벤트와 동작 연결하기 : 인스펙터로 연결
```cs
using UnityEngine;
using UnityEngine.Events;

public class TEST_UnityEvent : MonoBehaviour
{
    
    [System.Serializable]
    public class InputType {
        public int Amount;
        public float Time;
        public Vector3 Positon;
    }
    public InputType inputType;
    public UnityEvent<int, float, Vector3> inputInspectorEvents = new UnityEvent<int, float, Vector3>();

    [ContextMenu("Invoke inspectorEvent")]
    void InvokeInspectorEvent(){
        inputInspectorEvents.Invoke(inputType.Amount, inputType.Time, inputType.Positon);
    }
}
```

<div align=center>
    <img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExZGZiMmZlNGQzMzdkN2RhYzJmNzU2NWNmM2Q0ZDZiOThiMGZiMDJhMSZjdD1n/pVApQ7hUzaDQa2xL9V/giphy.gif" width=80%>
</div>

---

#### 2-2) : 이벤트와 동작 연결하기 : 런타임에서 동적으로 연결하는 방식

```cs
using UnityEngine;
using UnityEngine.Events;

public class TEST_UnityEvent : MonoBehaviour
{
    static internal UnityEvent<int, float, Vector3> inputScriptEvents = new UnityEvent<int, float, Vector3>();
    [ContextMenu("Invoke scriptEvent")]
    void InvokeScriptEvent(){
        inputScriptEvents.Invoke(1004, 3f, new Vector3(6, 7 ,2));
    }
}
```

```cs
public class TEST_PrinterInputAmount : MonoBehaviour
{
                    :
    //Awake 추가하고 AddListener
    private void Awake() {
        TEST_UnityEvent.inputScriptEvents.AddListener(printAmount); 
    }
                    :
}
```

<div align=center>
    <img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExYTJmODhhYTkzOTc0ZmJiOWJkMjdkMDFjZGJlZjg0NGM4N2M1ZDZjMiZjdD1n/GAd0980zD3DD0AC1Av/giphy.gif" width=80%>
</div>

---

### 📄 3. 결론

**이벤트가 발생되면 그 연결된 동작이 실행된다.**

<div align=center>
    <img src="https://imgur.com/1iGuGxA.png" width=25%>
    <p>이벤트 입장에서는 연결된 동작이 어떻게 구현되었는지 알빠?</p>
</div>

#### 장점 
1. 장점은 커플링을 줄여준다.
2. `GameObject.Find().SendMessage()` 또는 ***"캐싱"*** 을 통한 함수호출이 필요하지 않다.
   1. 전자는 성능이 매우 구리고
   2. 후자는 코드 가독성이 떨어지는 위험이 있다.

#### 비교

|인스펙터 연결|동적 연결|
|---|---|
|실행순서를 보장받는다 🟢|실행순서를 보장받지 못한다.. ❌ <br>*런타임에 따라 순서 바뀜*|
|Public 함수만 연결<br>Private로 은닉된 함수는 연결 불가|Private라도 연결 가능<br> 동작의 주체가 되는 코드에서 AddListener 해준다면 |
|Play 이전에서 연결해줘야한다|동적 바인딩 가능|

### 📄 4. 참고

[유니티 공식 Doc](https://docs.unity3d.com/2023.2/Documentation/ScriptReference/Events.UnityEvent.html)