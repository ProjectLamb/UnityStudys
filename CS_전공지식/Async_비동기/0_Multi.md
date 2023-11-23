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
</style>

## ⏱️ 0. Multi

---

### 1. 용어 정리

#### 프로세스(프로그램) : RAM(보조 기억 장치)에 적제되어 "실행되는" 처리 대상이 되는 프로그램

<div align=center>
<img src="img/23-11-21-17-41-30.png" width=70%>
</div>

* 
    ```json
    공유되는 데이터
    프로세스 ID : 메타데이터
    파일 : 애플리케이션이 읽고 쓰기위해 여는 파일 입니다.
    코드 : CPU에서 실행되는 프로그램의 명령어
    힙 : 애플리케이션에 필여한 데이터

    메인스레드 : 스레드
        스텍 : 메모리영역 지역 변수, 함수
        명령어 포인터
    ```


#### 프로세서(하드웨어) : 처리를 위한 하드웨어 (CPU)
* **CPU 연산 순서**
    1. Fetch (인출) : RAM의 프로그램 카운터가 가르키는 명령어를 인출해 CPU로 적재
    2. Decode (해석) : 명렁어의 종류, 타겟을 판단
    3. Execute (실행) : 명령어에 따라 데이터에 대한 연산 수행
    4. WriteBack (쓰기) : 처리된 데이터를 RAM에 기록

* **구성요소**
    1. CU (Control Unit) : RAM으로 부터 프로그램 명령을 "인출, 해독"하며, 명령어 실행에 필요한 "제어 신호" RAM, ALU, I/O에 보내는 장치
    2. ALU : 연산을 수행하는 장치
    3. Register : CPU 내에 있는 메모리 최상위에 위치한 가장 빠른 속도로 접근 가능한 메모리다.

#### 스레드 : CPU에서 실행되며, 프로세스보다 더 작은 수행단위 
* 스레드가 수행 된다는 의미는 
    리소스(CPU 레지스터 & 캐시메모리, 메모리 커널 리소스) 같은 것을 차지한다는것.
* 하나의 프로세스에는 단일 스레드, 다중 스레드가 존재한다. 
* 코드를 수행하는 주체가 되고, 실행 자원을 공유한다.
* 프로세스보단 스레드가 더 적은 비용을 사용한다.
    * 생성과 삭제가 빠르고, Context_Switcing에 유리하다
    이유는 프로세스는 공유하는 자원이 더 많고 스레드는 적은 자원을 공유하기 때문이다.


#### 동기적 (Imperative 직렬적) & 비동기 (Asynchronouse 병렬적)

* 
    |동기적 | 비동기|
    |:--|:--|
    |끝날때까지 대기 |  끝날때까지 대기 안함|
    |요청을 보낸후 해당 응답을 받아야<br> 다음 동작을 실행|요청을 보낸 후 응답에 관계 없이<br> 다음 동작을 실행|
    |실행이 끝나고 다음 실행|실행중에도 다음 실행|

#### Concurrency(동시성) & Parallelism(병렬성)

* 
    |Concurrency|Parallelism|
    |:--|:--|
    |동시에 실행되는것 처럼 보임 (응답성)|실제로 동시에 실행 (성능)|
    |단일 코어만으로도 가능|멀티코어에서만 가능|
    |Context_Switcing|Race Condition|

#### 프로세스 처리 발전흐름

*
    |_|Single Process|Multi Programming|Multi Tasking|Multi Processing|Multi Thread|
    |:--|:-:|:-:|:-:|:-:|:-:|
    |여러 프로그램 실행 유무|❌|✅|✅|✅|✅|
    |프로세스 대기 유무 & 프로세스 작업 스위칭(Context_Switcing)|❌|❌|✅|✅|✅|
    |프로그램 병렬성 & 동시 작업 처리 가능성|❌|❌|❌|✅|✅|
    |고유의 코데힙스, ID & 독립 실행|❌|❌|❌|✅|❌|
    |자원(메타데이터, 코드, 파일, 힙) 공유가능성|❌|❌|❌|⚠️|✅|

**문맥교환 Context_Switcing**

* 절차

    ```txt
    Stop Thread1
    Schedule thread 1 out
    Schedule thread 2 in
    Start Thread2
    ```
    > 다른 스레드로 Context_Switcing한다면 
    > 현재 스레드의 리소스, 데이터를 저장하고 
    > 또 다른 스레드의 리소스를 CPU & 메모리에 복원해야 한다.

* 스레싱
    * 너무 많은 스레드를 가동하게 되면 스레싱이 발생한다.
    * Context_Switcing에 더 많은 비용이 들어가는 문제가 생긴다.

* 문맥 교환 타이밍 (스케쥴링)
    > 각 스레드에 대한 동적 우선 순위를 유지하며, 
    >인터랙티브 스레드를 우선시하며 
    >특정 스레드가 기아상태가 되는것을 방지한다.
    * 선점형
    * 비선점형


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


### 참조

1. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-multi-programming-tasking-processing
2. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-%ED%94%84%EB%A1%9C%EC%84%B8%EC%8A%A4-%E2%9A%94%EF%B8%8F-%EC%93%B0%EB%A0%88%EB%93%9C-%EC%B0%A8%EC%9D%B4
3. https://inpa.tistory.com/entry/%F0%9F%91%A9%E2%80%8D%F0%9F%92%BB-multi-process-multi-thread
