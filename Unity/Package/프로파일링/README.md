## 머리말

### 참 늘 누누이 말하지만. 
* 최적화를 처음부터 신경쓰지 않아야한다.
* 교수도 누누이 말하지만 구현에 집중을 해야한다.
* 우선순위는 다음과 같다
   1. 프로토타입 구현
   2. 재구현
   3. 프로파일링
   4. {
      * CPU : 구현으로 해결할 수 있나? / 패턴으로 해결할 수 있나? / 물리의 문제인가? / 
      * GPU : 렌더 문제인가?
      }


### 프로파일링은 자주하자
* 병목탐지, 병목제거
* **추측에 의한 최적화 금지!**

## 유니티 프로파일러

내가 작성한 코드의 Custom profil tag : 특정 구간을 찍어서 프로파일링 가능

## xcode instuments

## GPU
#### GPU에 형향을 미치는것
1. 포스트 프로세싱
2. 투명 오버드로우
3. 업스케일링
4. 텍스쳐 압축
PNG, JPG 상관 없는게 그래픽 라이브러리에서 사용하는 포맷만 사용하므로 최종적을 포멧이 중요한것.

astc 4x4 를 추천한다.

#### 프레임 디버거
프레임이 그려지는 순서를 프레임하나마다 볼 수 있다.
드로우콜 확인가능

스프라이트 렌더러의 Sorting Layer -> 배칭(한번에) 최적화 가능

모델 임포터

## 코드
프로젝트 세팅 -> 타임

Awake Onenable, Update 타이밍
Update, Fixed Update

![](2023-05-02-02-20-58.png)

매니지 패턴

![](2023-05-02-02-23-51.png)
JSON -> 스크립터블로 옮기는 작업을하는게 좋다.