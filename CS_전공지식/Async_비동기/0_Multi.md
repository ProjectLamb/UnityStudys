---
ebook:
  theme: one-dark.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #45C1A4; border-left: 5px solid #45C1A4; border-right: 5px solid #45C1A4; background-color: #45C1A4; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #45C1A4 !important;}

    h4 { font-weight: bold; color: #FFF !important; }

    summary { cursor:pointer; font-weight:bold; color : #0F0 !important;}

    .red{color: #d93d3d;}
    .darkred{color: #470909;}
    .orange{color: #cf6d1d;}
    .yellow{color: #DD3;}
    .green{color: #25ba00;}
    .blue{color: #169ae0;}
    .pink{color: #d10fd1;}
    .dim{color : #666666;}
    .lime{color : #addb40;}
    .container {
        display : flex; 
        flex-direction:row;
        align-items:center;
    }
    .item {
        margin-right:2%;
    }

    @media screen and (min-width:1001px){
        .container {
            width: 90%;
            flex-wrap : nowrap;
            justify-content:center;
        }
    }
    
    @media screen and (max-width:1000px){
        .container {
            width: 98%;
            flex-wrap : nowrap;
            justify-content:center;
        }
    }
    
    @media screen and (max-width:799px){
        .container {
            justify-content:left;
            flex-wrap : wrap;
        }
    }

</style>

## ⏱️ 0. Multi

---

### 1. 용어 정리

#### 프로세스(프로그램) : RAM(보조 기억 장치)에 적제되어 "실행되는" 처리 대상이 되는 프로그램

<div>
    <div class="container">
        <div class="item">
            <img src="img/23-11-23-23-58-01.png" width=100%>
            </img>
        </div>
        <div class="item">
        <h5>① 스레드간 공유가능한 데이터</h5>
            <ol>
                <li>프로세스 ID : 메타데이터</li>
                <li>파일 : 애플리케이션이 읽고 쓰기위해 여는 파일 입니다. </li>
                <li>코드 : CPU에서 실행되는 프로그램의 명령어 </li>
                <li>힙(Data) : 애플리케이션에 필요한 데이터</li>
            </ol>
        <h5>② 스레드간 공유 되지 않는 데이터</h5>
            <ol>
                <li>스택 : 메모리영역 지역 변수, 함수</li>
                <li>명령어 포인터</li>
            </ol>
        </div>
    </div>
</div>


#### 프로세서(하드웨어) : 처리를 위한 하드웨어 (CPU)

**① CPU 연산 순서**

1. Fetch (인출) : RAM의 프로그램 카운터가 가르키는 명령어를 인출해 CPU로 적재
2. Decode (해석) : 명렁어의 종류, 타겟을 판단
3. Execute (실행) : 명령어에 따라 데이터에 대한 연산 수행
4. WriteBack (쓰기) : 처리된 데이터를 RAM에 기록


**② 구성요소**

1. CU (Control Unit) : RAM으로 부터 프로그램 명령을 "인출, 해독"하며, 
명령어 실행에 필요한 "제어 신호" RAM, ALU, I/O에 보내는 장치
1. ALU : 연산을 수행하는 장치
2. Register : CPU 내에 있는 메모리 최상위에 위치한 가장 빠른 속도로 접근 가능한 메모리다.

#### 스레드 : CPU에서 실행되며, 프로세스보다 더 작은 수행단위

**① 설명**

* 스레드가 수행될때 자원의 할당은 ***CPU(레지스터, 캐시) & 메모리***에 일어난다.
* 하나의 프로세스에는 단일 스레드, 다중 스레드가 존재한다.
* 위의 설명 그대로 ***코드 수행를 하는 최소 수행 단위*** 이며, 프로세스보다 더 적은 비용을 사용한다.
    * 그 이유는 프로세스의 자원을 일부 공유를 하고, 개별적인 자원이 프로세스보다 더 적기 때문.
    * 생성과 삭제가 빠르고, Context_Switcing에 유리하다.


**② 스레드의 상태 관리**

<div align=center>
    <img src="img/23-11-23-17-44-45.png">
</div>

|스레드 상태|설명|
|:-:|:--|
|Unstarted| thread 객체는 생겨져 있지만, Start() 메서드가 아직 호출이 안된 상태 |
|Running|Start()가 호출되어 thread가 동작중인 상태|
|Suspended| Suspend() 메서드가 호출되어 스레드가 일시 중지된 상태|
|Wait/Sleep/Join|스레드가 Block 된 상태 Enter(), Sleep(), Join() 호출될때 상태다|
|Aborted|Aborted 메서드가 호출되어 스레드의 동작이 취소된 상태, 이후 Stopped 상태로 바뀌어 스레드가 완전 중지됨|
|Stopped| 스레드가 완전히 종료된 상태|


```cs
static void Main(string[] args)
{
    Thread t = new Thread(Working);
    // 2진수 값을 갖고 있기때문에 비트 마스킹을 통해서  스레드의 실행 여부를 조건분기로 처리 할 수 있다.
    if ((t.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) == 0) {

    }
}
```

**③ Foreground Thread & Background Thread**
* 포어그라운드이면 MainThread가 종료 되어도 프로세스가 종료에 영향을 미치지만, 
* 백그라운드라면 MainThread의 종료 여부를 따지지 않기 때문에 
  메인 스레드에 종료에 따라 프로세스, 스레드 모두 종료된다. *Java에서는 Daemon 상태냐 아니냐를 의미한다.*

**④ 비동기 프로그래밍 패턴 VS 병렬 프로그래밍**

언제 `async/await`를 써야 하는것이며, 언제 `parallel.foreach`를 사용해야 하는것일까.. 무엇이 두가지가 다른것이지?

두가지 비슷한 개념을 공유하고 있지만 다른것이다.

`async/await` is about asynchrony
* 수행해야하는 A 연산이 B(비동기 적인) 연산이 완료되지 않는한 수행할 수 없고, 하지면 현재 스레드를 block하고 싶지는 않을때 유용하다.
    1. UI나 렌더링 이후
    2. 긴 연산을 다룰때, (웹서버)
`Parallel.ForEach` is about parallelism.
* 콜렉션에 있는 아이템을 수행할때, 모든 연산이 수행 되기 전까지 Blocking 됨

그렇다면 `parallel.foreach`와 `Task.Run`and`Task.WhenAll`과의 차이는?


#### 동기적 (Imperative) & 비동기적 (Asynchronouse)

|동기적 | 비동기적|
|:--|:--|
|끝날때까지 대기 |  끝날때까지 대기 안함|
|요청을 보낸후 해당 응답을 받아야<br> 다음 동작을 실행|요청을 보낸 후 응답에 관계 없이<br> 다음 동작을 실행|
|실행이 끝나고 다음 실행|실행중에도 다음 실행|

#### Concurrency(동시성) & Parallelism(병렬성)

|Concurrency|Parallelism|
|:--|:--|
|동시에 실행되는것 처럼 보임 (응답성)|실제로 동시에 실행 (성능)|
|단일 코어만으로도 가능|멀티코어에서만 가능|
|Context_Switcing|Race Condition|

#### Concurrency and Parallelism & Synchronous and Asynchronous
* Concurrency and Parallelism     : Way tasks are executed.
    * 스레드나 프로세스에 작업을 실행하게 되는것
    * 스레드나 프로세스에 작업이 2개 이상 동시에 실행되면 Parallelism개념이 나오는것,
* Synchronous and Asynchronous    : Programming model. 
    * 그말은 즉슨, 이전 작업을 기다리지 않고 다음 작업을 시작한다는 점에서
    * 방법이 어떻게 되었든, 싱글스레드에서도 작동이 되고 멀티 스레드에서도 작동이 된다.


#### 프로세스 처리 발전흐름

|특징|Single Process|Multi Programming|Multi Tasking|Multi Processing|Multi Thread|
|:--|:-:|:-:|:-:|:-:|:-:|
|여러 프로그램 실행 유무|❌|✅|✅|✅|✅|
|프로세스 대기 유무 & 프로세스 작업 스위칭(Context_Switcing)|❌|❌|✅|✅|✅|
|프로그램 병렬성 & 병렬 작업 처리 가능성|❌|❌|❌|✅|✅|
|고유의 코파힙, ID|❌|❌|❌|✅|❌ : 고유스택|
|자원(메타데이터, 코드, 파일) 공유가능성|❌|❌|❌|⚠️|✅ : 스택제외|

**문맥교환 Context_Switcing**

```txt
Stop thread 1 ->
Schedule thread 1 out ->
Schedule thread 2 in ->
Start thread 2
```

> 다른 스레드로 Context_Switcing한다면 
> 현재 스레드의 리소스, 데이터를 저장하고 
> 또 다른 스레드의 리소스를 CPU & 메모리에 복원해야 한다.

**① 스레싱**
* 너무 많은 스레드를 가동하게 되면 스레싱이 발생한다.
* Context_Switcing에 더 많은 비용이 들어가는 문제가 생긴다.

**② 스케쥴링 : 문맥 교환 타이밍**
> 각 스레드에 대한 동적 우선 순위를 유지하며, 
> 인터랙티브 스레드를 우선시하며 
> 특정 스레드가 기아상태가 되는것을 방지한다.

#### Thread VS Task
```

두 개념 모두 Concurrency(동시성)과 Parallelism(병렬성)를 다루기 위해 
종종 사용되는 개념이였다 (developers often leverage).

지금부터 두가지 각각의 특성과 제공하는 목적이 무었인지 확인해보자.
```

```
1. Task in .Net
Task가 소개된 목적으로는 "Asynchronouse Operation(비동기 작업)의 추상화" 입니다. 
비동기 처리에 사용된다는것, 

thread가 정말 low-level이라 하면, 
task는 그 thread를 추상화해 단순화된 모델로 제공된 high-level 이라는것 이다.
Task는 그래서 Concurrently하게 실행하는 작업 단위를 말한다.
Concurrently(동시성)
그리고 효율적인 자원 사용을 이용하도록 목적이 되어 있다.

이 Task 라는 녀석은 내부적으로는 Thread로 구현되어 있다
정확히는 런타임에서 관리되는 thread pool에 의존한다.
따라서 thread pool을 사용하는 목적대로 가벼우며 확장성이 높다.

Task인스턴스를 만들기 위해 Delegate를 매개변수로 넘겨 줘야한다(Action, Func)
```

*
    ```cs

    /******************************************************
    * 
    * Task.Run 이녀석은 비동기적적으로 실행되는 task(작업)을 실행하는 녀석이다.
    * 주로 "오래 걸리는 작업", "I/O 작업"이 들어가겠다. delegate로
    *
    * ContinueWith함수는 Task가 완료될때 실행되는 동작을 넣는다
    * 주로 "작업 완료 핸들링 이벤트", 또는 "task 결과를 가지고 어떤 처리를 해야할때"
    * 
    *******************************************************/

    Task.Run(() => {
        // Perform computationally intensive(강한) or I/O-bound work here
    }).ContinueWith(task => {
        // Handle task completion or process the result
    });

    Task task = Task.Run( () => { Console.WriteLine("작업 메소드");});
    task.Wait();
    Console.WriteLine("메인 작업");
    ```

```
2. Thread in .Net

스레드는 프로그램의 실행 기본 단위다.
스레드는 운영체제 스레드와 직접 관련이 있으며, 개발자에 의해 명시적으로 관리되는 부분이다.
코드의 Concurrency한 실행을 허용하며, 여러 CPU 코어에서 Parallel하게 실행 될 수 있다.
```

*
    ```cs
    /******************************************************
    *
    * `new Thread` 객체는 delegate로 실행되는 코드를 명시한다.
    * 
    * `Start` 스레드를 시작하는 녀석
    * 
    * `join` 스레드가 완료될때까지 기다리는 녀석
    * 
    *******************************************************/

    Thread thread = new Thread( () => {
        // Perform complex or time-consuming operations here
    });

    thread.Start();
    thread.Join(); // Wait for the thread to complete
    ```

```
3. 차이점 & 참고할 점
① Abstraction Level     : 
    Task (higher-level abstraction) thread보단 사용성에 용이한 녀석
    Thread (Lower-level) : 명시적인 스레드 Control & Management
② Resource Utilization  : 
    Task 는 스레드풀의 스레드를 사용한다.
        띠리서 자원 할당과 동적인 확장이 가능
③ Synchronization       : 
    Task의 동기화 매커니즘을 `await` `ContinueWith`을 통해서 coordinate하고 핸들링한다
④ Fine-Grained Control : 
     일단 Fine-Grained 라는 의미는 "다수의 호출로 하나의 작업의 결과"를 이루어내는 방식을 말하는것이고 
    Coarse-Grained 라고 함은 "Single-Call"로 다수의 결과를 이루어 내는 방식이라.. 
     이어서, Threads는 세심한 Control과 Flexibility를 제공한다는 점이다
     스레드에대한 직접적인 조작이 가능하게 한다.

Concurrent(병행성) 프로그래밍 영역에서는(In the realm of)
thread와 task를 매우 중요하게 나눠서 봐야 한다.

그래서 Task의 존재 의의는 Thread의 Thread Pool를 객체화 시킨것이며,
asynchronous(비동기적) 연산에 효율적이며 친숙화 되어 있으며 
Thread는 더 세심하고 세부적인 조작을 위해 사용한다.
```

```
4. Parallel
직접 Task를 활용해 병렬 처리를 구현하는것 보다 더 쉽게 병렬 처리를 구현할 수 있도록 해주는 클래스다.
```

### 멀티스레드를 알아야 하는 이유
① 응답성 (대기, Blocking 해결, UI 반응성, Concurrency, 동시에 작업되는것 처럼 보이는 환상이다.)

② 성능 (실제로 작업을 여러개 실행, 같은 시간에 많은 작업을 함)

### 스레드 종료, Deamon Thread

#### 1. Thread Termination
**스레드를 멈춰야할 때** : 스레드는 아무 작업을 하지 않을떄도, 리소스를 사용한다.
1. 자원 소모 방지 EX). CPU 시간과, 캐시 공간, 메모리와 커널 자원
2. 작업 완료한 스레드 정리
3. 오작동
4. 앱 전체를 종료하기 위해. 메인스레드가 멈췄다 하더라도, 최소 스레드가 실행되고 있어도 종료가 안된다.

#### 2. `Thread.interrupt()`

각 스레드 객체는 interrupt를 가진다. 
시그널을 보낸다

1. 인터럽트 예외 처리
2. 인터럽트 신호 명시적으로
    ```java
    if(Thread.currentThread().isInterrupted()) {
        종료 명령...
    }
    ```

#### 3. Daemon threads
> 백그라운드에서 실행되는 스레드로 스레드 때문에 app 종료가 방해 받는 일이 없다.
> (메인 스레드가 멈추면, app 멈춘다)

Ex). 
1. 자동 저장을 담당하는 백그라운드 스레드.
1. 워커 스레드에 있는 제어권 없는(?) 코드

`threadInstance.setDaemon(true)`

### 스레드 연결

> #### 처리속도를 높이고 안전하고 정확하게 결과를 종합하는것이 목적이다.

일반적으로 스레드의 순서를 추측할 수 없다.
만약 스레드간 Dependency가 있다면..

1. 완료되었는지 계속 확인 -> Busy하다라는 의미
2. A가 완료될때까지 B를 재운다. "이게 좋다."


#### 1. `Thread.join()`

**① 스레드 동기화**
여러개의 스레드들이 특정 자원에 접근할때 점유를 하는 방식이라
A스레드가 자원 점유 중이라면, 다른 B스레드가 점근하게 되면 문제가 생기므로 하면 안된다.
따라서 스레드간 동기화를 통해 불안정을 제거하고 스레드간 순서를 매길 필요가 있다.
* **1. Lock**
* **2. Monitor**
lock과 모니터가 하는 일은 비슷한데 모니터쪽이 좀더 세밀한 컨트롤을 가능하게 한다.
Enter, Exit 뿐만 아니라 Wait, Pulse 메서드를 사용해 스레드를 좀더 세부적으로 제어하도록 한다. 
Wait메서드는 WaitSleepJoin 상태로 만들며, 해당 스레드가 실행중인 lock을 해제하도록 한다.
그 뒤에는 Waiting_Queue라는 큐에 입력이 되고, 다른스레드가 lock을 잡게 된다.
작업을 마치면 바로 Pulse 메서드를 이용해 Waiting Queue에 있는 스레드를 꺼내 Ready Queue에 입력시킨다..
그리고 그 스레드를 순서대로 동작시켜 Running 상태로 만든다.

<details>
    <summary>Example1 : Lock & Moniter {펼치기}</summary>

```cs
class Program {
    static int count = 0;
    static readonly object lck = new Object();
    
    static void Main(string[] args) {
        List<Thread> threadList= new List<Thread>();
        threadList.Foreach(T => T.Add(new Thread(_Working_)));
        threadList.Foreach(T => T.Start());
        threadList.Foreach(T => T.Join());

    }

    static void UnlockedWorking() {
        ++count;
    }
    static void LockedWorking() {
        lock(lck)
        {
            ++count;
        }
    }
    static void MoniterWorking() {
        Monitor.Enter(lck);
        ++count;
        Monitor.Exit(lck);
    }
}
```

</details>

<details>
    <summary> Example2 : Lock & Moniter & Queue {펼치기}</summary>

```cs
class Program
{
    static int count = 0;

    static readonly object lck = new Object();
    static Queue q = new Queue();
    static bool threadLock = true;
    static bool workEnd = false;

    static void Main(string[] args) {
        List<Thread> threadList = new List({
            new Thread(SetQueue),
            new Thread(GetQueue),
        });

        threadList.Foreach(t => t.Start());
        threadList.Foreach(t => t.Join());
    }

    static void SetQueue() {
        lock(lck) 
        {
            while(true) {
                q.Enqueue(++count);

                if(count == 10 && threadLock == true && workEnd == false) {
                    threadLock = false;
                    Monitor.Wait();
                }
                else if(workEnd == true) {break;}
            }
        }
    }

    static void GetQueue()
    {
        lock(lck) 
        {
            foreach(var item in q) {
                WriteLine(item);
            }
            if(threadLock == false && workEnd == false) 
            {
                workEnd == true;
                Monitor.Pulse(lck);
            }
        }
    }
}
```
</details>


### 성능 및 지연 시간 최적화 개요

#### 1. criteria(기준)/definition(정의)
> 성능이라는 용어는 다양하게 정의되며, 경우에 따라 그때그떄 정의해야한다.

#### 2. Performance in Multithreaded applications
> 아래 두가지(Latency, Throughput)는 서로 다른 메트릭이라 
> 한쪽이 개선된다 하더라도 다른쪽에도 영향을 끼치는것을 보장 할 수 없다.

**① Latency (지연 시간)**  : 하나의 작업이 끝나는데 끝나는 시간.
* 지연시간(T)을 줄이는 방법
    ```
    이론적으로 접근해.
    T를 N개의 서브테스크롤 나누면 되지 않을까?
    그러면 각각의 서브 테스크들은 T/N의 Latency를 가진다.

    다만.. 이렇게 하는게 가능한지? 몇가지 따져봐야 할것이 있다.

    1. N을 도데체 몇까지 나눌 수 있을까?
        이론상 N의 개수는 컴퓨터의 코어 개수와 동일해야한다. 
        만약 N보다 더 많아지면 쓸데없는 CPU(Context_Switcing, 캐시 성능 저하), 메모리 낭비가 생긴다.
        
        다만, 정말로 이론상의 이야기 인것이 
        정말 이 N의 서브 테스크들이 인터럽트 없이 runnable이며, IO, Nonblocking가 보장되는가 그게 문제다.

    2. CPU가 많이 소모되는 작업이 돌아가면 안되야 한다.
    3. 하이퍼 스레딩 : 코어 하나가 스레드 두개를 동시에 실행할 수 있다.
        물리적인 코어의 하드웨어를 일부 복제함으로 달성한다.
    
    4. 결과를 병렬처리하고 종합하면서 발생하는 비용.
        - 테스크를 작은 세그먼트로 나눈데 드는 비용
        - 스레드 생성, 스레드에 작업을 전달하고 시작하는 비용
        - 스레드를 실제로 스케쥴링해 스레드가 실행되기까지 시간 비용
        - 결과를 얻기위해 마지막 스레드가 완료되었다는 신호를 기다리는 비용
        - 하위 작업을 하나로 합치는 비용

        사실.. 짧게 걸리는 요소에 대해서는 싱글스레드가 유리하지만.
        정말 병렬로 실행할 가치가 있을만큼 작업이 길고, 무거울수록 좋다.

    5. 과연 모든것이 서브테스크로 분할이 되는가?
        3가지 유형이 있다
        - 모든것이 정말 병렬
        - 오직 하나의 스레드만 사용할 수 밖에 없는 경우 : 
        - 어떤것은 병렬, 어떤것은 직렬

    ```

**② Throughput (처리량)** : 일정 단위 시간동안 완료한 작업의 양 
1. 한 테스크를 쪼개는 관점 (작업이 내부적으로 연관됨)
Throughput = N(Subtasks) / T(LatancyTime)
다른 작업이 끝마쳐지는것을 기다려서 모아야한다.

1. 수많은 별개의 테스크 관점 (내부적으로 별개의 작업)
2. Throughput = N(threads|cores) / T(LatancyTime)
다른 작업의 끝마치는것을 기다릴 필요는 없다.

**③ Thread Pooling** 
* 스레드 풀링은 스레드를 생성하고 삭제를 하는것이 아닌 다시 그 스레드를 사용한다.
Task는 Queue를 통해 순서대로 풀에 처리를 맡긴다.

* 64개의 코어를 갖춘 머신이 있다고 가정해 보겠습니다.
    HTTP 요청을 처리하는 데 최적인 스레드 풀 크기는 무엇일까요?
    작업에 블로킹 호출이 포함되어 정확히 알 수는 없지만 64 이상인것은 확실하다.
    스레드가 더 많다는 것은 더 많은 요청을 처리할 수 있다는 뜻이지만, 오버헤드와 컨텍스트 스위칭도 더 많아지기 때문에 최적의 스레드 개수를 미리 알 수 있는 방법은 없습니다. 따라서 부하 테스트를 수행해야 하죠.

### 참조

1. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-multi-programming-tasking-processing
2. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-%ED%94%84%EB%A1%9C%EC%84%B8%EC%8A%A4-%E2%9A%94%EF%B8%8F-%EC%93%B0%EB%A0%88%EB%93%9C-%EC%B0%A8%EC%9D%B4
3. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-multi-process-multi-thread

4. [Thread & Task](https://medium.com/c-sharp-progarmming/understanding-the-difference-between-task-and-thread-in-net-d1a35acb2dc3)
5. [Process & Thread & Task](https://lab.cliel.com/entry/C-%EC%8A%A4%EB%A0%88%EB%93%9C%EC%99%80-%ED%83%9C%EC%8A%A4%ED%81%AC)
6. [동기&비동기 / 병행성&병렬성](https://velog.io/@brown_eyed87/220929%EB%B3%91%EB%A0%AC%EC%84%B1%EB%8F%99%EC%8B%9C%EC%84%B1-%EB%B9%84%EB%8F%99%EA%B8%B0%EB%8F%99%EA%B8%B0)
7. [Asynchronous vs Multithreading and Multiprocessing Programming (The Main Difference)](https://www.youtube.com/watch?v=0vFgKr5bjWI)
8. [비동기 작업 & Thread, Task 그리고 Async를 쓸까말까](https://www.youtube.com/watch?v=HkLhKyoh3sI)
9. [Async & Await 유니티 예시](https://www.youtube.com/watch?v=gxaJyuf-2dI)

https://medium.com/swift-india/concurrency-parallelism-threads-processes-async-and-sync-related-39fd951bc61d
https://medium.com/geekculture/asynchronous-and-parallel-programming-in-c-net-1e0f14e1db80
https://blog.christian-schou.dk/concurrency-vs-parallelism-vs-asynchronous/

https://stackoverflow.com/questions/14455293/how-and-when-to-use-async-and-await?rq=1
https://stackoverflow.com/questions/9898441/do-the-new-c-sharp-5-0-async-and-await-keywords-use-multiple-cores
https://stackoverflow.com/questions/11564506/nesting-await-in-parallel-foreach/11565531#11565531
https://stackoverflow.com/questions/19102966/parallel-foreach-vs-task-run-and-task-whenall


https://www.youtube.com/watch?v=G3tz9rxts8E

https://www.youtube.com/watch?v=EJNBLD3X2yg&list=WL&index=3
https://www.youtube.com/watch?v=mb-QHxVfmcs&list=WL&index=4
https://www.youtube.com/watch?v=H01FkDtllwc&list=WL&index=6
https://www.youtube.com/watch?v=XNGfl3sfErc&list=WL&index=7