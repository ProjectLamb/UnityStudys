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

    h2 { border-top: 12px solid #bf8bff; border-left: 5px solid #bf8bff; border-right: 5px solid #bf8bff; background-color: #bf8bff; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #5b0d7c !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## 🧑🏻‍💻 4. 리플렉션

### 📄 1. 개요

#### 리플렉션을 이용한다면 특정 클래스에 대한 멤버(필드, 메소드 ,이벤트 등등)를 동적으로 불러올 수 있다.
1. 멤버를 foreach로 돌려볼 수 있음
2. 지어 다른 어셈블리에서의 정보도 참조 할 수 있다는점 

### 📄 2. 사용

\#Type \#Object


#### 1). 자주사용하는 Type클래스
|메소드|반환 형식|설명|
|:--|:--|:--|
|GetConstructors()|ConstructorInfo[]|해당 형식의 모든 생성자 목록을 반환합니다.|
|GetEvents()|Eventinfo[]|해당 형식의 이벤트 목록을 반환합니다.|
|GetFields()|Fieldinfo[]|해당 형식의 필드 목록을 반환합니다.|
|GetGenericArguments()|Type[]|해당 형식의 형식 매개 변수 목록을 반환합니다.|
|GetInterfaces()|Type[]|해당 형식이 상속하는 인터페이스 목록을 반환합니다.|
|GetMembers()|MemberInfo[]|해당 형식의 멤버 목록을 반환합니다.|
|GetMethods()|MethodInfo[]|해당 형식의 메소드 목록을 반환합니다.|
|GetNestedTypes()|Type[]|해당 형식의 내장 형식 목록을 반환합니다.|
|GetProperties()|Propertylnfo[]|해당 형식의 프로퍼티 목록을 반환합니다.|


#### 2). 예제

**① 객체 생성하고 이용하기**

이 속성의 진짜 모습, 즉 '실체'를 담는 곳이 필드(field, 멤버변수)이다. 

```cs
Type type = Type.GetType("_Namespace_.객체");
object obj = Activator.CreateInstance(customerType); 
```
**② 프로퍼티 찾고 값 넣기**

```js
//old와 name을 property라고 부릅니다.
var duckgoo = {old : 12, name : 'duck'};
```

그 속성을 칭하는 단어를 프로퍼티(property)라고 한다

[Property API](https://learn.microsoft.com/ko-kr/dotnet/api/system.reflection.propertyinfo?view=net-7.0)

* API
    ```cs
    PropertyInfo pi = _객체_.GetType().GetProperty("_속성이름_");

    //속성
    pi.PropertyType; //프로퍼티 타입 가져옥;
    pi.Name;         //멤버의 이름을 가져온다

    //메소드
    pi.Equals(Object) //이 인스턴스가 지정된 객체와 같은지 반환
    pi.GetValue(Object) //지정된 객체의 값을 반환한다.
    pi.SetValue(Object) //지정된 객체의 값을 wlwjdgksek.
    ```

* 프로퍼티 순회
    ```cs
    using System.Reflection; 

    static void PrintProperties(Type type)
    {
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo i in properties)
        {
            Console.WriteLine($"Type : {i.PropertyType.Name}, Name : {i.Name}");
        }
        Console.WriteLine();
    }
    ```

**③ 메소드 호출**

```cs
MethodInfo mi = _객체_.GetType().GetMetod("_메소드이름_"); 
```

* 메소드 순회
    ```cs
    static void PrintMethods(Type type) {
        MethodInfo[] methods = type.GetMethods();
        foreach (MethodInfo i in methods) 
        {
            Console.WriteLine($"Type : {i.ReturnType.Name}, Name : {i.Name}, Parameters : ");
            ParameterInfo[] args = i.GetParameters();

            foreach(ParameterInfo a in args) {
                Console.Write($"{a.ParameterType.Name} ");
            }
        }
    }
    ```

**④ 타입 비교**

* 타입 가져오기 & 비교
    ```cs
    _instance.GetType() == typeof(type)

    부모클래스 가져오기
    _instance.GetType().BaseType;
    typeof(type).BaseType;

    인터페이스 가져오기
    typeof(type).GetInterface();
    typeof(type).GetInterfaces("");
    ```

**⑤ Enums 가져오기**

* Enum값을 배열로 가져오기
    ```cs
    enum Achive { UnlockPotato, UnlockBean }
    Achive[] achives;

    void Awake ()
    {
        achives = (Achive [])Enum.GetValues(typeof (Achive));
    }
    ```

* 실제 사례
    ```cs
    public enum Affector_PlayerState { 
        Move, Dash, Attack, Skill, GetDamaged, Die, Trigger
    }
    foreach(ENUM_TYPE Enum in Enum.GetValues(typeof(ENUM_TYPE))){
        dynamicsDic.Add(Enum, () => {});
    }

    foreach(KeyValuePair<Affector_PlayerState, UnityAction> kvp in dynamicsDic){
        Debug.Log($"{kvp.Key}, {kvp.Value}");
    }
    ```
    <img src="./img/2023-05-15-19-35-26.png"> 

### 📄 3. 참고

<details style="cursor:pointer">
<summary>접기/펼치기</summary>

<!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Reflection : MonoBehaviour
{
    [ContextMenu("Components")]
    void PRINT_GAMEOBJECT_COMPONENTS(){
        List<Component> components = gameObject.GetComponents<Component>().ToList();
        foreach(var item in components){
            Debug.Log($"Component {item} ComponentName : {item.name}, ComponentTag {item.tag}");
        }
    }
    [ContextMenu("Parent Component")]
    void PRINT_GAMEOBJECT_PARENTCOMPONENT(){
        List<Component> components = gameObject.GetComponentsInParent<Component>().ToList();
        foreach(var parItem in components){
            Debug.Log($"Component {parItem} ComponentName : {parItem.name}, ComponentTag {parItem.tag}");
        }
    }
    [ContextMenu("Child Component")]
    void PRINT_GAMEOBJECT_CHILDCOMPONENT(){
        List<Component> components = gameObject.GetComponentsInChildren<Component>().ToList();
        foreach(var childsItem in components){
            Debug.Log($"Component {childsItem} ComponentName : {childsItem.name}, ComponentTag {childsItem.tag}");
        }
    }

    [ContextMenu("Properties")]
    void PRINT_CLASS_PROPERTIES(){
        var propertiesList = typeof(Equipment_003).GetProperties().ToList();
        foreach(var item in propertiesList){
            Debug.Log($"PropertyInfo : {item}, Name {item.Name}");
        }
    }

    [ContextMenu("Base Class")]
    void PRINT_CLASS_BASE(){
        var baseClass = typeof(Equipment_003).BaseType;
            Debug.Log($"Type : {baseClass}, Name {baseClass.Name}, FullName : {baseClass.FullName}");
    }

    [ContextMenu("Interface")]
    void PRINT_CLASS_INTERFACE(){
        var interfacesList = typeof(Equipment_003).GetInterfaces().ToList();
        foreach(var item in interfacesList){
            Debug.Log($"Type : {item}, Name {item.Name}, FullName : {item.FullName}");
        }
    }

    [ContextMenu("Enum")]
    void PRINT_CLASS_ENUM(){
        var enums_name = System.Enum.GetNames(typeof(E_DebuffState)).ToList();
        var enums_value = System.Enum.GetValues(typeof(E_DebuffState)).OfType<int>().ToList();
        var enums_value_string = System.Enum.GetValues(typeof(E_DebuffState)).OfType<string>().ToList();

        Debug.Log("===============================================");
        Debug.Log("enums_name");
        Debug.Log("===============================================");
        foreach(var item in enums_name){ Debug.Log(item); }
        Debug.Log("===============================================");
        Debug.Log("enums_value");
        Debug.Log("===============================================");
        foreach(var item in enums_value){ Debug.Log(item); }
        Debug.Log("===============================================");
        Debug.Log("enums_value_string");
        Debug.Log("===============================================");
        foreach(var item in enums_value_string){ Debug.Log(item); }
    }
}
```
</details>
