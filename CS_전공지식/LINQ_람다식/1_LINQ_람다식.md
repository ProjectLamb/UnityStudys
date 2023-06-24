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

    h2 { border-top: 12px solid #F586C5; border-left: 5px solid #F586C5; border-right: 5px solid #F586C5; background-color: #F586C5; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #D566A5 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## &nbsp;ƛ 1. Lambda Expression
---

### 📄 1. 개요

#### 특징

**① 람다식은 함수형 자료다.**
* 람다는 외부 상태를 참조해서 변경하지 않는게 원칙이다.
* 순수 함수로서, 무조건 함수내 지역변수, 인풋으로만 작동 되어야 한다. immutable data (변경 불가능한 값) 인풋외에 다른 요소 떄문에 아웃풋 값이 영향미치는 경우는 없다.
* 원자적이라는것, 여러 스레드들에 의해 병렬적으로 수행되어도 결과의 안전성을 보장받을 수 있어야한다.

**② 장점**
  1. 코드의 간결성 
  2. 퍼포먼스 향상, 불필요한 연산의 베제가 가능하다.
  3. 콜백 사용시 함수 선언을 위한 메모리를 절약할 수 있다.
     * 재사용할 필요가 없다.
  4. 병렬프로그래밍에 용이하다
     * Thread Safe 하다.
     * 스레드를 활용하여 병렬 처리를 수행하는 대상
     * 사실 모든 병렬 프로그래밍에서, 원자적인 함수를 사용하는게 좋다. 즉, 외부 변수가 변경되는 그런 함수를사용하면 보장이 안된다.

**③ 예시**
```cs
//일반함수
void string Hello(매개변수, ...){
    //실행문
    return "Hello World"
}

```

```cs
//람다식
(매개변수, ...) => {
    //실행문
    "Hello World"
}
```