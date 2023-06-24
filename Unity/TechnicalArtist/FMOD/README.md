<h1 align="center"> Fmod </h1>

---

## 개요

* 동적인 음악 협업을 위한 툴

---

### 📄 1. FMOD?

1. DSP 사운드 이벤트
2. 유니티의 오디오 엔진을 대체할 수 있다.

3. 사운드 블랜드
4. 로직 컨트롤

배경음악을 구성하는 종류

Vertical Adaptive
* 동시에 음악을 재생하고
* 볼륨을 크로스 페이드

Horizontal Adaptive
* 전환하고자하는 음악 A B 
* 변경할 떄 템포에 맞춰 스팅어(Stinger)를 통해 전환되는 시점의 어색한 부분을 가려
  * 재생중인 음악에 겹쳐서 믹싱되게 함
  * 자연스럽게 전환 하게 한다.


---

### 📄 2. FMOD Integrate

bank란?
빌드란?
이벤트란?

<img src="./image/2023-03-05-15-52-11.png">
1. 뎀포 바꾸기
2. 루프 구간
3. option shipt s : 그리드
4. 이벤트를 데이터 영역으로 뱅크
---

1. 유니티에 가서 FMOD 세팅
2. 카메라 소리 없에기
3. 뱅크를 통해 연결

뱅크 빌드는 다음과 같다.

<img src="./image/2023-03-05-18-55-13.png">

---

### 📄 FMOD Project
#### 개요
1. 폴더채로 공유하면 된다.
2. AutoSave가 없으므로 꼮 주의하다.

#### UI

이벤트
   * 게임속 이벤트랑 1대1 매칭이 된다.
   * 뱅크에 Assign되야 의미가 있다.

뱅크
   * 이벤트를 종류별로 모아 담는다
   * 게임에 여러 리소스가 올라갈떄 뱅크 단위로 올라간다.

에셋
   * 리소스가 담딤

#### 오디오 트랙 & 타임라인
1. 패러미터
   *  오토메이션 가능
2. Deck 
   * 이펙트넣을 수 있음
3. 3D Preview

#### 오디오 임포트
1. 에셋에서 임포트

#### FADE 기능
<img src="./image/2023-03-05-17-05-32.png"> 

#### 리젼
1. 오토메이션
   * <img src="./image/2023-03-05-16-48-17.png">
2. LFO
   * <img src="./image/2023-03-05-16-51-20.png">
3. loop
   * <img src="./image/2023-03-05-16-54-45.png">
   * <img src="./image/2023-03-05-17-09-04.png">
4. Async
   * 마커를 통해 헌번 트리거 되기만해도 계속 진행되도록

#### 파라메터
알파요 오메가다.
패러미터를 짜는 생각을 잘하자.
<img src="./image/2023-03-05-17-12-29.png">
라우터 추가하기
<img src="./image/2023-03-05-17-28-12.png">
분위기 바꾸기
|일반|전투|
|:--|:--|
|<img src="./image/2023-03-05-17-29-34.png">|<img src="./image/2023-03-05-17-29-45.png">|


#### 오디오 추가하기
<img src="./image/2023-03-05-17-11-48.png">

#### 스냅샷 이벤트

AHDSR
<img src="./image/2023-03-05-17-38-52.png">

---

### 참고
https://www.youtube.com/watch?v=6QjjB2sRKBE&list=PLrJD7pzELsiY8FXY3edclUxbnFNCSr1Ep&index=3

https://davisan.itch.io/dvn-effects-fmod

https://www.youtube.com/watch?v=rcBHIOjZDpk
