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
    <img src="./img/2023-04-19-12-13-34.png" width=100%>
</div>

### 📄 1. 의존성 주입/관계 주입 (Dependency Injection)

#### 1). Injection : 주입을 한다?
의존 객체를 인자로 가지는 생성자, Setter를 통해 사용하려는 객체를 의존적인 클래스 외부에서 주입받는다.
그것이 주입이라고 한다. 약 세가지 정도로 나눌수 있을것 같은데

```cs
public interface IInjectable(){void Inject(ServiceClass _s);}

class ClientClass : IInjectable {
    List<ServiceClass> sInstances;
    
    /* 1. 생성자 주입 */
    public ClientClass(ServiceClass _s){
        this.sInstances = new List<ServiceClass>();
        this.sInstances.Add(_s);
    }
    /* 2. Setter 주입 */
    public void AddB(ServiceClass _s){
        this.sInstances.Add(_s);
    }

    /* 3. 인터페이스 주입 */
    public override Inject(ServiceClass _s){
        this.sInstances.Add(_s);
    }
}
class ServiceClass {...}
class Injector {...}
```

DI 세 종류의 클래스가 정의된다 : 

1. **Client 클래스** : Client 클래스는 Service 객체를 사용하는 클래스로 Service 클래스에 의존한다. 
2. **Serice 클래스** : Client와 관계를 맺는 객체
3. **Injector 클래스** : Injector 클래스는 이 Service 객체를 Client 클래스에 주입하는 역할을 한다.
Injector 클래스가 의존성을 주입하는 방법에는 크게 세가지가 있다.  생성자 주입, 속성 주입, 메소드 주입. 모두 Client의 무언가를 통해 Service 객체를 주입하는데 생성자 주입은 생성자를 통해, 속성 주입은 속성을 통해, 메소드 주입은 메소드를 통해 주입한다.

### 📄 2. 제어권 역전 (Inversion of Control)

**① 제어**
제어(Control)라는 단어를 한번 짚고 가보자.

"한 클래스가 가진 주요 책임 외에 다른 부가적인 책임"을 이르는 말로,
기존 개발자가 제어했던 책임은 아래와 같다.
```txt
1. 의존성 주입(Dependency Injection) : 
    의존 객체를 인자로 가지는 생성자, Setter를 통해 사용하려는 객체를 주입받는다.
    기존에는 클라이언트 코드에서 개발자가 직접 new를 통해서 의존객체를 생성하곤 했다. 
2. 객체의 생명주기 관리
    객체의 생명 주기란 생성, 초기화, 사용, 소멸 각각의 단계를 말한다.
    기존에는 개발자가 직접 생성 초기화를 실행했다
3. 설정 정보의 외부화
    XML의 설정 정보를 기반으로 객체를 생성하고 구성한다.
4. AOP(Aspect-Oriented Programing)
    AOP는 횡단 관심사(로깅, 트랜젝션 관리)를 분리하여 모듈화 하는 기법을 말한다.
5. 컴포넌트 스캔
    자동으로 프로젝트의 클래스를 스캔해 Bean으로 등록하는 기능을 제공, 
    따라서 개발자가 일일이 빈을 등록하지 않아도 된다.
6. 인터셉팅과 프록시패턴
```

**② 제어의 역전**
위의 것들은 IoC컨테이너가 대신 제어할것들이다.

IoC라는 컨테이너 역할을 하는 클래스를 만들어서. 
객체 생성, 의존 관계 생성, 해제, 프로그램의 흐름에 대한 제어 같은 모듈들을 등록해 두고, 
Factory Method의 역할을 하며, 관계 주입을 하는 방식을 하게 된다는 말 인것 같다.

이런 식으로 IoC 설계 원칙을 적용하면 클래스 간 의존성을 줄여서 프로젝트를 테스트하고 관리하고 확장하는 데 용이하게 될 것이다.

**③ IoC Container**

 IoC Container

- IoC 컨테이너는 의존성 주입을 자동으로 하기 위한 프레임워크로 
위에 제시된 제어를 관리하여, 제어의 주체를 개발자로 부터 컨테이너로 역전 시켜준다.

모든 IoC 컨테이너는 다음과 같은 동작을 제공한다.

1. Register : 컨테이너는 반드시 지정된 타입의 객체를 생성할려고 한다면 어떤 의존성이 있는지 통보받아야 한다.이 과정을 등록(Registration)이라 부르며, 기본적으로 타입과 의존 타입을 연결하는 방법을 컨테이너는 제공해야 한다.
2. Resolve : IoC 컨테이너를 사용할 때 객체를 직접 생성하진 않아도 된다. 
지정된 타입을 생성하고 필요한 의존성을 주입하고 객체를 반환하는 방법이다.
3. Dispose : 컨테이너는 반드시 의존 객체의 수명을 관리한다. 대부분의 IoC 컨테이너는 여러 수명 관리 객체를 통해 의존 객체의 수명을 관리하고 해제한다. 


### 📄 3. 장점
**① 의존성 감소** : 메인 모듈과 하위 모듈간 의존성을 조금더 느슨하게 만들수 있다
* 변화에 강함
* 재사용성 좋아짐
* 유지보수 용이 : 클래스들이 SRP를 만족하기 쉬운 구조로 된다. 단위 테스트의 용이성

**② 코드양 감소**
**③ 테스트 용이**

### 참고

<details>
<summary>접기/펼치기</summary>

1. [의존성 주입에 대한 Spring강의](https://www.youtube.com/watch?v=qyGjLVQ0Hog&list=PLumVmq_uRGHgBrimIp2-7MCnoPUskVMnd)

2. [Swift를 통한 Dependency Injection & Inverse of Controll](https://develogs.tistory.com/19)

3. [DI & IoC & PureDI](https://jwchung.github.io/DI%EB%8A%94-IoC%EB%A5%BC-%EC%82%AC%EC%9A%A9%ED%95%98%EC%A7%80-%EC%95%8A%EC%95%84%EB%8F%84-%EB%90%9C%EB%8B%A4)

4. [| Spring DI/IoC | IoC? DI? 그게 뭔데?](https://velog.io/@ohzzi/Spring-DIIoC-IoC-DI-%EA%B7%B8%EA%B2%8C-%EB%AD%94%EB%8D%B0)

5. https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=raveneer&logNo=221122126506

6. https://gall.dcinside.com/mgallery/board/view/?id=github&no=18272

7. https://www.gamedeveloper.com/programming/ioc-container-for-unity3d#close-modal

</details>
