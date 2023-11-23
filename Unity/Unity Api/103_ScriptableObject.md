# 103 ScriptableObject

---

<div align="center">
    <img src="./image/2023-05-15-11-55-58.png" width=800px>
    <img src="./image/2023-02-08-22-58-28.png" width=800px>
</div>

---------------------------------------------------------------------------------

### 📄 1. 용어

> #### 0. 개요

**① intrinsic/Repeating** : 
* contain unchanging data duplicated across many objects

**② extrinsic/Unique** : 
* contextual data unique to each object

**③ 플라이 웨이트** : 
* 여러 객체들 간에 상태의 공통 부분들을 공유하여 RAM을 더 가볍게 하기 위함이다. 
    * Immutable -> intrinsic/Repeating : 공유되는것은 인스턴스마다 차이가 안나는것. readonly
    * Mutable -> extrinsic/Unique : 공유되지 않는것은 인스턴스마다 차이 나는것이다.

> #### 1. 스크립터블 오브젝트 사용하는 이유

\#캐시

플라이 웨이트 패턴을 유니티에서 구현한것이다.
따라서 플라이 웨이트가 가지는 장점을 그대로 내려 받았다고 이해하면 된다.

<div align="center">
    <img src="./image/2023-05-15-12-09-52.png" width=300px><br> &nbsp
</div>

```text
보통 개발하면서 클래스를 통해 인스턴스가 만들어지면 인스턴스 크기에 비례해 메모리가 할당된다.
분명 동일한 부분이 있음에도 인스턴스각각에 메모리가 할당 되야 하는것인가?
동일한 데이터가 인스턴스 수만큼 메모리를 차지하는것을 막기 위해..
```

**① 객체의 수에 관계 없이 값의 사본이 생기는 것을 방지하므로, <br>동일 데이터는 단 하나만 존재하게 되어 메모리를 절약 할 수 있다.**

**② 독립적인 에셋 형태로 저장 되므로 유니티 에디터를 통한수정이 수월하다.** 
  * 프리펩처럼 가져와 사용할 수 있는 데이터 컨테이너 변수 설계에 용이하다.
  * 게임이 실행될 떄 같이 메모리에 로드되는 에셋

**③ 레퍼런스 추적 가능**
  * 검색 가능 

**④ 커플링 감소에 기여한다.** 
  * 시스템간 하드 레퍼런스를 방지한다. 기인한 개발이 가능하도록 
  * 씬에 들어간 프리펩(능동적인 기능을 가지고 있는 구조를 만들기 좋다) 순수 기능없는 데이터를 굳이 씬으로 옮길 필요가 없다는것.

**⑤ 유니티 고유 타입 사용 가능 & 자동완성 가능**

> #### 2. 조심할 점

플라이 웨이트를 기억하자
**변하는것, 인스턴스마다 차이 나는것을 묶으려고 하는 시도를 하지 말자.**


> #### 3. MonoBehaviour Vs SciptableObject

```cs
/* : MonoBehaviour*/
using UnityEngine;
public class ___ : MonoBehaviour {
    private void Awake() {}
    private void Start() {}
    private void Update() {}
    private void OnEnable() {}
    private void OnDisable() {}
    private void OnDestroy() {}
}


/* : SciptableObject*/
using UnityEngine;
[CreateAssetMenu(fileName = "ObjAsset", menuName = "Scriptable Object/ObjAsset", order = int.MaxValue)]
public class ___ : SciptableObject {
    //Loop가 없음
    private void Awake() {}
    private void Start() {}
    private void OnEnable() {}
    private void OnDisable() {}
    private void OnDestroy() {}
    //단 메소드 사용 가능
}
```

---------------------------------------------------------------------------------

### 2. 활용하는 법

> #### 1. 데이터 컨테이너로 사용하기

대량의 데이터를 저장하며 프리펩으로 사용 가능


```cs
/* Card.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Object")]
public class Card : ScriptableObject {
    public string name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;
}

/*CardDisplay*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {
    public Card card;

    void Start ()
}

```

```cs
/*ScriptabelObjectDefinition*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_ScriptabelObjectDefinition_", menuName = "_ScriptableObjects_/_ObjAsset_")]
public class _ScriptabelObjectDefinition_ : SciptableObject {
    public string myString;
    public Sprite[] spriteArray;
}

/**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    [SerializeField] private _ScriptabelObjectDefinition_ scriptableObj;

}
```

> #### 2. EnumState로 사용 

> #### 3. 스크립터블 싱글톤


```cs
// UISetting.cs Scriptable
using UnityEngine;

//수동 제작
[CreateAssetMenu(fileName = "UISetting", menuName = "Scriptable Object/UISetting", order = int.MaxValue)]
public Class UISetting : ScriptableObject {
    private static UISetting _instance;
    public static UISetting Instance 
    {
        get 
        {
            if(_instance == null){ _instance = Resources.Load<UISetting>("UISetting");
            return _instance;
        }
    }

    /*
        UI에 사용할 데이터 모두
    */
}

using UnityEngine;

//수동 제작
public Class UISetting : ScriptableObject {
    UISetting.Instance.___;
}
```

