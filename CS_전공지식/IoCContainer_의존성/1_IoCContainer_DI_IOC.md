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

    h2 { border-top: 12px solid #86B049; border-left: 5px solid #86B049; border-right: 5px solid #86B049; background-color: #86B049; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #476930 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>


## &nbsp;♽ 1. DI & IoC

<div align=center>
    <img src="2023-04-19-12-13-34.png" width=800px>
</div>

### 📄 1. 의존성 주입 (Dependency Injection)

#### 1). Dependency : 의존성이란?

> 한 클래스가 다른 클래스를 참조할때 의존성이 있다고 말할 수 있다.
> 추상화를 해치지 않고 의존성을 인수로 넘겨주는 방법이 DI


* **① A는 B에 의존적이다.**
    1. A가 B를 멤버로 가지고 있거나
    2. A메소드에서 B를 패러미터로 이용하거나 리턴한다던지.
    3. B의 메소드를 사용한다던지
    4. 어쨌든 A에서 B를 사용하면~

* **② Class Diagram**
    ```mermaid
    ---
    title : Dependancy example
    ---
    classDiagram
        AClass <.. BClass
        class AClass {
            List bInstance
        }

        class BClass {
        }
    ```

#### 2). Injection : 주입을 한다?
외부로 부터 전달을 받는것, 그것이 주입이라고 한다.
약 세가지 정도로 나눌수 있을것 같은데

***예시 코드***

*
    ```cs
    public interface BInjection(){void InjectB(B b);}

    class AClass :{
        List<BClass> bInstances;

        AClass(BClass _b){
            this.bInstance = new List<BClass>();
            this.bInstance.Add(_b);
        }

        public void AddB(BClass _b){
            this.bInstance.Add(_b);
        }

        public override InjectB(BClass _b){
            this.bInstance.Add(_b);
        }
    }
    class BClass {...}
    ```

**① 생성자 주입**

*
    ```cs
    AClass(BClass _b){
        this.bInstance = new List<BClass>();
        this.bInstance.Add(_b);
    }
    ```

**② Setter 주입**

*
    ```cs
    public void AddB(BClass _b){
        this.bInstance.Add(_b);
    }
    ```

**③ 인터페이스 주입**

* 
    ```cs
    public interface BInjection(){void InjectB(B b);}
    :
    public override InjectB(BClass _b){
        this.bInstance.Add(_b);
    }
    ```

### 📄 2. 제어권 역전 (Inversion of Control)
*웬만해서 탑다운 방식을 상정하는게..*

#### 1). Dependency Inversion : 의존의 역전 

> 직접 참조하던것을 매제체(*Absctact,Interface*) 를 통해서 참조하게 구성하자 라는 의미

* SOLID의 **DIP** 원칙을 따른다~ 라고 생각하면된다.
* 의존관계를 인터페이스로 추상화
  * Main모듈은 "매개체모듈(Absctact,Interface)"애 의존하고
매개체를 implements 해서 기능을 구체화 해서 사용하자~ 라는것이다.

#### 2). IoC Container : 프레임워크(NextJs, Spring, Zenject)
> “내가 전에도 얘기했잖아, 나한테 먼저 연락하지마, 필요하면 내가 연락할께” 🤷‍♀️ (뭔소리노)
> 해당 객체들이 어느 시점에 호출될 지는 신경쓰지 않는다.

* 개발자가 의존성 제어하던것을 매게체에 제어권을 일임하게해서
의존성 제어 주체는 더이상 개발자가 아니게 된것 = 제어의 역전

* IoC라는 매게체를 두고 필요한 모든 모듈들을 등록해 두고,
사용처에서 직접 생성하는게 아니라 의존성이 있는 모듈을 주입하는 방식을 하게 된다.

* 의존성 생성, 해제, 주입 작업을 IoC가 해준다

### 📄 3. 장점
**① 의존성 감소** : 메인 모듈과 하위 모듈간 의존성을 조금더 느슨하게 만들수 있다
* 변화에 강함
* 재사용성 좋아짐
* 유지보수 용이

**② 코드양 감소**
**③ 테스트 용이**

### 참고

1. [의존성 주입에 대한 Spring강의](https://www.youtube.com/watch?v=qyGjLVQ0Hog&list=PLumVmq_uRGHgBrimIp2-7MCnoPUskVMnd)

2. [DI의 이해](https://tecoble.techcourse.co.kr/post/2021-04-27-dependency-injection/)
3. [5분 개념](https://www.youtube.com/watch?v=1vdeIL2iCcM)

4. [Swift를 통한 Dependency Injection & Inverse of Controll](https://develogs.tistory.com/19)

5. [DI & IoC & PureDI](https://jwchung.github.io/DI%EB%8A%94-IoC%EB%A5%BC-%EC%82%AC%EC%9A%A9%ED%95%98%EC%A7%80-%EC%95%8A%EC%95%84%EB%8F%84-%EB%90%9C%EB%8B%A4)

6. [| Spring DI/IoC | IoC? DI? 그게 뭔데?](https://velog.io/@ohzzi/Spring-DIIoC-IoC-DI-%EA%B7%B8%EA%B2%8C-%EB%AD%94%EB%8D%B0)

6. [싱글톤을 안쓰면 도데체 뭘 쓰길레 안쓴다는거지?](https://velog.io/@backfox/%EC%8B%B1%EA%B8%80%ED%86%A4-%ED%8C%A8%ED%84%B4%EC%9D%84-%EA%B2%BD%EA%B3%84%ED%95%98%EB%8A%94-%EC%82%AC%EB%9E%8C%EB%93%A4%EC%9D%98-%EC%9D%B4%EC%95%BC%EA%B8%B0)

7. [적어도 인디게임 만들면서 안티패턴이라는 싱글톤을 밀어낼 필요는 없다](https://gall.dcinside.com/mgallery/board/view/?id=game_dev&no=71438)

8. https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=raveneer&logNo=221122126506