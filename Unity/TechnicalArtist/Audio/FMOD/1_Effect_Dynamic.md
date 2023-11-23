##  다이나믹계 

<img src="./src/2023-04-25-09-48-35.png" width=95%>

---

### 1. Compressor

#### 컴프레서는 커지는 소리를 알아서 줄여주고 다시 작아지면 원상태로 돌려줄 것


<div align=center>
    <img src="./src/2023-04-25-09-17-28.png" width=60%>
    <img src="./src/2023-04-25-09-18-44.png" width=26%>
    <br>컴프레서는 <strong>"음"을 압축</strong> 하는 장비
</div>

#### 1). 해석
> 설정해 놓은 소리크기보다 높아지면 정해놓은 일정한 비율로 자동적으로 소리를 줄여주는(압축; compression) 기기 
> Threshold : 수학에서 쓰이는 용어인데 어떤 이벤트를 발생시키는 기준점을 의미한다.
```
위 그래프를 해석해보자면
* 보통은 (볼륨업) -> (볼륨이 커짐)이 일반적이지만
* 컴프를 걸면 아무리 볼륨업을 해도 Threshold 기준으로 소리가 더디게 커지거나. 아예 안커지는 상황이 온다.
```

#### 2). 값
<div align=center>
    <img src="./src/2023-04-25-09-29-00.png" width=400px><br>
    <img src="./src/2023-04-25-09-33-19.png" width=400px>
</div>

1. Threshold : 음의 압축이 시작되는 최소 음압 기준점
2. Ratio : $input ∝ output$ 의 비율을 설정
3. Attack time : 압축하기 시작하는데 걸리는 시간
   * 0이면 Smooth하지 않겠지?
4. Release time : 풀어주는데 걸리는 시간

#### 3). 사이드 체인
<div align=center>
    <img src="./src/2023-04-25-09-36-40.png" width=400px>
</div>

사이드 체인과 컴프레서를 함께 사용한다는 의미는 다음과 같다. 
**특정 소스를 기준으로 컴프레서를 걸고 싶을때** 
특정 소스가 울릴때, 스레숄드가 "On" 되게끔 하고싶을떄 컴프레션의 제어 소스로 사용된다.

---

### 2. Gate

#### 노이즈 차단위해 안쓰면 끄고, 쓸때면 키고 하는 수동적으로 하는것을 자동화 하기 위해 사용 

<div align=center>
    <img src="./src/2023-04-25-09-42-48.png" width=400px>
</div>

#### 1). 해석

> 게이트는 일정 수준의 음압(소리의 크기)이 들어 오기 전에는 소리를 일정한 비율로 음을압축하여 차단했다가 기준점 이상이 되면 모든 음이 자유롭게 들어 오도록 문을 완전히 열어 주는 장치 입니다. 

컴프레스랑 반대 개념인데 얘는 초반부터 
컴프레서를 걸어 놓은 느낌이다. ($Ratio : ∞$)
그리고 **Threshold를 넘어 서야지 제대로 된 값을 출력한다.** 생각하면 된다.


---

### 3. Limit
$Ratio : ∞$인 컴프레서 
왜 한거냐면 무한대로 소리가 커지는것을 방지하기 위해서다.
FMOD를 사용하면 타격음이 10중첩, 100중첩될떄 소리가 찢어지는것을 막을 수 있다.

---

### 참고

* https://m.blog.naver.com/leegc96/221019757699

* https://mynewmicrophone.com/the-complete-guide-to-audio-compression-compressors/

* https://www.sonarworks.com/blog/learn/sidechain-compression