> #### 4. 이벤트 설계

업데이트 루프에서 상태 변경을 계속 모니터링 하지 않아도 상태 변경에 대응 가능.

```cs
[CreateAssetMenu]
public class ScriptableEvent : ScriptableObject
{
	private List<GameEventListener> listeners = 
		new List<GameEventListener>();

    public void Raise()
    {
    	for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(GameEventListener listener)
    { listeners.Remove(listener); }
}

-----------------------------------------

public class GameEventListener : MonoBehaviour
{
    public ScriptableEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised()
    { Response.Invoke(); }
}
```


```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zooports.Event
{
    [CreateAssetMenu(fileName = "NewEventCaller", menuName = "ZOOPORTS/ScriptableObj/Event/EventCaller", order = 1)]
    public class MirageNetworkEventCaller : ScriptableObject 
    {
        private List<MirageNetworkEventListener> _serverListeners = new List<MirageNetworkEventListener>();
        private List<MirageNetworkEventListener> _clientListeners = new List<MirageNetworkEventListener>();
        private List<MirageNetworkEventListener> _localListeners = new List<MirageNetworkEventListener>();

        /// <summary>
        /// 서버를 대상으로 이벤트를 호출
        /// </summary>
        public void OnServerRaise()
        {
            for (int i = _serverListeners.Count - 1; i >= 0; i--)
                _serverListeners[i].OnEventRaised();
        }

        public void OnServerRegisterListener(MirageNetworkEventListener listener)
        { _serverListeners.Add(listener); }

        public void OnServerUnregisterListener(MirageNetworkEventListener listener)
        { _serverListeners.Remove(listener); }

        /// <summary>
        /// 모든 클라이언트를 대상으로 이벤트를 호출
        /// </summary>
        public void OnClientRaise()
        {
            for (int i = _clientListeners.Count - 1; i >= 0; i--)
                _clientListeners[i].OnEventRaised();
        }

        public void OnClientRegisterListener(MirageNetworkEventListener listener)
        { _clientListeners.Add(listener); }

        public void OnClientUnregisterListener(MirageNetworkEventListener listener)
        { _clientListeners.Remove(listener); }

        /// <summary>
        /// 로컬 플레이어를 대상으로 이벤트를 호출
        /// </summary>
        public void OnLocalClientRaise()
        {
            for (int i = _localListeners.Count - 1; i >= 0; i--)
                _localListeners[i].OnEventRaised();
        }

        public void OnLocalClientRegisterListener(MirageNetworkEventListener listener)
        { _localListeners.Add(listener); }

        public void OnLocalClientUnregisterListener(MirageNetworkEventListener listener)
        { _localListeners.Remove(listener); }
    }
}
```

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Zooports.Data;
using Mirage;

namespace Zooports.Event
{
    public class MirageNetworkEventListener : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("DEV")]
        [FormerlySerializedAs("Comment")]
        public string DEVComment;
#endif

        [Header("Event Setting")]
        [FormerlySerializedAs("Event Listener Type")]
        [SerializeField] EventListenerType EventListenerType;
        public MirageNetworkEventCaller Event;
        public UnityEvent Response;

        void OnEnable()
        {
            switch (EventListenerType)
            {
                case EventListenerType.Server:
                    Event.OnServerRegisterListener(this);
                    break;
                case EventListenerType.Client:
                    Event.OnClientRegisterListener(this);
                    break;
                case EventListenerType.Local:
                    Event.OnLocalClientRegisterListener(this);
                    break;
            }
        }
        void OnDisable()
        {
            switch (EventListenerType)
            {
                case EventListenerType.Server:
                    Event.OnServerUnregisterListener(this);
                    break;
                case EventListenerType.Client:
                    Event.OnClientUnregisterListener`(this);
                    break;
                case EventListenerType.Local:
                    Event.OnLocalClientUnregisterListener(this);
                    break;
            }
        }

        public void OnEventRaised()
        { Response.Invoke(); }
    }
}
```


> #### 5. 인벤토리 매니저를 스크립터블 오브젝트에 두기

---------------------------------------------------------------------------------

### 3. APIs

---------------------------------------------------------------------------------

### 참고 
* https://refactoring.guru/ko/design-patterns/flyweight
* https://www.youtube.com/watch?v=PVOVIxNxxeQ
* https://docs.unity3d.com/kr/2022.2/Manual/class-ScriptableObject.html
* https://wergia.tistory.com/189
* https://unity.com/kr/how-to/architect-game-code-scriptable-objects
* https://medium.com/wardgames/unity-scriptable-object%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%9C-%EC%9D%B4%EB%B2%A4%ED%8A%B8-%EC%B2%98%EB%A6%AC-b689a0c27c46


