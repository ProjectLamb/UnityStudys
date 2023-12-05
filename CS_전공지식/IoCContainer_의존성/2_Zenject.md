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


## &nbsp;♽ 2. Zenject
### 1. 유니티에서 IoC 컨테이너
> What’s wrong with GameObject.Find
> What’s wrong with the Singleton
> What’s wrong with the Object.FindObjectOfType

주 목적은,

1. 사용하려는 의존 객체를 연결하고 싶을때.
2. 생성, 초기화, 사용, 삭제의 제어를 관리 받고 싶을때.
3. MVC(MVP, MVVM) 아키텍쳐를 사용할때도 유용하다.
4. 클래스들이 SRP를 만족하기 쉬운 구조로 된다. 단위 테스트의 용이성
5. 또한 유니티의 애매모호한 이벤트 라이프 사이클(Awake, Start)때문에
널레퍼런스가 무서워 if (dependency != null)로 코드를 도배할 겁니까?

```
확장, 유지성, 테스트 용이성

직접 new를 통해 의존관계 하는것 보단..
모든 new 생성과정을 한곳에서 관리 하자는 
그리고 DI를 이용해서 의존성을 주입하자는 의미.

Monobehaviuor과, 생성자 두상황에서도 DI를 제공한다
1. 특히 Monobehaviuor는 생성자가 없으므로 [Inject] 키워드를 등록한다.
2. SceneContent에서 등록한다.
```
```cs
public class GameInstaller : MonoInstaller 
{
    public override void InstallBindings() {
        Container.Bind<IAudioService>()
            .To<DebugAudioService>()
            .AsSingle();
    }
}
```

```
Composition Root

The single place where the Composition of
your application's entire Object Graph takes place

직접 지정하거나 IoC 컨테이너를 사용하기도 한다.
Zenject에서 Composition Root는 다수의 인스톨러를 사용할수도 있다.
이 모든 종속성은 게임이 시작되기 전에 모두 충족해야 하며 이를 Composition Root라고 부른다.

Inversion of Control (loC) Container

An object that creates and contains
the dependencies that must be injected
inside the application's objects
```
```
Injections
How Zenject knows which dependecies to inject where?
다음 4가지의 방법이 있다

1. Constructor Injection
2. Field Injection
3. Property Injection
4. Method Injection
```

```cs
public class Weapon
{
    readonly private BulletFactory _bulletFactory; readonly private Settings _settings;
    public Weapon(BulletFactory bulletfactory, Settings settings)
    {
        _bulletFactory = bulletFactory;
        _settings = settings;
    }
}

public class Weapon {
    [Inject]
    private BulletFactory _bulletFactory { get; set; }
    [Inject]
    public Settings Settings { get; private set; }
}


public class Weapon {
    [Inject]
    private BulletFactory _bulletFactory;
    [Inject]
    public Settings Settings;
}

public class Weapon {
    private BulletFactory _bulletFactory;
    private Settings _settings;
    [Inject]
        public void Construct (BulletFactory bulletFactory, Settings settings){
        bulletFactory = bulletFactory;
        _settings = settings;
    }
}
모노비헤이비어에 IoC인젝트 하기위해서는 Method 방식으로 넣어야하기 떄문에 매우 중요한 개념이다.
```

```
Bindings 

Dependency Mapping
The Binding of a type to an instance 
Accomplished using binding statements

컨테이너에 바인딩 추가하는 방법으로. 
그 컨테이너는 모든 객체 인스턴스를 만드는 방법을 알고 있어야 한다.


Contract Method

Container.Bind<IWeapon>();  //Contract Type
    .To<Weapon>();          //Result Type
    .WithId                 //Identifier
    .FromFactory()          //커스텀 팩토리 가능
    .AsSingle()             //싱글톤으로 사용하기
    .WithArgument(120)      //인수 넣기
    .When(c => c.objecttpye == typeof(Player)) // 컨디션으로 할지 말지 결정
    .NonLazy()              //클래스가 호출될때 되서야 만들도록 정한다.
ContractType Tell the Container Wich type you want to map the instance to
```

```
Installers


```
https://github.com/karais89/ZenjectAndUniRxExample

https://github.com/ATHellboy/SampleProject-FightingGame

https://www.youtube.com/playlist?list=PLKERDLXpXl_jNJPY2czQcfPXW4BJaGZc_

https://mentum.tistory.com/591

https://m.blog.naver.com/PostSearchList.naver?blogId=raveneer&orderType=sim&searchText=zenject

https://lemonheim.blogspot.com/2017/12/zenject-inject-binding.html