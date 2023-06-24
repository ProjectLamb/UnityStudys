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

## 💡 1. Event 개요 바인딩

### 📄 0. 용어정리
#### 0). 가상함수
**가상함수**는 수퍼클래스를 상속하는 서브클래스에서 **Override(함수 재정의)** 할 것으로 기대하고 정의해놓은 함수다. 

**① 특징?**
1. **Virtual** 예약어를 사용해 함수 앞에 붙여서 생성할 수 있다. 다르게 말하면 **Override**되려면 **Virtual 키워드가 붙여져 있어야 한다.**
    ```cs
    class SuperClass {
        public virtual void Method(){Console.WriteLine("저는 부모클래스 메소드입니다.");}
    }
    class SubClass : SuperClass {
        public override void Method(){Console.WriteLine("저는 자식클래스 메소드입니다.");}
    }
    ```
2. 런타임에 함수포인트 값이 정의 된다. 즉, 동적 바인딩 되는 함수다.
3. 동적 바인딩(런타임에 함수가 정해진다.) 으로 함수의 다형성을 구현할 수 있다.


#### 1). 함수의 바인딩
> 함수를 만들어 컴파일 하면, 각각의 코드가 메모리 어딘가에 저장된다.
> 그리고 함수를 호출하는 부분에서 그 메모리가 저장된 함수 포인터를 참조한다.
> 프로그램 실행 -> 함수 호출 -> 함수가 저장된 주소로 점프 -> 함수 실행 -> 원래 위치로
> 함수의 호출부와 정의부를 연결시켜주는 것이 **바인딩** 이라고 할 수 있다.

#### 2). 정적 바인딩 & 동적 바인딩
**① 정적 바인딩**
>**컴파일 타임에 호출될 함수가 결정되는것이다.**
>일반적으로 함수는 정적 바인딩이다.

**② 동적 바인딩**
> **런타임에 호출될 함수가 결정되는 것**
> 함수가 가상함수로 선언이 되면 포인터 변수가 실제로 가르키는 객체에 따라 호출 대상이 결정된다.
> 동적 바인딩을 하게된다면 컴파일 당시 호출될 함수의 메모리 포인터가 미리 결정되는것이 아니라 런타임 중 함수가 결정된다.

## 참조
https://velog.io/@ikmy0ung/CS%EB%A9%B4%EC%A0%91-%EB%8C%80%EB%B9%84